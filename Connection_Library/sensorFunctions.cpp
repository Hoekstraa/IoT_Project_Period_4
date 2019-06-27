#include "sensorFunctions.h"
#include "Connection.h"

/// Makes an Actuator object.
Actuator::Actuator (int pin) {
  pinMode(pin, OUTPUT);
  this->pin = pin;
}

/// Turns on real-life actuator.
String Actuator::TurnOn() {
  digitalWrite(pin, HIGH);

  this->state = 1;
  return "succes";
}

/// Tells the object to turn on. Used from the app.
String Actuator::ManualOn() {
  this->manualOn  = true;
  return "success";
}

/// Tells the object to turn off. Used from the app.
String Actuator::ManualOff() {
  this->manualOn  = false;
  return "success";
}

/// Turns off real-life actuator.
String Actuator::TurnOff() {
  digitalWrite(pin, LOW);
  this->state = 0;
  return "success";
}

/// Returns the real-life state of the actuator.
String Actuator::State() {
  return String(state);
}

/// Initializes a sensor.
GroundSensor::GroundSensor (int pin) {
  this->pin = pin;
}

/// Maps values read from the sensor to 0 - 100.
int GroundSensor::State() {
  int x = map(analogRead(pin), 600, 190, 0, 100);
  if(x >= 0 && x <= 100) return x;
  if(x < 0) return 0;
  if(x > 100) return 100;
}

/// Parses a Request and applies the Request to the Actuator.
String handleObject(Request* r, Actuator* a)
{
  if (r->type == "get") {
    return String(a->State());
  }
  if (r->type == "set") {
    if (r->value == 1) {
      a->TurnOn();
    }
    else {
      a->TurnOff();
    }
    return "succes";
  }
}
