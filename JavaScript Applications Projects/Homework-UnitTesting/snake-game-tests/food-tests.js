module("Food.init (constructor)");
test("When food is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var size = 10;
    var food = new snakeGame.Food(position, size);

    equal(position, food.position, "Position is set");
    equal(size, food.size, "Size is set");
});