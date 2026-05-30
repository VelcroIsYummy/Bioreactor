# Bioreactor?
This project is a expandable and usable bioreactor designed to allow **you** to grow bacteria, fungi, anything you can grow in a conventional bioreactor! Essencially this is a sterile volume, with ports or holes for instumentation (thermocouples, pH sensors, ect.) with software for controlling and managing the systems within. This bioreactor is unique (compared to other options at this price) by being very open and easy to build (some are open source, however they typically don't have great instructions on how to build your own.) Being very easily expandable, for example, extra slots are included if you want more motors, and it's easy to just add them (all design files are included.) And finally, being much larger than most other options (500mL.)

# Why?
Decentralized science is one of the most pivotal steps toward our future, wether it's finding a cure for an obscure disease, or providing resources to those who need it, decentralized science is the solution. Our project enables this, helping fuel a better future for us all. Perhaps one day someone will use it for something like producing insulin in areas that have limited outside access. The reason why I personally needed this is simple: I have a science fair that involves the growth of bacteria.

# Features
This bioreactor is a pretty full-fledged bioreaction system, it can grow almost any organism (that you could with a insustrial bioreactor), has dosing systems, optical density measurments, temprature control and a online, accessible UI. The only thing that this bioreactor can't handle is significant pressure differentials, as it's just not meant for that. It's also no

## BOM
|Name                        |Purpose                                                                                                                                          |Quantity|Total Cost (USD)|Link                                                                                      |Distributor|
|----------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------|--------|----------------|------------------------------------------------------------------------------------------|-----------|
|Perfboard                   |It is used to connect everything together.                                                                                                       |1       |8.00            |https://www.amazon.ca/Protoboard-Solderable-Breadboard-Electronics-Projects/dp/B0B9F2DNXD/|Amazon     |
|Schottky Diodes (Pack of 10)|The Schottky diodes are so that the MOSFET doesn't burn out due to back EMF.                                                                     |1       |3.41            |https://www.aliexpress.com/item/1005007566611868.html                                     |Aliexpress |
|500mL Media Storage Bottle  |It shall be used to contain the media in which the biological processes are happening.                                                           |1       |30.00           |https://stonylab.com/products/250ml-wide-mouth-media-storage-bottle?variant=47202194620674|StonyLab   |
|CoPA filament               |It is to print some parts that will either be exposed to warm temperatures and that will be contacting the media (for sterilization reasons.)    |1       |43.70           |https://www.amazon.ca/gp/product/B09MTC51RH/                                              |Amazon     |
|30x30x10mm fan              |The fan is to cool the MOSFETs and the Arduino.                                                                                                  |1       |3.72            |https://www.aliexpress.com/item/1005009082132202.html                                     |Aliexpress |
|S8050 (Pack of 20)          |It is used to switch the MOSFET on and off,                                                                                                      |1       |1.40            |https://www.aliexpress.com/item/1005008583538092.html                                     |Aliexpress |
|IRFZ44N (Pack of 10)        |The MOSFET is used both for motor control, and for the control of the heater.                                                                    |1       |2.42            |https://www.aliexpress.com/item/1005007580466441.html                                     |Aliexpress |
|Thermal Paste               |The thermal paste is so that the heater pad and the media container can have proper conduction, as otherwise heat transfer would be poor.        |1       |8.74            |https://www.amazon.ca/Thermal-Grizzly-Kryonaut-Grease-Paste/dp/B011F7W3LU/                |Amazon     |
|MAX6675                     |It is so that I may use the thermocouple in coordination with the Arduino.                                                                       |1       |6.50            |https://www.amazon.ca/MAX6675-Thermocouple-Temperature-Sensor-Module/dp/B07YC25RFW/       |Amazon     |
|Type K thermometer          |It is used for PID control and data collection.                                                                                                  |1       |8.74            |https://www.amazon.ca/MECCANIXITY-Surface-Thermocouple-Handheld-Temperature/dp/B0CCSKDCW3/|Amazon     |
|Geared Motor                |It is used in order to stir the media, allowing equal dispersion of materials and organisms.                                                     |1       |15.60           |https://www.aliexpress.com/item/1005010720335071.html                                     |Aliexpress |
|Silicone Heating Pad 12V/40W|It is used for heating and maintaining the temperature of the media.                                                                             |1       |10.00           |https://www.aliexpress.com/item/1005005338245057.html                                     |Aliexpress |
|12V/15A Power Supply        |I shall use this PSU for powering the Bioreactor's systems.                                                                                      |1       |19.67           |https://www.aliexpress.com/item/1005011601037869.html                                     |Aliexpress |
|Arduino Minima              |The Arduino Minima is used for the control of biological processes (pH control, temperature control, ect.) and for communications through Serial.|1       |20.00           |https://store-usa.arduino.cc/collections/uno/products/uno-r4-minima                       |Arduino    |

# Usage
The usage of this bioreactor is pretty simple, after assembly, connect it to the internet (you can put in your WiFi password by just adding it to the "secrets.h" file.) After this, just turn on the PSU, and connect to it on the internet. The process by which you connect everything together, and set up the web UI is detailed in the instructions.

# Requirements/Libraries
For this project to work you will need to download the following libraries in Arduino IDE:

- PID (https://github.com/br3ttb/Arduino-PID-Library/tree/master)
- MAX6675 (https://github.com/RobTillaart/MAX6675)
- functional (included with Arduino IDE)
- WiFiS3 (included with Arduino IDE)
- ArduinoMqttClient (https://github.com/arduino-libraries/ArduinoMqttClient)
- RTC (https://github.com/cvmanjoo/RTC)