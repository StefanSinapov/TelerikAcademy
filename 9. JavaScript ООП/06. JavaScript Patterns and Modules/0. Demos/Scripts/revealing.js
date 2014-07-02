var module = (function (someValue) {
    
    var privateVar = someValue;

    function change(newVar) {
        privateVar = newVar;
    }

    function publicVar() {
        return privateVar;
    }

    return {
        changeVar: change,
        publicVar: publicVar
    }

}('pesho'))

