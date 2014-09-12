define(['Utility', 'GlobalConsts', 'GameBlock'], function(utility, GlobalConsts, GameBlock) {

   'use strict';
    var Food = (function(){
        // Constructor
        function Food(posX, posY) {
            GameBlock.apply(this, arguments);
            this.blockSize = GlobalConsts.FOOD_SIZE;
        }

        Food.inherit(GameBlock);

        return Food;
    })();

    return Food;
});