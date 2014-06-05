window.onload = function() {
	var stage = new Kinetic.Stage({
		container: 'kinetic-container',
		width: 960,
		height: 640
	});

	var layer = new Kinetic.Layer({
		draggable: true
	});

	layer.on("mousemove", function() {
		document.body.style.cursor = 'pointer';
	});

	layer.on("mouseout", function() {
		document.body.style.cursor = 'default';
	});

	var rect = new Kinetic.Rect({
		fill: 'yellowgreen',
		stroke: 'black',
		x: 50,
		y: 50,
		width: 150,
		height: 150
	});

	layer.add(rect);
	stage.add(layer);

};