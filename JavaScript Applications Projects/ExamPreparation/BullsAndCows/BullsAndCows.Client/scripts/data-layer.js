/// <reference path="cryptojs-sha1.js" />
/// <reference path="http-requester.js" />
/// <reference path="class.js" />
/// <reference path="jquery-2.0.2.js" />

var DataLayer = (function () {
    var DataPersister = Class.create({
        init: function (serviceRootUrl) {
            this.serviceRootUrl = serviceRootUrl;

            this.user = new UserPersister(serviceRootUrl + "user/");
            this.games = new GamePersister(serviceRootUrl + "game/", this.user);
            this.guesses = new GuessPersister(serviceRootUrl + "guess/", this.user);
            this.messages = new MessagesPersister(serviceRootUrl + "messages/", this.user);
        },

        isUserLoggedIn: function () {
            return this.user.isUserLoggedIn();
        }
    });

    var UserPersister = Class.create({
        init: function (serviceRootUrl) {
            this.serviceRootUrl = serviceRootUrl;
        },

        register: function (username, nickname, password, success, error) {
            var self = this;
            var url = self.serviceRootUrl + "register";
            var userData = {
                username: username,
                nickname: nickname,
                authCode: CryptoJS.SHA1(username + password).toString()
            };

            return HttpRequester.postJSON(url, userData, function (data) {
                self._setUsername(username);
                self._setNickname(data.nickname);
                self._setSessionKey(data.sessionKey);
                success(data);
            }, error);
        },

        login: function (username, password, success, error) {
            var self = this;
            var url = self.serviceRootUrl + "login";
            var userData = {
                username: username,
                authCode: CryptoJS.SHA1(username + password).toString()
            };

            return HttpRequester.postJSON(url, userData, function (data) {
                self._setUsername(username);
                self._setNickname(data.nickname);
                self._setSessionKey(data.sessionKey);
                success(data);
            }, error);
        },

        logout: function (success, error) {
            var self = this;
            var url = self.serviceRootUrl + "logout/" + self._getSessionKey();
            return HttpRequester.getJSON(url, function () {
                self._clearUsername();
                self._clearNickname();
                self._clearSessionKey();
                success();
            }, error);
        },

        getScores: function (success, error) {
            var url = this.serviceRootUrl + "scores/" + this._getSessionKey();
            return HttpRequester.getJSON(url, success, error);
        },

        isUserLoggedIn: function () {
            return this._getUsername() != null && this._getNickname() != null;
        },

        getCurrentUserData: function () {
            return {
                username: this._getUsername(),
                nickname: this._getNickname(),
                sessionKey: this._getSessionKey()
            }
        },

        _setUsername: function (value) {
            this.username = value;
            localStorage.setItem("username", value);
        },

        _setNickname: function (value) {
            this.nickname = value;
            localStorage.setItem("nickname", value);
        },

        _setSessionKey: function (value) {
            localStorage.setItem("sessionKey", value);
        },

        _getUsername: function () {
            return localStorage.getItem("username");
        },

        _getNickname: function () {
            return localStorage.getItem("nickname");
        },

        _getSessionKey: function () {
            return localStorage.getItem("sessionKey");
        },

        _clearUsername: function () {
            this.username = null;
            localStorage.removeItem("username");
        },

        _clearNickname: function () {
            this.nickname = null;
            localStorage.removeItem("nickname");
        },

        _clearSessionKey: function () {
            localStorage.removeItem("sessionKey");
        }
    });

    var GamePersister = Class.create({
        init: function (serviceRootUrl, userPersister) {
            this.serviceRootUrl = serviceRootUrl;
            this.userPersister = userPersister;
        },

        create: function (gameTitle, number, gamePassword, success, error) {
            var gameOptions = {
                title: gameTitle,
                number: number,
            };

            if (gamePassword) {
                gameOptions.password = CryptoJS.SHA1(gamePassword).toString();
            }

            var url = this.serviceRootUrl + "create/" + this.userPersister.getCurrentUserData().sessionKey;
            return HttpRequester.postJSON(url, gameOptions, success, error);
        },

        join: function (gameTitle, number, gamePassword, success, error) {
            var gameOptions = {
                title: gameTitle,
                number: number,
            };

            if (gamePassword) {
                gameOptions.password = CryptoJS.SHA1(gamePassword).toString();
            }

            var url = this.serviceRootUrl + "join/" + this.userPersister.getCurrentUserData().sessionKey;
            return HttpRequester.postJSON(url, gameOptions, success, error);
        },

        start: function (gameID, success, error) {
            var url = this.serviceRootUrl + gameID + "/start/" + this.userPersister.getCurrentUserData().sessionKey;
            return HttpRequester.getJSON(url, success, error);
        },

        getOpen: function (success, error) {
            var url = this.serviceRootUrl + "open/" + this.userPersister.getCurrentUserData().sessionKey;
            return HttpRequester.getJSON(url, success, error);
        },

        getCurrentUserActive: function (success, error) {
            var url = this.serviceRootUrl + "my-active/" + this.userPersister.getCurrentUserData().sessionKey;
            return HttpRequester.getJSON(url, success, error);
        },

        getState: function (gameID, success, error) {
            var url = this.serviceRootUrl + gameID + "/state/" + this.userPersister.getCurrentUserData().sessionKey;
            return HttpRequester.getJSON(url, success, error);
        }
    });

    var GuessPersister = Class.create({
        init: function (serviceRootUrl, userPersister) {
            this.serviceUrl = serviceRootUrl;
            this.userPersister = userPersister;
        },

        make: function (number, gameID, success, error) {
            var url = this.serviceRootUrl + "make/" + this.userPersister.getCurrentUserData().sessionKey;
            var guessData = {
                number: number,
                gameId: gameID
            };

            return HttpRequester.postJSON(url, guessData, success, error);
        }
    });

    var MessagesPersister = Class.create({
        init: function (serviceRootUrl, userPersister) {
            this.serviceRootUrl = serviceRootUrl;
            this.userPersister = userPersister;
        },

        getUnread: function (success, error) {
            var url = this.serviceRootUrl + "unread/" + this.userPersister.getCurrentUserData().sessionKey;
            return HttpRequester.getJSON(url, success, error);
        },

        getAll: function (success, error) {
            var url = this.serviceRootUrl + "all/" + this.userPersister.getCurrentUserData().sessionKey;
            return HttpRequester.getJSON(url, success, error);
        }
    });

    return {
        getDataPersister: function (serviceRootUrl) {
            return new DataPersister(serviceRootUrl);
        }
    }
}());

var pers = DataLayer.getDataPersister("http://localhost:40643/api/");
//pers.games.create("SomeTitle", 5921, "password", function (data) {
//    console.log("done");
//}, function (data) {
//    console.log(data);
//});

//pers.games.join("SomeTitle", 2513, "password", function () {
//    console.log("joined");
//}, function () {
//    console.log("not joined");
//});