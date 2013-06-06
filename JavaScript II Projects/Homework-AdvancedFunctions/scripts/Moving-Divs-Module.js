var movingDivs = (function () {
    var DIV_WIDTH = 50;
    var DIV_HEIGHT = 50;
    var BORDER_RADIUS = 50;
    var RECTANGLE_CENTER_TOP = 200;
    var RECTANGLE_CENTER_LEFT = 300;
    var ELLIPSE_CENTER_TOP = 200;
    var ELLIPSE_CENTER_LEFT = 900;
    var MAJOR_SEMIAXIS = 230;
    var MINOR_SEMIAXIS = 130;
    var ELLIPSE_DEGREES_INCREMENT = 6;
    var RECTANGLE_DEGREES_INCREMENT = 3;

    var ellipseDegreePositions = [];
    var rectangleDegreePositions = [];

    var ellipseOrbitDivs = document.getElementsByClassName("div-ellipse");
    var rectangularOrbitDivs = document.getElementsByClassName("div-rectangle");

    // Shim for requestAnimFrame function
    window.requestAnimFrame = (function () {
        return window.requestAnimationFrame ||
            window.webkitRequestAnimationFrame ||
            window.mozRequestAnimationFrame ||
            window.oRequestAnimationFrame ||
            window.msRequestAnimationFrame ||
            function (callback) {
                window.setTimeout(callback, 500);
            };
    })();

    window.requestAnimFrame(moveDivs);

    function moveInEllipseOrbit(element, angleInDegrees) {
        var theta = angleInDegrees * Math.PI / 180;

        var left = parseInt(ELLIPSE_CENTER_LEFT + MAJOR_SEMIAXIS * Math.sin(theta));
        element.style.left = left + "px";

        var top = parseInt(ELLIPSE_CENTER_TOP - MINOR_SEMIAXIS * Math.cos(theta));
        element.style.top = top + "px";
    }

    function moveInRectangleOrbit(element, angleInDegrees) {
        var theta = angleInDegrees * Math.PI / 180;
        var cosTheta = Math.cos(theta);
        var sinTheta = Math.sin(theta);

        var left = parseInt(RECTANGLE_CENTER_LEFT + MAJOR_SEMIAXIS * (Math.abs(cosTheta) * cosTheta + Math.abs(sinTheta) * sinTheta));
        element.style.left = left + "px";

        var top = parseInt(RECTANGLE_CENTER_TOP + MINOR_SEMIAXIS * (Math.abs(cosTheta) * cosTheta - Math.abs(sinTheta) * sinTheta));
        element.style.top = top + "px";
    }

    function moveDivs() {
        window.requestAnimFrame(moveDivs);

        for (var i = 0; i < ellipseDegreePositions.length; i++) {
            ellipseDegreePositions[i] += ELLIPSE_DEGREES_INCREMENT;
            if (ellipseDegreePositions[i] >= 360) {
                ellipseDegreePositions[i] = ellipseDegreePositions[i] % 360;
            }

            moveInEllipseOrbit(ellipseOrbitDivs[i], ellipseDegreePositions[i]);
        }

        for (var i = 0; i < rectangleDegreePositions.length; i++) {
            rectangleDegreePositions[i] += RECTANGLE_DEGREES_INCREMENT;
            if (rectangleDegreePositions[i] >= 360) {
                rectangleDegreePositions[i] = rectangleDegreePositions[i] % 360;
            }

            moveInRectangleOrbit(rectangularOrbitDivs[i], rectangleDegreePositions[i]);
        }
    }

    function generateDivElement(orbitType, top, left) {
        var div = document.createElement("div");
        div.setAttribute("class", "div-" + orbitType);

        div.style.backgroundColor = getRandomColor();
        div.style.color = getRandomColor();

        div.style.width = DIV_WIDTH + "px";
        div.style.height = DIV_HEIGHT + "px";

        var borderWidth = getRandomNumberInRange(1, 3);
        div.style.borderStyle = "solid";
        div.style.borderRadius = BORDER_RADIUS + "%";
        div.style.MozBorderRadius = BORDER_RADIUS + "%";
        div.style.WebkitBorderRadius = BORDER_RADIUS + "%";
        div.style.borderColor = getRandomColor();
        div.style.borderWidth = borderWidth + "px";

        div.style.position = "absolute";
        div.style.left = left + "px";
        div.style.top = top + "px";

        div.innerHTML = "<strong>DIV</strong>";
        div.style.textAlign = "center";

        return div;
    }

    function getRandomNumberInRange(min, max) {
        return ((Math.random() * (max - min + 1)) | 0) + min;
    }

    function getRandomColor() {
        var red = Math.random() * 256 | 0;
        var green = Math.random() * 256 | 0;
        var blue = Math.random() * 256 | 0;

        return "rgb(" + red + "," + green + "," + blue + ")";
    }

    function add(orbitType) {
        var newDiv;
        if (orbitType == "ellipse") {
            newDiv = generateDivElement("ellipse", ELLIPSE_CENTER_TOP, ELLIPSE_CENTER_LEFT);
            ellipseDegreePositions.push(0);
        } else if (orbitType == "rectangle") {
            newDiv = generateDivElement("rectangle", RECTANGLE_CENTER_TOP, RECTANGLE_CENTER_LEFT);
            rectangleDegreePositions.push(0);
        }

        var wrapper = document.getElementById("wrapper");
        wrapper.appendChild(newDiv);
    }

    return {
        add: add
    }
})();