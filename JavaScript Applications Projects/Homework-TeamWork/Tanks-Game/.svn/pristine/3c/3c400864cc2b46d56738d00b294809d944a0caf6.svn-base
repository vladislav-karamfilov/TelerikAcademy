
module("Test GameObject class ", {
    setup: function () {
       
        var animation = new Animation("testurl.com", 10, false, false, 10, 5, 1);
        var options = $.extend({
            x: 0,
            y: 0,
            width: 34,
            height: 34,
            flipH: false,
            flipV: false,
            rotate: 0,
            scale: 1
        }, options);
        this.test = new gameObjectsNS.GameObject("testID", animation,options);
    }, teardown: function () {
        delete this.test;
    }
});
test("When GameObject  is initialized set correct values", function () {

    var options = $.extend({
        x: 0,
        y: 0,
        width: 34,
        height: 34,
        flipH: false,
        flipV: false,
        rotate: 0,
        scale: 1
    }, options);
    var animationTest = new Animation("testurl.com", 10, false, false, 10, 5, 1);
    var topLeftTest = new gameFieldNS.Position(10, 10);
    var id = "testID"
    deepEqual(id, this.test.id, "Property id set successfully");
    deepEqual(animationTest, this.test.animation, "Property animation set successfully");
    deepEqual(options, this.test.options, "Property topLeft set successfully");
});

module("Test StaticObject class ", {
    setup: function () {
        var animation = new Animation("testurl.com", 10, 10, 5, 1);
        var options = $.extend({
            x: 0,
            y: 0,
            width: 34,
            height: 34,
            flipH: false,
            flipV: false,
            rotate: 0,
            scale: 1
        }, options);
        this.test = new gameObjectsNS.GameObject("testID", animation, options);
    }, teardown: function () {

    }
});
test("When Staticbject  is initialized set correct values", function () {

    var animation = new Animation("testurl.com", 10, 10, 5, 1);
    var options = $.extend({
        x: 0,
        y: 0,
        width: 34,
        height: 34,
        flipH: false,
        flipV: false,
        rotate: 0,
        scale: 1
    }, options);
    var topLeftTest = new gameFieldNS.Position(10, 10);
    var id = "testID"
    deepEqual(id, this.test.id, "Property id set successfully");
    deepEqual(animation, this.test.animation, "Property animation set successfully");
    deepEqual(options, this.test.options, "Property topLeft set successfully");
});


module("Test MovingObject class ", {
    setup: function () {
        var animation = new Animation("testurl.com", 10, 10, 5, 1);
        var options = $.extend({
            x: 0,
            y: 0,
            width: 34,
            height: 34,
            flipH: false,
            flipV: false,
            rotate: 0,
            scale: 1
        }, options);
    
        this.test = new gameObjectsNS.MovingObject("testID", animation,100,options);
       
    }, teardown: function () {
        delete this.test;
    }
});
test("When MovingObject  is initialized set correct values", function () {


    var animationTest = new Animation("testurl.com", 10, 10, 5, 1);
    var speed = 100;
    var id = "testID";
    var options = $.extend({
        x: 0,
        y: 0,
        width: 34,
        height: 34,
        flipH: false,
        flipV: false,
        rotate: 0,
        scale: 1
    }, options);

  
    deepEqual(id, this.test.id, "Property id set successfully");
    deepEqual(animationTest, this.test.animation, "Property animation set successfully");
    deepEqual(speed, this.test.speed, "Property speed set successfully");
    deepEqual(options, this.test.options, "Property options set successfully");

});
/*
test("When MovingObject  is moved set correct values", function () {

    var image = 1;
    var topLeft = new gameFieldNS.Position(42, 42);
    //this.test.move();
    ok(true);
   // deepEqual(image, this.test.image, "Property image set successfully");
   // deepEqual(topLeft, this.test.topLeft, "Property topLeft updated successfully");
   // deepEqual(speed, this.test.speed, "Property speed set successfully");
});

*/

