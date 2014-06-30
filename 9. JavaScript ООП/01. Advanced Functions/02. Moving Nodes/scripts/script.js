'use strict';
window.onload = function() {
    var $container = $('#wrapper');
    var movingShapes = new ShapeModule($container.first());

//    movingShapes.add('circle');
//    movingShapes.add('circle');
//    movingShapes.add('rectangle');
//    movingShapes.add('rectangle');
    window.onclick = function() {

        if(Math.random() > 0.5) {
           movingShapes.add('circle');
        }
        else{
            movingShapes.add('rectangle');
        }
    }
};