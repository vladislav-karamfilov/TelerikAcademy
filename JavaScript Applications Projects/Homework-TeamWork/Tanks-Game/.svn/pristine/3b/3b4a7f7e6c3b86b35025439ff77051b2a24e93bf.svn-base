module("Test Field class ", {
    setup: function () {
        this.test = new gameFieldNS.Field(1, 2, 3);
    }, teardown: function () {
        delete this.test;
    }
});
test("When Field is initialized, should set the correct values", function () {
    var container = 1;
    var width = 2;
    var height = 3; 
    deepEqual(container, this.test.container, "Container property set successully");
    deepEqual(width, this.test.width, "Width property set successully");
    deepEqual(height, this.test.height, "Height property set successully");
});


module("Test FieldPosition Class", {
    setup: function () {
        this.test = new gameFieldNS.Position(2, 2);
    }, teardown: function () {
        delete this.test;
    }
});

test("When FieldPosition is initialized, should set the correct values", function () {

   // var test = new gameFieldNS.FieldPosition(2, 2);
    var xCoord = 2
    var yCoord = 2 
   
    equal(xCoord, this.test.xCoord, "xCoord property set correctly");
    equal(yCoord, this.test.yCoord, "yCoord property set correctly");
});
test("When FieldPosition is updated, should set the correct values", function () {

    var delta = new gameFieldNS.Position(2, 0);
    var xCoord = 4
    var yCoord = 2
    this.test.update(delta);
    equal(xCoord, this.test.xCoord, "xCoord property updated correctly");
    equal(yCoord, this.test.yCoord, "yCoord property updated correctly");
   
});

