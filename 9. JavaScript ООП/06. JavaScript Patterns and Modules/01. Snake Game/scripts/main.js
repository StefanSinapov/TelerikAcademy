(function () {
    'use strict';
    require.config({
        paths: {
            'GameEngine': './Controllers/GameEngine',
            'CollisionDispatcher': './Controllers/CollisionDispatcher',
            'GameBlockDrawer': './Controllers/GameBlockDrawer',
            'KeyboardEventHandler': './Controllers/KeyboardEventHandler',
            'Food': './Models/Food',
            'GameBlock': './Models/GameBlock',
            'GlobalConsts': './Models/GlobalConsts',
            'ScoreBoard': './Models/ScoreBoard',
            'Snake': './Models/Snake',
            'Utility': './Helper/utility'

        }
    });

    require(['GameEngine'], function (GameEngine) {
        var CANVAS = document.getElementById('the-canvas');
        var CONTEXT = CANVAS.getContext("2d");
        var speedInMs = 170;

        var gameEngine = new GameEngine(CONTEXT);
        gameEngine.startGame(speedInMs);
    });
}).call(this);

//'GlobalConsts', 'ScoreBoard', 'GameBlockDrawer', 'KeyboardEventHandler', 'CollisionDispatcher', 'Snake', 'Food'],
//function(GlobalConsts, ScoreBoard, GameBlockDrawer, KeyboardEventHandler, CollisionDispatcher, Snake, Food)