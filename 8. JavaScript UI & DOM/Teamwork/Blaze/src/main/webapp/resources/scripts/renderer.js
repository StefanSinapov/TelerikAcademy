/*
 *   Initializes a new instance of the Renderer class.
 */
function Renderer(width, height) {
    this.width = width;
    this.height = height;

    var fragment = document.createDocumentFragment();
    this.svg = this.createBackgroundSVG();

    if (Common.getRandomInt(0, 1)) {
        this.drawDayBackground();
    } else {
        this.drawNightBackground();
    }

    var canvas = this.creteCanvas();

    fragment.appendChild(this.svg);
    fragment.appendChild(canvas);
    document.body.appendChild(fragment);

    this.ctx = canvas.getContext('2d');
}

/*
 *   Draws all objects.
 */
Renderer.prototype.drawAll = function (blaze, eggman, sonic) {
    this.ctx.clearRect(0, 0, this.width, this.height);
    this.drawClip(blaze);
    this.drawScore(blaze);
    this.drawMissed(blaze);

    if (eggman.isOnScreen) {
        this.drawEggman(eggman);
    }

    if (eggman.isHit && !sonic.isDrawed) {
        this.drawSonic(sonic);
    }

    this.drawBlaze(blaze);
};

/*
 *   Draws the missed count.
 */
Renderer.prototype.drawMissed = function (blaze) {
    var scoreText = "Missed: " + blaze.missedCount;
    this.ctx.font = '30px ' + Renderer.CONFIG.get('FONTS');
    this.ctx.fillStyle = '#dcdcdc';
    this.ctx.fillText(scoreText, 10, 60);
};

/*
 *   Constants for the game object.
 */
Renderer.CONFIG = function () {
    var constants = {
        FONTS: 'Comic Sans MS, Arial, Sans',
        BLAZE_LINE_LENGTH: 60,
        BLAZE_INNER_RADIUS: 10,
        BLAZE_OUTER_RADIUS: 20,
        BLAZE_COLOR: 'white',
        SVG_NS: 'http://www.w3.org/2000/svg',
        BULLET_WIDTH: 20,
        BULLET_HEIGHT: 30,
        BULLET_SPACING: 5,
        BACKGROUND_COLOR: '#181e4b',
        BACKGROUND_STARS_COUNT: 50,
        BACKGROUND_PLANETS_COUNT: 5,
        GAME_NAME: 'Blaze Laser Light'
    };

    return {
        get: function (name) {
            return constants[name];
        }
    };
}();

/*
 *   Draws Blaze.
 */
Renderer.prototype.drawBlaze = function (blaze) {

    var LINE_LENGTH = Renderer.CONFIG.get('BLAZE_LINE_LENGTH');
    var INNER_RADIUS = Renderer.CONFIG.get('BLAZE_INNER_RADIUS');
    var OUTER_RADIUS = Renderer.CONFIG.get('BLAZE_OUTER_RADIUS');

    var centerX = blaze.position.x;
    var centerY = blaze.position.y;

    var point1X = centerX + LINE_LENGTH / 2;
    var point1Y = centerY;

    var point2X = centerX - LINE_LENGTH / 2;
    var point2Y = centerY;

    var point3X = centerX;
    var point3Y = centerY + LINE_LENGTH / 2;

    var point4X = centerX;
    var point4Y = centerY - LINE_LENGTH / 2;

    this.ctx.beginPath();
    this.ctx.moveTo(point1X, point1Y);
    this.ctx.lineTo(point2X, point2Y);
    this.ctx.moveTo(point3X, point3Y);
    this.ctx.lineTo(point4X, point4Y);
    this.ctx.moveTo(centerX, centerY);
    this.ctx.arc(centerX, centerY, INNER_RADIUS, 0, 2 * Math.PI, false);
    this.ctx.moveTo(centerX, centerY);
    this.ctx.arc(centerX, centerY, OUTER_RADIUS, 0, 2 * Math.PI, false);
    this.ctx.strokeStyle = Renderer.CONFIG.get('BLAZE_COLOR');
    this.ctx.stroke();
};

