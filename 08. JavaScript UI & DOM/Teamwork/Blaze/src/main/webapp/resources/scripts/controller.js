/*
 *   Initializes a new instance of the Controller class.
 */
function Controller() {
    var self = this;
    var canvas = document.getElementById('drawing');

    this.mouseClick = null;
    this.mousePosition = null;

    /*
     *   Event listener for shooting.
     */
    canvas.addEventListener("click", function (ev) {
        var rect = canvas.getBoundingClientRect();
        var x = ev.clientX - rect.left;
        var y = ev.clientY - rect.top;
        self.mouseClick = new Coordinate(x, y);
        // console.log(mouseClick.toString())
    });

    /*
     *   Event listener for movement of Blaze.
     */
    canvas.addEventListener("mousemove", function (ev) {
        var rect = canvas.getBoundingClientRect();
        var x = ev.clientX - rect.left;
        var y = ev.clientY - rect.top;
        self.mousePosition = new Coordinate(x, y);
        //console.log(mousePosition.toString())
    });
}