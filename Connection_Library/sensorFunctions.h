#ifndef SENSORFUNCTIONS_h
#define SENSORFUNCTIONS_h

#if (ARDUINO >= 100)
#include <Arduino.h>
#else
#include <WProgram.h>
#endif

/// Contains all functions and data needed for handling real-life actuators.
class Actuator {
    int pin;
    int state = 0;
    
  public:
    Actuator(int pin);
    String TurnOn();
    String TurnOff();
    String State();
    String ManualOn();
    String ManualOff();

    bool manualOn = false;
};

/// Relays data from real-life analog sensors.
class AnalogSensor {
    int pin;
  public:
    AnalogSensor(int pin);
    int State();
};

#endif
