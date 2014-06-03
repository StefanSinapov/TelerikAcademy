taskName = "01. Select inner divs";

function Main(bufferElement) {
	showAllDivsOnPage();
	showInnerDivsWithLiveNode();
	showInnerDivsWithStaticNode();
};

function showAllDivsOnPage() {
	var allDivs = document.getElementsByTagName('div');

	WriteLine("Number of all divs: " + allDivs.length);
	WriteLine();
};

function showInnerDivsWithLiveNode() {
	var allDivs = document.getElementsByTagName('div');
	var innerDivs = [];
	for (var i = 0; i < allDivs.length; i++) {
		if (allDivs[i].parentNode instanceof HTMLDivElement) {
			innerDivs.push(allDivs[i]);
		}
	};
	WriteLine("Live node - Number of inner divs: " + innerDivs.length);
	WriteLine();
};

function showInnerDivsWithStaticNode(){
	var innerDivs = document.querySelectorAll('div > div');

	WriteLine("Static Node - Number of inner divs: " + innerDivs.length);
	WriteLine();
}