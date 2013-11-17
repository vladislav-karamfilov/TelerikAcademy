window.dataPersisters = (function () {
    var API_ROOT_URL = "http://localhost:12014/api/";

    var MainDataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.user = new UsersPersister(apiUrl + "users/");
            this.news = new NewsPersister(apiUrl + "newsArticles", this.user);
            this.categories = new CategoriesPersister(apiUrl + "categories", this.user);
        },

        isUserLoggedIn: function () {
            return this.user.isUserLoggedIn();
        }
    });

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        register: function (username, nickname, password) {
            var self = this;
            var url = self.apiUrl + "register";
            var userData = {
                username: username,
                nickname: nickname,
                authCode: CryptoJS.SHA1(password).toString()
            };

            if (!username) {
                throw "Username not provided!";
            }

            if (username.length < 6) {
                throw "Username must be at least 6 symbols!";
            }

            if (!nickname) {
                throw "Nickname not provided!";
            }

            if (!password) {
                throw "Password not provided";
            }

            return httpRequester.postJson(url, userData).then(function (data) {
                self._setDisplayName(data.nickname);
                self._setsessionKey(data.sessionKey);
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

            if (!username) {
                throw "Username not provided!";
            }

            if (username.length < 6) {
                throw "Username must be at least 6 symbols!";
            }

            if (!password) {
                throw "Password not provided!";
            }

            return httpRequester.postJson(url, userData).then(function (data) {
                self._setDisplayName(data.nickname);
                self._setsessionKey(data.sessionKey);
                return data;
            }, function (errorData) {
                return errorData;
            });
        },

        logout: function () {
            var self = this;
            var url = self.apiUrl + "logout";
            var headers = {
                "X-sessionKey": self._getsessionKey()
            };

            return httpRequester.putJson(url, null, headers).then(function () {
                self._clearDisplayName();
                self._clearsessionKey();
            }, function (errorData) {
                return errorData;
            });
        },

        isUserLoggedIn: function () {
            return this._getDisplayName() != null && this._getsessionKey() != null;
        },

        getCurrentUserData: function () {
            return {
                displayName: this._getDisplayName(),
                sessionKey: this._getsessionKey()
            };
        },

        _setDisplayName: function (value) {
            localStorage.setItem("displayName", value);
        },

        _setsessionKey: function (value) {
            localStorage.setItem("sessionKey", value);
        },

        _getDisplayName: function () {
            return localStorage.getItem("displayName");
        },

        _getsessionKey: function () {
            return localStorage.getItem("sessionKey");
        },

        _clearDisplayName: function () {
            localStorage.removeItem("displayName");
        },

        _clearsessionKey: function () {
            localStorage.removeItem("sessionKey");
        }
    });

    var CategoriesPersister = Class.create({
        init: function (apiUrl, userPersister) {
            this.apiUrl = apiUrl;
            this.user = userPersister;
        },

        getAllCategories: function () {
            var url = this.apiUrl + "/all";
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.getJson(url, headers);
        },

        create: function (categoryName) {
            if (!categoryName) {
                throw "Category name cannot be null or empty!";
            }

            if (categoryName.length > 200) {
                throw "Category name cannot be more than 200 characters long!";
            }

            var url = this.apiUrl + "/create";
            var data = {
                id: 0,
                category: categoryName
            };
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.postJson(url, data, headers);
        },

        getNews: function (categoryId) {
            var url = this.apiUrl + "/news/" + categoryId;
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.getJson(url, headers);
        }
    });

    var NewsPersister = Class.create({
        init: function (apiUrl, userPersister) {
            this.apiUrl = apiUrl;
            this.user = userPersister;
        },

        getById: function (id) {
            if (id === null || id === undefined) {
                throw "News article ID not provided!";
            }

            if (id <= 0) {
                throw "Invalid news article ID provided!";
            }

            var url = this.apiUrl + "/details/" + id;
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.getJson(url, headers);
        },

        create: function (title, content, imageUrl, categoryId, latitude, longitude) {
            if (!title) {
                throw "News title cannot be null or empty!";
            }

            if (title.length > 100) {
                throw "News title cannot be more than 100 characters long!";
            }

            if (!content) {
                throw "News content cannot be null or empty!";
            }

            if (categoryId <= 0) {
                throw "Invalid news category provided!";
            }

            var url = this.apiUrl + "/create";
            var newsArticle = {
                author: this.user._getDisplayName(),
                date: new Date(),
                title: title.trim(),
                content: content.trim(),
                image: imageUrl != null ? imageUrl.trim() : null,
                categoryId: categoryId,
                coordinates: (latitude != null && longitude != null) ? {
                    latitude: latitude,
                    longitude: longitude
                } : null
            };
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.postJson(url, newsArticle, headers);
        },

        getAllNews: function () {
            var url = this.apiUrl + "/all";
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.getJson(url, headers);
        },

        getLatestNews: function () {
            var url = this.apiUrl + "/latest";
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.getJson(url, headers);
        },

        getTopVotedNews: function () {
            var url = this.apiUrl + "/topVoted";
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.getJson(url, headers);
        },

        getComments: function (id) {
            if (id === null || id === undefined) {
                throw "News article ID not provided!";
            }

            if (id <= 0) {
                throw "Invalid news article ID provided!";
            }

            var url = this.apiUrl + "/comments/" + id;
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.getJson(url, headers);
        },

        comment: function (id, comment) {
            if (id === null || id === undefined) {
                throw "News article ID not provided!";
            }

            if (id <= 0) {
                throw "Invalid news article ID provided!";
            }

            if (!comment) {
                throw "Comment cannot be null or empty!";
            }

            if (comment.length > 500) {
                throw "Comment cannot be more than 500 characters long!";
            }

            var url = this.apiUrl + "/comment?id=" + id + "&comment=" + comment;
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.putJson(url, null, headers);
        },

        vote: function (id) {
            if (id === null || id === undefined) {
                throw "News article ID not provided!";
            }

            if (id <= 0) {
                throw "Invalid news article ID provided!";
            }

            var url = this.apiUrl + "/vote/" + id;
            var headers = {
                "X-sessionKey": this.user._getsessionKey()
            };

            return httpRequester.putJson(url, null, headers);
        }
    });

    return {
        get: function () {
            return new MainDataPersister(API_ROOT_URL);
        }
    };
})();