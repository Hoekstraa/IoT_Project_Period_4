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
    if (t == "state[0]") return String(Light->State()); // light
    if (t == "state[1]") return String(Fan->State()); // fan
    if (t == "state[2]") return String(Pump->State()); // pump
    if (t == "gnd") return String(Gnd1->State());
    if (t == "hmd") return String(Hmd->State());
  }
  if (req->type == "set") {
    if (req->value == 1) {
      if (t == "state[0]") return Light->ManualOn(); // light
      if (t == "state[1]") return Fan->ManualOn(); // fan
      if (t == "state[2]") return Pump->ManualOn(); // pump
    }
    else {
      if (t == "state[0]") return Light->ManualOff(); // light
      if (t == "state[1]") return Fan->ManualOff(); // fan
      if (t == "state[2]") return Pump->ManualOff(); // pump
    }
  }
  return "invalid request";
}

/// Checks if plants need something
///   and subsequently turns on an actuator 'till the need has been satisfied.
void automatics()
{
  int groundMoistnessMinimum = 70;
  int airHumidityMaximum = 10;
  
  if (Gnd1->State() < groundMoistnessMinimum || Pump->manualOn == 1) Pump->TurnOn(); else Pump->TurnOff();
  if (Hmd->State() > airHumidityMaximum || Fan->manualOn == 1) Fan->TurnOn(); else Fan->TurnOff();
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
  //automatics();
}
