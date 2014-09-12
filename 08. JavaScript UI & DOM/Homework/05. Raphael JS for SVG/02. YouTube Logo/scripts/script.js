/**
 * Created by Stefan on 11.6.2014 г..
 */

window.onload = function (){
    var paper = Raphael(0, 0, 600, 300);
    drawBorder(paper);
    drawYouTubeLogo(paper);
};

function drawBorder(paper){
    paper.rect(3, 3, 500, 210, 1).attr({
        fill: 'none',
        stroke: '#DAEDF2',
        "stroke-width": 4
    });
}

function drawYouTubeLogo(paper){

    paper.rect(210, 18, 270, 180, 40).attr({
        fill: '#EC2828',
        stroke: 'none'
    });

    paper.setStart();
    paper.text(100, 110, 'You').attr({
        fill: 'black'
    });
    paper.text(350, 110, 'Tube').attr({
        fill: 'white'
    });
    paper.setFinish().attr({
        'font-size': '93px',
        'font-weight': 'bold',
        'letter-spacing': '-3px',
        'font-family': 'Arial'
    }).scale(1.15,1.8);
}