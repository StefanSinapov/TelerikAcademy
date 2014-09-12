taskName = "1. Working with Shapes";

function Main(bufferElement) {
	var firstPoint = ReadLine("Point A(x, y): ", "1  2"),
		secondPoint = ReadLine("Point B(x, y): ", "3 -5");
    SetSolveButton(function () {

    	//Two points
    	var coordsFirstPoint = ParseFloatCollection(firstPoint.value),
    		coordsSecondPoint = ParseFloatCollection(secondPoint.value);

    	var pointA = buildPoint(coordsFirstPoint[0], coordsFirstPoint[1]),
   			pointB = buildPoint(coordsSecondPoint[0], coordsSecondPoint[1]);

   		//Line between them
   		var line = Line(pointA, pointB);
   		line.distance();
   		WriteLine(Format("Distance between {0} and {1} is: {2}", pointA.toString(), pointB.toString(), line.distance()));
    	WriteLine("Line they make is: " + line.toString());

    	//Check if 3 lines can form triangle
    	var pointC = buildPoint(2, 4);
    	var ifCanFormTriangle = canFormTriangle(Line(pointA, pointB), Line(pointA, pointC), Line(pointB, pointC));
    	WriteLine(Format("Points {0}, {1}, {2} can form triangle: ", pointA.toString(), pointB.toString(), pointC.toString()) + ifCanFormTriangle);
    });
}
function buildPoint(initX, initY)
	{
		return {
			X : initX,
			Y : initY,
			toString:function pointToString() {
				return "Point(" + this.X + ", "+ this.Y + ")";
			}
		};
	};

function Line(startPoint, endPoint) {
	
	if (!(this instanceof Line)) {
        return new Line(startPoint, endPoint);
    }

	this.startPoint = startPoint;
	this.endPoint =  endPoint;
};

Line.prototype.distance = function () {
	return Math.sqrt(Math.pow(this.startPoint.X - this.endPoint.X, 2) + Math.pow(this.startPoint.Y - this.endPoint.Y ,2));
}
Line.prototype.toString = function () {
	return "Line["+ this.startPoint.toString() + ", " + this.endPoint.toString() + "]";
}

function canFormTriangle(a, b, c) {
    return a.distance() < b.distance() + c.distance() &&
           b.distance() < a.distance() + c.distance() &&
           c.distance() < a.distance() + b.distance();
}