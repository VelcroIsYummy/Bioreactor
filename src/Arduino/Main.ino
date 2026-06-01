#include <PID_v1.h>
#include "MAX6675.h"
#include <functional>
#include "WiFiS3.h"
#include "secrets.h"
#include <ArduinoMqttClient.h>
#include "RTC.h"
#include <Wire.h>
#include <Adafruit_Sensor.h>
#include "Adafruit_TSL2591.h"
#include <HttpClient.h>

using namespace std;

long dosesGiven = 0; float motor1DisplacementAmount = 0; float motor2DisplacementAmount = 0;
bool fanOn = false; const int fanPin = 8;
float motor3DisplacementAmount = 0; int timeToDosing = 600;
const int perlestaticMotor1Pin = 10; const int perlestaticMotor2Pin = 11; 
const int perlestaticMotor3Pin = 12; const int perlestaticMotor4Pin = 13;
int dosingTimer = 0; int msPerMl = 1000; float int motorFluidCaptureDelay = 100;
const int dataPin = 7; const int clockPin = 6; const int selectPin = 5;
const int heaterPin = 3; const int motorPin = 9;
const int ledPin = 4;
int telemetryTimeSinceLastMessage = 0;
const char brokerUrl[] = "test.mosquitto.org"; const int brokerPort = 1883;
const int encoderInputPin = 2; const int encoderRevoultionsPerRotationOfMotorShaft = 11;
volatile int encoderPulses = 0;
double heaterKp = 0; double heaterKi = 0; double heaterKd = 0;
double rpmKp = 0; double rpmKi = 0; double rpmKd = 0;
bool on = false; bool motorOn = false; bool heaterOn = false;
double heaterSetpoint = 0; double heaterOutput = 0; double rpmSetpoint = 0; 
double rpmOutput = 0;
double thermocoupleTemp = 0; double motorRpm = 0;
const int maxRpm = 530; const int maxTemp = 60;

MAX6675 thermoCouple(selectPin, dataPin, clockPin);
uint32_t start, stop;

PID heaterPID(&thermocoupleTemp, &heaterOutput, &heaterSetpoint, 
  heaterKp, heaterKi, heaterKd, DIRECT);
PID rpmPID(&motorRpm, &rpmOutput, &rpmSetpoint, rpmKp, rpmKi, rpmKd, DIRECT);
void setup() {
  Serial.begin(9600);
  Wire.begin();
  WiFi.setTimeout(0);
  WiFi.begin(SSID, PASS);
  while (WiFi.status() != WL_CONNECTED) {}
  Adafruit_TSL2591 od600LuminositySensor = Adafruit_TSL2591(2591);
  od600LuminositySensor.setGain(TSL2591_GAIN_LOW);
  od600LuminositySensor.setTiming(TSL2591_INTEGATIONTIME_100MS); // no idea if that's good, might change
  WiFiClient client;
  MqttClient mqttClient(client);
  HttpClient http(client);
  mqttClient.connect(brokerUrl, brokerPort);
  mqttClient.onMessage(reciveMqttMessage);
  mqttClient.subscribe("BioreactorGui/onOffButton");
  mqttClient.subscribe("BioreactorGui/heaterOnOffButton");
  mqttClient.subscribe("BioreactorGui/fanOnOffButton");
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
  pinMode(perlestaticMotor1Pin, OUTPUT);
  pinMode(perlestaticMotor2Pin, OUTPUT);
  pinMode(perlestaticMotor3Pin, OUTPUT);
  pinMode(perlestaticMotor4Pin, OUTPUT);
  pinMode(ledPin, OUTPUT);
  SPI.begin();
  thermoCouple.begin();
  heaterPID.SetMode(AUTOMATIC);
  rpmPID.SetMode(AUTOMATIC);
  RTC.begin();
  RTCTime rtc(30, Month::JUNE, 1970, 00, 00, 00, DayOfWeek::TUESDAY, 
    SaveLight::SAVING_TIME_ACTIVE);
  RTC.setTime(rtc);
  RTC.setPeriodicCallback(rtcIncrement, Period::ONCE_EVERY_2_SEC);
  RTC.setPeriodicCallback(sendTelemetry, Period::ONCE_EVERY_2_SEC);
}

void loop() {
  delay(950);
  if (WiFi.status() != WL_CONNECTED) {
    if (WiFi.begin(SSID, PASS) != WL_CONNECTED) {
      // something to notify about lack of connection?
    }
  }
  if (on == true) {
    onLoop();
  }
}

double od600Measurement() {
  digitalWrite(perlestaticMotor4Pin, HIGH);
  delay(motorFluidCaptureDelay);
  digitalWrite(perlestaticMotor4Pin, LOW);
  digitalWrite(ledPin, HIGH);
  uint16_t luminosityMeasurement = od600LuminositySensor.getLuminosity(TSL2591_VISIBLE);
  digitalWrite(ledPin, LOW);
  double od600 = -log10(luminosityMeasurement/2000); // assuming exactly 1cm of media.
  return od600;
}

double checkThermocouple() {
  start = micros();
  int status = thermoCouple.read();
  stop = micros();
  double thermocoupleTemp = thermoCouple.getCelsius();
  return thermocoupleTemp;
}

void onLoop() {
  mqttClient.poll();
  if (heaterOn == true) {
    onHeater();
  }
  if (heaterOn != true) {
    digitalWrite(heaterPin, HIGH);
  }
  if (motorOn == true) {
    onMotor();
  }
  if (motorOn != true) {
    digitalWrite(motorPin, 255);
  }
  if (fanOn == true) {
    onFan();
  }
  if (fanOn != true) {
    digitalWrite(fanPin, 255);
  }
  if (dosingTimer == timeToDosing) {
    motorCallback();
  }
}

