define([], function() {
    'use strict';
   var ScoreBoard = (function() {
       var _scoreContainer = null;

       function ScoreBoard() {
           _scoreContainer = document.getElementById('score-result');
       }

       function getScore() {
           var score = parseInt(_scoreContainer.textContent) || 0;
           return score;
       }

       ScoreBoard.prototype.ShowEndResult = function () {

           alert("END GAME. Your score is: " + getScore());
       };

       ScoreBoard.prototype.update = function (value) {
           var result = getScore() + value;
           _scoreContainer.textContent = result;
       };

       return ScoreBoard;
   })();

    return ScoreBoard;
});