/*
 *   Draws the clip (available bullets).
 */
Renderer.prototype.drawClip = function (blaze) {
    var sx = 20;
    var sy = this.height - Renderer.CONFIG.get('BULLET_HEIGHT') - sx;
    var bulletsCount = blaze.bullets;
    var image = new Image();
    image.src = 'resources/imgs/bullet.png';

    for (var i = 0; i < bulletsCount; i += 1) {
        this.ctx.drawImage(image, sx, sy);
        sx += Renderer.CONFIG.get('BULLET_WIDTH') + Renderer.CONFIG.get('BULLET_SPACING');
    }
};

/*
 *   Draws Eggman.
 */
Renderer.prototype.drawEggman = function (eggman) {
    var x = eggman.position.x;
    var y = eggman.position.y;

    /*Some objects that have to stay in the back*/

    this.ctx.beginPath();
    this.ctx.arc((x + 40), (y + 22), 8, 0, 2 * Math.PI);
    this.ctx.arc((x + 12), (y + 22), 8, 0, 2 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "gray";
    this.ctx.fill();

    this.ctx.beginPath();
    this.ctx.strokeStyle = "black";
    this.ctx.strokeRect((x + 45), (y + 31), 12, 7);
    this.ctx.fillStyle = "lightgray";
    this.ctx.fillRect((x + 45), (y + 31), 12, 7);

    this.ctx.beginPath();
    this.ctx.moveTo((x + 47), (y + 31));
    this.ctx.arc((x + 47), (y + 31), 10, 1.5 * Math.PI, 2 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "yellow";
    this.ctx.fill();

    this.ctx.beginPath();
    this.ctx.strokeStyle = "black";
    this.ctx.strokeRect((x + 54), (y + 31), 3, 7);
    this.ctx.fillStyle = "darkgray";
    this.ctx.fillRect((x + 54), (y + 31), 3, 7);


    /*Draw Robotnik's body*/
    this.ctx.beginPath();
    this.ctx.fillStyle = "red";
    this.ctx.fillRect((x + 13), (y + 14), 25, 18);
    this.ctx.strokeStyle = "black";
    this.ctx.strokeRect((x + 13), (y + 14), 25, 18);
    this.ctx.beginPath();
    this.ctx.fillStyle = "yellow";
    this.ctx.fillRect((x + 20), (y + 14), 10, 18);
    this.ctx.strokeRect((x + 20), (y + 14), 10, 18);

    /*Draw Robotnik's head*/
    this.ctx.beginPath();
    this.ctx.moveTo((x + 30), (y + 8));
    this.ctx.arc((x + 25), (y + 8), 6, 0, 2 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "lightpink";
    this.ctx.fill();

    /*Draw Robotnik's eyes*/
    this.ctx.beginPath();
    this.ctx.arc((x + 22), (y + 8), 1.5, 0, 2 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "lightblue";
    this.ctx.fill();
    this.ctx.beginPath();
    this.ctx.arc((x + 25), (y + 8), 1.5, 0, 2 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "lightblue";
    this.ctx.fill();

    /*Draw Robotnik'snose and mustaches*/
    this.ctx.beginPath();
    this.ctx.moveTo((x + 23), (y + 12));
    this.ctx.lineTo((x + 13), (y + 8));
    this.ctx.lineTo((x + 15), (y + 10));
    this.ctx.lineTo((x + 13), (y + 12));
    this.ctx.lineTo((x + 17), (y + 12));
    this.ctx.lineTo((x + 13), (y + 14));
    this.ctx.lineTo((x + 23), (y + 12));
    this.ctx.stroke();
    this.ctx.fillStyle = "brown";
    this.ctx.fill();
    this.ctx.beginPath();
    this.ctx.arc((x + 23), (y + 11), 2, 0, 2 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "salmon";
    this.ctx.fill();
    this.ctx.beginPath();
    this.ctx.moveTo((x + 23), (y + 12));
    this.ctx.lineTo((x + 36), (y + 8));
    this.ctx.lineTo((x + 38), (y + 10));
    this.ctx.lineTo((x + 35), (y + 12));
    this.ctx.lineTo((x + 39), (y + 12));
    this.ctx.lineTo((x + 35), (y + 14));
    this.ctx.lineTo((x + 23), (y + 12));
    this.ctx.stroke();
    this.ctx.fillStyle = "brown";
    this.ctx.fill();

    /*Draw Eggmobile*/
    this.ctx.beginPath();
    this.ctx.arc((x + 25), (y + 28), 23, 1.9 * Math.PI, 1.1 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "lightgray";
    this.ctx.fill();
    this.ctx.beginPath();
    this.ctx.arc((x + 25), (y + 28), 23, 0.25 * Math.PI, 0.75 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "black";
    this.ctx.fill();
    this.ctx.beginPath();
    this.ctx.moveTo((x + 10), (y + 45));
    this.ctx.arc((x + 10), (y + 45), 12, 1.3 * Math.PI, 2 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "black";
    this.ctx.fill();
    this.ctx.beginPath();
    this.ctx.moveTo((x + 25), (y + 22));
    this.ctx.arc((x + 25), (y + 22), 23, Math.PI, 1.3 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "rgba(122, 251, 227, 0.44)";
    this.ctx.fill();
    this.ctx.beginPath();
    this.ctx.arc((x + 10), (y + 35), 5, 0, 2 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "yellow";
    this.ctx.fill();
    this.ctx.beginPath();
    this.ctx.strokeRect((x + 24), (y + 38), 4, 6);
    this.ctx.fillStyle = "gold";
    this.ctx.fillRect((x + 24), (y + 38), 4, 6);
    this.ctx.beginPath();
    this.ctx.fillStyle = "black";
    this.ctx.fillRect((x + 38), (y + 36), 1.5, 4);
    this.ctx.fillStyle = "gold";
    this.ctx.fillRect((x + 40), (y + 36), 1.5, 4);
    this.ctx.fillStyle = "black";
    this.ctx.fillRect((x + 42), (y + 36), 1.5, 4);
    this.ctx.fillStyle = "gold";
    this.ctx.fillRect((x + 44), (y + 36), 1, 4);
    this.ctx.beginPath();
    this.ctx.arc((x + 35), (y + 31), 5, 0, 2 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "white";
    this.ctx.fill();
    this.ctx.beginPath();
    this.ctx.arc((x + 35), (y + 31), 2, 0, 2 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "black";
    this.ctx.fill();
    this.ctx.beginPath();
    this.ctx.arc((x + 35), (y + 19), 17, 0.23 * Math.PI, 0.76 * Math.PI);
    this.ctx.stroke();
    this.ctx.fillStyle = "silver";
    this.ctx.fill();
};

/*
 *   Draws Sonic.
 */
Renderer.prototype.drawSonic = function (sonic) {
    var x = sonic.position.x;
    var y = sonic.position.y;

    var stage = new Kinetic.Stage({
        container: 'drawing',
        width: this.width,
        height: this.height
    });

    var layer = new Kinetic.Layer();

    var sonicImage = new Image();
    sonicImage.src = Sonic.CONFIG.get('SONIC_SPRITE');

    sonicImage.onload = function () {
        var sonicSprite = new Kinetic.Sprite({
            x: x,  //TODO: startPosition,
            y: y, //TODO: wrapper.height - 160,
            image: sonicImage,
            animation: Sonic.CONFIG.get('SONIC_ANIMATION_INIT'),
            animations: Sonic.CONFIG.get('SONIC_ANIMATIONS'),
            frameRate: this.frameRate,
            frameIndex: 0,
            scale: {
                x: 0.4,
                y: 0.4
            }
        });

        layer.add(sonicSprite);
        stage.add(layer);

        sonicSprite.start();
    };

    sonic.isDrawed = true;
};

/*
 *   Creates the background.
 */
Renderer.prototype.createBackgroundSVG = function () {
    // Creates the svg element
    var svg = document.createElementNS(Renderer.CONFIG.get('SVG_NS'), 'svg');
    svg.setAttribute('id', 'container');
    svg.setAttribute('height', this.height.toString());
    svg.setAttribute('width', this.width.toString());
    svg.style.position = 'fixed';
    svg.style.top = '31px';
    svg.style.left = '31px';
    return svg;
};

Renderer.prototype.drawNightBackground = function () {
    // Sets the background color.
    this.drawClipBackground();

    var rectAmmo = document.createElementNS(Renderer.CONFIG.get('SVG_NS'), 'rect');
    rectAmmo.setAttribute('x', '15');
    rectAmmo.setAttribute('y', (this.height - 55).toString());
    rectAmmo.setAttribute('width', (20 * 3 + 10 * 2 + 10).toString());
    rectAmmo.setAttribute('height', '40');
    rectAmmo.setAttribute('fill', '#dcdcdc');

    this.svg.appendChild(rectAmmo);

    // Creates the stars
    var starsCount = Renderer.CONFIG.get('BACKGROUND_STARS_COUNT');

    for (var i = 0; i < starsCount; i++) {
        this.svg.appendChild(this.createRandomStar());
    }

    // Creates the planets
    var planetsCount = Renderer.CONFIG.get('BACKGROUND_PLANETS_COUNT');

    for (i = 0; i < planetsCount; i++) {
        this.svg.appendChild(this.createRandomPlanet());
    }

    for (i = 0; i < 5; i++) {
        this.svg.appendChild(this.createRandomCloud());
    }
};

/*
 *   Draws the clip background rectangle.
 */
Renderer.prototype.drawClipBackground = function () {
    var rect = document.createElementNS(Renderer.CONFIG.get('SVG_NS'), 'rect');
    rect.setAttribute('x', '0');
    rect.setAttribute('y', '0');
    rect.setAttribute('width', this.width.toString());
    rect.setAttribute('height', this.height.toString());
    rect.setAttribute('fill', Renderer.CONFIG.get('BACKGROUND_COLOR').toString());
    this.svg.appendChild(rect);
};

Renderer.prototype.creteCanvas = function () {
    var canvas = document.createElement('canvas');
    canvas.setAttribute('id', 'drawing');
    canvas.setAttribute('width', this.width.toString());
    canvas.setAttribute('height', this.height.toString());
    canvas.style.position = 'fixed';
    canvas.style.left = '30px';
    canvas.style.top = '30px';
    return canvas;
};

/*
 *   Creates a random star.
 */
Renderer.prototype.createRandomStar = function () {
    var polygon = document.createElementNS(Renderer.CONFIG.get('SVG_NS'), 'polygon');

    var x = Common.getRandomInt(50, this.width - 50);
    var y = Common.getRandomInt(50, this.height - 50);

    var point1X = x + 2.9389;
    var point1Y = y + 9.0451;

    var point2X = x + 4.7553;
    var point2Y = y + 3.4549;

    var point3X = x - 4.7553;
    var point3Y = y + 3.4549;

    var point4X = x - 2.9389;
    var point4Y = y + 9.0451;

    var pointsText = x + ',' + y + ' ' + point1X + ',' + point1Y + ' ' + point3X + ',' + point3Y + ' ' + point2X + ',' + point2Y + ' ' + point4X + ',' + point4Y;
    polygon.setAttribute('points', pointsText);
    polygon.setAttribute('style', 'fill:#dcdcdc');

    var angle = Common.getRandomInt(0, 360);
    var rotateText = 'rotate(' + angle + ' ' + x + ' ' + y + ')';
    polygon.setAttribute('transform', rotateText.toString());

    return polygon;
};

/*
 *   Creates a random planet.
 */
Renderer.prototype.createRandomPlanet = function () {
    var circle = document.createElementNS(Renderer.CONFIG.get('SVG_NS'), 'circle');
    var cx = Common.getRandomInt(100, this.width - 100);
    var cy = Common.getRandomInt(100, this.height - 100);
    var radius = 10;
    circle.setAttribute('cx', cx.toString());
    circle.setAttribute('cy', cy.toString());
    circle.setAttribute('r', radius.toString());
    circle.setAttribute('fill', '#dd5f22');
    return circle;
};

/*
 *   Draws the score.
 */
Renderer.prototype.drawScore = function (blaze) {
    var scoreText = "Score: " + blaze.score;
    this.ctx.font = '30px ' + Renderer.CONFIG.get('FONTS');
    this.ctx.fillStyle = '#dcdcdc';
    this.ctx.fillText(scoreText, 10, 30);
};

/*
 *   Draws the Intro screen.
 */
Renderer.prototype.drawIntro = function (highScores) {

    var self = this;
    var grd = this.ctx.createLinearGradient(0, 0, 600, 0);
    grd.addColorStop(0, "#f210e6");
    grd.addColorStop(1, "#f41118");
    this.ctx.fillStyle = grd;
    this.ctx.fillRect(0, 0, this.width, this.height);
    this.ctx.fillStyle = 'black';
    this.ctx.font = "90px " + Renderer.CONFIG.get('FONTS');
    this.ctx.fillText(Renderer.CONFIG.get('GAME_NAME'), 50, 100);

    //draw eggman
    var eggmanImage = new Image();
    eggmanImage.src = 'resources/imgs/eggman.png';
    eggmanImage.onload = function () {
        self.ctx.drawImage(eggmanImage, 500, 250, 250, 300);
    };

    //draw blaze
    var blazeImage = new Image();
    blazeImage.src = 'resources/imgs/blaze.png';
    blazeImage.onload = function () {
        self.ctx.drawImage(blazeImage, 100, 250, 150, 300);
    };

    var x = this.width / 2 - 110;
    var y = 200;
    var text = "", player, i;

    this.ctx.font = "25px " + Renderer.CONFIG.get('FONTS');
    for (i = 0; i < highScores.length; i++) {
        player = highScores[i];
        text = player.id + ". " + player.name + " " + player.score;
        this.ctx.fillText(text, x, y);
        y += 30;
    }
};

/*
 *   Draws the Exit screen
 */
Renderer.prototype.drawExit = function (controller) {

    this.ctx.canvas.style.cursor = 'pointer';
    var self = this;
    var grd1 = this.ctx.createLinearGradient(0, 0, 750, 0);
    grd1.addColorStop(0, "#ffb7f6");
    grd1.addColorStop(0.5, "#f210e6");
    grd1.addColorStop(1.0, "#ffb7f6");
    this.ctx.fillStyle = grd1;
    this.ctx.fillRect(0, 0, this.width, this.height);
    this.ctx.fillStyle = 'black';
    this.ctx.font = '70px ' + Renderer.CONFIG.get('FONTS');

    var textThanks = "Thank you for playing!";
    var textTanksXPosition = this.findXForCenteredText(textThanks);
    this.ctx.fillText(textThanks, textTanksXPosition, 100);

    //draw eggman
    var eggmanImage = new Image();
    eggmanImage.src = 'resources/imgs/eggman.png';
    eggmanImage.onload = function () {
        self.ctx.drawImage(eggmanImage, 500, 250, 250, 300);
    };

    //draw blaze
    var blazeImage = new Image();
    blazeImage.src = 'resources/imgs/blaze.png';
    blazeImage.onload = function () {
        self.ctx.drawImage(blazeImage, 100, 250, 150, 300);
    };

    this.ctx.fillStyle = 'yellow';
    this.ctx.font = "40px " + Renderer.CONFIG.get('FONTS');
    var textCredits = "Credits";
    var x = parseInt(this.findXForCenteredText(textCredits));
    var y = 200;
    var length = parseInt(this.ctx.measureText(textCredits).width + x);
    var height = 200 - 40;
    this.ctx.fillText(textCredits, x, y);

    setInterval(function () {

        if (controller.mouseClick !== null) {

            if (x < controller.mouseClick.x && controller.mouseClick.x < length &&
                height < controller.mouseClick.y && controller.mouseClick.y < y) {
                self.drawCredits();
            }
        }

    }, 300);
};

Renderer.prototype.findXForCenteredText = function (text) {
    var measurement = this.ctx.measureText(text);
    return (this.width - measurement.width) / 2;
};

Renderer.prototype.drawCredits = function () {
    var credits = ['Pavel Hristov', 'Jivka Stoeva', 'Illiyan Yordanov', 'Ventsy Konov', 'Stefan Sinapov', 'Miroslav Gatsanoga'];
    var grd1 = this.ctx.createLinearGradient(0, 0, 750, 0);
    grd1.addColorStop(0, "#ffb7f6");
    grd1.addColorStop(0.5, "#f210e6");
    grd1.addColorStop(1.0, "#ffb7f6");
    this.ctx.fillStyle = grd1;
    this.ctx.fillRect(0, 0, this.width, this.height);
    var credit, x, y = 120;
    this.ctx.fillStyle = 'black';
    this.ctx.font = '50px ' + Renderer.CONFIG.get('FONTS');

    for (var i = 0; i < credits.length; i++) {
        credit = credits[i];
        x = this.findXForCenteredText(credit);
        this.ctx.fillText(credit, x, y);
        y += 80;
    }
};

Renderer.prototype.drawDayBackground = function () {

    var x = 0,
        y = 0;
    var paper = Raphael(this.svg, 900, 700);

    /*Draw background - sky*/

    paper.rect(x, y, 800, 600)
        .attr({
            fill: 'lightblue',
            'stroke-width': 0
        });

    /*Draw sun ;)*/

    paper.ellipse((x + 645), (y + 60), 6, 60)
        .attr({
            transform: "r15",
            fill: "110-orange-yellow",
            opacity: 0.2,
            'stroke-width': 0
        });
    paper.ellipse((x + 645), (y + 60), 6, 50)
        .attr({
            transform: "r35",
            fill: "110-orange-yellow",
            opacity: 0.3,
            'stroke-width': 0
        });
    paper.ellipse((x + 645), (y + 60), 6, 60)
        .attr({
            transform: "r55",
            fill: "110-orange-yellow",
            opacity: 0.2,
            'stroke-width': 0
        });
    paper.ellipse((x + 645), (y + 60), 6, 50)
        .attr({
            transform: "r75",
            fill: "110-orange-yellow",
            opacity: 0.3,
            'stroke-width': 0
        });

    paper.ellipse((x + 645), (y + 60), 6, 60)
        .attr({
            transform: "r95",
            fill: "110-orange-yellow",
            opacity: 0.2,
            'stroke-width': 0
        });
    paper.ellipse((x + 645), (y + 60), 6, 50)
        .attr({
            transform: "r115",
            fill: "110-orange-yellow",
            opacity: 0.3,
            'stroke-width': 0
        });

    paper.ellipse((x + 645), (y + 60), 6, 60)
        .attr({
            transform: "r135",
            fill: "100-orange-yellow",
            opacity: 0.2,
            'stroke-width': 0
        });

    paper.ellipse((x + 645), (y + 60), 6, 50)
        .attr({
            transform: "r155",
            fill: "80-orange-yellow",
            opacity: 0.3,
            'stroke-width': 0
        });

    paper.ellipse((x + 645), (y + 60), 6, 60)
        .attr({
            transform: "r175",
            fill: "70-orange-yellow",
            opacity: 0.2,
            'stroke-width': 0
        });


    paper.circle((x + 645), (y + 60), 18)
        .attr({
            fill: "90-yellow-orange-yellow",
            opacity: 0.9,
            "stroke-width": 0

        });


    /* Draw sand.*/

    paper.rect(x, (y + 400), 800, 200)
        .attr({
            fill: '100-darkgoldenrod-gold',
            opacity: 0.8,
            'stroke-width': 0
        });

    /* Draw sea. */
    paper.rect(x, (y + 350), 800, 50)
        .attr({
            fill: '100-blue:5-darkblue:50-#010746:80',
            opacity: 1,
            'stroke-width': 3,
            stroke: '40-blue-darkblue',
            'stroke-linecap': 'round'
        });

    /*
     *   Draw waves.
     */
    paper.path("M" + (x + 0) + "," + (y + 400)
        + "C" + (x + 50) + "," + (y + 450) + "," + (x + 150) + "," + (y + 400) + "," + (x + 170) + "," + (y + 400)
        + "C" + (x + 170) + "," + (y + 400) + "," + (x + 380) + "," + (y + 470) + "," + (x + 450) + "," + (y + 400)
        + "C" + (x + 450) + "," + (y + 400) + "," + (x + 570) + "," + (y + 440) + "," + (x + 650) + "," + (y + 400)
        + "C" + (x + 650) + "," + (y + 400) + "," + (x + 700) + "," + (y + 450) + "," + (x + 800) + "," + (y + 400)
        + "Z")
        .attr({
            fill: '90-white:25-blue',
            opacity: 0.9,
            stroke: '90-#000f48-#ffffff',
            'stroke-width': 5,
            'stroke-linecap': 'round',
            'stroke-linejoin': 'round'
        });

    /*Draw cloud.*/

    paper.path("M" + (x + 700) + "," + (y + 50)
        + "C" + (x + 720) + "," + (y + 70) + "," + (x + 710) + "," + (y + 100) + "," + (x + 690) + "," + (y + 90)
        + "C" + (x + 680) + "," + (y + 110) + "," + (x + 660) + "," + (y + 95) + "," + (x + 650) + "," + (y + 90)
        + "C" + (x + 630) + "," + (y + 100) + "," + (x + 620) + "," + (y + 90) + "," + (x + 650) + "," + (y + 70)
        + "C" + (x + 620) + "," + (y + 60) + "," + (x + 655) + "," + (y + 50) + "," + (x + 660) + "," + (y + 45)
        + "C" + (x + 675) + "," + (y + 35) + "," + (x + 680) + "," + (y + 45) + "," + (x + 690) + "," + (y + 40)
        + "Z")
        .attr({
            fill: '270-white-azure',
            opacity: 0.2,
            stroke: '100-gray-white-blue',
            'stroke-width': 5,
            'stroke-linecap': 'round',
            'stroke-linejoin': 'round'

        });


    /* Draw back mountains */

    paper.path("M" + (x + 0) + "," + (y + 350)
        + "L" + (x + 0) + "," + (y + 150)
        + "C" + (x + 50) + "," + (y + 100) + "," + (x + 100) + "," + (y + 150) + "," + (x + 350) + "," + (y + 350)
        + "M" + (x + 200) + "," + (y + 350)
        + "C" + (x + 320) + "," + (y + 150) + "," + (x + 350) + "," + (y + 280) + "," + (x + 480) + "," + (y + 350)
        + "M" + (x + 200) + "," + (y + 350)
        + "C" + (x + 550) + "," + (y + 210) + "," + (x + 630) + "," + (y + 200) + "," + (x + 730) + "," + (y + 320)
        + "M" + (x + 500) + "," + (y + 350)
        + "C" + (x + 630) + "," + (y + 320) + "," + (x + 800) + "," + (y + 20) + "," + (x + 800) + "," + (y + 150)
        + "L" + (x + 800) + "," + (y + 150)
        + "L" + (x + 800) + "," + (y + 350)
        + "Z")
        //paper.path("M"+(x -10) 350 C 130 100 260 340 300 320 C 300 320 350 280 400 310 C 400 310 530 280 630 320 C 630 320 900 20 800 350 Z ')
        .attr({
            fill: "90-midnightblue-white:90-navy",
            opacity: 0.01

        });

    /* Draw front mountains */

    paper.path("M" + (x + 0) + "," + (y + 350)
        + "L" + (x + 0) + "," + (y + 300)
        + "C" + (x + 50) + "," + (y + 200) + "," + (x + 260) + "," + (y + 340) + "," + (x + 300) + "," + (y + 320)
        + "C" + (x + 300) + "," + (y + 320) + "," + (x + 350) + "," + (y + 280) + "," + (x + 400) + "," + (y + 310)
        + "C" + (x + 400) + "," + (y + 310) + "," + (x + 530) + "," + (y + 280) + "," + (x + 630) + "," + (y + 320)
        + "C" + (x + 630) + "," + (y + 320) + "," + (x + 800) + "," + (y + 200) + "," + (x + 800) + "," + (y + 350)
        + "L" + (x + 800) + "," + (y + 350)
        + "Z")
        .attr({
            fill: "100-#002c06-green:30-lightgreen:100",
            opacity: 0.2,
            stroke: "100-#002c06-green:30-lightgreen:100",
            'stroke-width': 5,
            'stroke-linecap': 'round',
            'stroke-linejoin': 'round'
        });
    /*Draw some rocks*/

    paper.ellipse((x + 70), (y + 480), 50, 20)
        .attr({
            fill: "100-black-darkgray",
            opacity: 0.6,
            stroke: "100-black-darkgray",
            'stroke-width': 5
        });

    /*draw flower*/
    paper.ellipse((x + 70), (y + 450), 1, 40)
        .attr({
            fill: "green",
            stroke: "darkgreen",
            'stroke-width': 1
        });

    paper.ellipse((x + 70), (y + 420), 7, 15)
        .attr({
            fill: "hotpink",
            stroke: "white",
            'stroke-width': 3
        });

    paper.ellipse((x + 63), (y + 420), 2, 18)
        .attr({
            transform: 'r160',
            fill: "pink",
            stroke: "purple",
            'stroke-width': 2
        });
    paper.ellipse((x + 77), (y + 420), 2, 18)
        .attr({
            transform: 'r200',
            fill: "pink",
            stroke: "purple",
            'stroke-width': 2
        });
    paper.ellipse((x + 58), (y + 450), 3, 40)
        .attr({
            transform: 'r160',
            fill: "green",
            stroke: "darkgreen",
            'stroke-width': 1
        });

    paper.ellipse((x + 82), (y + 457), 3, 32)
        .attr({
            transform: 'r200',
            fill: "green",
            stroke: "darkgreen",
            'stroke-width': 1
        });

    /*draw more rocks*/

    paper.ellipse((x + 75), (y + 490), 30, 15)
        .attr({
            fill: "100-black-darkgray",
            opacity: 0.6,
            stroke: "100-black-darkgray",
            'stroke-width': 5
        });
    paper.ellipse((x + 55), (y + 495), 20, 10)
        .attr({
            fill: "100-black-darkgray",
            opacity: 0.6,
            stroke: "100-black-darkgray",
            'stroke-width': 5
        });

    /*Insert palm tree*/
    paper.image("resources/imgs/PalmTree.png", (x + 530), (y + 190), 250, 250);
    // paper.path("M" + (x + 50) + "," + (y + 50) + " L" + (x + 100) + "," + (y + 100));
};

/*
 *   Creates a random cloud;
 */
Renderer.prototype.createRandomCloud = function () {

    var cloud = document.createElementNS(Renderer.CONFIG.get('SVG_NS'), 'path');
    var x = Common.getRandomInt(100, this.width - 200);
    var y = Common.getRandomInt(100, this.height - 200);

    var points = "M" + (x ) + "," + (y) + "C" + (x + 20) + "," + (y + 30) + "," + (x + 10) + "," + (y + 50) + "," + (x - 10 ) + "," + (y + 40)
        + "C" + (x - 20) + "," + (y + 35) + "," + (x - 40) + "," + (y + 45) + "," + (x - 50) + "," + (y + 40)
        + "C" + (x - 70) + "," + (y + 50) + "," + (x - 80) + "," + (y + 40) + "," + (x - 50) + "," + (y + 20)
        + "C" + (x - 60) + "," + (y + 10) + "," + (x - 45) + "," + (y) + "," + (x - 40) + "," + (y - 5)
        + "C" + (x - 10) + "," + (y - 15) + "," + (x - 20) + "," + (y - 5) + "," + (x - 10) + "," + (y - 10)
        + "Z";

    cloud.setAttribute('d', points);
    var style = "fill: white;opacity: 0.8;stroke:black;stroke-width:1;";
    cloud.setAttribute('style', style);
    return cloud;
};




