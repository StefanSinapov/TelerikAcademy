 window.onload = function() {
     var stage = initializeStage();
     var layer = new Kinetic.Layer();
     var target = initializeTarget(stage);


     layer.add(target);
     stage.add(layer);

     performAnimation(stage, layer, target);
 }

 function initializeStage() {
     var stage = new Kinetic.Stage({
         container: 'container',
         width: 960,
         height: 640
     });
     return stage;
 };

 function initializeTarget(stage) {
     var target = new Kinetic.Circle({
         x: 100,
         y: stage.height() / 2,
         radius: 40,
         fill: 'red',
         stroke: 'black',
         strokeWidth: 4
     });

     return target;
 };

 function performAnimation(stage, layer, target) {
     var amplitude = 350;
     var period = 3500;
     // in ms
     var centerX = stage.width() / 2;

     var anim = new Kinetic.Animation(function(frame) {
         target.setX(amplitude * Math.sin(frame.time * 2 * Math.PI / period) + centerX);

     }, layer);

     target.on('click', function() {
         alert("target was clicked");
     })

     anim.start();
 }