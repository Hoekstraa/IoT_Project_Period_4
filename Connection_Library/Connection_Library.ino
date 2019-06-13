#include <Ethernet.h>
#include "Connection.h"

const byte mac[] = {0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa};
const int port = 2525;

IPAddress ip (192, 168, 1, 2);

Connection connection(port);

char* getter(String toGet)
{
  return "1024";
}


char* setter(String toSet, int value)
{
  return "succes";
}

char* whatToDo(const char* s)
{
  const String ss = String(s);
  
  if (ss.startsWith("get ")) {
    Serial.print("Getting ");
    Serial.println(ss.substring(4));
    return getter(ss.substring(4));
  }
  if (ss.startsWith("set ")) {
    Serial.print("Setting ");
    Serial.println(ss.substring(4));
    return setter(ss.substring(4), 0);
  }
  return "invalid command";
}

void setup() {
  Ethernet.begin(mac, ip);
  Serial.begin(9600);
  Serial.println("Connected to serial");
  Serial.println("Starting listening");
}

void loop() {
  connection.Listen(whatToDo);
}
