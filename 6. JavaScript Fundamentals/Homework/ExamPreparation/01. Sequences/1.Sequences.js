function Solve(input) {
	var count = parseInt(input[0]);

	input = input.map(Number);
	var answer = 1;
	for (var i = 2; i < input.lenght; i++) {
		if (input[i - 1] > input[i]) {
			answer++;
		}
	}
	return answer;

	//console.log(answer);
}

var input = [
	'7',
	'1',
	'2',
	'-3',
	'4',
	'4',
	'0',
	'1'
];

Solve(input);