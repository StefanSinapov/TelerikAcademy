window.onload = function() {
	function setBodyBackground() {
		var color = document.getElementById("body-bg");
		document.body.style.backgroundColor = color.value;
	}

	document.getElementById("setBodyBG").onclick = setBodyBackground;
}