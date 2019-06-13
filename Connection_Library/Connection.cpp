#include "Connection.h"
#include <Ethernet.h>

Connection::Connection(int port) : _server(port) {
  _server.begin();
}

// If a client is connected, collect the string sent and run the callback function on the string.
Connection::Listen(String(*callback)(const String *)) {
  String _dataRec = "";
  EthernetClient client = _server.available();
  while (client.connected()) {
      char received = client.read();
      _dataRec += received;

      if (received == '\n') {
        _server.println(_dataRec);
        const String result = _dataRec;
        _server.println(callback(result[0])); // Grabs pointer of result, runs callback on the string and returns that to the client.
        _dataRec = "";
        //client.stop();
      }
  }
}
