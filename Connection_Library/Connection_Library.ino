#include <Ethernet.h>
#include "Connection.h"
#include "sensorFunctions.h"

const byte mac[] = {0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa};
const int port = 2525;

IPAddress ip (192, 168, 1, 10);

Connection connection(port);

auto Pump = new Actuator(6);
auto Light = new Actuator(9);
auto Fan = new Actuator(8);

auto gnd1 = new AnalogSensor(1);
auto gnd2 = new AnalogSensor(2);

// return string is for reply to client.
String handleRequest(Request *req)
{
  //  if (req->type != "get" && req->type != "set") {
  //    return "invalid";
  //  }
  String t = req->thing;

  if (req->type == "get") {
    if (t == "state[0]") return String(Light->State()); // light
    if (t == "state[1]") return String(Fan->State()); // fan
    if (t == "state[2]") return String(Pump->State()); // pump
  }
  if (req->type == "set") {
    if (req->value == 1) {
      if (t == "state[0]") return Light->TurnOn(); // light
      if (t == "state[1]") return Fan->TurnOn(); // fan
      if (t == "state[2]") return Pump->TurnOn(); // pump
    }
    else {
      if (t == "state[0]") return Light->TurnOff(); // light
      if (t == "state[1]") return Fan->TurnOff(); // fan
      if (t == "state[2]") return Pump->TurnOff(); // pump
    }
  }

  return "invalid request";
}

void setup() {
  Ethernet.begin(mac, ip, {172, 16, 0, 1}, {255, 255, 0, 0});
  // Only enable this if it's necessary. Writing to Serial slows down the whole proces.
  Serial.begin(230400);
  //Serial.println("Connected to serial");
  //Serial.println("Starting listening");
}

void loop() {
  connection.Listen(handleRequest);
}
