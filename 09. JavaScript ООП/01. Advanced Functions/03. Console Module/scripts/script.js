window.onload = function() {
    'use strict';
    var $container = $('#output');
    var specialConsole = new ConsoleModule($container.first());
    specialConsole.writeLine("Message: hello");
    specialConsole.writeLine("Message: {0}", "hello");
    specialConsole.writeError("Error: {0}", "Something happened");
    specialConsole.writeWarning("Warning: {0}", "A warning");
};