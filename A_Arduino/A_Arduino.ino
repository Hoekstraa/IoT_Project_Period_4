#include <SPI.h>
#include <Ethernet.h>
#include <NewRemoteTransmitter.h>

// code van transmitter
#define transmitterCode 10806062
#define RFPin 3

NewRemoteTransmitter transmitter(transmitterCode, RFPin, 260, 3);


// the media access control (ethernet hardware) address for the shield:
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
IPAddress ip(192, 168, 1, 6);
byte dns[] = {192,168,1,1};
byte gateway[] = { 192, 168, 1, 1 };
byte subnet[] = { 255, 255, 255, 0 };

EthernetServer server(12345);

byte pinState[3] = {0,0,0};
  
void setup()
{
  // initialize the ethernet device
  Ethernet.begin(mac, ip, dns, gateway, subnet);

   
  pinMode(RFPin, OUTPUT);
  // start listening for clients
  server.begin();
  Serial.begin(9600);
  Serial.println("Serial available");
}


void loop()
{
  // if an incoming client connects, there will be bytes available to read:
  EthernetClient client = server.available();

  // Do what needs to be done while the socket is connected.
   while(client.connected()) 
   {
      if(client.read() == 85){
        readForSwitch(client); 
      }
   }
}

void readForSwitch(EthernetClient c)
{
  int unitNmr = c.read() - 38;
  int state = toggle(unitNmr);
  c.write(state); 
  Serial.println(unitNmr); 
  Serial.println(state); 
  switchTransmitter(unitNmr,state); 
}

void switchTransmitter(int unit, int state)
{   
   transmitter.sendUnit(unit, toBool(state));               
   delay(100);
}

bool toBool(int n)
{
  if(n == 1)
    return true;
  else
    return false; 
}

int toggle(int buttonNmr)
{
  if (buttonNmr == 13)
  {
    if(pinState[0] == 0)
      pinState[0] = 1; 
    else
      pinState[0] = 0; 
    return pinState[0]; 
  }
  if (buttonNmr == 14)
  {
    if(pinState[1] == 0)
      pinState[1] = 1; 
    else
      pinState[1] = 0; 
   return pinState[1]; 
  }
  if (buttonNmr == 15)
  {
    if(pinState[2] == 0)
      pinState[2] = 1; 
    else
      pinState[2] = 0; 
   return pinState[2]; 
  }
}
