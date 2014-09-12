window.onload = function() {
	function showInputValue() {
		var input = document.getElementById("searched-input");
		alert(input.value);
	};

	document.getElementById("clickMe").onclick = showInputValue;
}