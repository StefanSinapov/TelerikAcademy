(function () {
    'use strict';
    require.config({
        paths: {
            "jquery": "libs/jquery",
            "GuessingGame": "GuessingGame",
            'scoreboard': 'scoreboard'
        }
    });

    require(['GuessingGame', 'scoreboard', 'ui-drawer', 'jquery'], function(GuessingGame, scoreboard, drawer, $){

		//TODO: fix scoreboard
        var $guessButton = $('#guess-button'),
            $numberInput = $('#number-input'),
            $nameInput = $('#name-input'),
            $saveButton = $('#save-score-button');

        $guessButton.on('click', onGuessCheck);
        $saveButton.on('click', onNicknameInput);

        var game = new GuessingGame();
        game.start();
        game.logNumber();

        function onGuessCheck(){
            var number = $numberInput.first().val();
            var guess;
            try{
                guess = game.guessNumber(number);
                if(!guess.isNumberGuessed) {
                    drawer.addHistory(number, guess.sheepCount, guess.ramCount);
                }
                else {
                    drawer.hideGame();
                    drawer.showWinContainer(game.numberOfGuesses);
                }
            }
            catch(ex){
                drawer.showError(ex);
            }
            finally{
                $numberInput.first().val('');
                //clear all HIstory
                //hide game and history

            }
        }

        function onNicknameInput(){
            //TODO: check
            var input = $nameInput.first().val();
            scoreboard.addPlayerToRank(input, game.numberOfGuesses);
            drawer.hideWinContainer();
            drawer.showScoreBoard(scoreboard.getTop10());
        }
    });

}());