module("Test BrickWall class ", {
    setup: function () {
        var animation = new Animation("testurl.com", 10, 10, 5, 1);
        var options = $.extend({
            x: 0,
            y: 0,
            width: 34,
            height: 34,
            flipH: false,
            flipV: false,
            rotate: 0,
            scale: 1
        }, options);
        this.test = new gameObjectsNS.BrickWall("testID", animation, options);
    }, teardown: function () {

    }
});
test("When BrickWall  is initialized set correct values", function () {

    var animation = new Animation("testurl.com", 10, 10, 5, 1);
    var options = $.extend({
        x: 0,
        y: 0,
        width: 34,
        height: 34,
        flipH: false,
        flipV: false,
        rotate: 0,
        scale: 1
    }, options);
    var isDestroyed = false;
    var topLeftTest = new gameFieldNS.Position(10, 10);
    var id = "testID"
    deepEqual(id, this.test.id, "Property id set successfully");
    deepEqual(animation, this.test.animation, "Property animation set successfully");
    deepEqual(options, this.test.options, "Property topLeft set successfully");
    equal(isDestroyed, this.test.isDestroyed, "Property isDesroyed set correctly");
});

module("Test SteelWall class ", {
    setup: function () {
        var animation = new Animation("testurl.com", 10, 10, 5, 1);
        var options = $.extend({
            x: 0,
            y: 0,
            width: 34,
            height: 34,
            flipH: false,
            flipV: false,
            rotate: 0,
            scale: 1
        }, options);
        this.test = new gameObjectsNS.SteelWall("testID", animation, options);
    }, teardown: function () {

    }
});
test("When SteelWall  is initialized set correct values", function () {

    var animation = new Animation("testurl.com", 10, 10, 5, 1);
    var options = $.extend({
        x: 0,
        y: 0,
        width: 34,
        height: 34,
        flipH: false,
        flipV: false,
        rotate: 0,
        scale: 1
    }, options);
  
    var topLeftTest = new gameFieldNS.Position(10, 10);
    var id = "testID"
    deepEqual(id, this.test.id, "Property id set successfully");
    deepEqual(animation, this.test.animation, "Property animation set successfully");
    deepEqual(options, this.test.options, "Property topLeft set successfully");
   
});


module("Test PlayerTank class ", {
    setup: function () {
        var animation = new Animation("testurl.com", 10, 10, 5, 1);
        var options = $.extend({
            x: 0,
            y: 0,
            width: 34,
            height: 34,
            flipH: false,
            flipV: false,
            rotate: 0,
            scale: 1
        }, options);

        this.test = new gameObjectsNS.PlayerTank("testID", animation, 100, options);

    }, teardown: function () {
        delete this.test;
    }
});
test("When PlayerTank  is initialized set correct values", function () {

    var animationTest = new Animation("testurl.com", 10, 10, 5, 1);
    var speed = 100;
    var id = "testID";
    var isAlive = true;
    var isMoving = false;
    var canShoot = true;
    var options = $.extend({
        x: 0,
        y: 0,
        width: 34,
        height: 34,
        flipH: false,
        flipV: false,
        rotate: 0,
        scale: 1
    }, options);


    deepEqual(id, this.test.id, "Property id set successfully");
    deepEqual(animationTest, this.test.animation, "Property animation set successfully");
    deepEqual(speed, this.test.speed, "Property speed set successfully");
    deepEqual(options, this.test.options, "Property options set successfully");
    deepEqual(isAlive, this.test.isAlive, "Property options set successfully");
    deepEqual(isMoving, this.test.isMoving, "Success");
    deepEqual(canShoot, this.test.canShoot, "Success");
});

