window.onload = function() {

	var stage = initalizeStage();
	var layer = initializeLayer();

	var posX = 50;
	var posY = 50;

	var rect = new Kinetic.Rect({
		fill: 'yellowgreen',
		stroke: 'black',
		x: posX,
		y: posY,
		width: 150,
		height: 150
	});

	var nodeText = new Kinetic.Text({
        x: posX,
        y: posY,
        width: 150,
        padding: 10,
        text: "sameple text",
        fontSize: 24,
        fill: 'black',
        align: 'center'
    });

	layer.add(rect);
	layer.add(nodeText);
	stage.add(layer);

	//console.log(Data.familyMembers[0]);

};

function initalizeStage() {
	var stage = new Kinetic.Stage({
		container: 'kinetic-container',
		width: 960,
		height: 640
	});

	return stage;
};

function initializeLayer(stage) {
	var layer = new Kinetic.Layer();

	return layer
};