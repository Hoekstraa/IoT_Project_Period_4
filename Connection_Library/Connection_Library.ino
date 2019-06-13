#include <Ethernet.h>
#include "Connection.h"

const byte mac[] = {0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa};
const int port = 2525;

IPAddress ip (192, 168, 1, 2);

Connection connection(port);

char* whatToDo(const char* s)
{
  Serial.println(s);
  //char* ptr = strtok(s, " ");

  //char* result[5];

  //while(ptr != NULL)
  //{
  //  result[0] = ptr;
  //  ptr = strtok(NULL, " ");
  //}
  //return result[0];
  return s;
}

void setup() {
  Ethernet.begin(mac, ip);
  Serial.begin(9600);
}

void loop() {
  connection.Listen(whatToDo);
}
