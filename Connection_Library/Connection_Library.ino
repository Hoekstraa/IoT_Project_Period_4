#include <Ethernet.h>
#include "Connection.h"

const byte mac[] = {0xaa, 0xaa, 0xaa, 0xaa, 0xaa, 0xaa};
const int port = 2525;

IPAddress ip      (192,168,1,2);

Connection connection(port);

String MergeStringArray (String strArr[])
{
  String result = "";
  for(int i = 0; i < 5; i++)
  {
    result = result + "i";
  }
  return result;
}

String whatToDo(const String *s)
{
  char str[30];
  s->toCharArray(str, s->length());
  String command[5] = strtok(str, ' ');
  String result = MergeStringArray(command);
  return result;
  //return "test";
}

void setup() {
  Ethernet.begin(mac,ip);
}

void loop() {
  connection.Listen(whatToDo);
}
