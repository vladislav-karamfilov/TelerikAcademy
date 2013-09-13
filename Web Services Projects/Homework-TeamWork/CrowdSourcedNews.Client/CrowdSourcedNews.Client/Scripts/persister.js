var persisters = (function () {

    var storeData = function (data) {
        localStorage.setItem("sessionKey", data.sessionKey);
        localStorage.setItem("nickname", data.nickname);
    };

    var clearData = function () {
        localStorage.removeItem("sessionKey");
        localStorage.removeItem("nickname");
    };

    var getSessionKey = function () {
        return localStorage.getItem("sessionKey");
    };

    var getNickname = function () {
        return localStorage.getItem("nickname");
    };

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
            this.articles = new NewsArticlePersister(this.rootUrl);
            this.comment = new CommentPersister(this.rootUrl);
            this.getNickName = getNickname;
        },
        isLoggedIn: function () {
            return !!(getSessionKey() && getNickname());
        }
    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + 'users/';
        },
        login: function (user, success, error) {
            var url = this.rootUrl + 'login/';
            var userData =
            {
                username: user.username,
                authCode: CryptoJS.SHA1(user.password).toString()
            };

            httpRequester.postJson(url, userData,
                function (data) {
                    storeData(data);
                    success(data);
                },
                function (data) {
                    error(data);
                });
        },
        register: function (user, success, error) {
            var url = this.rootUrl + 'register/';
            var userData =
            {
                username: user.username,
                authCode: CryptoJS.SHA1(user.password).toString(),
                nickname: user.nickname
            };

            httpRequester.postJson(url, userData,
                 function (data) {
                     storeData(data);
                     success(data);
                 },
                function (data) {
                    error(data);
                });
        },
        logout: function (success, error) {
            var url = this.rootUrl + "logout/" + getSessionKey();
            httpRequester.getJson(url,
                function (data) {
                    clearData();
                    success(data);
                },
                function (data) {
                    error(data);
                });

        },
        myArticles: function (success, error) {
            var url = this.rootUrl + "newsArticles/" + getSessionKey();
            httpRequester.getJson(url, success, error);
        }
    });

    var NewsArticlePersister = Class.create({
        init: function (serviceRootUrl, userPersister) {
            this.serviceRootUrl = serviceRootUrl + "newsarticles/";
            this.user = userPersister;
        },

        getArticle: function (articleID, success, error) {
            var currentSessionKey = getSessionKey();
            httpRequester.getJson(this.serviceRootUrl + articleID + "/get/" + currentSessionKey, success, error);
        },

        getAllArticles: function (success, error) {
            var currentSessionKey = getSessionKey();

            httpRequester.getJson(this.serviceRootUrl + "get/" + currentSessionKey, success, error);
        },

        add: function (title, content, author) {
            var currentSessionKey = getSessionKey();

            var articleAddData = {
                title: title,
                content: content,
                date: new Date(),
                author: author,
                rating: 0
            };

            httpRequester.postJson(this.serviceRootUrl + "add/" + currentSessionKey, articleAddData, function (data) { return data });
        },

        edit: function (newsArticleID, content) {
            var currentSessionKey = getSessionKey();

            var articleEditData = {
                newsArticleID: newsArticleID,
                content: content,
            };

            httpRequester.postJson(this.serviceRootUrl + "edit/" + currentSessionKey, articleEditDat, function (data) { return data });
        },

        remove: function (newsArticleID) {
            var currentSessionKey = getSessionKey();

            var articleDeleteData = {
                newsArticleID: newsArticleID
            };

            httpRequester.postJson(this.serviceRootUrl + "remove/" + currentSessionKey, articleDeleteData, function (data) { return data });
        }
    });

    var CommentPersister = Class.create({

        init: function (serviceRootUrl, userPersister) {
            this.serviceRootUrl = serviceRootUrl + "comments/";
            this.userPersister = userPersister;
        },

        add: function (content, articleId, success) {
            var currentSessionKey = getSessionKey();

            var commentAddData = {
                content: content,
                date: new Date(),
                articleId: articleId
            };

            httpRequester.postJson(this.serviceRootUrl + "add/" + currentSessionKey, commentAddData, success);
        },

        edit: function (commentID, content) {
            var currentSessionKey = getSessionKey();

            var commentEditData = {
                commentID: commentID,
                content: content
            };

            httpRequester.postJson(this.serviceRootUrl + "edit/" + currentSessionKey, commentEditData, function (data) { return data });
        },

        remove: function (commentID) {
            var currentSessionKey = getSessionKey();

            var commentDeleteData = {
                commentID: commentID
            };

            httpRequester.postJson(this.serviceRootUrl + "remove/" + currentSessionKey, commentDeleteData, function (data) { return data });
        }
    });

    return {
        getPersister: function (rootUrl) {
            return new MainPersister(rootUrl);
        }
    };
}());