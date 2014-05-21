var params1 = [
	'110',
	'13',
	'15',
	'17'
];

var params2 = [
	'20',
	'11',
	'200',
	'300'
];

var params3 = [
	'110',
	'19',
	'29',
	'39'
];

function solve(params) {
	var money = parseInt(params[0])	,
		n = 3,
		c1 = {
			value: parseInt(params[1]),
			isBigger: false
		},
		c2 = {
			value: parseInt(params[2]),
			isBigger: false
		},
		c3 = {
			value: parseInt(params[3]),
			isBigger: false
		},
		bestSum = 0;
	var parameters = [c1, c2, c3];
	for (var i = 0; i < n; i++) {
		parameters[i].group = [0];
	};
	//console.log("money - " + money)
	//console.log(parameters);
	//check if any of them is bigger than S
	for (var i = 0; i < n; i++) {
		if (parameters[i].value > money) {
			parameters[i].isBigger = true;
		}
	};
	//console.log(parameters);
	//check if three are bigger
	if (parameters[0].isBigger && parameters[1].isBigger && parameters[2].isBigger) {
		return 0;
	}
	//check for each one if it its own make it
	for (var i = 0; i < n; i++) {
		var currentBestSum = 0;
		if (!parameters[i].isBigger) {
			currentBestSum = findSingleBestSum(parameters[i], money);
		}
		//check the groups

		//two by two

		if (currentBestSum > bestSum && currentBestSum <= money) {
			bestSum = currentBestSum;
		}
	}

	var currentBestSum = executeAllGroups(parameters, money);

	if (currentBestSum > bestSum && currentBestSum <= money) {
			bestSum = currentBestSum;
		}


	//console.log(parameters);
	return bestSum;



	//functions
	function findSingleBestSum(parameter, money) {
		var currentBestSum = 0;
		
		while (true) {
			if (currentBestSum + parameter.value > money) {
				break;
			} else {
				currentBestSum += parameter.value;
				parameter.group.push(currentBestSum);
			}
		}
		return currentBestSum;
	}

	function executeAllGroups(parameters, money)
	{

		var currentBestSum = 0,
			tempSum = 0,
			currentMaxSum = 0;
		//var firstArray = parameters[0].group;
		//console.log(firstArray);
		for (var i = 0; i < parameters[0].group.length; i++) {
			for (var j = 0; j < parameters[1].group.length; j++) {
				for (var k = 0; k < parameters[2].group.length; k++) {
					
					if(currentBestSum += (parameters[0].group[i] + parameters[1].group[j] + parameters[2].group[k]) > money)
					{
						currentBestSum = 0;
					}
					else {
						currentBestSum += (parameters[0].group[i] + parameters[1].group[j] + parameters[2].group[k]);
						//console.log("-> " + currentBestSum);
						if(currentBestSum > currentMaxSum && currentBestSum <= money)
						{

							currentMaxSum = currentBestSum;
						}
					}
				};
			};
		};
		//console.log(currentMaxSum + " hello")
		return currentMaxSum;
	}
}

console.log(solve(params1));