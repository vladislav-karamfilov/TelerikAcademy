var gameObjectsNS = (function () {
    var GameObject = Class.create({
        initialize: function (image, topLeft) {
            this.image = image;
            this.topLeft = topLeft;
        },
        render: function () {
            // TODO: Implement logic with[out] jQuery.
        }
    });

    var StaticObject = Class.create(GameObject, {
        initialize: function ($super, image, topLeft) {
            $super(image, topLeft);
        }
    });

    var MovingObject = Class.create(GameObject, {
        initialize: function ($super, image, topLeft, speed) {
            $super(image, topLeft);
            this.speed = speed;
        },
        move: function () {
            this.topLeft.update(this.speed);
        }
    });

    var BrickWall = Class.create(StaticObject, {
        initialize: function ($super, image, topLeft) {
            $super(image, topLeft);
        }
    });

    var SteelWall = Class.create(StaticObject, {
        initialize: function ($super, image, topLeft) {
            $super(image, topLeft);
        }
    });

    var PlayerTank = Class.create(MovingObject, {
        initialize: function ($super, image, topLeft, speed) {
            $super(image, topLeft, speed);
            this._isAlive = true;
        }
    });

    var EnemyTank = Class.create(MovingObject, {
        initialize: function ($super, image, topLeft, speed) {
            $super(image, topLeft, speed);
            this._isAlive = true;
        },
        move: function () {
            // TODO: Override with logic for 50% guessing player's move.
        }
    });

    return {
        GameObject: GameObject,
        StaticObject: StaticObject,
        MovingObject: MovingObject,
        BrickWall: BrickWall,
        SteelWall: SteelWall,
        PlayerTank: PlayerTank,
        EnemyTank: EnemyTank
    }
})();