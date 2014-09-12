var args = [
	'1, 3, -6, 7, 4 ,1, 12',
	'3',
	'1, 2, -3',
	'1, 3, -2',
	'1, -1'
];

console.log(Solve(args));

function Solve(args) {

	function parsePatterns(args) {
		var paterns = []
		for (var i = 2; i < args.length; i++) {
			//console.log(args[i]);
			paterns[i - 2] = args[i].split(",").map(Number);
		};
		return paterns;
	}

	function executePattern(pattern, numbers) {

		var coins = 0,
			position = 0,
			visitedCells = [];
		//console.log("------ new pattern ------");
		for (var i = 0; i <= pattern.length; i++) {

			if (visitedCells[position] === true) {
				break;
			}
			if (i === pattern.length) {
				i = 0;
			}
			//console.log(numbers[position]);
			coins += numbers[position];
			visitedCells[position] = true;
			position += pattern[i];
		};

		return coins;
	}

	var numbers = args[0].split(",").map(Number),
		numberOfpatterns = parseInt(args[1]),
		patterns = parsePatterns(args),
		coins = Number.NEGATIVE_INFINITY;

	for (var i = 0; i < numberOfpatterns; i++) {
		var currentCoins = executePattern(patterns[i], numbers);
		if (currentCoins > coins) {
			coins = currentCoins;
		}
		
	};

	return coins;
}