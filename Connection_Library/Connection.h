#include <Ethernet.h>

#ifndef conn
#define conn

#if (ARDUINO >= 100)
#include <Arduino.h>
#else
#include <WProgram.h>
#endif

class Request {
  public:
    char* type;
    char* thing;
    int value;
};

class Connection {
  public:
    // Constructor
    Connection(int port);
    
    // Methods
    Listen(char*(*callback)(Request *req)); //Listens for connections, pushing strings forwards to a callback
    appendChar(char* s, char c);

    
  private:
    EthernetServer _server;
    Request* parseString(char* str);
};

#endif
