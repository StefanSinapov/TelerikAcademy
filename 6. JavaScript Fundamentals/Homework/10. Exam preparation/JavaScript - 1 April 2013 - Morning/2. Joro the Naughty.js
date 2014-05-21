var input = [
	'6 7 3',
	'0 0',
	'2 2',
	'-2 2',
	'3 -1'
];

function Solve(input) {
	var rowsColsAndJumps = parseNumbers(input[0]),
		rows = rowsColsAndJumps[0],
		cols = rowsColsAndJumps[1],
		allJums = rowsColsAndJumps[2],
		startingPosition = parseNumbers(input[1]),
		currentRow = startingPosition[0],
		currentCol = startingPosition[1],
		field = initField(rows, cols),
		jumps = readJumps(input),
		sumOfNumbers = 0,
		countOfJumps = 0;
	
	for (var i = 0; i <= jumps.length; i++) {
		
		if(i === jumps.length){
			i = 0;
		}

		if(currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols)
		{
			return "escaped " + sumOfNumbers;
		}
		else if (field[currentRow][currentCol] === 'visited'){
			return "caught " + countOfJumps;
		}
		else {
			countOfJumps++;
			sumOfNumbers += field[currentRow][currentCol];
			field[currentRow][currentCol]='visited'
			currentRow += jumps[i].row;
			currentCol += jumps[i].col;

			
		}
	}

	function initField(rows, cols) {
		var field = [],
			counter = 1;
		for (var i = 0; i < rows; i++) {
			field[i] = [];
			for (var j = 0; j < cols; j++) {
				field[i][j] = counter;
				counter++;
			};
		};
		return field;
	};

	function readJumps(input) {
		var jumps = [];
		for (var i = 2; i < input.length; i++) {
			var currentJump = parseNumbers(input[i]);
			jumps.push({
				row: currentJump[0],
				col: currentJump[1]
			});
		};
		return jumps;
	};

	function parseNumbers(numbers) {
		return numbers.split(' ').map(Number);
	};
}



console.log(Solve(input));