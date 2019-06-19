#ifndef SENSORFUNCTIONS_h
#define SENSORFUNCTIONS_h

#if (ARDUINO >= 100)
#include <Arduino.h>
#else
#include <WProgram.h>
#endif

class Actuator {
    int pin;
    int state = 0;

  public:
    Actuator(int pin);
    String TurnOn();
    String TurnOff();
    String State();
};

class AnalogSensor {
    int pin;
  public:
    AnalogSensor(int pin);
    int state();
};

#endif
