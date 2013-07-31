module("MovingGameObject.init (constructor)");
test("Should construct a moving game object with correct values", function () {
    var position = { x: 3, y: 3 },
        size = 5,
        fcolor = "#ccc",
        scolor = "#000",
        speed = 35,
        direction = 1;
    var movingObject =
        new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    equal(movingObject.position, position, "Checking the position");
    equal(movingObject.size, size, "Checking the size");
    equal(movingObject.fcolor, fcolor, "Checking the fill color");
    equal(movingObject.scolor, scolor, "Checking the stroke color");
    equal(movingObject.speed, speed, "Checking the speed");
    equal(movingObject.direction, direction, "Checking the direction");
});

module("MovingGameObject.move");
test("Move horizontal negative X (direction 0)", function () {
    var positionX = 17,
        positionY = 17,
        size = 5,
        fcolor = "#ccc",
        scolor = "#000",
        speed = 5,
        direction = 0;
    var movingObject =
        new snakeGame.MovingGameObject({ x: positionX, y: positionY }, size, fcolor, scolor, speed, direction);

    movingObject.move();

    equal(movingObject.position.x, positionX - speed, "Checking the new X coordinate");
    equal(movingObject.position.y, positionY, "Checking for not changed Y coordinate");
});

test("Move horizontal positive X (direction 2)", function () {
    var positionX = 17,
        positionY = 17,
        size = 5,
        fcolor = "#ccc",
        scolor = "#000",
        speed = 5,
        direction = 2;
    var movingObject =
        new snakeGame.MovingGameObject({ x: positionX, y: positionY }, size, fcolor, scolor, speed, direction);

    movingObject.move();

    equal(movingObject.position.x, positionX + speed, "Checking the new X coordinate");
    equal(movingObject.position.y, positionY, "Checking for not changed Y coordinate");
});

test("Move vertical negative Y (direction 1)", function () {
    var positionX = 17,
        positionY = 17,
        size = 5,
        fcolor = "#ccc",
        scolor = "#000",
        speed = 5,
        direction = 1;
    var movingObject =
        new snakeGame.MovingGameObject({ x: positionX, y: positionY }, size, fcolor, scolor, speed, direction);

    movingObject.move();

    equal(movingObject.position.x, positionX, "Checking for not changed X coordinate");
    equal(movingObject.position.y, positionY - speed, "Checking the new Y coordinate");
});

test("Move vertical positive Y (direction 3)", function () {
    var positionX = 17,
        positionY = 17,
        size = 5,
        fcolor = "#ccc",
        scolor = "#000",
        speed = 5,
        direction = 3;
    var movingObject =
        new snakeGame.MovingGameObject({ x: positionX, y: positionY }, size, fcolor, scolor, speed, direction);

    movingObject.move();

    equal(movingObject.position.x, positionX, "Checking for not changed X coordinate");
    equal(movingObject.position.y, positionY + speed, "Checking the new Y coordinate");
});

module("MovingGameObject.changeDirection");
test("Should change direction from 0 to 1", function () {
    var positionX = 17,
        positionY = 17,
        size = 5,
        fcolor = "#ccc",
        scolor = "#000",
        speed = 5,
        direction = 0;
    var movingObject =
        new snakeGame.MovingGameObject({ x: positionX, y: positionY }, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(1);

    equal(movingObject.direction, 1, "Checking the new direction");
});

test("Should not change direction from 2 to 0", function () {
    var positionX = 17,
        positionY = 17,
        size = 5,
        fcolor = "#ccc",
        scolor = "#000",
        speed = 5,
        direction = 2;
    var movingObject =
        new snakeGame.MovingGameObject({ x: positionX, y: positionY }, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(0);

    equal(movingObject.direction, 2, "Checking for not changed direction");
});

test("Should change direction from 0 to 3", function () {
    var positionX = 17,
        positionY = 17,
        size = 5,
        fcolor = "#ccc",
        scolor = "#000",
        speed = 5,
        direction = 0;
    var movingObject =
        new snakeGame.MovingGameObject({ x: positionX, y: positionY }, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(3);

    equal(movingObject.direction, 3, "Checking the new direction");
});

test("Should not change direction from 3 to 1", function () {
    var positionX = 17,
        positionY = 17,
        size = 5,
        fcolor = "#ccc",
        scolor = "#000",
        speed = 5,
        direction = 3;
    var movingObject =
        new snakeGame.MovingGameObject({ x: positionX, y: positionY }, size, fcolor, scolor, speed, direction);

    movingObject.changeDirection(3);

    equal(movingObject.direction, 3, "Checking for not changed direction");
});