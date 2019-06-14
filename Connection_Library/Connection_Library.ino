#include <Ethernet.h>
#include "Connection.h"

const byte mac[] = {0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa};
const int port = 2525;

IPAddress ip (192, 168, 1, 2);

Connection connection(port);

String whatToDo(Request *req)
{
  if (req->type == "invalid") {
    return req->type;
  }
  return req->type + req->thing + req->value;
}

void setup() {
  Ethernet.begin(mac, ip);
  // Only enable this if it's necessary. Writing to Serial slows down the whole proces.
  //Serial.begin(230400);
  //Serial.println("Connected to serial");
  //Serial.println("Starting listening");
}

void loop() {
  connection.Listen(whatToDo);
}
