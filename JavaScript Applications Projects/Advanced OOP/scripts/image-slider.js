var ImageSlider = {
    init: function (images) {
        this.images = images;
        this._currentImageIndex = 0;
    },
    render: function (containerId) {
        var container, previousButton, nextButton;
        container = document.getElementById(containerId);

        previousButton = Object.create(SliderButton);
        previousButton.init("previous", "images/left-arrow.png");
        this._renderButton(previousButton, container);

        this._renderTumbnailImages(container);

        nextButton = Object.create(SliderButton);
        nextButton.init("next", "images/right-arrow.png");
        this._renderButton(nextButton, container);

        this._renderLargeImage(container);
    },
    _renderTumbnailImages: function (container) {
        var i, tumbnailsCount, tumbnailsContainer, liItem, imageItem;
        tumbnailsContainer = document.createElement("ul");
        tumbnailsCount = this.images.length;

        for (i = 0; i < tumbnailsCount; i++) {
            liItem = document.createElement("li");
            imageItem = document.createElement("img");
            imageItem.setAttribute("src", this.images[i].tumbnailUrl);
            imageItem.setAttribute("id", this.images[i].title);
            imageItem.className = "tumbnail";
            liItem.appendChild(imageItem);

            tumbnailsContainer.appendChild(liItem);
        }

        tumbnailsContainer.firstElementChild.firstElementChild.className = "current";
        container.appendChild(tumbnailsContainer);
    },
    _renderLargeImage: function (container) {
        var largeImageContainer, imageItem;
        largeImageContainer = document.createElement("div");
        imageItem = document.createElement("img");
        imageItem.setAttribute("id", "large-image");
        imageItem.setAttribute("src", this.images[this._currentImageIndex].largeImageUrl);

        largeImageContainer.appendChild(imageItem);
        container.appendChild(largeImageContainer);
    },
    _renderButton: function (button, container) {
        var self, buttonContainer;
        buttonContainer = document.createElement("img");
        buttonContainer.setAttribute("id", button.name);
        buttonContainer.setAttribute("src", button.imageSource);

        buttonContainer.addEventListener("mouseover", function () {
            this.style.cursor = "pointer";
        }, false);

        self = this;
        buttonContainer.addEventListener("click", function (ev) {
            var currentImage, currentSelected;

            if (!ev) {
                ev = window.event;
            }

            if (!ev.preventDefault) {
                ev.preventDefault();
            }

            if (ev.stopPropagation) {
                ev.stopPropagation();
            }

            if (this.id == "previous") {
                if (self._currentImageIndex > 0) {
                    self._currentImageIndex--;
                } else {
                    self._currentImageIndex = self.images.length - 1;
                }
            } else if (this.id == "next") {
                if (self._currentImageIndex < self.images.length - 1) {
                    self._currentImageIndex++;
                } else {
                    self._currentImageIndex = 0;
                }
            }

            currentSelected = document.getElementsByClassName("current")[0];
            currentSelected.className = "tumbnail";

            currentImage = document.getElementById("large-image");
            currentImage.setAttribute("src", self.images[self._currentImageIndex].largeImageUrl);

            currentSelected = document.getElementById(self.images[self._currentImageIndex].title);
            currentSelected.className = "current";
        }, false);

        container.appendChild(buttonContainer);
    }
};

var Image = {
    init: function (title, tumbnailUrl, largeImageUrl) {
        this.title = title;
        this.tumbnailUrl = tumbnailUrl;
        this.largeImageUrl = largeImageUrl;
    }
};

var SliderButton = {
    init: function (name, imageSource) {
        this.name = name;
        this.imageSource = imageSource;
    }
};