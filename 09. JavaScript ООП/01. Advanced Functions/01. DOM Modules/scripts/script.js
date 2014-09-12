/*
1. Create a module for working with DOM. The module should have the following functionality
    * Add DOM element to parent element given by selector
    * Remove element from the DOM by given selector
    * Attach event to given selector by given event type and event hander
    * Add elements to buffer, which appends them to the DOM when their count for some selector becomes 100
    * The buffer contains elements for each selector it gets
    * Get elements by CSS selector
    * The module should reveal only the methods
*/



// Code from demo
'use strict';
var div = document.createElement("div");

//appends div to #wrapper
domModule.appendChild(div,"#wrapper");

//removes li:first-child from ul
domModule.removeChild("ul","li:first-child");

//add handler to each a element with class button
domModule.addHandler("a.button", 'click', function(){alert("Clicked")});

var navItem = $('<li/>');
for (var i = 0; i < 12; i++)
{
    navItem.text('buffer item ' + (i + 1));
    domModule.appendToBuffer("#main-nav ul", navItem.clone());
}
