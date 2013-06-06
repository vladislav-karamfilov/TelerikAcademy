var bouncingBalls = (function () {
    var canvas;
    var context;

    var balls = []

    function Ball(xCoordinate, yCoordinate, speedX, speedY, radius, color) {
        this.xCoordinate = xCoordinate;
        this.yCoordinate = yCoordinate;
        this.speedX = speedX;
        this.speedY = speedY;
        this.radius = radius;
        this.color = color;
    }

    function addBall(xCoordinate, yCoordinate, speedX, speedY, radius, color) {
        balls.push(new Ball(xCoordinate, yCoordinate, speedX, speedY, radius, color));
    }

    function clearBalls() {
        for (var i = 0, ballsCount = balls.length; i < ballsCount; i++) {
            balls.pop();
        }
    }

    function load(canvasID) {
        canvas = document.getElementById(canvasID);
        context = canvas.getContext("2d");

        setTimeout(drawFrame, 24);
    }

    function drawFrame() {
        context.clearRect(0, 0, canvas.width, canvas.height);

        context.beginPath();
        for (var i = 0, ballsCount = balls.length; i < ballsCount; i++) {
            moveBall(balls[i]);

            context.fillStyle = balls[i].color;
            context.arc(balls[i].xCoordinate, balls[i].yCoordinate, balls[i].radius, 0, 2 * Math.PI, true);
            context.fill();
        }
        
        context.closePath();

        setTimeout(drawFrame, 24);
    }

    function moveBall(ball) {
        ball.xCoordinate += ball.speedX;
        ball.yCoordinate += ball.speedY;

        if ((ball.xCoordinate + ball.radius > canvas.width) || (ball.xCoordinate - ball.radius < 0)) {
            ball.speedX = -ball.speedX;
        }

        if ((ball.yCoordinate + ball.radius > canvas.height) || (ball.yCoordinate - ball.radius < 0)) {
            ball.speedY = -ball.speedY;
        }
    }

    return {
        load: load,
        addBall: addBall,
        clearBalls: clearBalls
    };
})();