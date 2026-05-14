#include <PID_v1.h>
#include "MAX6675.h"
#include <functional>

const int dataPin = 7; const int clockPin = 6; const int selectPin = 5;
const int heaterPin = 3; const int motorPin = 9;
const int encoderInputPin = 2; const int encoderRevoultionsPerRotationOfMotorShaft = 11; // may be wrong
int encoderPulses = 0;
double heaterKp = 0; double heaterKi = 0; double heaterKd = 0;
double rpmKp = 0; double rpmKi = 0; double rpmKd = 0;
bool on = false; bool motorOn = false;
double heaterSetpoint = 0; double heaterOutput = 0; double rpmSetpoint = 0; double rpmOutput = 0;
double thermocoupleTemp = 0; volatile double motorRpm = 0;
const int maxRpm = 530;

MAX6675 thermoCouple(selectPin, dataPin, clockPin);
uint32_t start, stop;

PID heaterPID(&thermocoupleTemp, &heaterOutput, &heaterSetpoint, heaterKp, heaterKi, heaterKd, DIRECT);
PID rpmPID(&motorRpm, &rpmOutput, &rpmSetpoint, rpmKp, rpmKi, rpmKd, DIRECT);
void setup() {
  pinMode(encoderInputPin, INPUT_PULLUP);
  attachInterrupt(digitalPinToInterrupt(encoderInputPin), incrementEncoderPulse, RISING)
  pinMode(heaterPin,OUTPUT);
  pinMode(motorPin, OUTPUT);
  SPI.begin();
  thermoCouple.begin();
  heaterPID.SetMode(AUTOMATIC);
  rpmPID.SetMode(AUTOMATIC);
  Serial.begin(9600);
  Serial.setTimeout(50);
}

void loop() {
  if (on == true) {
    onLoop();
  }
}

double checkThermocouple() {
  start = micros();
  int status = thermoCouple.read();
  stop = micros();
  double temp = thermoCouple.getCelsius();
  return temp;
}

void onLoop() {
  thermocoupleTemp = checkThermocouple();
  heaterPID.Compute();
  analogWrite(heaterPin, 255 - heaterOutput);
  Serial.println(thermocoupleTemp);
  Serial.print(",");
  Serial.print(motorRpm);
  if (Serial.available() > 0) {
    serialComms(Serial.readString());
  }
}

void onMotor() {
  double motorRpm = checkEncoder();
}

void serialComms(String comms) {
  char firstLetter = comms.charAt(0);
  if (firstLetter == 'A') {
    comms.remove(0,1);
    double tempSet = comms.toDouble();
    if (tempSet < 60) {
      double heaterSetpoint = tempSet;
    }
    else {
      double heaterSetpoint = 0;
    }
  }
  if (firstLetter == 'B') {
    on = true;
  }

  if (firstLetter == 'C') {
    on = false;
  }
  if (firstLetter == 'D') {
    motorOn = true;
  }
  if (firstLetter == 'E') {
    motorOn = false;
  }
  if (firstLetter == 'F') {
    comms.remove(0,1);
    double rpmSet = comms.toDouble();
    if (rpmSet <= maxRpm) {
      double rpmSetpoint = rpmSet;
    }
    else {
      double rpmSetpoint = 0;
    }
  }
  if (firstLetter == 'G') {
    comms.remove(0,1);
    double heaterKp = comms.toDouble();
  }
  if (firstLetter == 'H') {
    comms.remove(0,1);
    double heaterKi = comms.toDouble();
  }
  if (firstLetter == 'I') {
    comms.remove(0,1);
    double heaterKd = comms.toDouble();
  }
  if (firstLetter == 'J') {
    comms.remove(0,1);
    double rpmKp = comms.toDouble();
  }
  if (firstLetter == 'K') {
    comms.remove(0,1);
    double rpmKi = comms.toDouble();
  }
  if (firstLetter == 'L') {
    comms.remove(0,1);
    double rpmKd = comms.toDouble();
  }
}

double checkEncoder() {
  double motorRpm = encoderPulses/encoderRevoultionsPerRotationOfMotorShaft * 60;
}

void incrementEncoderPulse() {
  encoderPulses++;
}
