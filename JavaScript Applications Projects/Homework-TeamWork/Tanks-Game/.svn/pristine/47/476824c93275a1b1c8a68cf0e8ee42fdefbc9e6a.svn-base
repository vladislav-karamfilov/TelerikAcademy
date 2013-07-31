module("FieldPosition", {
    setup: function () {
        this.fieldPosition = new GridPosition();
    }, teardown: function () {
        delete this.fieldPosition;
    }
});
test("test initialize", function () {
    equal(this.fieldPosition.initialize(3,3), 3,3)
});