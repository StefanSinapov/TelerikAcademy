/*
 *   Initializes a new instance of the Game class.
 */
function Game() {
    this.width = Game.CONFIG.get('WIDTH');
    this.height = Game.CONFIG.get('HEIGHT');

    this.highScores = [];
    this.isEnd = Game.CONFIG.get('INITIAL_END');
    this.scoreHolder = document.getElementById('myform:scores');

    window.requestAnimFrame = (function () {
        return  window.requestAnimationFrame ||
            window.webkitRequestAnimationFrame ||
            window.mozRequestAnimationFrame ||
            function (callback) {
                window.setTimeout(callback, 1000 / 60);
            };
    })();
}

/*
 *   Function that starts the game.
 */
Game.prototype.start = function () {
    this.getHighScores();

    var renderer = new Renderer(this.width, this.height); // renderer object
    var controller = new Controller(); // controller object
    renderer.drawIntro(this.highScores);

    var blazeInitialCoordinate = new Coordinate(this.width / 2, this.height / 2);
    var blaze = new Blaze(blazeInitialCoordinate); // blaze object
    var eggman = new Eggman(blazeInitialCoordinate); // todo: fix coordinate.

    var sonicInitialCoordinate = new Coordinate(-80, this.height - 100); // TODO: move numbers as constants
    var sonic = new Sonic(sonicInitialCoordinate);

    var sounds = new Sound(Game.CONFIG.get('BACKGROUND_SOUND_PATH'), Game.CONFIG.get("VOLUME"), true);
    sounds.play();

    var self = this;
    setTimeout(function () {
        self.animationGameLoop(renderer, controller, blaze, eggman, sonic);
    }, Game.CONFIG.get('INITIAL_WAIT_TIME'));

};

/*
 *   Constants for the game object.
 */
Game.CONFIG = function () {
    var constants = {
        WIDTH: 800,
        HEIGHT: 600,
        INITIAL_WAIT_TIME: 5000,
        SCORES_MAX_COUNT: 10,
        INITIAL_END: false,
        BACKGROUND_SOUND_PATH: 'resources/sounds/background-loop.wav',
        VOLUME: 0.3
    };

    return {
        get: function (name) {
            return constants[name];
        }
    };
}();

/*
 *  Writes the high scores to the local storage.
 */
Game.prototype.logScores = function (currentName, currentScore) {
    var player = new Player(11, currentName, currentScore);
    this.highScores.push(player);
    this.sortHighScores();

    var N = this.highScores.length;
    var i;

    var text = '';

    for (i = 0; i < N; i += 1) {
        if (i === 10) {
            break;
        }

        if (this.highScores[i] instanceof  Player) {
            var id = this.highScores[i].id.toString();
            var name = this.highScores[i].name === null ? 'Unknown' : this.highScores[i].name;
            var score = this.highScores[i].score.toString();
            text = text + id + ',' + name + ',' + score + ',';
        }
    }

    this.scoreHolder.value = text;
};

/*
 *   Function for animation loop of the game.
 */
Game.prototype.animationGameLoop = function (renderer, controller, blaze, eggman, sonic) {
    var self = this;

    if (this.isEnd) {
        return; // TODO: Show end screen -> renderer.drawEnd() ?
    }

    blaze.update(controller, eggman);
    eggman.update(renderer);
    sonic.update(renderer);

    requestAnimFrame(function () {
        self.animationGameLoop(renderer, controller, blaze, eggman, sonic);
    });

    renderer.drawAll(blaze, eggman, sonic);

    if (blaze.missedCount >= 3) {
        this.isEnd = true;
        this.logScores('someName', blaze.score);
        renderer.drawExit(controller);
    }
};


/*
 *   Gets the high scores from local storage.
 */
Game.prototype.getHighScores = function () {
    var highScoresText = this.scoreHolder.value;

    var i, player, spitArray, length, playerName, playerScore, playerId;

    if (highScoresText) {
        spitArray = highScoresText.split(',');
        length = spitArray.length;

        for (i = 0; i < length; i += 3) {
            playerId = parseInt(spitArray[i]);
            playerName = spitArray[i + 1];
            playerScore = parseInt(spitArray[i + 2]);

            if (playerName !== undefined && !isNaN(playerScore)) {
                player = new Player(playerId, playerName, playerScore);
                this.highScores.push(player);
            }
        }
    }
};


/*
 *  Sorts the high scores.
 */
Game.prototype.sortHighScores = function () {
    var N = this.highScores.length;
    var i;

    for (i = 0; i < N; i += 1) {
        for (var j = i + 1; j < N; j += 1) {
            if (this.highScores[i].score < this.highScores[j].score) {
                var oldValue = this.highScores[i];
                this.highScores[i] = this.highScores[j];
                this.highScores[j] = oldValue;
            }
        }
    }
};

