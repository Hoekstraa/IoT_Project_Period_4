#include "Connection.h"
#include <Ethernet.h>

/// Makes Connection, with server started.
Connection::Connection(int port) : _server(port) {
  _server.begin();
}

/// \brief Concatenates a char to a (char pointer) string
///WARNING: This function by itself does not check if appending will go out of range of char* s!
/// \param s String to append a char to.
/// \param c Char to append to string s.
void Connection::appendChar(char* s, char c)
{
  int len = strlen(s);
  s[len] = c;
  s[len + 1] = '\0';
}

/// If a client is connected, collect the string sent and run the callback function on the string.
/// \param callback Function pointer to a callback that parses and reacts to all Requests.
void Connection::Listen(String (*callback)(Request *req)) {
  char _dataRec[30];
  memset(&_dataRec[0], 0, sizeof(_dataRec)); //clear char array for later reuse

  EthernetClient client = _server.available();

  // If a client connects, read its data.
  while (client.connected()) {
    char received = client.read();
    appendChar(_dataRec, received);

    if (strlen(_dataRec) > 29){_server.println("message too long"); client.stop(); break;} //When buffer size limit has been reached, just stop the connection and exit.
    
    // When the end of message appears, do the callback.
    if (received == '\n') {
      Serial.println("Data Received:");
      Serial.print(_dataRec);
      //Serial.println("Callback calculating..");
      //Request* req;
      String result = callback(parseString(_dataRec));
      //delete req; // Needed to clear the result type for next time a client connects
      Serial.println("result:");
      Serial.println(result);
      _server.println(result); // Return result of callback to client.
      strcpy(_dataRec, "");
      client.stop();
    }
  }
}

/// Turns a string into a Request object.
/// If the string is not valid, it returns a Request of type "invalid".
/// \param str String to parse.
Request* Connection::parseString(char* str) {
  Request* req = new Request();
  const String ss = String(str);

  req->type = "invalid";

  if (ss.startsWith("get ")) {
    req->type = "get";
    req->thing = ss.substring(4); //Remove "get " from the string, the rest should be the thing to get.
    req->thing.trim(); //Remove trailing newline, for easy front-end use.
  }
  else if (ss.startsWith("set ")) {
    req->type = "set";
    String sss = ss.substring(4);
    //Serial.println(sss.indexOf(' '));
    if (sss.indexOf(' ') != 0) { // Another space char exists in the string.
      req->thing = sss.substring(0, sss.indexOf(' ')); // Get the string between 'set' and the second space. And make a copy of it.
      //Serial.println("thing: " + req->thing);
      req->value = sss.substring(sss.indexOf(' ') + 1).toInt(); //Get the string after the space, interpret as an int.
      //Serial.println(req->value);
    }
  }
  return req;
}
