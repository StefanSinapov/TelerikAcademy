'use strict';
var Drawer = (function() {
    var context;

    function Drawer(){
        var canvas = document.createElement('canvas');
        canvas.width = 900;
        canvas.height = 640;
        canvas.style.position = "absolute";
        canvas.style.border = "1px solid black";
        canvas.style.top = '20px';
        canvas.style.left = '20px';
        document.body.appendChild(canvas);
        context = canvas.getContext('2d');
        context.lineWidth = 2;
        context.strokeStyle = 'black';
        context.fillStyle = 'red';
    }

    Drawer.prototype = {
        drawLine: function(x1, y1, x2, y2){
            context.beginPath();
            context.moveTo(x1, y1);
            context.lineTo(x2, y2);
            context.stroke();
        },
        drawCircle: function(x, y, radius){
            context.beginPath();
            context.arc(x, y, radius, 0, 2 * Math.PI);
            context.fill();
            context.stroke();
        },
        drawRect: function(x, y, width, height){
            context.beginPath();
            context.rect(x, y, width, height);
            context.fill();
            context.stroke();
        }
    }

    return Drawer;
}());