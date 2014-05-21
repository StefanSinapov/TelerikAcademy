function Solve(params) {
	var N = parseInt(params[0]);
	var numbers = params.splice(1, N).map(function (number) { return parseInt(number); });

	//console.log(numbers.join(', '));
	//console.log(maxSum(numbers));

	return findMaxSum(numbers);
	
	function findMaxSum(numbers){

		if(numbers.length == 0) {
	        return 0;
	    }

	   	var maxSum = numbers[0];
	    var curSum = maxSum;
	    for(var i=1; i<numbers.length; i++) {
	        curSum = Math.max(numbers[i],  curSum+numbers[i]);

	        if(curSum > maxSum) {
	            maxSum = curSum;
	        }
	    }

	    return maxSum;
	}
}

var params = [
	'8',
	'1',
	'6',
	'-9',
	'4',
	'4',
	'-2',
	'10',
	'-1'
];

Solve(params);
