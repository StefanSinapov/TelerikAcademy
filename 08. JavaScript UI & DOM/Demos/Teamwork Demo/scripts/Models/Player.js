define(function(require) {

    var GlobalConsts = require('./GlobalConsts.js');

    var _maxBulletsCount = 0,
    	_currentBulletsCount = 0,
    	_reloadingTime = 0;
    	//_cursor = null,


    //Constructor
    //function Player(bulletsCount)
    function Player()
    {
    	if(GlobalConsts.PLAYER_BULLETS_COUNT <= 0) {
    		throw "Initial bullets count cannot be zero or negative"
    	}
    	_maxBulletsCount = GlobalConsts.PLAYER_BULLETS_COUNT;
    	_currentBulletsCount = _maxBulletsCount;
    	//_cursor = initializeCursor();
    }

    //initlizeCursor

    Player.prototype.getCursor = function () {
    	return _cursor;
    }
    //prototype.shoot

    Player.prototype.shoot = function () {
    	_currentBulletsCount--;
    	if(_currentBulletsCount === 0)
    	{
    		this.reload();
    	}

    	//here to check if hit something?
    }

    Player.prototype.reload = function () {
    	//here to set timeout?
    	_currentBulletsCount = _maxBulletsCount;
    }

    //prototype.kill?
    //prototype.reload
    //prototype.getBullets
});


//FOR renderer.js
// Draws Bullets // TODO: add global consts and change here.
// function drawClip(context, blaze) {
//     var BULLET_WIDHT = 20,
//         BULLET_HEIGHT = 30,
//         SPACING = 5,
//         sx = 20,
//         sy = context.canvas.height - BULLET_HEIGHT - 10,
//         bulletsCount = blaze.getBulletsCount();
    
//     context.beginPath();
//     for (var i = 0; i < bulletsCount; i+=1) {
//         context.moveTo(sx, sy);
//         context.strokeRect(sx, sy, BULLET_WIDHT, BULLET_HEIGHT);
//         sx = sx + BULLET_WIDHT + SPACING;
//     };
//     context.stroke();
//}


// FOR blaze.js

