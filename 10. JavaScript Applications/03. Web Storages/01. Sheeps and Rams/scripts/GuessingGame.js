define([], function () {
    'use strict';
    var GuessingGame = (function () {
        var NUMBER_OF_DIGITS = 4,
            POSSIBLE_DIGITS = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

        function GuessingGame() {

        }

        GuessingGame.prototype.start = function () {
            this.secretNumber = getSecretNumber();
            this.numberOfGuesses = 0;
        };

        GuessingGame.prototype.logNumber = function () {
            console.log('For testing purposes only!');
            console.log(this.secretNumber);
        };

        GuessingGame.prototype.guessNumber = function (chosenNumber) {
            chosenNumber = chosenNumber || 0;

            checkIfValidNumber(chosenNumber);

            this.numberOfGuesses += 1;
            var sheepCount = getNumberOfGuessedDigits.call(this, chosenNumber, true);
            var ramCount = getNumberOfGuessedDigits.call(this, chosenNumber, false);

            return {
                sheepCount: sheepCount,
                ramCount: ramCount,
                isNumberGuessed: ramCount === NUMBER_OF_DIGITS,
                numberOfGuesses: this.numberOfGuesses
            }
        };

        function isNumber(n) {
            return !isNaN(parseFloat(n)) && isFinite(n);
        }

        function getRandomInt(min, max) {
            min = parseInt(min);
            max = parseInt(max);

            if (!isNumber(min)) {
                return 0;
            }

            if (!isNumber(max)) {
                max = min;
                min = 0;
            }

            if (min > max) {
                return 0;
            }

            return Math.floor(Math.random() * (max - min + 1)) + min;
        }

        function getSecretNumber() {
            var randomIndex, randomDigit,
                possibleDigits = POSSIBLE_DIGITS.slice(0),
                numberAsArray = [];

            randomIndex = getRandomInt(1, possibleDigits.length - 1);
            randomDigit = possibleDigits.splice(randomIndex, 1);
            numberAsArray.push(randomDigit);

            for (var i = 0; i < NUMBER_OF_DIGITS - 1; i++) {
                randomIndex = getRandomInt(0, possibleDigits.length - 1);
                randomDigit = possibleDigits.splice(randomIndex, 1);
                numberAsArray.push(randomDigit);
            }

            var parsedNumber = numberAsArray.join("") || 0;
            return parsedNumber;
        }

        function checkIfValidNumber(chosenNumber) {
            var isNumberInRange = chosenNumber >= Math.pow(10, NUMBER_OF_DIGITS - 1) && chosenNumber < Math.pow(10, NUMBER_OF_DIGITS);
            if (!isNumberInRange) {
                throw new Error("Chosen number is not in valid range!")
            }

            var chosenNumberAsArray = chosenNumber.toString().split(""),
                digitCounter = [],
                uniqueDigitsCount = 0;

            for (var i = 0; i < chosenNumberAsArray.length; i++) {
                var digit = chosenNumberAsArray[i];
                if (!digitCounter[digit]) {
                    uniqueDigitsCount++;
                }
                digitCounter[digit] = true;
            }

            if (uniqueDigitsCount !== NUMBER_OF_DIGITS) {
                throw new Error("Chosen number contains non-unique digits!")
            }
        }

        function getNumberOfGuessedDigits(chosenNumber, isSheepChecker) {
            var guessedDigits = 0,
                chosenNumberAsArray = chosenNumber.toString().split(""),
                secretNumberAsArray = this.secretNumber.toString().split("");

            for (var i = 0; i < NUMBER_OF_DIGITS; i++) {
                var digit = secretNumberAsArray[i],
                    indexOfDigit = chosenNumberAsArray.indexOf(digit),
                    isDigitGuessed = isSheepChecker ? indexOfDigit !== i : indexOfDigit === i;

                if (indexOfDigit !== -1 && isDigitGuessed) {
                    guessedDigits++;
                }
            }
            return guessedDigits;
        }

        return GuessingGame;
    }());

    return GuessingGame
});