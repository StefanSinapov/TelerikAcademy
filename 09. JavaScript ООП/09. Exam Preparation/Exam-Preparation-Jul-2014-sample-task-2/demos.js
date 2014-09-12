var obj = {
	name: 'Gosho',
	otherName: 'Pesho',
	number: 7,
	func: function(){

	}
};

var objStr = JSON.stringify(obj);
console.dir(objStr);
var objectClone = JSON.parse(objStr);
console.dir(objectClone);