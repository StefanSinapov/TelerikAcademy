
var controller = new Controller();

QUnit.test("Controller Constructor", function(assert){
    assert.deepEqual(controller, new Controller(), 'Controller constructor');
    assert.ok(controller instanceof Controller, 'reference instance of controller');
    assert.ok(controller.mouseClick !== undefined, "mouseClick field exists");
    assert.ok(controller.mousePosition !== undefined, 'mousePosition field exists');
});