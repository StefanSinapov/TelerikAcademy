function tick(text) {
	repeatCount++;
	if (repeatCount > 10) {
		clearInterval(timer);
		return;
	}
	self.postMessage(text);
}


var timer;
var repeatCount = 0;

self.onmessage = function onMessage(event) {
	timer = setInterval(function () { tick(event.data.name) }, 100);
}