test("When PlayerTank  shoot", function () {

    var animation = new Animation("testurl.com", 10, 10, 5, 1);
    var speed = 100;
    var id = "testID";
    var isAlive = true;
    var isMoving = false;
    var canShoot = true;
    var direction = "down";
    var options = $.extend({
        x: 0,
        y: 0,
        width: 34,
        height: 34,
        flipH: false,
        flipV: false,
        rotate: 0,
        scale: 1
    }, options);


    var x = this.test.shoot(id, animation, speed, options, this.direction, false);
   //var t= x.shoot(id, animation, speed, options, direction, true);
    var bulet = new gameObjectsNS.Bullet(id, animation, speed, options,this.direction,false);
    deepEqual(bulet, x);
});



module("Test EnemyTank class ", {
    setup: function () {
        var animation = new Animation("testurl.com", 10, 10, 5, 1);
        var options = $.extend({
            x: 0,
            y: 0,
            width: 34,
            height: 34,
            flipH: false,
            flipV: false,
            rotate: 0,
            scale: 1
        }, options);

        this.test = new gameObjectsNS.PlayerTank("testID", animation, 100, options);

    }, teardown: function () {
        delete this.test;
    }
});
test("When EnemyTank  is initialized set correct values", function () {

    var animationTest = new Animation("testurl.com", 10, 10, 5, 1);
    var speed = 100;
    var id = "testID";
    var isAlive = true;
    var isMoving = false;
    var canShoot = true;
    var options = $.extend({
        x: 0,
        y: 0,
        width: 34,
        height: 34,
        flipH: false,
        flipV: false,
        rotate: 0,
        scale: 1
    }, options);


    deepEqual(id, this.test.id, "Property id set successfully");
    deepEqual(animationTest, this.test.animation, "Property animation set successfully");
    deepEqual(speed, this.test.speed, "Property speed set successfully");
    deepEqual(options, this.test.options, "Property options set successfully");
    deepEqual(isAlive, this.test.isAlive, "Property options set successfully");
    deepEqual(isMoving, this.test.isMoving, "Success");
    deepEqual(canShoot, this.test.canShoot, "Success");
});

test("When EnemyTank  shoot", function () {

    var animation = new Animation("testurl.com", 10, 10, 5, 1);
    var speed = 100;
    var id = "testID";
    var isAlive = true;
    var isMoving = false;
    var canShoot = true;
    var direction = "down";
    var options = $.extend({
        x: 0,
        y: 0,
        width: 34,
        height: 34,
        flipH: false,
        flipV: false,
        rotate: 0,
        scale: 1
    }, options);


    var x = this.test.shoot(id, animation, speed, options, this.direction, false);
    //var t= x.shoot(id, animation, speed, options, direction, true);
    var bulet = new gameObjectsNS.Bullet(id, animation, speed, options, this.direction, false);
    deepEqual(bulet, x);
});
module("Test Bullet class ", {
    setup: function () {
        var animation = new Animation("testurl.com", 10, 10, 5, 1);
        var options = $.extend({
            x: 0,
            y: 0,
            width: 34,
            height: 34,
            flipH: false,
            flipV: false,
            rotate: 0,
            scale: 1
        }, options);

        this.test = new gameObjectsNS.Bullet("testID", animation, 100, options);

    }, teardown: function () {
        delete this.test;
    }
});
test("When Bullet  is initialized set correct values", function () {


    var animationTest = new Animation("testurl.com", 10, 10, 5, 1);
    var speed = 100;
    var id = "testID";
    var isDestroyed = false;
    var options = $.extend({
        x: 0,
        y: 0,
        width: 34,
        height: 34,
        flipH: false,
        flipV: false,
        rotate: 0,
        scale: 1
    }, options);


    deepEqual(id, this.test.id, "Property id set successfully");
    deepEqual(animationTest, this.test.animation, "Property animation set successfully");
    deepEqual(speed, this.test.speed, "Property speed set successfully");
    deepEqual(options, this.test.options, "Property options set successfully");
    deepEqual(isDestroyed, this.test.isDestroyed, "Property options set successfully");

});