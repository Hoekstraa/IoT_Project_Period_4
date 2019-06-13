#include <Ethernet.h>

#ifndef conn
#define conn

#if (ARDUINO >= 100)
  #include <Arduino.h>
#else
  #include <WProgram.h>
#endif

class Connection {
  public:
    // Constructor
    Connection(int port);

    // Methods  
    Listen(String(*callback)(const String *)); //Listens for connections, pushing strings forwards to a callback
  
  private:
    EthernetServer _server;
};


#endif
