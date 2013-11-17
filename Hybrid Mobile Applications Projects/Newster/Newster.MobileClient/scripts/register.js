(function (global) {
    var RegisterViewModel,
        data = dataPersisters.get(),
        app = global.app = global.app || {};

    RegisterViewModel = kendo.data.ObservableObject.extend({
        username: "",
        nickname: "",
        password: "",

        register: function () {
            var self = this,
                username = self.get("username").trim(),
                password = self.get("password").trim(),
                nickname = self.get("nickname").trim();

            if (username === "" || password === "" || nickname === "") {
                navigator.notification.vibrate(100);
                navigator.notification.alert("All fields are required!", function () { }, "Register failed", 'OK');
                return;
            }

            try {
                data.user.register(username, nickname, password).then(function () {
                    app.application.navigate("views/latest-news.html#home-view");
                }, function (errorData) {
                    navigator.notification.vibrate(100);
                    navigator.notification.alert(errorData.responseText, function () { }, "Register failed", 'OK');
                });
            } catch (ex) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(ex, function () { }, "Register failed", 'OK');
            }
        },

        toLogin: function () {
            app.application.navigate('views/login.html#login-view');
        }
    });

    app.registerService = {
        viewModel: new RegisterViewModel()
    };
})(window);