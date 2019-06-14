#include <Ethernet.h>
#include "Connection.h"

const byte mac[] = {0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa};
const int port = 2525;

IPAddress ip (172, 16, 6, 0);

Connection connection(port);

int temp1 = 0;

// return string is for reply to client.
String handleRequest(Request *req)
{
  if (req->type != "get" && req->type != "set") {
    return "invalid";
  }

  if (req->type == "get")
  {
    //if (req->thing == "temp1") {
      return String(temp1);
    //}
  }

  if (req->type == "set")
  {
    if (req->thing == "temp1") {
      temp1 = req->value;
      return "succes";
    }
  }

  
  
  return "unknown thing";
}

void setup() {
  Ethernet.begin(mac, ip,{172,16,0,1},{255,255,0,0});
  // Only enable this if it's necessary. Writing to Serial slows down the whole proces.
  Serial.begin(230400);
  //Serial.println("Connected to serial");
  //Serial.println("Starting listening");
}

void loop() {
  connection.Listen(handleRequest);
}
