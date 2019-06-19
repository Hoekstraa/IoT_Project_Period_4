#include "sensorFunctions.h"
#include "Connection.h"

Actuator::Actuator (int pin) {
  pinMode(pin, OUTPUT);
  this->pin = pin;
}

String Actuator::TurnOn() {
  digitalWrite(pin, HIGH);
  
  this->state = 1;
  return "succes";
}
String Actuator::TurnOff() {
  digitalWrite(pin, LOW);
  this->state = 0;
  return "succes";
}
String Actuator::State() {
  return String(state);
}

AnalogSensor::AnalogSensor (int pin) {
  this->pin = pin;
}

int AnalogSensor::state() {
  return map(analogRead(pin), 1023, 200, 0, 100);
}


// parse request and apply request to object
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
