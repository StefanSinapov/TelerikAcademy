/*
 *   Initializes  a new instance of the GameObject class.
 */
function GameObject(coordinate) {
    this.position = coordinate;
}

/*
 *   Prints the properties of the game object on the console.
 */
GameObject.prototype.toString = function () {
    return "Current position = " + this.position.toString();
};

/*
 *   Updates the game object.
 */
GameObject.prototype.update = function (coordinate) {
    this.position = coordinate;
};