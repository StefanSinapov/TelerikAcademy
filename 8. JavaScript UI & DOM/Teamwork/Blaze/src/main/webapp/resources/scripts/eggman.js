/*
 *   Initializes a new instance of the Eggman class.
 */
function Eggman(coordinate) {
    GameObject.call(this, coordinate);
    this.isOnScreen = false;
    this.coolDown = Eggman.CONFIG.get('EGGMAN_COOLDOWN');
    this.width = Eggman.CONFIG.get('EGGMAN_WIDTH');
    this.height = Eggman.CONFIG.get('EGGMAN_HEIGHT');
    this.maxSpeed = Eggman.CONFIG.get('EGGMAN_MAXSPEED');
    this.dieSound = new Sound(Eggman.CONFIG.get('DIE_SOUND_PATH'),0.3);
}

/*
 *   Inherits GameObject
 */
Eggman.prototype = new GameObject();

/*
 *   Corrects the constructor pointer.
 */
Eggman.prototype.constructor = Eggman;

/*
 *   Prints the properties of eggman.
 */
Eggman.prototype.toString = function () {
    return "Eggman:\n" + GameObject.prototype.toString.call(this);
};

/*
 *   Constants for the Eggman object.
 */
Eggman.CONFIG = function () {
    var constants = {
        'EGGMAN_WIDTH': 60,
        'EGGMAN_HEIGHT': 60,
        'EGGMAN_COOLDOWN': 100,
        'EGGMAN_MAXSPEED': 5,
        'DIE_SOUND_PATH': 'resources/sounds/die.mp3'
//        'DIE_SOUND_PATH': 'resources/sounds/die.wav'
    };

    return {
        get: function (name) {
            return constants[name];
        }
    };
}();

// Moves eggman with own speed
Eggman.prototype.move = function (renderer) {

    this.position.x += this.speedX;
    this.position.y += this.speedY;

    if (this.isHit) {

        if (this.position.y > renderer.height / 2) {
            this.isOnScreen = false;
            this.isHit = false;
            this.coolDown = Eggman.CONFIG.get('EGGMAN_COOLDOWN');
        }

        return;
    }

    if (this.isOnScreen && (this.position.x > renderer.width || this.position.x + this.width < 0)) {
        this.isOnScreen = false;
        this.coolDown = Eggman.CONFIG.get('EGGMAN_COOLDOWN');
    }

    if (this.position.y + this.height > renderer.height / 2 || this.position.y < 0) {
        this.speedY = -this.speedY;
    }
};

// Call when Eggman is die
Eggman.prototype.die = function () {
    this.dieSound.play();
    this.isHit = true;
    var award = Math.abs(this.speedY) * 5 + Math.abs(this.speedX) * 10;
    this.speedX = 0;
    this.speedY = 15;
    return award;
};

Eggman.prototype.update = function (renderer) {
    if (!this.isOnScreen) {
        --this.coolDown;

        if (this.coolDown === 0) {
            this.isOnScreen = true;
            var randomX = parseInt((Math.random() * 2)) * (renderer.width + this.width) - this.width;
            var randomY = parseInt(Math.random() * (renderer.height / 2 - this.height));

            this.position = new Coordinate(randomX, randomY);

            this.speedX = parseInt(Math.random() * this.maxSpeed + 1);
            if (randomX > 0) this.speedX = -this.speedX;

            this.speedY = parseInt(Math.random() * this.maxSpeed + 1);
        }
    }

    this.move(renderer);
};