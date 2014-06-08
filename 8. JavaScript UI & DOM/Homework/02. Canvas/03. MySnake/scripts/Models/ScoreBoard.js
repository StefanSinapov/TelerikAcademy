define(function(require) {

    var _scoreContainer = null;

    function ScoreBoard() {
        scoreContainer = document.getElementById('score-result');
    }

    function getScore() {
        var score = parseInt(scoreContainer.textContent) || 0;
        return score;
    }

    ScoreBoard.prototype.ShowEndResult = function() {

        alert("END GAME. Your score is: " + getScore());
    };

    ScoreBoard.prototype.update = function(value) {
        var result = getScore() + value;
        scoreContainer.textContent = result;
    };

    return ScoreBoard;
});