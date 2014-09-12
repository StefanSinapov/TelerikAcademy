var x = 5,
    y = 10,
    coords = new Coordinate(x, y),
    eggman = new Eggman(coords);

QUnit.test("Eggman Constructor", function(assert){
    assert.ok(eggman instanceof GameObject, 'Eggman instance of GameObject');
    assert.ok(eggman instanceof Eggman, 'Eggman Constructor');
    assert.equal(eggman.constructor, Eggman, 'Eggman Constructor equals Eggman');
    assert.ok(eggman.coolDown !== undefined, 'cooldown field exists');
    assert.ok(eggman.isOnScreen !== undefined, 'onScreen field exists');
    assert.ok(eggman.height !== undefined, 'height field exists');
    assert.ok(eggman.width !== undefined, 'width field exists');
    assert.ok(eggman.maxSpeed !== undefined, 'maxSpeed field exists');
    assert.ok(eggman.move !== undefined, 'move function exists');
    assert.ok(eggman.die !== undefined, 'die function exists');
    assert.ok(eggman.update !== undefined, 'update function exists');
});

QUnit.test("Eggman die Method", function(assert)
{
    eggman.isHit = false;
    eggman.die();
    assert.ok(eggman.isHit, "isHit field get true when get hit ;)");
});

QUnit.test("Eggman move Method", function(assert){
    eggman = new eggman(coords);

});