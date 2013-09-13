/// <reference path="../libs/_references.js" />

window.dataPersisters = (function () {
    var MainDataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.user = new UsersPersister(apiUrl + "users/");
            this.appointments = new AppointmentsPersister(apiUrl + "appointments/", this.user);
            this.todoLists = new TodoListsPersister(apiUrl + "lists/", this.user);
        },

        isUserLoggedIn: function () {
            return this.user.isUserLoggedIn();
        }
    });

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        register: function (username, email, password) {
            var self = this;
            var url = self.apiUrl + "register";
            var userData = {
                username: username,
                email: email,
                authCode: CryptoJS.SHA1(password).toString()
            };

            if (!username) {
                throw new Error("Username not provided!");
            }

            if (username.length < 6) {
                throw new Error("Username must be at least 6 symbols!");
            }

            if (!email) {
                throw new Error("Email not provided!");
            }

            if (!password) {
                //throw new Error("Password not provided!");
                throw "Password not provided";
            }

            return httpRequester.postJson(url, userData);
        },

        login: function (username, password) {
            var self = this;
            var url = "api/auth/token";
            var userData = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            if (!username) {
                throw new Error("Username not provided!");
            }

            if (username.length < 6) {
                throw new Error("Username must be at least 6 symbols!");
            }

            if (!password) {
                throw new Error("Password not provided!");
            }

            return httpRequester.postJson(url, userData).then(
                function (data) {
                    self._setDisplayName(data.username);
                    self._setAccessToken(data.accessToken);
                    return data;
                }, function (errorData) {
                    return errorData;
                });
        },

        logout: function () {
            var self = this;
            var url = self.apiUrl + "logout";
            var headers = {
                "X-accessToken": self._getAccessToken()
            };

            // TODO: Validate!!! accessToken only

            return httpRequester.putJson(url, null, headers).then(
                function () {
                    self._clearDisplayName();
                    self._clearAccessToken();
                }, function (errorData) {
                    return errorData;
                });
        },

        isUserLoggedIn: function () {
            return this._getDisplayName() != null && this._getAccessToken() != null;
        },

        getCurrentUserData: function () {
            return {
                displayName: this._getDisplayName(),
                accessToken: this._getAccessToken()
            };
        },

        _setDisplayName: function (value) {
            localStorage.setItem("displayName", value);
        },

        _setAccessToken: function (value) {
            localStorage.setItem("accessToken", value);
        },

        _getDisplayName: function () {
            return localStorage.getItem("displayName");
        },

        _getAccessToken: function () {
            return localStorage.getItem("accessToken");
        },

        _clearDisplayName: function () {
            localStorage.removeItem("displayName");
        },

        _clearAccessToken: function () {
            localStorage.removeItem("accessToken");
        }
    });

    var AppointmentsPersister = Class.create({
        init: function (apiUrl, userPersister) {
            this.apiUrl = apiUrl;
            this.user = userPersister;
        },

        create: function (subject, description, appointmentDate, duration) {
            if (!subject) {
                throw new Error("Subject not provided!");
            }

            if (!description) {
                throw new Error("Subject not provided!");
            }

            if (!appointmentDate) {
                throw new Error("Subject not provided!");
            }

            if (!duration) {
                throw new Error("Subject not provided!");
            }

            var url = this.apiUrl + "new";
            var appointment = {
                subject: subject,
                description: description,
                appointmentDate: appointmentDate,
                duration: duration
            };
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };

            return httpRequester.postJson(url, appointment, headers);
        },

        getAll: function () {
            var url = this.apiUrl + "all";
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };
            return httpRequester.getJson(url, headers);
        },

        getComming: function () {
            var url = this.apiUrl + "comming";
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };

            return httpRequester.getJson(url, headers);
        },

        getByDate: function (date) {
            if (!date) {
                throw new Error("Date not provided!");
            }

            var url = this.apiUrl + "?date=" + date;
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };

            return httpRequester.getJson(url, headers);
        },

        getForToday: function () {
            var url = this.apiUrl + "today";
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };

            return httpRequester.getJson(url, headers);
        },

        getCurrent: function () {
            var url = this.apiUrl + "current";
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };

            return httpRequester.getJson(url, headers);
        }
    });

    var TodoListsPersister = Class.create({
        init: function (apiUrl, userPesister) {
            this.apiUrl = apiUrl;
            this.user = userPesister;
        },

        getAll: function () {
            var url = this.apiUrl;
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };

            return httpRequester.getJson(url, headers);
        },

        create: function (title, todos) {
            if (!title) {
                throw new Error("Title not provided!");
            }

            var url = this.apiUrl;
            var todoList = {
                title: title,
                todos: todos
            };
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };

            return httpRequester.postJson(url, todoList, headers);
        },

        getTodos: function (listId) {
            var url = this.apiUrl + "/single?id=" + listId;
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };

            return httpRequester.getJson(url, headers);
        },

        addTodo: function (listId, todoText) {
            if (!todoText) {
                throw new Error("Todo text not provided!");
            }

            var url = this.apiUrl + listId + "/todos";
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };
            var todoData = {
                text: todoText
            };

            return httpRequester.postJson(url, todoData, headers);
        },

        changeStateOfTodo: function (todoId) {
            var url = "api/todos/" + todoId;
            var headers = {
                "X-accessToken": this.user.getCurrentUserData().accessToken
            };

            return httpRequester.putJson(url, null, headers);
        }
    });

    return {
        get: function (apiUrl) {
            return new MainDataPersister(apiUrl);
        }
    };
})();