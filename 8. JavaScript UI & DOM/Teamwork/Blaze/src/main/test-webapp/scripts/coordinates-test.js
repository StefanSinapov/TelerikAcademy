var x = 5,
    y = 6;
var coords = new Coordinate(x, y);

QUnit.test( "Coordinates Constructor", function( assert ) {
    assert.deepEqual(coords, new Coordinate(x, y), 'Coordinates constructor instance');
    assert.notDeepEqual(coords, { 'x': x, 'y': y }, 'Coordinates instance of object');
    assert.ok(coords.x,'Coordinates x property exists');
    assert.ok(coords.y,'Coordinates y property exists');
});


QUnit.test( "Coordinates .toString() method", function( assert ) {
    assert.equal(coords.toString(),  "X: " + x + " Y: " + y, "Coordinates toString() method");
});

QUnit.test( "Coordinates .equals() method", function( assert ) {
    var newCoord = new Coordinate(x, y);

    assert.ok(coords.equals(newCoord),'Coordinates equals with same params');
    assert.ok(!coords.equals(new Coordinate(x+5, y)), 'Coordinates not equals with diff params');
});