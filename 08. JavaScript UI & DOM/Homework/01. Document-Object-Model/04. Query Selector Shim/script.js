taskName = "04. querySelector Shim";

function Main(bufferElement) {

	var minButtons = document.querySelectorAll('#control-buttons > button');
	WriteLine("querySelectorAll('#control-buttons > button')[0] -> " + minButtons[0]);

	WriteLine();

	var minButton = document.querySelector('button#minimize-button');
	WriteLine("querySelector(button#minimize-button') -> " + minButton);
}


(function shimQuerySelector() {
	if (typeof document.querySelector === 'undefined') {
		querySelectorAllShim();
		querySelectorShim();

		alert("querySelector shim added!");
	}
}())

// IE7 support for querySelectorAll. Supports multiple / grouped 
// selectors and the attribute selector with a "for" attribute. 
// http://www.codecouch.com/
function querySelectorAllShim() {
	(function(doc, styleSheet) {
		doc = document, styleSheet = doc.createStyleSheet();

		doc.querySelectorAll = function(selector) {
			var allDocElements = doc.all,
				collection = [];
			selector = selector.replace(/\[for\b/gi, '[htmlFor').split(',');

			for (var i = selector.length; i--;) {
				styleSheet.addRule(selector[i], 'k:v');

				for (var j = allDocElements.length; j--;) {
					allDocElements[j].currentStyle.k && collection.push(allDocElements[j]);
				}

				styleSheet.removeRule(0);
			}

			return collection;
		};
	})();
}

function querySelectorShim() {
	document.querySelector = function(selector) {
		var result = this.querySelectorAll(selector);
		return result[0] || null;
	};
}