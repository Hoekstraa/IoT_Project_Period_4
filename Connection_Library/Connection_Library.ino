#include <SimpleDHT.h>
#include <Ethernet.h>
#include "Connection.h"
#include "sensorFunctions.h"

///Contains all global variables
namespace g {
  uint8_t mac[] = {0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa};
  const int port = 2525;

  IPAddress ip (192, 168, 1, 10);

  Connection connection(port);

  auto Pump = new Actuator(3);
  auto Light = new Actuator(2);
  auto Fan = new Actuator(4);

  auto Gnd1 = new AnalogSensor(4);
  auto Gnd2 = new AnalogSensor(5);

  // Humidity/temp
  SimpleDHT11 Dht11(7);
  int dhtTemp;
  int dhtHumid;

  // Bar values (for automation)
  int light_length = 0;
  int moistnessMin = 60;
  int humidityMax = 80;
}

///update temperature and humidity variables (g::dhtTemp, g::dhtHumid).
void updateDht() {
  if (millis() % 3000 == 0) {
    byte temperature;
    byte humidity;
    g::Dht11.read(&temperature, &humidity, NULL);
    g::dhtTemp = (int)temperature;
    g::dhtHumid = (int)humidity;
  }
}

/// Callback function handling the Request objects
/// \return String is for reply to client.
String handleRequest(Request *req)
{
  String t = req->thing;

  if (req->type == "get") {
    if (t == "light") return String(g::Light->State()); // light
    if (t == "fan")   return String(g::Fan->State()); // fan
    if (t == "pump")  return String(g::Pump->State()); // pump
    if (t == "gnd")   return String(g::Gnd1->State());
    //if (t == "hmd") return String(DHT.humidity);
    //if (t == "tmp") return String(DHT.temperature);
  }
  if (req->type == "set") {
    if (t == "light" && req->value == 1) return g::Light->ManualOn();
    if (t == "fan" && req->value == 1)   return g::Fan->ManualOn();
    if (t == "pump" && req->value == 1)  return g::Pump->ManualOn();
    if (t == "light" && req->value == 0) return g::Light->ManualOff();
    if (t == "fan" && req->value == 0)   return g::Fan->ManualOff();
    if (t == "pump" && req->value == 0)  return g::Pump->ManualOff();

    // set bars
    if (t == "light_length") {
      g::light_length = req->value;
      return "success";
    };
    if (t == "moistness_min") {
      g::moistnessMin = req->value;
      return "success";
    };
    if (t == "humidity_max") {
      g::humidityMax = req->value;
      return "success";
    };
  }
  return "invalid request";
}

/// Checks if plants need something
///   and subsequently turns on an actuator 'till the need has been satisfied.
void automatics()
{
  if (g::Gnd1->State() < g::moistnessMin || g::Pump->manualOn) g::Pump->TurnOn(); else g::Pump->TurnOff();
  if (g::dhtHumid > g::humidityMax || g::Fan->manualOn) g::Fan->TurnOn(); else g::Fan->TurnOff();
  if (g::Light->manualOn) g::Light->TurnOn(); else g::Light->TurnOff();
}

/// Initialises Ethernet and Serial
void setup() {
  Ethernet.begin(g::mac, g::ip, {172, 16, 0, 1}, {255, 255, 0, 0});
  // Only enable this if it's necessary. Writing to Serial slows down the whole proces.
  Serial.begin(230400);
}

/// Main loop
void loop() {
  g::connection.Listen(handleRequest);
  automatics();
  updateDht();
}
