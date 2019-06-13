#include <Ethernet.h>
#include "Connection.h"

const byte mac[] = {0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa};
const int port = 2525;

IPAddress ip (192, 168, 1, 2);

Connection connection(port);

//char* getter(String toGet)
//{
//  return "1024";
//}
//
//
//char* setter(String toSet, int value)
//{
//  return "succes";
//}

char* whatToDo(Request *req)
{
  if(req->type == "invalid"){return req->type;}
  return req->type;
}

void setup() {
  Ethernet.begin(mac, ip);
  // Pushed this value up to increase throughput,
  // it seemingly decreased networkspeeds a lot.
  Serial.begin(1000000); 
  Serial.println("Connected to serial");
  Serial.println("Starting listening");
}

void loop() {
  connection.Listen(whatToDo);
}
