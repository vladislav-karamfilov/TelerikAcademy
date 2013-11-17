(function (global) {
    var LoginViewModel,
        data = dataPersisters.get(),
        app = global.app = global.app || {};

    LoginViewModel = kendo.data.ObservableObject.extend({
        username: "",
        password: "",

        login: function () {
            var self = this;
            var username = self.get("username").trim();
            var password = self.get("password").trim();

            if (username === "" || password === "") {
                navigator.notification.vibrate(100);
                navigator.notification.alert("Both fields are required!", function () { }, "Login failed", 'OK');
                return;
            }

            try {
                data.user.login(username, password).then(function () {
                    app.application.navigate("views/latest-news.html#home-view");
                }, function (errorData) {
                    navigator.notification.vibrate(100);
                    navigator.notification.alert(errorData.responseText, function () { }, "Login failed", 'OK');
                });
            } catch (ex) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(ex, function () { }, "Login failed", 'OK');
            }
        },

        toRegister: function () {
            app.application.navigate("views/register.html#register-view");
        }
    });

    app.loginService = {
        viewModel: new LoginViewModel()
    };
})(window);