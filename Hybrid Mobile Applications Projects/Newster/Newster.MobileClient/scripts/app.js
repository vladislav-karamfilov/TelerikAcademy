(function (global) {
    var app = global.app = global.app || {},
        isUserLoggedIn = dataPersisters.get().user.isUserLoggedIn();

    function onDeviceReady() {
        app.application = new kendo.mobile.Application(document.body, {
            initial: isUserLoggedIn ? "views/latest-news.html#home-view" : "views/login.html#login-view",
            skin: "flat"
        });

        document.addEventListener("backbutton", function () {
            history.go(-1);
        }, false);

        if (navigator.app) { // The device is using Android
            $("#back-btn").hide();
        }

        document.addEventListener("batterycritical", function (ev) {
            if (!ev.isPlugged) {
                navigator.notification.alert(
                    "Your battery level is critical! Please plug your device for charging and start the application again...",
                    function () {
                        if (navigator.app) {
                            navigator.app.exitApp();
                        }
                    },
                    "Critical battery level!",
                    "OK");
            }
        }, false);

        document.addEventListener("offline", function () {
            navigator.notification.alert(
                "You do not have access to Internet! Try reconnecting again...",
                function () { },
                "No Internet connection!",
                "OK");
        }, false);
    }

    document.addEventListener("deviceready", onDeviceReady, false);
})(window);