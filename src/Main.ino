#include <Wire.h>

/* Now I hate annotating my code, but since wilson will be working on this
and the judges will be looking at it. I guess I can swallow my pride and just
do it for once. */



// This is for a mosfet, according to a yt video i found the easiest way to
// control a mosfet w/ arduino is to use a BJT npn also, this needs a pullup
int PWM_pin = 3;

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
    float preverror = 0 // previous error, required for derivative
    float elapsedTime, Time, timePrev; // required for intergral
    std::function<float()> readSensor; // Bassically does a function

    int start (kp, ki, kd, setpoint, std::function<float()> sensorFn):
    kp(kp), ki(ki), kd(kd), setpoint(setpoint), readSensor(sensorFn) {
      val = readSensor(); // Pass in function
     //Next we calculate the error between the setpoint and the real value

      PID_error = set_temperature - temperature_read + 3;
      //Calculate the P value
      PID_p = 0.01*kp * PID_error;
      //Calculate the I value in a range on +-3
      PID_i = 0.01*PID_i + (ki * PID_error);
      //For derivative we need real time to calculate speed change rate
      timePrev = Time;                            
      Time = millis();                            
      elapsedTime = (Time - timePrev) / 1000; 
      //Now we can calculate the D value
      PID_d = 0.01*kd*((PID_error - previous_error)/elapsedTime);
      //Final total PID value is the sum of P + I + D
      PID_value = PID_p + PID_i + PID_d;
      preverror = error;

      constrain(PID_value, 0, 255); // stops errors cuz we can't have -pwm

  private:
    int PID_p = 0;    int PID_i = 0;    int PID_d = 0;
  
}





void setup() {
  pinMode(PWM_pin,OUTPUT);
  SetPinFrequencySafe(3, 928)
}




analogWrite(PWM_pin,255-PID_value);