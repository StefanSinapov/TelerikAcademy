var player,
    playerName = 'Pesho',
    score = 150;

QUnit.test( 'Player Constructor Test', function(assert){
    player = new Player(playerName, score);
    assert.deepEqual(player, new Player(playerName, score), 'Player object instance of Player');
    assert.ok(player.name,'Player name property exists');
    assert.ok(player.score,'Player score property exists');
//    assert.throws(new Player());
});

QUnit.test( 'Player .toString Method', function(assert){
    player = new Player(playerName, score);
    assert.equal(player.toString(), "Name: " + playerName + " Score: " + score, 'Player basic toString() method');
});