void onHeater() {
  thermocoupleTemp = checkThermocouple();
  heaterPID.Compute();
  analogWrite(heaterPin, 255 - heaterOutput);
}

void onOd600() {
  od600Measurement();
}

void onFan() {
  digitalWrite(fanPin, HIGH);
}

void onMotor() {
  motorRpm = checkEncoder();
  rpmPID.Compute();
  analogWrite(motorPin, 255 - rpmOutput);
}

double checkEncoder() {
  double motorRpm = encoderPulses/encoderRevoultionsPerRotationOfMotorShaft * 60;
  encoderPulses = 0;
  return motorRpm;
}

void incrementEncoderPulse() {
  encoderPulses++;
}

void reciveMqttMessage(int messageSize) {
  String messageTopic = mqttClient.messageTopic();
  if (messageTopic == "BioreactorGui/onOffButton") {
    if ("true" == String(mqttClient.read())) {
      on = true;
    }
    else {
      on = false;
    }
  }
  if (messageTopic == "BioreactorGui/heaterOnOffButton") {
    if ("true" == String(mqttClient.read())) {
      heaterOn = true;
    }
    else {
      heaterOn = false;
    }
  if (messageTopic == "BioreactorGui/motorOnOffButton") {
    if ("true" == String(mqttClient.read())) {
      heaterOn = true;
    }
    else {
      heaterOn = false;
    }
  }
  if (messageTopic == "BioreactorGui/fanOnOffButton") {
    if ("true" == String(mqttClient.read())) {
      fanOn = true;
    }
    else {
      fanOn = false;
    }
  }
  if (messageTopic == "BioreactorGui/heaterSetpoint") {
    double payload = String(mqttClient.read()).toDouble();
    if (payload <= maxTemp) {
    heaterSetpoint = payload;
    }
  }
  if (messageTopic == "BioreactorGui/heaterKp") {
    double payload = String(mqttClient.read()).toDouble();
    heaterKp = payload;
  }
  if (messageTopic == "BioreactorGui/heaterKi") {
    double payload = String(mqttClient.read()).toDouble();
    heaterKi = payload;
  }
  if (messageTopic == "BioreactorGui/heaterKd") {
    double payload = String(mqttClient.read()).toDouble();
    heaterKd = payload;
  }
  if (messageTopic == "BioreactorGui/rpmSetpoint") {
    double payload = String(mqttClient.read()).toDouble();
    if (payload <= maxRpm) {
      rpmSetpoint = payload;
    }
  }
  if (messageTopic == "BioreactorGui/rpmKp") {
    payload = String(mqttClient.read()).toDouble();
    double rpmKp = payload;
  }
  if (messageTopic == "BioreactorGui/rpmKi") {
    double payload = String(mqttClient.read()).toDouble();
    double rpmKi = payload;
  }
  if (messageTopic == "BioreactorGui/rpmKd") {
    double payload = String(mqttClient.read()).toDouble();
    double rpmKd = payload;
  }
  if (messageTopic == "Bioreactor/dosingSchedulingM1") {
    float payload = String(mqttClient.read()).toDouble();
    double motor1DisplacementAmount = payload;
  }
    if (messageTopic == "Bioreactor/dosingSchedulingM2") {
    double payload = String(mqttClient.read()).toDouble();
    motor2DisplacementAmount = payload;
  }
    if (messageTopic == "Bioreactor/dosingSchedulingM3") {
    double payload = String(mqttClient.read()).toDouble();
    motor3DisplacementAmount = payload;
  }
}}

void rtcIncrement() {
  dosingTimer + 2;
}

void motorCallback() {
  dosingTimer = 0;
  if (motor1DisplacementAmount > 0) {
    int motor1RunTime = motor1DisplacementAmount*1000/msPerMl;
    digitalWrite(perlestaticMotor1Pin, HIGH);
    digitalWrite(perlestaticMotor4Pin, HIGH);
    delay(motor1RunTime);
    digitalWrite(perlestaticMotor1Pin, LOW);
    digitalWrite(perlestaticMotor4Pin, LOW);
  }
  if (motor2DisplacementAmount > 0) {
    int motor2RunTime = motor2DisplacementAmount*1000/msPerMl;
    digitalWrite(perlestaticMotor2Pin, HIGH);
    digitalWrite(perlestaticMotor4Pin, HIGH);
    delay(motor2RunTime);
    digitalWrite(perlestaticMotor2Pin, LOW);
    digitalWrite(perlestaticMotor4Pin, LOW);
  }
  if (motor3DisplacementAmount > 0) {
    int motor3RunTime = motor3DisplacementAmount*1000/msPerMl;
    digitalWrite(perlestaticMotor3Pin, HIGH);
    digitalWrite(perlestaticMotor4Pin, HIGH);
    delay(motor3RunTime);
    digitalWrite(perlestaticMotor3Pin, LOW);
    digitalWrite(perlestaticMotor4Pin, LOW);
  }
}

void sendTelemetry() {
  if (telemetryTimeSinceLastMessage == 10) {
  http.begin(NESTIP, DATABASEPORT);
  http.addHeader("Content-Type", "application/json"")
  http.POST(std::format(
    "{\"temperature\":\"{}\",\"pH\":\"{}\",\"rpm\":\"{}\",\"od600\":\"{}\",\"key\":\"{}\"}",
    thermocoupleTemp, pH, motorRpm, od600Measurement, APIKEY));
  telemetryTimeSinceLastMessage = 0;
}
  else {
    telemetryTimeSinceLastMessage + 2;
  }
}