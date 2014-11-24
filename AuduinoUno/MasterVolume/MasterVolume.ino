//Message
byte input_byte;
//Setup
void setup(){
  //Serial baud rate 9600.
  Serial.begin(9600);
  //1/5
  pinMode(2, OUTPUT);
  //2/5
  pinMode(3, OUTPUT);
  //3/5
  pinMode(4, OUTPUT);
  //4/5
  pinMode(5, OUTPUT);
  //5/5
  pinMode(6, OUTPUT);
}
//Main loop.
void loop(){
  //Buffer size is 1 byte.
  if(Serial.available() == 1){
    //Read from buffer.
    input_byte = Serial.read();
  }
  switch (input_byte){
    case 0:
      Serial.print("THIS IS ARDUINO!");
      break;
    case 1:
      digitalWrite(2, HIGH);
      digitalWrite(3, LOW);
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      break;
    case 2:
      digitalWrite(2, HIGH);
      digitalWrite(3, HIGH);
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      break;
    case 3:
      digitalWrite(2, HIGH);
      digitalWrite(3, HIGH);
      digitalWrite(4, HIGH);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      break;
    case 4:
      digitalWrite(2, HIGH);
      digitalWrite(3, HIGH);
      digitalWrite(4, HIGH);
      digitalWrite(5, HIGH);
      digitalWrite(6, LOW);
      break;
    case 5:
      digitalWrite(2, HIGH);
      digitalWrite(3, HIGH);
      digitalWrite(4, HIGH);
      digitalWrite(5, HIGH);
      digitalWrite(6, HIGH);
      break;
  }
  //Clear message.
  input_byte = 0;
}
