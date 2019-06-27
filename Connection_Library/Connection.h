#include <Ethernet.h>

#ifndef conn
#define conn

#if (ARDUINO >= 100)
#include <Arduino.h>
#else
#include <WProgram.h>
#endif

/// This object contains all info about a request from a client.
class Request {
  public:
    /// Type of request. e.g. get, set, invalid.
    String type;
    /// Sensor/Actuator to set/get data from/to.
    String thing;
    /// Value to set to Actuator. Defaults to 0 if none is given.
    int value;
};

/// The Connection object contains the code to parse ASCII data sent over the network.
///   It turns it into a Request object and calls the callback function given.
/// \brief Serves to listen to clients and return Request objects.
class Connection {
  public:
    // Constructor
    Connection(int port);

    // Methods
    void Listen(String (*callback)(const Request& req)); //Listens for connections, pushing strings forwards to a callback
    void appendChar(char* s, char c);

  private:
    /// Underlying connection handler
    EthernetServer _server;
    Request parseString(char* str);
};

#endif
