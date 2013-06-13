var Slide = Class.create({
    initialize: function (content) {
        this.content = content;
    }
});

var Slider = Class.create({
    initialize: function (slides, changeAfterSec) {
        this.slides = slides;
        this.changeAfterSec = changeAfterSec;
        this._currentSlideIndex = 0;
    },
    addSlide: function (newSlide) {
        this.slides.push(newSlide);
    },
    render: function (containerSelector) {
        var self, container, slideContainer, buttonsContainer, prevButton, nextButton;

        self = this;

        setInterval(function () {
            if (self._currentSlideIndex < self.slides.length - 1) {
                self._currentSlideIndex++;
            } else {
                self._currentSlideIndex = 0;
            }

            slideContainer.html(self.slides[self._currentSlideIndex].content);
        }, self.changeAfterSec * 1000);

        slideContainer = $("<div></div>");
        slideContainer.attr("id", "slide-container");
        slideContainer.html(self.slides[self._currentSlideIndex].content);

        prevButton = $("<button>Previous</button>");
        prevButton.attr("id", "prev-button");
        prevButton.on("click", function () {
            if (self._currentSlideIndex > 0) {
                self._currentSlideIndex--;
            } else {
                self._currentSlideIndex = self.slides.length - 1;
            }

            slideContainer.html(self.slides[self._currentSlideIndex].content);
        });

        buttonsContainer = $("<div></div>");
        prevButton.appendTo(buttonsContainer);

        nextButton = $("<button>Next</button>");
        nextButton.attr("id", "next-button");
        nextButton.on("click", function () {
            if (self._currentSlideIndex < self.slides.length - 1) {
                self._currentSlideIndex++;
            } else {
                self._currentSlideIndex = 0;
            }

            slideContainer.html(self.slides[self._currentSlideIndex].content);
        });

        nextButton.appendTo(buttonsContainer);

        container = $(containerSelector);
        container.append(buttonsContainer);
        container.append(slideContainer);
    }
});