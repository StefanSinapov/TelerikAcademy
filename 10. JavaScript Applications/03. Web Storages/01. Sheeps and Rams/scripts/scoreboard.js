define(function () {
    'use strict';
    var ScoreBoard = (function () {
        function showTop10() {
            var top10Players = getSortedTop10Players(),
                top10PlayersToString = [];

            for (var i = 1; i <= top10Players.length && i <= 10; i++) {
                top10PlayersToString.push(i + ". " + top10Players[i - 1][0] + " -> " + top10Players[i - 1][1]);
            }

            if (top10PlayersToString.length > 0) {
                alert(top10PlayersToString.join("\n"));
            }
            else {
                alert("No players!");
            }
        }

        function addPlayerToRank(playerNickname, numberOfTries) {
            var lastRecord = localStorage.getItem(playerNickname) || numberOfTries,
                score = numberOfTries < lastRecord ? numberOfTries : lastRecord;
            localStorage.setItem(playerNickname, score);
        }

        function getSortedTop10Players() {
            var top10 = [];
            for (var i in localStorage) {
                top10.push([i, localStorage.getItem(i)]);
            }

            // Sort them by number of guessed numbers
            top10.sort(function (a, b) {
                return a[1] - b[1];
            });

            return top10;
        }

        function clearScoreBoard (){
            localStorage.clear();
        }

        return {
            addPlayerToRank: addPlayerToRank,
            getTop10: getSortedTop10Players,
            showTop10: showTop10,
            clearScoreBoard: clearScoreBoard
        }
    }());

    return ScoreBoard;
});