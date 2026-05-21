#include <PID_v1.h>
#include "MAX6675.h"
#include <functional>
#include "WiFiS3.h"
#include "secrets.h"
#include <ArduinoMqttClient.h>
#include "RTC.h"
using namespace std;


long dosesGiven = 0; float motor1DisplacementAmount = 0; float motor2DisplacementAmount = 0; float motor3DisplacementAmount = 0;
const int perlestaticMotor1Pin = 10; const int perlestaticMotor2Pin = 11; perlestaticMotor3Pin = 12; perlestaticMotor4Pin = 13;
int dosingTimer = 0; int msPerMl = 1000; // this hurts, mL is correct
const int dataPin = 7; const int clockPin = 6; const int selectPin = 5;
const int heaterPin = 3; const int motorPin = 9;
const char brokerUrl[] = "test.mosquitto.org"; const int brokerPort = 1883; // must change soon
const int encoderInputPin = 2; const int encoderRevoultionsPerRotationOfMotorShaft = 11; // may be wrong
volatile int encoderPulses = 0;
double heaterKp = 0; double heaterKi = 0; double heaterKd = 0;
double rpmKp = 0; double rpmKi = 0; double rpmKd = 0;
bool on = false; bool motorOn = false; bool heaterOn = false;
double heaterSetpoint = 0; double heaterOutput = 0; double rpmSetpoint = 0; double rpmOutput = 0;
double thermocoupleTemp = 0; double motorRpm = 0;
const int maxRpm = 530;

MAX6675 thermoCouple(selectPin, dataPin, clockPin);
uint32_t start, stop;
WiFiClient client;
MqttClient mqttClient(client);


PID heaterPID(&thermocoupleTemp, &heaterOutput, &heaterSetpoint, heaterKp, heaterKi, heaterKd, DIRECT);
PID rpmPID(&motorRpm, &rpmOutput, &rpmSetpoint, rpmKp, rpmKi, rpmKd, DIRECT);
void setup() {
  WiFi.begin(SSID, PASS);
  delay(10000);
  RTC.begin();
  RTCTime rtc(30, Month::JUNE, 1970, 00, 00, 00, DayOfWeek::TUESDAY, SaveLight::SAVING_TIME_ACTIVE);
  RTC.setTime(rtc);
  RTC.setPeriodicCallback(rtcIncrement, Period::ONCE_EVERY_2_SEC);
  mqttClient.connect(brokerUrl, brokerPort);
  mqttClient.onMessage(reciveMqttMessage);
  mqttClient.subscribe("BioreactorGui/onOffButton");
  mqttClient.subscribe("BioreactorGui/heaterOnOffButton");
  mqttClient.subscribe("BioreactorGui/motorOnOffButton");
  mqttClient.subscribe("BioreactorGui/heaterSetpoint");
  mqttClient.subscribe("BioreactorGui/heaterKp");
  mqttClient.subscribe("BioreactorGui/heaterKi");
  mqttClient.subscribe("BioreactorGui/heaterKd");
  mqttClient.subscribe("BioreactorGui/rpmSetpoint");
  mqttClient.subscribe("BioreactorGui/rpmKp");
  mqttClient.subscribe("BioreactorGui/rpmKi");
  mqttClient.subscribe("BioreactorGui/rpmKd");
  mqttClient.subscribe("BioreactorGui/dosingSchedulingM1");
  mqttClient.subscribe("BioreactorGui/dosingSchedulingM2");
  mqttClient.subscribe("BioreactorGui/dosingSchedulingM3");
  pinMode(encoderInputPin, INPUT_PULLUP);
  attachInterrupt(digitalPinToInterrupt(encoderInputPin), incrementEncoderPulse, RISING);
  pinMode(heaterPin,OUTPUT);
  pinMode(motorPin, OUTPUT);
  SPI.begin();
  thermoCouple.begin();
  heaterPID.SetMode(AUTOMATIC);
  rpmPID.SetMode(AUTOMATIC);
}

void loop() {
  delay(950);
  if (on == true) {
    onLoop();
  }
}

double checkThermocouple() {
  start = micros();
  int status = thermoCouple.read();
  stop = micros();
  double thermocoupleTemp = thermoCouple.getCelsius();
}

