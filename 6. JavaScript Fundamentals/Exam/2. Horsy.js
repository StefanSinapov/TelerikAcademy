args = [
	'3 5',
	'54561',
	'43328',
	'52388',
];

args2 = [
	'3 5',
	'54361',
	'43326',
	'52188',
];

function sovle(args) {
	var rowsAndCols = args[0].split(' ');
	var rows = parseInt(rowsAndCols[0], 10);
	var cols = parseInt(rowsAndCols[1], 10);
	//read moves
	var moves = []
	for (var i = 0; i < rows; i++) {
		moves[i] = args[i + 1].split('').map(Number);
	};
	//console.log(moves);

	var arena = initArena(rows, cols);
	//console.log(arena);
	function initArena(rows, cols) {
		var arena = [];
		for (var i = 0; i < rows; i++) {
			arena[i] = [];
			for (var j = 0; j < cols; j++) {
				arena[i][j] = Math.pow(2, i) - j;
			};
		};

		return arena;
	}

	var currentRow = rows - 1,
		currentCol = cols - 1,
		sum = 0,
		numberOfJumps = 0;

	while(true) {
		//check if go out
		if (currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols) {
			return 'Go go Horsy! Collected ' + sum + ' weeds';
		}
		//check if visited
		if (arena[currentRow][currentCol] === 'visited') {
			return "Sadly the horse is doomed in " + numberOfJumps + " jumps";
		}

		sum += arena[currentRow][currentCol];
		arena[currentRow][currentCol] = 'visited';
		var direction = moves[currentRow][currentCol];
		numberOfJumps++;
		switch (direction) {
			case 1:
				currentRow -= 2;
				currentCol += 1;
				break;
			case 2:
				currentRow -= 1;
				currentCol += 2;
				break;
			case 3:
				currentRow += 1;
				currentCol += 2
				break;
			case 4:
				currentRow += 2;
				currentCol += 1;
				break;
			case 5:
				currentRow += 2;
				currentCol -= 1;
				break;
			case 6:
				currentRow += 1;
				currentCol -= 2;
				break;
			case 7:
				currentRow -= 1;
				currentCol -= 2;
				break;
			case 8:
				currentRow -= 2;
				currentCol -= 1;
				break;
		}
	}
}

console.log(sovle(args2));