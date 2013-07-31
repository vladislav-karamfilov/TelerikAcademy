var CapitalsMap = Class.create({
    initialize: function (containerID, capitals) {
        this.container = document.getElementById(containerID);
        this.capitals = capitals;
        this._currentCapitalIndex = 0;
    },
    addCapital: function (newCapital) {
        this.capitals.push(newCapital);
    },
    render: function () {
        var self = this;

        var mapContainer = document.createElement("div");
        mapContainer.style.width = "640px";
        mapContainer.style.height = "480px";

        var mapOptions = {
            zoom: 5,
            center: new google.maps.LatLng(self.capitals[0].x, self.capitals[0].y),
            mapTypeId: google.maps.MapTypeId.TERRAIN
        };

        var map = new google.maps.Map(mapContainer, mapOptions);

        var marker = new google.maps.Marker({
            position: map.getCenter(),
            map: map,
            title: self.capitals[0].name
        });

        var infoBox = new google.maps.InfoWindow({
            map: map,
            position: map.getCenter(),
            content: self.capitals[0].info
        });

        var position = null;

        var previousButton = document.createElement("button");
        previousButton.innerHTML = "Previous";
        previousButton.setAttribute("id", "prev-button");
        previousButton.addEventListener("click", function (ev) {
            if (!ev) ev = window.event;

            if (!ev.preventDefault) ev.preventDefault();

            if (ev.stopPropagation) ev.stopPropagation();

            if (self._currentCapitalIndex > 0) {
                self._currentCapitalIndex--;
            } else {
                self._currentCapitalIndex = self.capitals.length - 1;
            }

            position = new google.maps.LatLng(self.capitals[self._currentCapitalIndex].x,
                self.capitals[self._currentCapitalIndex].y);
            map.panTo(position);
            marker.setPosition(position);
            marker.title = self.capitals[self._currentCapitalIndex].name;
            infoBox.setPosition(position);
            infoBox.setContent(self.capitals[self._currentCapitalIndex].info);
        });

        var buttonsContainer = document.createElement("div");
        buttonsContainer.appendChild(previousButton);

        var nextButton = document.createElement("button");
        nextButton.innerHTML = "Next";
        nextButton.setAttribute("id", "next-button");
        nextButton.addEventListener("click", function () {
            if (self._currentCapitalIndex < self.capitals.length - 1) {
                self._currentCapitalIndex++;
            } else {
                self._currentCapitalIndex = 0;
            }

            position = new google.maps.LatLng(self.capitals[self._currentCapitalIndex].x,
                self.capitals[self._currentCapitalIndex].y);
            map.panTo(position);
            marker.setPosition(position);
            marker.title = self.capitals[self._currentCapitalIndex].name;
            infoBox.setPosition(position);
            infoBox.setContent(self.capitals[self._currentCapitalIndex].info);
        });

        buttonsContainer.appendChild(nextButton);

        self.container.appendChild(buttonsContainer);
        self.container.appendChild(mapContainer);
    }
});

var Capital = Class.create({
    initialize: function (x, y, name, info) {
        this.x = x;
        this.y = y;
        this.name = name;
        this.info = info;
    }
});
