var x = 5,
    y = 6;
var coords = new Coordinate(x, y);
var gameObject;

QUnit.test( "GameObject Constructor", function( assert ) {

    gameObject = new GameObject();
    assert.deepEqual(gameObject, new GameObject(), "gameObject return same type with no params");
    gameObject = new GameObject(coords);
    assert.deepEqual(gameObject, new GameObject(coords), "gameObject return same type with params");

});

QUnit.test( "GameObject toString() Method", function( assert ) {
    gameObject = new GameObject(coords);
    assert.equal(gameObject.toString(), "Current position = " + coords.toString(), "gameObject current position toString()");
});

QUnit.test( "GameObject update method", function (assert) {
    var newCoords = new Coordinate(x+3, y);
    gameObject = new GameObject(coords);
    gameObject.update(newCoords);
    assert.deepEqual(gameObject, new GameObject(newCoords), "gameObject update method");
});

