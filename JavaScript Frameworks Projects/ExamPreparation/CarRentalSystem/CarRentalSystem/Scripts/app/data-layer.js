/// <reference path="../libs/_references.js" />

window.dataPersisters = (function () {
    var MainDataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.user = new UsersPersister(apiUrl + "users/");
            this.cars = new CarsPersister(apiUrl + "cars/", this.user);
            this.carStores = new CarStoresPersister(apiUrl + "carStores/", this.user);
        },

        isUserLoggedIn: function () {
            return this.user.isUserLoggedIn();
        }
    });

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        register: function (username, displayName, password) {
            var self = this;
            var url = self.apiUrl + "register";
            var userData = {
                username: username,
                displayName: displayName,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return httpRequester.postJson(url, userData).then(
                function (data) {
                    self._setDisplayName(data.displayName);
                    self._setSessionKey(data.sessionKey);
                    return data;
                }, function (errorData) {
                    return errorData;
                });
        },

        login: function (username, password) {
            var self = this;
            var url = self.apiUrl + "login";
            var userData = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return httpRequester.postJson(url, userData).then(
                function (data) {
                    self._setDisplayName(data.displayName);
                    self._setSessionKey(data.sessionKey);
                    return data;
                }, function (errorData) {
                    return errorData;
                });
        },

        logout: function () {
            var self = this;
            var url = self.apiUrl + "logout";
            var headers = {
                "X-sessionKey": self._getSessionKey()
            };

            return httpRequester.putJson(url, null, headers).then(
                function () {
                    self._clearDisplayName();
                    self._clearSessionKey();
                }, function (errorData) {
                    return errorData;
                });
        },

        isUserLoggedIn: function () {
            return this._getDisplayName() != null && this._getSessionKey() != null;
        },

        getCurrentUserData: function () {
            return {
                displayName: this._getDisplayName(),
                sessionKey: this._getSessionKey()
            };
        },

        _setDisplayName: function (value) {
            localStorage.setItem("displayName", value);
        },

        _setSessionKey: function (value) {
            localStorage.setItem("sessionKey", value);
        },

        _getDisplayName: function () {
            return localStorage.getItem("displayName");
        },

        _getSessionKey: function () {
            return localStorage.getItem("sessionKey");
        },

        _clearDisplayName: function () {
            localStorage.removeItem("displayName");
        },

        _clearSessionKey: function () {
            localStorage.removeItem("sessionKey");
        }
    });

    var CarsPersister = Class.create({
        init: function (apiUrl, userPersister) {
            this.apiUrl = apiUrl;
            this.user = userPersister;
        },

        getAll: function () {
            var url = this.apiUrl + "all";
            return httpRequester.getJson(url);
        },

        getById: function (id) {
            var url = this.apiUrl + "all/" + id;
            return httpRequester.getJson(url);
        },

        getPage: function (page, count) {
            var url = this.apiUrl.substring(0, this.apiUrl.length - 1) + "?page=" + page + "&count=" + count;
            var headers = {
                "X-sessionKey": this.user.getCurrentUserData().sessionKey
            };

            return httpRequester.getJson(url, headers);
        },

        getMyRented: function () {
            var url = this.apiUrl + "rented";
            var headers = {
                "X-sessionKey": this.user.getCurrentUserData().sessionKey
            };

            return httpRequester.getJson(url, headers);
        },

        rentCar: function (carId) {
            var url = this.apiUrl + "rent/" + carId;
            var headers = {
                "X-sessionKey": this.user.getCurrentUserData().sessionKey
            };

            return httpRequester.putJson(url, null, headers).then(function (renter) {
                return renter;
            });
        },

        returnCar: function (carId) {
            var url = this.apiUrl + "return/" + carId;
            var headers = {
                "X-sessionKey": this.user.getCurrentUserData().sessionKey
            };

            return httpRequester.putJson(url, null, headers);
        }
    });

    var CarStoresPersister = Class.create({
        init: function (apiUrl, userPesister) {
            this.apiUrl = apiUrl;
            this.user = userPesister;
        },

        getAll: function (userLatitude, userLongitude) {
            var url = this.apiUrl + "/all" +
			    "?latitude=" + userLatitude + "&longitude=" + userLongitude;
            var headers = {
                "X-sessionKey": this.user.getCurrentUserData().sessionKey
            };

            return httpRequester.getJson(url, headers);
        },

        getById: function (id) {
            var url = this.apiUrl + "/all?carStoreId=" + id;
            var headers = {
                "X-sessionKey": this.user.getCurrentUserData().sessionKey
            };

            return httpRequester.getJson(url, headers);
        },

        getCars: function (carStoreId) {
            var url = this.apiUrl + "cars?carStoreId=" + carStoreId;
            var headers = {
                "X-sessionKey": this.user.getCurrentUserData().sessionKey
            };

            return httpRequester.getJson(url, headers);
        }
    });

    return {
        get: function (apiUrl) {
            return new MainDataPersister(apiUrl);
        }
    };
})();