#include <Ethernet.h>
#include "Connection.h"
#include "sensorFunctions.h"

const byte mac[] = {0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa};
const int port = 2525;

IPAddress ip (192, 168, 1, 10);

Connection connection(port);

auto Pump = new Actuator(3);
auto Light = new Actuator(2);
auto Fan = new Actuator(4);

auto Gnd1 = new AnalogSensor(4);
auto Gnd2 = new AnalogSensor(5);
auto Hmd = new AnalogSensor(1);
//auto Tmp = new AnalogSensor(4);

/// Callback function handling the Request objects
/// \return String is for reply to client.
String handleRequest(Request *req)
{
  String t = req->thing;

  if (req->type == "get") {
    if (t == "light") return String(Light->State()); // light
    if (t == "fan") return String(Fan->State()); // fan
    if (t == "pump") return String(Pump->State()); // pump
    if (t == "gnd") return String(Gnd1->State());
    if (t == "hmd") return String(Hmd->State());
  }
  if (req->type == "set") {
    if (req->value == 1) {
      if (t == "light") return Light->ManualOn(); // light
      if (t == "fan") return Fan->ManualOn(); // fan
      if (t == "pump") return Pump->ManualOn(); // pump
    }
    else {
      if (t == "light") return Light->ManualOff(); // light
      if (t == "fan") return Fan->ManualOff(); // fan
      if (t == "pump") return Pump->ManualOff(); // pump
    }
  }
  return "invalid request";
}

/// Checks if plants need something
///   and subsequently turns on an actuator 'till the need has been satisfied.
void automatics()
{
  int groundMoistnessMinimum = 60;
  int airHumidityMaximum = 80;
  //int lampTime = 0;
  if (Gnd1->State() < groundMoistnessMinimum || Pump->manualOn) {Pump->TurnOn();} else {Pump->TurnOff();}
  if (Hmd->State() > airHumidityMaximum || Fan->manualOn) Fan->TurnOn(); else Fan->TurnOff();
  if (Light->manualOn) Light->TurnOn(); else Light->TurnOff();
}

/// Initialises Ethernet and Serial
void setup() {
  Ethernet.begin(mac, ip, {172, 16, 0, 1}, {255, 255, 0, 0});
  // Only enable this if it's necessary. Writing to Serial slows down the whole proces.
  Serial.begin(230400);
}

/// Main loop
void loop() {
  connection.Listen(handleRequest);
  automatics();
}
