/*
    4. Write a script that finds the lexicographically smallest
    and largest property in document, window and navigator objects.
*/
taskName = "4. Property finder in document";

function Main(bufferElement) {

	Write('Smallest and largest property in document, window and navigator objects');
    SetSolveButton(function () {
    	GetProperties(document, window, navigator);
    });
}

function GetProperties() {
	
	for(var objectId in arguments){
		var properties = [];

		for(var prop in arguments[objectId])
		{
			properties.push(prop);
		}

		properties.sort();
		WriteLine("Properties in " + arguments[objectId]);
		WriteLine("Smallest: " + properties.shift());
		WriteLine("Largest: " + properties.pop());
		WriteLine();
	}

}