void onLoop() {
  mqttClient.poll();
  if (heaterOn == true) {
    onHeater();
  }
  if (heaterOn != true) {
    digitalWrite(heaterPin, 255);
  }
  if (motorOn == true) {
    onMotor();
  }
  if (motorOn != true) {
    digitalWrite(motorPin, 255);
  }
  
  sendMqttMessage("Bioreactor/ThermocoupleTemprature", String(thermocoupleTemp));
  sendMqttMessage("Bioreactor/MotorRpm", String(thermocoupleTemp));
}

void onHeater() {
  checkThermocouple();
  heaterPID.Compute();
  analogWrite(heaterPin, 255 - heaterOutput);
}

void onMotor() {
  checkEncoder();
  rpmPID.Compute();
  analogWrite(motorPin, 255 - rpmOutput);
}

double checkEncoder() {
  double motorRpm = encoderPulses/encoderRevoultionsPerRotationOfMotorShaft * 60;
  encoderPulses = 0;
}

void incrementEncoderPulse() {
  encoderPulses++;
}

void sendMqttMessage(String topic, String input) {
  mqttClient.beginMessage(topic);
  mqttClient.print(input);
  mqttClient.endMessage();
}

void reciveMqttMessage(int messageSize) {
  String messageTopic = mqttClient.messageTopic();
  if (messageTopic == "BioreactorGui/onOffButton") {
    if ("True" == String(mqttClient.read())) {
      on = true;
    }
    else {
      on = false;
    }
  }
  if (messageTopic == "BioreactorGui/heaterOnOffButton") {
    if ("True" == String(mqttClient.read())) {
      heaterOn = true;
    }
    else {
      heaterOn = false;
    }
  if (messageTopic == "BioreactorGui/motorOnOffButton") {
    if ("True" == String(mqttClient.read())) {
      heaterOn = true;
    }
    else {
      heaterOn = false;
    }
  }
  if (messageTopic == "BioreactorGui/heaterSetpoint") {
    double heaterSetpoint = mqttClient.read();
  }
  if (messageTopic == "BioreactorGui/heaterKp") {
    double heaterKp = mqttClient.read();
  }
  if (messageTopic == "BioreactorGui/heaterKi") {
    double heaterKi = mqttClient.read();
  }
  if (messageTopic == "BioreactorGui/heaterKd") {
    double heaterKd = mqttClient.read();
  }
  if (messageTopic == "BioreactorGui/rpmSetpoint") {
    double rpmSetpoint = mqttClient.read();
  }
  if (messageTopic == "BioreactorGui/rpmKp") {
    double rpmKp = mqttClient.read();
  }
  if (messageTopic == "BioreactorGui/rpmKi") {
    double rpmKi = mqttClient.read();
  }
  if (messageTopic == "BioreactorGui/rpmKd") {
    double rpmKd = mqttClient.read();
  }
  if (messageTopic == "Bioreactor/dosingSchedulingM1") {
    float motor1DisplacementAmount = mqttClient.read();
  }
    if (messageTopic == "Bioreactor/dosingSchedulingM2") {
    float motor2DisplacementAmount = mqttClient.read();
  }
    if (messageTopic == "Bioreactor/dosingSchedulingM3") {
    float motor3DisplacementAmount = mqttClient.read();
  }
}}

void rtcIncrement() {
  dosingTimer + 2;
}

void motorCallback() {
  if (motor1DisplacementAmount > 0) {
    int motor1RunTime = motor1DisplacementAmount*1000/msPerMl;
    analogWrite(perlestaticMotor1Pin, 255);
    analogWrite(perlestaticMotor4Pin, 255);
    delay(motor1RunTime);
    analogWrite(perlestaticMotor1Pin, 0);
    analogWrite(perlestaticMotor4Pin, 0);
  }
  if (motor2DisplacementAmount > 0) {
    int motor2RunTime = motor2DisplacementAmount*1000/msPerMl;
    analogWrite(perlestaticMotor2Pin, 255);
    analogWrite(perlestaticMotor4Pin, 255);
    delay(motor2RunTime);
    analogWrite(perlestaticMotor2Pin, 0);
    analogWrite(perlestaticMotor4Pin, 0);
  }
  if (motor3DisplacementAmount > 0) {
    int motor3RunTime = motor3DisplacementAmount*1000/msPerMl;
    analogWrite(perlestaticMotor3Pin, 255);
    analogWrite(perlestaticMotor4Pin, 255);
    delay(motor3RunTime);
    analogWrite(perlestaticMotor3Pin, 0);
    analogWrite(perlestaticMotor4Pin, 0);
  }
  dosingTimer = 0;
}