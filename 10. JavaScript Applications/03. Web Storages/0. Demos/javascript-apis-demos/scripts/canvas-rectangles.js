(function() {
    var ctx = document.getElementsByTagName("canvas")[0].getContext("2d");
    var leftTb = document.getElementById("tb-left");
    var topTb = document.getElementById("tb-top");
    var widthTb = document.getElementById("tb-width");
    var heightTb = document.getElementById("tb-height");
    var colorTb = document.getElementById("tb-color");
    
    document.getElementById("btn-fill").onclick = function(){
        onDrawBtnClick("fill");        
    }

    document.getElementById("btn-stroke").onclick = function(){
        onDrawBtnClick("stroke");        
    }

    var handlers = {
        fill: function(left, top, width, height, color) {
            ctx.fillStyle = color;
            ctx.fillRect(left, top, width, height);
        },
        stroke: function(left, top, width, height, color) {
            ctx.strokeStyle = color;
            ctx.strokeRect(left, top, width, height);
        }
    };

    function onDrawBtnClick(type) {
        var width = widthTb.value | 0;
        var height = heightTb.value | 0;
        var color = colorTb.value;
        if (!width || !height || !color) {
            return;
        }

        var left = (leftTb.value | 0) || 0;
        var top = (topTb.value | 0) || 0;
        if (handlers[type] && typeof handlers[type] === 'function') {
            handlers[type](left, top, width, height, color);
        }
    }
}());
