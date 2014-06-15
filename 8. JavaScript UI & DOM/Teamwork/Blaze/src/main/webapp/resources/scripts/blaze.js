/*
 *   Initializes a new instance of the Blaze class.
 */
function Blaze(coordinate) {
    GameObject.call(this, coordinate);
    this.bullets = Blaze.CONFIG.get('MAX_BULLETS_COUNT');
    this.score = Blaze.CONFIG.get('INITIAL_SCORE');
    this.missedCount = Blaze.CONFIG.get('INITIAL_MISSED_EGGMAN');
    this.shootSound = new Sound(Blaze.CONFIG.get('SHOOT_SOUND_PATH'));
}

/*
 *   Inherits GameObject
 */
Blaze.prototype = new GameObject();

/*
 *   Corrects the constructor pointer.
 */
Blaze.prototype.constructor = Blaze;

/*
 *   Shoots and lowers the count of the total bullets.
 */
Blaze.prototype.shoot = function (eggman) {
    this.bullets--;
    this.shootSound.play();
    if (this.bullets === Blaze.CONFIG.get('MIN_BULLETS_COUNT')) {
        this.reload();
    }

    if (eggman.position.x <= this.position.x && this.position.x <= eggman.position.x + eggman.width
        && eggman.position.y <= this.position.y && this.position.y <= eggman.position.y + eggman.height) {
        this.score += eggman.die();
    }
    else{
        ++this.missedCount;
    }
};

/*
 *   Reloads the bullets to max bullet count.
 */
Blaze.prototype.reload = function () {
    this.bullets = Blaze.CONFIG.get('MAX_BULLETS_COUNT');
};

/*
 *   Constants for the Blaze object.
 */
Blaze.CONFIG = function () {
    var constants = {
        'MAX_BULLETS_COUNT': 3,
        'MIN_BULLETS_COUNT': 0,
        'RELOADING_TIME': 3000,
        'INITIAL_SCORE': 0,
        'INITIAL_MISSED_EGGMAN': 0,
        'SHOOT_SOUND_PATH': 'resources/sounds/shoot.wav'
    };

    return {
        get: function (name) {
            return constants[name];
        }
    };
}();

/*
 *   Prints Blaze's properties on the console.
 */
Blaze.prototype.toString = function () {
    return "Blaze:\n" + GameObject.prototype.toString.call(this);
};

/*
 *   Updates the state of Blaze.
 */
Blaze.prototype.update = function (controller, eggman) {

    if (controller.mousePosition !== null) {
        //  console.log(controller.mousePosition);
        GameObject.prototype.update.call(this, controller.mousePosition);
    }

    if (controller.mouseClick !== null) {
        this.shoot(eggman);
        // console.log(controller.mouseClick);
        controller.mouseClick = null;
    }
};