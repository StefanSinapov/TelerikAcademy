taskName = "Demo";
message = "This is simple demo: <br/><br/>"

function Main(bufferElement) {

    var firstName = ReadLine("First name: ");
    var secondName = ReadLine("Second name: ");

     SetSolveButton(function () {
        Regard(firstName.value, secondName.value);
    });
}

function Regard(firstName, secondName) {
    WriteLine(Format("Hello, {0} {1}!", firstName, secondName));
}