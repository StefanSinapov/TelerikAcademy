/*
 *   Common object.
 */
function Common() {

}

/*
 *   Returns a random integer between min and max
 */
Common.getRandomInt = function (min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
};