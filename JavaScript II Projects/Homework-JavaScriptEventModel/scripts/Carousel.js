var carouselModule = (function myfunction() {
    var CAROUSEL_WIDTH = 640;
    var CAROUSEL_HEIGHT = 480;
    var SLIDE_BUTTON_WIDTH = 50;
    var SLIDE_BUTTON_HEIGHT = 50;

    function Carousel(containerID, imagesSources) {
        this.container = document.getElementById(containerID);
        this.container.style.width = CAROUSEL_WIDTH + "px";
        this.container.style.height = CAROUSEL_HEIGHT + "px";

        this.images = imagesSources;

        this.currentImage = 0;
    }


    Carousel.prototype.load = function () {
        var self = this;
        if (self.images.length > 0) {
            var image = document.createElement("img");
            image.setAttribute("src", self.images[0]);
            image.setAttribute("alt", "picture");
            self.container.appendChild(image);

            var slideButtons = getSlideButtons();

            addEventListener(slideButtons[0], "click", function () {
                if (self.currentImage > 0) {
                    self.currentImage--;
                    self.container.firstChild.setAttribute("src", self.images[self.currentImage]);
                }
            });

            addEventListener(slideButtons[1], "click", function () {
                if (self.currentImage < self.images.length - 1) {
                    self.currentImage++;
                    self.container.firstChild.setAttribute("src", self.images[self.currentImage]);
                }
            });

            self.container.appendChild(slideButtons[0]);
            self.container.appendChild(slideButtons[1]);
        }
    }

    Carousel.prototype.addImage = function (imageSource) {
        this.images.push(imageSource);
    }

    function getSlideButtons() {
        var slideButtons = [];

        var left = document.createElement("button");
        left.innerHTML = "<strong>&lt;</strong>";
        left.id = "left-slider";
        left.style.borderRadius = "50%";
        left.style.width = SLIDE_BUTTON_WIDTH + "px";
        left.style.height = SLIDE_BUTTON_HEIGHT + "px";
        left.style.cssFloat = "left";
        left.style.cursor = "pointer";
        left.style.backgroundColor = "#00ff21";
        slideButtons.push(left);

        var right = document.createElement("button");
        right.innerHTML = "<strong>&gt;</strong>";
        right.id = "right-slider";
        right.style.borderRadius = "50%";
        right.style.width = SLIDE_BUTTON_WIDTH + "px";
        right.style.height = SLIDE_BUTTON_HEIGHT + "px";
        right.style.cssFloat = "right";
        right.style.cursor = "pointer";
        right.style.backgroundColor = "#00ff21";
        slideButtons.push(right);

        return slideButtons;
    }

    function addEventListener(element, eventType, eventHandler) {
        if (element) {
            if (document.addEventListener) {
                element.addEventListener(eventType, eventHandler, false);
            } else if (document.attachEvent) {
                element.attachEvent("on" + eventType, eventHandler);
            } else {
                element['on' + eventType] = eventHandler;
            }
        }
    }

    return {
        Carousel: Carousel
    }
})();