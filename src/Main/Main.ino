#include <Wire.h>
#include <functional>
#include "MAX6675.h"

/* Now I hate annotating my code, but since wilson will be working on this
and the judges will be looking at it. I guess I can swallow my pride and just
do it for once. */
const int dataPin   = 7; // this is for the thermocouple as it's connected
const int clockPin  = 6; // over SPI
const int selectPin = 5;
int heaterPin = 3;
int motorPin = 9;
int tempSet = 0;
int rpmSet = 0;
int heaterkp = 0;
int heaterki = 0;
int heaterkd = 0;
bool on =  false;
bool motorOn == false;
int heaterConstraintPercentage = 100;
int heaterConstraint = constrain(round(heaterConstraintPercentage/100 * 255), 0, 255);

MAX6675 thermoCouple(selectPin, dataPin, clockPin);

uint32_t start, stop;

// This is for a mosfet, according to a yt video i found the easiest way to
// control a mosfet w/ arduino is to use a BJT npn also, this needs a pullup

// I choose a class because it's easy, and
// I might have to make multiple PID loops
class PIDControl {
  public:
    int kp; // gains for p i and d, gotta tune them
    int ki; // also these are bassically divided by 100 later in the code
    int kd; // maybe I should lower the jank?
    // PID temp control vars
    float setpoint; // Set points are our target temprature
    float val; // Our current value, eg. temp, pH, DO
    float error; // current error in temp
    float preverror = 0; // previous error, required for derivative
    float elapsedTime, Time, timePrev; // required for intergral
    std::function<float()> readSensor; // Bassically does a function
    float PID_value;

    int doPID (int kp, int ki, int kd, float setpoint,
    std::function<float()> sensorFn)
    {
    this->kp = kp; this->ki = ki; this->kd = kd; this->setpoint = setpoint;
    this->readSensor = sensorFn;
      val = readSensor(); // Pass in function
     //Next we calculate the error between the setpoint and the real value

      error = setpoint - val + 3;
      //Calculate the P value
      PID_p = 0.01*kp * error;
      //Calculate the I value in a range on +-3
      PID_i = 0.01*PID_i + (ki * error);
      //For derivative we need real time to calculate speed change rate
      timePrev = Time;
      Time = millis();
      elapsedTime = (Time - timePrev) / 1000;
      //Now we can calculate the D value
      PID_d = 0.01*kd*((error - preverror)/elapsedTime);
      //Final total PID value is the sum of P + I + D
      PID_value = PID_p + PID_i + PID_d;
      preverror = error;

      return constrain(255 - PID_value, 0, HeaterConstraint);
      // stops errors because we can't have -pwm
    }
  private:
    int PID_p = 0;    int PID_i = 0;    int PID_d = 0;

}





void setup() {
  pinMode(heaterPin,OUTPUT);
  SetPinFrequencySafe(3, 928);
  SPI.begin();
  thermoCouple.begin();
  PIDControl tempLoop;
  PIDControl rpmLoop;
  Serial.begin(9600);
  Serial.setTimeout(50);
}

void loop() {
  if (on == true) {
  delay(50);
  analogWrite(heaterPin, tempLoop.doPID(heaterkp, heaterki, heaterkd, tempSet, checkThermocouple));
  // reverses the PWM signal, LOW = HIGH, HIGH = LOW
  Serial.println(checkThermocouple());
  Serial.print(",");
  Serial.print(checkEncoder());
  Serial.print(",");
  Serial.print();
  if (motorOn == true) {
  digitalWrite(motorPin, rpmLoop.doPID(90, 30, 80, rpmSet, checkEncoder));
  }
  }
  else {
    Serial.println("Off");
  }
  if (Serial.available()) {
    int data = Serial.parseInt();
    if (data > 100 and < 400) { // this is for temp setting
      int tempSet = data - 100;
    }
    if (data == 2) {
      bool on = true;
    }
    if (data == 3) {
      bool on = false;
    }
    if (data == 5) {
      motorOn = false;
    }
    if (data >= 1000 and < 4000) {
      heaterConstraintPercentage = data - 1000;
    }
    if (data >= 4000 and < 6999) {
      int rpmSet = data - 4000;
    }
    if (data >=7000 and < 7999) {
      int kp = data - 7000;
    }
    if (data >= 8000 and < 8999) {
      int ki = data - 8000;
    }
    if (data >= 9000) {
      int kd = data - 9000;
    }
  }

}

float checkThermocouple() {
  start = micros();
  int status = thermoCouple.read();
  stop = micros();
  float temp = thermoCouple.getCelsius();
  return temp; // just code to get temp from the MAX6675
}

int checkEncoder() {
  // todo: put in code for checking motor rpm
}
