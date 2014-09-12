/*
 *   Initializes a new instance of the Coordinate class.
 */
function Coordinate(x, y) {
    this.x = x;
    this.y = y;
}

/*
 *   Checks if a coordinate is equal to other coordinate.
 */
Coordinate.prototype.equals = function (other) {
    var result = false;

    if (other.x === this.x && other.y === this.y) {
        result = true;
    }

    return result;
};

/*
 *   Prints the coordinate on the console.
 */
Coordinate.prototype.toString = function () {
    return  "X: " + this.x + " Y: " + this.y;
};