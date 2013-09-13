/// <reference path="class.js" />
/// <reference path="http-requester.js" />
/// <reference path="cryptojs-sha1.js" />
/// <reference path="q.js" />

CrowdSourcedNews.Data = (function () {
    var DataPersister = Class.create({
        init: function (serviceRootUrl) {
            this.serviceRootUrl = serviceRootUrl;

            this.user = new UserPersister(serviceRootUrl);

            this.newsArticle = new NewsArticlePersister(serviceRootUrl);

            this.comment = new CommentPersister(serviceRootUrl);
        }
    });
    var UserPersister = Class.create({
        init: function (serviceRootUrl) {
            this.serviceRootUrl = serviceRootUrl;
        },

        register: function (username, nickname, password) {
            var self = this;

            return HttpRequester.postJson(this.serviceRootUrl + "register", {
                username: username,
                nickname: nickname,
                authCode: CryptoJS.SHA1(password).toString() 
            }).then(function (result) {
                self._setSessionKey(result.sessionKey),
                self._setNickname(result.nickname);
                self._setUsername(username);
            })
        },
        
        login: function(username, password) {
            var self = this;

            return HttpRequester.postJson(this.serviceRootUrl + "login", {
                username: username,
                authCode: CryptoJS.SHA1(password).toString(),
            }).then(function (result) {
                self._setSessionKey(result.sessionKey);
                self._setNickname(result.nickname);
                self._setUsername(username);
            });
        },

        logout: function () {
            var self = this;

            return HttpRequester.getJson(this.serviceRootUrl + "logout/" + this._getSessionKey())
                .then(function () {
                    self._clearSessionKey();
                    self._clearNickname();
                    self._clearUsername();
                });
        },

        isUserLoggedIn: function () {
            return (this._getNickname() !== null);
        },

        getCurrentUserData: function () {
            return {
                username: this._getUsername(),
                nickname: this._getNickname(),
                sessionKey: this._getSessionKey()
            }
        },

        _getSessionKey: function () {
            return localStorage.getItem("sessionKey");
        },

        _getNickname: function () {
            return localStorage.getItem("nickname");
        },

        _getUsername: function(){
            return localStorage.getItem("username");
        },

        _setSessionKey: function (value) {
            localStorage.setItem("sessionKey", value);
        },

        _setNickname: function (value) {
            this.nickname = value;
            localStorage.setItem("nickname", value);
        },

        _setUsername: function(value){
            this.username = value;
            localStorage.setItem("username", value);
        },

        _clearSessionKey: function () {
            localStorage.removeItem("sessionKey");
        },

        _clearNickname: function () {
            localStorage.removeItem("nickname");
        },

        _clearUsername: function(){
            localStorage.removeItem("username");
        },
    });

    var NewsArticlePersister = Class.create({
        init: function (serviceRootUrl, userPersister) {
            this.serviceRootUrl = serviceRootUrl,
            this.userPersister = userPersister
        },



        getArticle: function(articleID) {
            var currentSessionKey = this.userPersister.getCurrentUserData.sessionKey;         

            return HttpRequester.getJson(this.serviceRootUrl + articleID + "/get/" + currentSessionKey).
                then(function (result) {
                    return result;
                });
        },

        getAllArticles : function() {
            var currentSessionKey = this.userPersister.getCurrentUserData.sessionKey;

            return HttpRequester.getJson(this.serviceRootUrl + "get/" + currentSessionKey).
                then(function (result) {
                    return result;
                });
        },

        add: function (title, content, date) {
            var currentSessionKey = this.userPersister.getCurrentUserData.sessionKey;

            var articleAddData = {
                title: title,
                content: content,
                date: date
            };

            return HttpRequester.postJson(this.serviceRootUrl + "add/" + currentSessionKey, articleAddData);
        },

        edit: function (newsArticleID, content) {
            var currentSessionKey = this.userPersister.getCurrentUserData.sessionKey;

            var articleEditData = {
                newsArticleID: newsArticleID,
                content: content,
            };

            return HttpRequester.postJson(this.serviceRootUrl + "edit/" + currentSessionKey, articleEditData);
        },

        remove: function (newsArticleID) {
            var currentSessionKey = this.userPersister.getCurrentUserData.sessionKey;

            var articleDeleteData = {
                newsArticleID: newsArticleID
            };

            return HttpRequester.postJson(this.serviceRootUrl + "remove/" + currentSessionKey, articleDeleteData).result;
        }
    });

    var CommentPersister = Class.create({

        init: function (serviceRootUrl, userPersister) {
            this.serviceRootUrl = serviceRootUrl;
            this.userPersister = userPersister;
        },

        add: function (content, date, isNested) {
            var currentSessionKey = this.userPersister.getCurrentUserData.sessionKey;

            var commentAddData = {
                content: content,
                date: date,
                isNested: isNested
            };

            return HttpRequester.postJson(this.serviceRootUrl + "add/" + currentSessionKey, commentAddData);
        },

        edit: function (commentID, content) {
            var currentSessionKey = this.userPersister.getCurrentUserData.sessionKey;

            var commentEditData = {
                commentID: commentID,
                content: content
            };

            return HttpRequester.postJson(this.serviceRootUrl + "edit/" + currentSessionKey, commentEditData);
        },

        remove: function (commentID) {
        var currentSessionKey = this.userPersister.getCurrentUserData.sessionKey;

        var commentDeleteData = {
            commentID: commentID
        };

        return HttpRequester.postJson(this.serviceRootUrl + "remove/" + currentSessionKey, commentDeleteData);
    }
    });

    return {
        getDataPersister: function(serviceRootUrl) { return new DataPersister(serviceRootUrl); }
    };
})();