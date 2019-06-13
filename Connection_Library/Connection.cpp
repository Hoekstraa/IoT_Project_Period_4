#include "Connection.h"
#include <Ethernet.h>

Connection::Connection(int port) : _server(port) {
  _server.begin();
}

//WARNING: Does not check if appending will go out of range of char* s!
Connection::appendChar(char* s, char c)
{
  int len = strlen(s);
  s[len] = c;
  s[len + 1] = '\0';
}

// If a client is connected, collect the string sent and run the callback function on the string.
Connection::Listen(char* (*callback)(Request *req)) {
  char _dataRec[30] = "";
  EthernetClient client = _server.available();

  // If a client connects, read its data.
  while (client.connected()) {
    char received = client.read();
    appendChar(_dataRec, received);

    // When the end of message appears, do the callback.
    if (received == '\n') {
      Serial.println("Data Received:");
      Serial.print(_dataRec);
      Serial.println("Callback calculating..");
      Request* req;
      char* result = callback(parseString(_dataRec));
      delete req; // Needed to clear the result type for next time a client connects
      Serial.println("result:");
      Serial.println(result);
      _server.println(result); // Return result of callback to client.
      strcpy(_dataRec, "");
      client.stop();
    }
  }
}

Request* Connection::parseString(char* str) {
  Request* req = new Request();
  const String ss = String(str);
  
  if (ss.startsWith("get ")) {
    req->type = "get";
    Serial.println(ss.substring(4));
  }
  else if (ss.startsWith("set ")) {
    req->type = "set";
    Serial.println(ss.substring(4));
  }
  else {req->type = "invalid";}

  req->thing = "ThisIsATest";
  req->value = 0;
  
  return req;
}
//}
