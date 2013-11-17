$(function () {
    var playerPoints = 0;

    var tankAnimSmall = new engine.animation({
        url: "images/tank1.png",
        numberOfFrames: 2,
        rate: 200,
        width: 34,
    })

    var tankAnimBig = new engine.animation({
        url: "images/tank2.png",
        numberOfFrames: 2,
        rate: 200,
        width: 34,
    })

    var tankAnimBigger = new engine.animation({
        url: "images/tank3.png",
        numberOfFrames: 2,
        rate: 200,
        width: 34,
    })

    var tankAnimBigSpecial = new engine.animation({
        url: "images/tanksBigSpecial.png",
        numberOfFrames: 2,
        rate: 200,
        width: 34,
    })

    var tankAnimBiggerSpecial = new engine.animation({
        url: "images/tanksBiggerSpecial.png",
        numberOfFrames: 2,
        rate: 200,
        width: 34,
    })

    var bulletAnimation = new engine.animation({
        url: "images/bullet.png",
        numberOfFrames: 1,
        rate: 200,
        width: 7,
    })

    var playerAnimation = {
        move: new engine.animation({
            url: "images/player-tank.png",
            numberOfFrames: 2,
            rate: 200,
            width: 34,
        }),
        stand: new engine.animation({
            url: "images/player-tank.png",
            numberOfFrames: 1,
            rate: 200,
            width: 34,
        })
    };

    var standardTankOptionsLeft = {
        x: 34,
        y: 34,
        width: 34,
        height: 34,
    }

    var standardTankOptionsRight = {
        x: 600,
        y: 34,
        width: 34,
        height: 34,
    }

    var tiles = [
        new engine.animation({
            url: "images/tiles.png"
        }),
        new engine.animation({
            url: "images/tiles.png",
            offset: 34
        }),
        new engine.animation({
            url: "images/tiles.png",
            offset: 68
        }),
        new engine.animation({
            url: "images/tiles.png",
            offset: 102
        }),
        new engine.animation({
            url: "images/tiles.png",
            offset: 136
        }),
        new engine.animation({
            url: "images/tiles.png",
            offset: 170
        }),
        new engine.animation({
            url: "images/tiles.png",
            offset: 204
        }),
    ];

    var level = [[6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6],
                 [6, 0, 0, 0, 0, 0, 0, 0, 0, 6, 2, 0, 0, 0, 0, 0, 0, 0, 0, 6],
                 [6, 0, 0, 1, 1, 1, 0, 0, 0, 6, 2, 0, 0, 2, 2, 2, 0, 0, 0, 6],
                 [6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6],
                 [6, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 6],
                 [6, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 6],
                 [6, 0, 2, 0, 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 1, 0, 1, 0, 6],
                 [6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6],
                 [6, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6],
                 [6, 0, 1, 0, 6, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 6],
                 [6, 0, 1, 0, 6, 0, 0, 2, 1, 1, 1, 1, 2, 0, 0, 0, 0, 6, 0, 6],
                 [6, 0, 1, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 0, 6],
                 [6, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6],
                 [6, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 6],
                 [6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6]];

    var container, tilemap;
    var player = new gameObjectsNS.PlayerTank("player-tank", playerAnimation, 10, { x: 340, y: 440 });

    $("#startButton").click(function () {
        engine.startGame(initialize);
    });

    var initialize = function () {
        $("#myGame").append("<div id='container' style='display: none; width: 680px; height: 480px; background-color: black;'>");

        container = $("#container");
        group = engine.addGroup(container, "group");
        tilemap = engine.addTilemap(group, "level", { tileWidth: 34, tileHeight: 34, width: 20, height: 15, map: level, animations: tiles });

        player.container = engine.addSprite(container, "player-tank", { x: 340, y: 440, width: 34, height: 34 });

        engine.setAnimation(player.container, playerAnimation.stand);

        engine.addCallback(gameLoop, 100);
        engine.addCallback(changeDirections, 600);
        engine.addCallback(addTanks, 3000);
        engine.addCallback(moveBullets, 60);
        engine.addCallback(shootTanks, 1303);

        $("#startButton").remove();
        container.css("display", "block");
    }

    var tanks = [];
    var bullets = [];
    var changeDirections = function () {
        for (var i = 0; i < tanks.length; i++) {
            tanks[i].changeDirection(player.options.x, player.options.y);
        }
    }

    var moveTanks = function () {
        for (var i = 0; i < tanks.length; i++) {
            var movements = rotateAndGetNextPos(tanks[i], tanks[i].direction, tanks[i].speed);
            moveObject(tanks[i], movements.horizontalMove, movements.verticalMove)
        }
    }

    //Create random tanks
    var addTanks = function () {
        if (tanks.length < 14) {

            var typeOfTankLeft = generateTypeOfTank();
            var newTank = new gameObjectsNS.EnemyTank("tank" + tanks.length, typeOfTankLeft.animation, typeOfTankLeft.speed, 
                                                        standardTankOptionsLeft, typeOfTankLeft.points);
            engine.setAnimation(newTank.container, typeOfTankLeft.animation);

            container.append(newTank.container);
            tanks.push(newTank);

            var typeOfTankRight = generateTypeOfTank();
            var anotherTank = new gameObjectsNS.EnemyTank("tank" + tanks.length, typeOfTankRight.animation, typeOfTankRight.speed, 
                                                            standardTankOptionsRight, typeOfTankRight.points);
            engine.setAnimation(anotherTank.container, typeOfTankRight.animation);

            container.append(anotherTank.container);
            tanks.push(anotherTank);
        }
    }
    
    var generateTypeOfTank = function () {
        var typeOfTank = {};
        var randomNumber = (Math.random() * 5) | 0;
        switch (randomNumber) {
            case 0:
                typeOfTank.animation = tankAnimSmall;
                typeOfTank.points = 10;
                typeOfTank.speed = 5;
                break;
            case 1:
                typeOfTank.animation = tankAnimBig;
                typeOfTank.points = 20;
                typeOfTank.speed = 5;
                break;
            case 2:
                typeOfTank.animation = tankAnimBigger;
                typeOfTank.speed = 5;
                typeOfTank.points = 30;
                break;
            case 3:
                typeOfTank.animation = tankAnimBigSpecial;
                typeOfTank.speed = 10;
                typeOfTank.points = 40;
                break;
            case 4:
                typeOfTank.animation = tankAnimBiggerSpecial;
                typeOfTank.speed = 5;
                typeOfTank.points = 50;
                break;
        }

        return typeOfTank;
    }

    var shootTanks = function () {
        for (var i = 0; i < tanks.length; i++) {
            createBullet(tanks[i], true);
        }
    }

    var createBullet = function (shootingObject, isEnemy) {
        var posX;
        var posY;
        switch (shootingObject.direction) {
            case "left":
                posX = shootingObject.options.x;
                posY = shootingObject.options.y + 15;;
                break;
            case "right":
                posX = shootingObject.options.x + shootingObject.options.width;
                posY = shootingObject.options.y + 15;
                break;
            case "up":
                posX = shootingObject.options.x + 15;
                posY = shootingObject.options.y;
                break;
            default:
                posX = shootingObject.options.x + 15;
                posY = shootingObject.options.y + shootingObject.options.height;
                break;
        }

        var bulletOptions = {
            x: posX,
            y: posY,
            width: 4,
            height: 4,
        }

        newBullet = shootingObject.shoot("bullet" + shootingObject.id + bullets.length, bulletAnimation, 15,
            bulletOptions, shootingObject.direction, isEnemy);
        if (newBullet) {
            engine.setAnimation(newBullet.container, bulletAnimation);
            rotateAndGetNextPos(newBullet, newBullet.direction, 0);
            container.append(newBullet.container);
            bullets.push(newBullet);
        }
    }

    var moveBullets = function () {
        var removedBullets = [];
        var movements;
        var isMoved;
        for (var i = 0; i < bullets.length; i++) {
            movements = rotateAndGetNextPos(bullets[i], bullets[i].direction, bullets[i].speed);
            isMoved = moveBullet(bullets[i], movements.horizontalMove, movements.verticalMove);
            if (!isMoved) {
                removedBullets.push(bullets[i]);
            }
        }

        for (var j = 0; j < removedBullets.length; j++) {
            for (var i = 0; i < bullets.length; i++) {
                if (bullets[i] == removedBullets[j]) {
                    bullets.splice(i, 1);
                    break;
                }
            }
        }
    }

    var rotateAndGetNextPos = function (gameObject, direction, inputStep) {
        var step = 5;
        var horizontalMove = 0;
        var verticalMove = 0;

        if (inputStep) step = inputStep;
        switch (direction) {
            case "left":
                horizontalMove = -step;
                engine.transform(gameObject, { rotate: 0, flipH: true });
                break;
            case "right":
                horizontalMove = step;
                engine.transform(gameObject, { rotate: 0, flipH: false });
                break;
            case "up":
                verticalMove = -step;
                engine.transform(gameObject, { rotate: -90, flipH: false });
                break;
            default:
                verticalMove = step;
                engine.transform(gameObject, { rotate: 90, flipH: false });
                break;
        }

        return {
            horizontalMove: horizontalMove,
            verticalMove: verticalMove
        }
    }

    var moveBullet = function (bullet, horizontalMove, verticalMove) {
        var newY = engine.y(bullet) + verticalMove;
        var newX = engine.x(bullet) + horizontalMove;
        var newW = engine.width(bullet);
        var newH = engine.height(bullet);

        var collisions = engine.tilemapCollide(tilemap, { x: newX, y: newY, width: newW, height: newH });
        if (collisions.length > 0) {
            removeGameObject(bullet);
            return false;
        }

        if (bullet.isEnemy) {
            if (engine.objectCollide(bullet, player)) {
                removeGameObject(player);
                removeGameObject(bullet);
                endGame();
                return false;
            }
        }
        else {
            for (var i = 0; i < tanks.length; i++) {
                if (engine.objectCollide(tanks[i], bullet)) {
                    playerPoints += tanks[i].points;

                    removeGameObject(tanks[i]);
                    removeGameObject(bullet);
                    tanks.splice(i, 1);
                    return false;
                }
            }
        }

        engine.x(bullet, newX);
        engine.y(bullet, newY);
        return true;
    }

    var moveObject = function (gameObject, horizontalMove, verticalMove) {
        var newY = engine.y(gameObject) + verticalMove;
        var newX = engine.x(gameObject) + horizontalMove;
        var newW = engine.width(gameObject);
        var newH = engine.height(gameObject);

        var collisionObject =  { x: newX, y: newY, width: newW, height: newH };

        var collisions = engine.tilemapCollide(tilemap, collisionObject);

        var i = 0;
        while (i < collisions.length > 0) {
            var collision = collisions[i];
            collision.options = {
                x: collision.data("engine").x, y: collision.data("engine").y, width: collision.data("engine").width,
                height: collision.data("engine").height
            };
            i++;
            var collisionBox = {
                x1: engine.x(collision),
                y1: engine.y(collision),
                x2: engine.x(collision) + engine.width(collision),
                y2: engine.y(collision) + engine.height(collision)
            };

            var x = engine.intersect(newX, newX + newW, collisionBox.x1, collisionBox.x2);
            var y = engine.intersect(newY, newY + newH, collisionBox.y1, collisionBox.y2);

            var diffx = (x[0] === newX) ? x[0] - x[1] : x[1] - x[0];
            var diffy = (y[0] === newY) ? y[0] - y[1] : y[1] - y[0];
            if (Math.abs(diffx) > Math.abs(diffy)) {
                newY -= diffy;
            } else {
                newX -= diffx;
            }
        }

        for (var i = 0; i < tanks.length; i++) {
            if (tanks[i] !== gameObject) {
                var x = engine.intersect(newX, newX + newW, tanks[i].options.x, tanks[i].options.x + tanks[i].options.width);
                var y = engine.intersect(newY, newY + newH, tanks[i].options.y, tanks[i].options.y + tanks[i].options.height);

                var diffx = (x[0] === newX) ? x[0] - x[1] : x[1] - x[0];
                var diffy = (y[0] === newY) ? y[0] - y[1] : y[1] - y[0];
                if (Math.abs(diffx) > Math.abs(diffy)) {
                    newY -= diffy;
                } else {
                    newX -= diffx;
                }
            }
        }

        engine.x(gameObject, newX);
        engine.y(gameObject, newY);
    }

    var removeGameObject = function (gameObject) {
        gameObject.remove();
        engine.removeAnimation(gameObject.container);
    }

    var lastPlayerShoot = 0;
    var gameLoop = function () {
        //move all the tanks
        moveTanks();

        //get player next pos
        var newPosition;
        var moving = false;
        if (engine.keyboard[37]) {
            moving = true;
            player.direction = "left";
        } else if (engine.keyboard[38]) {
            moving = true;
            player.direction = "up";
        } else if (engine.keyboard[39]) {
            moving = true;
            player.direction = "right";
        } else if (engine.keyboard[40]) {
            moving = true;
            player.direction = "down";
        }

        if (moving) {
            engine.setAnimation(player.container, playerAnimation.move);
            newPosition = rotateAndGetNextPos(player, player.direction, player.speed);
        }  else {
            engine.setAnimation(player.container, playerAnimation.stand);
        }

        //update the last time the player shoot
        if (lastPlayerShoot > 0) {
            lastPlayerShoot--;
        }

        //player shoots
        if (engine.keyboard[32] && lastPlayerShoot === 0) {
            lastPlayerShoot = 5;
            createBullet(player, false);
        }

        //set player next pos
        if (newPosition) {
            moveObject(player, newPosition.horizontalMove, newPosition.verticalMove);
        }
    }

    var endGame = function () {
        engine.removeCallback(shootTanks);
        player.canShoot = false;
        player.options.x = 680;

        var endGameContainer = $("#endGameContainer");
        endGameContainer.css("display", "block");

        addTwitterFunctionality(endGameContainer);
        addViewScoreBoardFunctionality(endGameContainer);
    }

    function addViewScoreBoardFunctionality(endGameContainer) {
        var scoreBoardContainer = $("<div></div>");
        var scoreBoardForm = $("<form></form>");
        scoreBoardForm.append("<label for='user-name'>Enter your name: </label>");
        scoreBoardForm.append("<input type='text' id='user-name'/>");
        scoreBoardForm.append(($("<input type='submit' value='Submit' />").click(function () {
            var playerName = $('#user-name').val();
            localStorage.setItem(playerName, playerPoints);
        })));

        scoreBoardContainer.append(scoreBoardForm);
        var topScoresContainer = $("<div></div>");
        var topScoresButton = $("<button id='scores-button'>View top scores</button>");
        topScoresButton.click(function () {
            topScoresContainer.html("");
            var scoreBoard = new scoresNS.ScoreBoard();
            for (var i = 0, scoresCount = localStorage.length; i < scoresCount; i++) {
                var key = localStorage.key(i);
                var newScore = new scoresNS.Score(key, localStorage.getItem(key));
                scoreBoard.add(newScore);
            }

            topScoresContainer.append(scoreBoard.getRendered());
            scoreBoardContainer.append(topScoresContainer);;
        });

        scoreBoardContainer.append(topScoresButton);
        endGameContainer.append(scoreBoardContainer);
    }

    function addTwitterFunctionality(endGameContainer) {
        var twitterContainer = $("<div></div>");
        twitterContainer.html('<iframe id="tweet-button" allowtransparency="true" frameborder="0" scrolling="no" \
        src="http://platform.twitter.com/widgets/tweet_button.html?via=DragonFruitTeam&amp;text=Tweet%20Your%20Score:&amp;count=horizontal"; \
        style="width: 110px; height: 20px;"></iframe>');
        endGameContainer.append(twitterContainer);

        function tweet(message) {
            var tweetButton = $('#tweet-button');
            var account = 'DragonFruitTeam';
            var text = message.replace(/ /g, "%20");
            var tButtonSrc = 'http://platform.twitter.com/widgets/tweet_button.html?via=' + account + '&text=' + text + '&count=horizontal';
            tweetButton.attr("src", tButtonSrc);
        };

        tweet("Great game! My points are: " + playerPoints);
    }
})