var x = 5,
    y = 5,
    coordinates = new Coordinate(x, y);
    blaze = new Blaze(coordinates);

QUnit.test('Blaze Constructor Tests', function(assert){
    assert.ok(blaze instanceof GameObject, 'Blaze child of GameObject');
    assert.ok(blaze instanceof Blaze, 'Blaze Constructor');
    assert.ok(blaze.bullets !== undefined, "bullets field exists");
    assert.ok(blaze.reload !== undefined, "reload method exists");
    assert.ok(blaze.shoot !== undefined, "shoot method exists");
    assert.ok(blaze.toString !== undefined, "toString method exists");
    assert.ok(blaze.update !== undefined, 'update method exists');
});

QUnit.test('Blaze reload Method Test', function(assert){
    blaze = new Blaze(coordinates);
    var bullets = blaze.bullets;
    blaze.bullets = 0;
    blaze.reload();
    assert.equal(blaze.bullets, bullets, "reloading from 0 bullets");
});

QUnit.test('Blaze shoot method test', function(assert){
    var target = new Eggman(new Coordinate(5,5));

    var bullets = blaze.bullets;
    blaze.shoot(target);
    assert.equal(blaze.bullets, bullets - 1, 'Bullets decrease when shoot');

    blaze.reload();
    bullets = blaze.bullets;
    blaze.bullets = 1;
    blaze.shoot(target);
    assert.equal(blaze.bullets, bullets, 'Reload function is called when bullets hit 0');

    target.position.x = 2;
    target.position.y = 2;
    target.isHit = false;
    blaze.position.x = target.position.x;
    blaze.position.y = target.position.y;
    blaze.shoot(target);
    assert.ok(target.isHit, 'Target get hit when is in range of the shoot');

    target.position.x = 2;
    target.position.y = 2;
    target.isHit = false;
    blaze.position.x = target.position.x + 150;
    blaze.position.y = target.position.y + 150;
    blaze.shoot(target);
    assert.ok(!target.isHit, 'Target dont get hit when is out of the range of the shoot');
});