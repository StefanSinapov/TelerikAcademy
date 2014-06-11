/**
 * Created by Stefan on 11.6.2014 г..
 */

window.onload = function (){
    var paper = Raphael(0, 0, 600, 300);
   drawTelerikLogo(paper);
};

function drawTelerikLogo(paper){
    var rect = paper.rect(3, 2, 585, 210);
    rect.attr({
        fill: 'none',
        stroke: '#E0FFA3',
        'stroke-width' : 4
    });

    var logo = paper.path('M40 70 L60 50 L115 100 L90 125 L65 100 L115 50 L 135 70');
    logo.attr({
        stroke: '#5CE600',
        'stroke-width': 14
    });

    paper.setStart();
    paper.text(320, 100, "Telerik").attr({
        'font-size': '108px',
        'letter-spacing': '-5px'
    });
    paper.text(500, 90, "®").attr({
        'font-size': '28px'
    });
    var set = paper.setFinish();
    set.attr({
        'font-family': 'Segoe UI, Arial',
        fill: '#282828',
        'font-weight': 'bold'
    });

    paper.text(365, 165, "Develop experiences").attr({
        fill: "282828",
        'font-size': '43px',
        'font-family': 'Segoe UI Light, Arial'
    });
}