function Solve(args) {

	// console.log(args[0]);

	// var pattern = /\[.*]/;
	// var testedWithRegEx = pattern.exec(args[0])
	// var numbers = ParseIntCollection(testedWithRegEx[0]);
	// console.log(testedWithRegEx[0]);
	// console.log(numbers);

	// line = line.replace('[', ' ['); // def func2[5, 3, 7, 2, 6, 3] -> def func2 [5, 3, 7, 2, 6, 3]
	//line = line.replace(/\s+/g, ' '); // Remove unnecessary whitespaces


	var lines = args.map(function(item) {
		item = item.trim();
		if (item.indexOf('def ') !== 0) {
			return item;
		}
		//item = item.substr('def '.length).trim();
		return item;
	});
	//When there is no def whe shoud skip this line
	for (var i = 0; i < lines.length; i++) {
		if (lines[i].indexOf('def ') !== 0 && i < lines.length - 1) {
			lines.splice(i, 1);
			i--;
		}
		else if(lines[i].indexOf('def ') === 0) {
			lines[i] = lines[i].substr('def '.length).trim();
		}
	};
	//console.log(lines);

	var operations = parseOperations(lines);
	// named last operation and exchange func
	var lastOperation = operations[operations.length - 1];
	lastOperation.func = lastOperation.name;
	lastOperation.name = 'LastOperation';
	//console.log(operations);
	var scope = {};
	for (var i = 0; i < operations.length; i++) {
		var operation = operations[i];
		scope[operation.name] = operation;
		evaluateOperation(operation.name, scope);
	};

	//final
	if (lastOperation.value instanceof Array) {
		return lastOperation.value.reduce(function(a) {
			return a;
		});
	} else {
		return lastOperation.value;
	}

	function parseOperations(lines) {
		var operations = [];
		for (var i = 0; i < lines.length; i++) {
			var line = lines[i];
			// parts[0] -> variable + oparation
			// parts[1] -> values 
			var parts = line.split('[');
			var operation = parseOperation(parts[0]);
			var value = parseValue(parts[1]);
			operation.value = value;

			//console.dir(parts[1]);
			// console.dir(operation);

			operations.push(operation);
		};

		return operations;
	}

	function parseOperation(operationString) {
		var indexOfWhiteSpace = operationString.trim().indexOf(' '),
			name,
			func;
		if (indexOfWhiteSpace === -1) {
			name = operationString.trim();
			func = '';
		} else {
			name = operationString.substring(0, indexOfWhiteSpace).trim();
			func = operationString.substring(indexOfWhiteSpace, operationString.length).trim();
		}

		return {
			name: name,
			func: func
		};
	}

	function parseValue(valueString) {
		valueString = valueString.trim().replace(']', '');
		var parts = valueString.split(',').map(function(item) {
			item = item.trim();
			if (isFinite(item)) {
				return parseInt(item);
			} else {
				return item.trim();
			}
		});
		//console.dir(parts);
		return parts;
	}

	function evaluateOperation(name, scope) {
		var operation = scope[name];
		var newValues = [];
		for (var i = 0; i < operation.value.length; i++) {
			var item = operation.value[i];
			if (!isFinite(item) && item !== '') {
				//replace fariable with value
				var variableValue = scope[item].value;

				if (variableValue instanceof Array) {
					// for( var j = 0; j < variableValue.length; j++)
					// {
					// 	newValues.push(variableValue[j]);
					// }
					Array.prototype.push.apply(newValues, variableValue);
				} else {
					newValues.push(variableValue);
				}
			} else {
				newValues.push(item)
			}
		};
		operation.value = newValues;
		operation = calculateOperation(operation, scope)
		// console.log("-----");
		// console.log(operation.value);
	}

	function calculateOperation(operation, scope) {
		switch (operation.func) {
			case '':
				break;
			case 'sum':
				operation.value = operation.value.reduce(function(a, b) {
					return a + b;
				});
				break;
			case 'min':
				operation.value = Math.min.apply(null, operation.value);
				break;
			case 'max':
				operation.value = Math.max.apply(null, operation.value);
				break;
			case 'avg':
				operation.value = Math.floor(operation.value.reduce(function(a, b) {
					return a + b;
				}) / operation.value.length);
				break;
		}

		return operation;
	}
}

var args = [
	'def func sum[5, 3, 7, 2, 6, 3]',
	'def func2 [5, 3, 7, 2, 6, 3]',
	'def func3 min[func2]',
	'def func4 max[5, 3, 7, 2, 6, 3]',
	'def func5 avg[5, 3, 7, 2, 6, 3]',
	'def func6 sum[func2, func3, func4 ]',
	'sum[func6, func4]'
];
var args2 = [
	'def func sum[1, 2, 3, -6]',
	'def newList [func, 10, 1]',
	'def newFunc sum[func, 100, newList]',
	'[newFunc]'
];

var args3 = [
	'def newFunc     [      123,432    , 4]',
	'def blaBLA sum[newFunc]',
	'def BLAbla min[newFunc]',
	'avg[BLAbla,blaBLA]'
];

var args4 = [
	'def maxy max[100]', //100
	'def summary [0]', //0
	'combo [maxy, maxy,maxy,maxy, 5,6]', //[100, 100, 100, 100, 5, 6]
	'summary sum[combo, maxy, -18000]', // sum[100, 100, 100, 100, 5, 6, 100, -18000] -> -17489
	'def pe6o avg[summary,maxy]', // avg[-17489, 100] --> -8695
	'sum[7, pe6o]' // sum[7, -8695] --> -8688
];

console.log(Solve(args4));