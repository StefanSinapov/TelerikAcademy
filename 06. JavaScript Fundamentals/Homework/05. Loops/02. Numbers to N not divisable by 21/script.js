// Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time
taskName = "2. Numbers to N not divisable by 21";
function Main(bufferElement) {

	var n = ReadLine("Enter n : ");
	

    SetSolveButton(function () {
    	ConsoleClear();
    	for (var i = 1; i <= n.value; i++) {
			if(i%21 !== 0){
					Write(i + ", ");
				}
		};
    });	
}

