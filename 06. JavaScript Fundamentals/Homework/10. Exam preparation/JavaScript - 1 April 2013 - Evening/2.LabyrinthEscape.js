function Solve(args)
{
	var mAndNAsString = args[0];
	mAndNAsString = mAndNAsString.split(" ");
	var rows = parseInt(mAndNAsString[0]);
	var cols = parseInt(mAndNAsString[1]);

	
	var currentRow = parseInt(args[1].split(' ')[0]);
	var currentCol = parseInt(args[1].split(' ')[1]);
	

	//console.log(currentCol);
	//console.log(M + ' ' + N);

	var area = buildArea(rows, cols);
	var jumps = readJumps(args);

	//console.log(area[1][3]);
	//console.log(args[2].split(''));

	var totalSum = 0;
	var countOfSteps=0
	while(jumps[currentRow][currentCol] !== "visited")
	{
		if(currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols) {
			//console.log( "out " + totalSum);
			return ("out " + totalSum);
			break;
		}
		totalSum += parseInt(area[currentRow][currentCol]);
		var currentCommand = jumps[currentRow][currentCol];
		jumps[currentRow][currentCol] = "visited";
		countOfSteps++;
		switch(currentCommand)
		{
			case "l":
				currentCol -= 1;
				break;
			case "r":
				currentCol += 1;
				break;
			case "u":
				currentRow -= 1;
				break;
			case "d":
				currentRow += 1;
				break;
		}
	}
	//console.log("lost " + countOfSteps);
	return("lost " + countOfSteps);

	function buildArea(M, N)
	{
		var counter = 1;
		var area = [];
		for (var i = 0; i < rows; i++) {
			area[i]=[];
			for (var j = 0; j < cols; j++) {
				area[i][j] = counter;
				counter ++; 
			};
		};
		return area;
	}

	function readJumps(args)
	{
		var jumps = []
		for (var i = 2; i < args.length; i++) {
			jumps[i-2] = args[i].split('');
		};
		return jumps;
	}
}

args =[
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"];

Solve(args);