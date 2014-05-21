var args = [
    '7',
    '1',
    '2',
    '-3',
    '4',
    '4',
    '0',
    '1'
];

var args2 = [
    '6',
    '1',
    '3',
    '-5',
    '8',
    '7',
    '-6'
];

var args3 = [
    '9',
    '1',
    '8',
    '8',
    '7',
    '6',
    '5',
    '7',
    '7',
    '6'
];

console.log(Solve(args3));

function Solve(args) {
    var N = parseInt(args.shift()),
        numbers = args.map(function(item) {
            return parseInt(item, 10);
        }),
        numberOfSequences = 1;

    for (var i = 1; i < numbers.length ; i++) {
        if (numbers[i - 1] > numbers[i]) {
            numberOfSequences++;
        }
    };

    return numberOfSequences;

}