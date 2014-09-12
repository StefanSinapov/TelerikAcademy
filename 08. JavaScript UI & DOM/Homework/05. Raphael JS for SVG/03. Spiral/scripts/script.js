/**
 * Created by Stefan on 11.6.2014 г..
 */

function drawBorder(paper) {
    'use strict';
    paper.rect(3, 3, 500, 490, 15).attr({
        fill: 'none',
        stroke: '#DAEDF2',
        "stroke-width": 4
    });
}

function drawCircle(paper, cx, cy) {
    'use strict';
    paper.circle(cx, cy, 1)
        .attr({
            stroke: 'black',
            fill: 'black'
        });
}

function drawSpiral(paper) {
    'use strict';
    var space = 8,
        scale = 10,
        centerX = 250,
        centerY = 250,
        STEPS_PER_ROTATION = space * 100,
        increment = 2 * Math.PI / STEPS_PER_ROTATION,
        angle = increment,
        newX,
        newY;
    while (angle < scale * Math.PI) {
        newX = centerX + (space * angle) * Math.cos(angle);
        newY = centerY - (space * angle) * Math.sin(angle);
        drawCircle(paper, newX, newY);
        angle += increment;
    }
}

window.onload = function () {
    'use strict';
    var paper = Raphael(0, 0, 600, 600);
    drawBorder(paper);
    drawSpiral(paper);
};

