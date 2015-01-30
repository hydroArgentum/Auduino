Auduino
=======
An Audio visualization project using Arduino.

# About Auduino

Auduino allows Windows to communicate audio data to the Arduino using serial communication.
The corresponding Arduino code takes the data and uses it to display volume information and (hopefully) audio frequency data.
This project uses NAudio to obtain data from Windows playback devices. Link to NAudio can be found [here](http://naudio.codeplex.com/).

# Q&A

Q: What/who is this project intended for?
A: The exact code is actually something that I'm interested in and is a personal project of mine.
However, other hardware developers may use this code as a reference for a hardware project of their own design.
Not only does it have the audio visualization scheme (in the C# code), but also ways to verify and communicate to Arduinos using serial communication.
(Because by manipulating the code, theoretically, you can have any number of Arduinos connected to your computer.)
It also allows developers a look into how NAudio works.

Q: How do I open the files?
The Arduino sketch can be opened using the [Arduino software](http://arduino.cc/en/Main/Software).
The C# code can be opened using Visual Studio 2013.

Q: What Arduino model is this code for?
This particular code is written for the Arduino Uno.
However, it only takes simple modifications to the code to make it work for any other Arduino and could probably be used for Arduino-like devices
(as long as they use/are compatible to the Arduino software).

Q: What is with the Uno at the end of the file name?
The Auduino Uno is planned to be a master volume (single-channel) audio visualization project.
The next part of the project, Auduino Due is planned to be a stereo (two-channel) audio visualization project.
The Auduino Tre is planned to visualize both the stereo and the master volume.
Subsequent numbers (counting in Italian) will be used to visualize different numbers of frequencies.
