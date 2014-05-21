  /*Task 1 - all possible literals*/
  "use strict";
  var bool = (false || (false === 0));
  jsConsole.writeLine("Boolean literal can be: " + bool + ' or ' + !bool);
  var int = 32;
  jsConsole.writeLine("Integer litaral can be any integer number like: " + int);
  var double = Math.PI;
  jsConsole.writeLine("Floating-point literal can be any fractional number like: " + double);
  var string = "alaBala Nica";
  jsConsole.writeLine("String literal can be any string of words like: " + string);

  /*Task 2 - escaping quotes*/
  var quote = '"How you doin\'?", Joey said.';
  jsConsole.writeLine(quote);

  /*Task 3 - typeof of all variables*/
  jsConsole.writeLine("TypeOf true is:" + typeof (bool));
  jsConsole.writeLine("TypeOf 32 is: " + typeof (int));
  jsConsole.writeLine("TypeOf 3.14 is: " + typeof (double));
  jsConsole.writeLine('TypeOf \"' + string + '\ is: ' + typeof (string));

  /*Task 4 - typeof null and undefined*/
  jsConsole.writeLine('TypeOf null is: ' + typeof (null));
  jsConsole.writeLine('TypeOf undefined is: ' + typeof (undefined));