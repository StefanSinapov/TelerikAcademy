/*
 *   Initializes a new instance of the Player class.
 */
function Player(id, name, score) {
    if (!name) {
        throw "The parameter for Player's name is missing.";
    }

    if (!score && score !== 0) {
        throw "The parameter for Player's score is missing.";
    }

    if (score < 0) {
        throw "The parameter for Player's score: " + score + " is less than 0.";
    }

    this.id=id;
    this.name = name;
    this.score = score;
}

/*
 *   Prints the properties of the player on the console.
 */
Player.prototype.toString = function () {
    return "Name: " + this.name + " Score: " + this.score;
};