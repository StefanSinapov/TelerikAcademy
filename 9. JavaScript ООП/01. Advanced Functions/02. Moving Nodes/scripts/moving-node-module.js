'use strict';
var ShapeModule = (function() {
    function ShapeModule(container) {
        this.container = container;
        return this;
    }

    ShapeModule.prototype.add = function(shapeName) {
        var shape = _generateDiv(shapeName);
        this.container.append(shape);
    };

    function _getRandomFontFamily() {
        var fonts = ['Arial', 'Consolas', 'Tahoma', 'Verdana'];
        return fonts[_getRandomInt(fonts.length - 1)];
    }

    function _getRandomInt(min, max) {
        min = parseInt(min);
        max = parseInt(max);

        if (!isNumber(min)) {
            return 0;
        }

        if (!isNumber(max)) {
            max = min;
            min = 0;
        }

        if (min > max) {
            return 0;
        }

        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    function _getRandomColor(){
        return '#' + Math.random().toString(16).substr(-6);
    }

    function _generateDiv(className) {
        var div = $('<div/>')
            .addClass('shape').addClass(className)
            .css('font-family', _getRandomFontFamily())
            .css('background-color', _getRandomColor())
            .css('border-color', _getRandomColor());
        div.text(div.css('font-family'));
        return div;
    }

    return ShapeModule;
})();