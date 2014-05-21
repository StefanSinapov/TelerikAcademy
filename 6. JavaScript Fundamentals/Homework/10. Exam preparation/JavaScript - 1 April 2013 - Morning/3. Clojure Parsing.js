function Solve(input) {

	function removeSpaces(lines) {
		for (var i = 0; i < lines.length; i++) {
			lines[i] = lines[i].replace(/\s+/g, ' '); //remove unnecessary whitespaces
			lines[i] = lines[i].replace('( ', '('); // (  + 3 4 5) -> (+ 3 4 5)
			lines[i] = lines[i].substr(1);
		};
		return lines
	}

	function parseFunctions(lines) {
		var functions = [];
		var indexOfOpenBracket,
			indexOfCloseBracket,
			indexOfDef,
			indexOfWhiteSpace;
		for (var i = 0; i < lines.length; i++) {
			functions[i] = {};
			indexOfDef = lines[i].indexOf('def');

			if (indexOfDef !== -1) {
				lines[i] = lines[i].substring('def '.length);
				indexOfWhiteSpace = lines[i].indexOf(' ');
				indexOfOpenBracket = lines[i].indexOf('(');
				indexOfCloseBracket = lines[i].indexOf(')');
				functions[i].name = lines[i].substring(0, indexOfWhiteSpace).trim();
				if (indexOfOpenBracket !== -1) {

					functions[i].operator = lines[i].trim().substr(indexOfOpenBracket + 1, 1);
					functions[i].value = lines[i].substring(indexOfOpenBracket + 2, indexOfCloseBracket).trim().split(' ');
				} else {
					functions[i].operator = '';
					functions[i].value = lines[i].substring(indexOfWhiteSpace, indexOfCloseBracket).trim().split();
				}
			} else {
				//console.log(lines[i]);
				indexOfCloseBracket = lines[i].indexOf(')');
				functions[i].name = 'noName';
				functions[i].operator = lines[i].trim().substr(0, 1);
				functions[i].value = lines[i].substring(2, indexOfCloseBracket).trim().split(' ');
			}
		};
		return functions;
	}

	function executeOperation(scope, currentFunction, i) {
		if (currentFunction.value.length === 1) {
			currentFunction.value = parseInt(currentFunction.value);
			scope[currentFunction.name] = currentFunction;
			return scope;
		}
		switch (currentFunction.operator) {
			case '':
				break;
			case '+':
				currentFunction.value = currentFunction.value.reduce(function(a, b) {
					return parseInt(a) + parseInt(b);
				})
				break;
			case '-':
				currentFunction.value = currentFunction.value.reduce(function(a, b) {
					return parseInt(a) - parseInt(b);
				});
				break;
			case '*':
				currentFunction.value = currentFunction.value.reduce(function(a, b) {
					return parseInt(a) * parseInt(b);
				});
				break;
			case '/':
				currentFunction.value = Math.floor(currentFunction.value.reduce(function(a, b) {
					return parseInt(a) / parseInt(b);
				}));
				break;
		}

		scope[currentFunction.name] = currentFunction;
		return scope;
	}

	function exchangeValues(scope, currentFunction) {
		//console.log(currentFunction.value);
		var newValues = [];
		for (var i = 0; i < currentFunction.value.length; i++) {
			var currentItem = currentFunction.value[i];
			//console.log(currentItem);
			if (isFinite(parseInt(currentItem))) {
				newValues.push(parseInt(currentItem));
				//Math.prototype.push.apply(newValues, parseInt(currentItem));
			} else {
				//console.log(scope[currentItem].value);
				newValues.push(parseInt(scope[currentItem].value));
				//Math.prototype.push.apply(newValues, parseInt(scope[currentItem].value[i]);
			}
		};
		currentFunction.value = newValues;
		scope[currentFunction.name] = currentFunction;
		return scope;
	}

	var lines = removeSpaces(input);
	var functions = parseFunctions(lines);
	var scope = []
	for (var i = 0; i < functions.length; i++) {
		var currentFunction = functions[i]
		scope[currentFunction.name] = currentFunction;
		scope = exchangeValues(scope, currentFunction);
		scope = executeOperation(scope, currentFunction, i);

		if (!isFinite(currentFunction.value)) {
			return "Division by zero! At Line:" + (i + 1);
		}
		//console.log(currentFunction);
	};

	//console.dir(scope);
	//return Final result
	return scope[functions[functions.length - 1].name].value;
}



var input1 = [
	"(+ 1 2)", //3
	"(+ 5 2 7 1)", //15
	"(- 4 -2)", //6
	"(- 4)", //4
	"(/ 2)", //2
	"(* 3 5)", //15
	"(/ 10 3)", //floor! 3
	"(/ 10 3 2)" // 1
]

var input = [
	"(def myFunc 5   )",
	"(def myNewFunc (+  myFunc  myFunc 2))",
	"(def MyFunc (* 2  myNewFunc))",
	"(/   MyFunc  myFunc)"
]

var input2 = [
	'(def func 10)',
	'(def newFunc (+  func 2))',
	'(def sumFunc (+ func func newFunc 0 0 0))',
	'(* sumFunc 2)'
];

var input3 = [
	'(def func (+ 5 2))',
	'(def func2 (/  func 5 2 1 0))',
	'(def func3 (/ func 2))',
	'(+ func3 func)'
];

var input4 = [
	'(def     go6o    (+ -5 -2) )',
	'(def pe6o (   /  -15 go6o))',
	'(def asD (/ 2 0))',
	'(def func2 asD  )',
	'(           +        4          2      func2)'
];

console.log(Solve(input4));