define(['jquery'], function ($) {
    'use strict';

    var HISTORY_CONTAINER = '#history-container',
        SCORE_CONTAINER = '#score-container',
        GAME_CONTAINER = '#game-container',
        WIN_CONTAINER = '#win-container',
        ERROR_COLOR = '#F08080',
        BOX_CLASS = 'box';

    var drawer = (function () {

        var $scoreContainer = $(SCORE_CONTAINER);
        var $historyContainer = $(HISTORY_CONTAINER);
        var $gameContainer = $(GAME_CONTAINER);
        var $winContainer = $(WIN_CONTAINER);


        function hideScoreBoard() {
            $scoreContainer.slideUp(1000);
        }

        function showScoreBoard(scores) {
            $scoreContainer.slideDown(1000);
            var $playerContainer = $('<div/>'),
                text;

            for (var i = 0, len = scores.length; i < len; i += 1) {
                text = i + 1 + '. ' + scores[i][0] + ':  ' + scores[i][1];
                $playerContainer.first().addClass(BOX_CLASS);
                $playerContainer.first().text(text);
                $scoreContainer.append($playerContainer.clone());
            }

        }

        function showError(text, time) {
            text = text || "Error";
            time = time || 3000;

            var $errorContainer = $('<div/>');
            $errorContainer.first().addClass(BOX_CLASS);
            $errorContainer.first().text(text);
            $errorContainer.first().css('background-color', ERROR_COLOR);

            $errorContainer.hide();
            $errorContainer.prependTo($historyContainer);
            $errorContainer.slideDown();
            setTimeout(function () {
                $errorContainer.slideUp();
            }, time);
            setTimeout(function () {
                $errorContainer.remove();
            }, time + 1000);

        }

        function addHistory(number, sheepCount, ramCount) {
            $historyContainer.first().show();
            var $item = $('<div/>'),
                text = number + ' -  Sheeps: '+ sheepCount + ', Rams: ' + ramCount;
            $item.first().addClass(BOX_CLASS);
            $item.first().text(text);
            $item.hide();
            $item.prependTo($historyContainer);
            $item.slideDown();
        }

        function hideWinContainer(){
            $winContainer.fadeOut()
        }

        function showWinContainer(number){
            $winContainer.fadeIn();
            $winContainer.find('strong').text(number)
        }

        function hideGame(){
            $gameContainer.fadeOut();
            $historyContainer.hide();
        }

        return {

            hideScoreBoard: hideScoreBoard,
            showScoreBoard: showScoreBoard,
            showError: showError,
            addHistory: addHistory,
            hideGame: hideGame,
            hideWinContainer: hideWinContainer,
            showWinContainer: showWinContainer
        }

    }());

    //drawScore
    //addHistory
    //getUserName

    return drawer;
});