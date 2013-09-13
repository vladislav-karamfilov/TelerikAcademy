/// <reference path="libs/_references.js" />

(function () {
    var PARTIALS_ROOT_PATH = "Scripts/partials/";
    var API_ROOT_URL = "/api/";

    var data = dataPersisters.get(API_ROOT_URL);
    var viewModelsFactory = viewModels.get(data);
    var viewsFactory = views.get(PARTIALS_ROOT_PATH);

    var layout = new kendo.Layout('<div id="content"></div>');
    var router = new kendo.Router();

    router.route("/", getHomeView);

    router.route("/home", getHomeView);

    router.route("/register", function () {
        viewsFactory.getRegister().then(function (registerFormHtml) {
            var registerViewModel = viewModelsFactory.getRegister(function () {
                router.navigate("/");
            }, function () {
                router.navigate("/error");
            });

            var registerView = new kendo.View(registerFormHtml, { model: registerViewModel });
            layout.showIn("#content", registerView);
        });
    });

    router.route("/login", function () {
        if (data.isUserLoggedIn()) {
            router.navigate("/");
        } else {
            viewsFactory.getLogin().then(function (loginFormHtml) {
                var loginViewModel = viewModelsFactory.getLogin(function () {
                    router.navigate("/");
                }, function () {
                    router.navigate("/error");
                });

                var loginView = new kendo.View(loginFormHtml, { model: loginViewModel });
                layout.showIn("#content", loginView);
            });
        }
    });

    router.route("/error", function () {
        viewsFactory.getError().then(function (errorViewHtml) {
            var errorView = new kendo.View(errorViewHtml);
            layout.showIn("#content", errorView);
        });
    });

    router.route("/logout", function () {
        data.user.logout().then(function () {
            router.navigate("/home");
        });
    });

    router.route("/appointments", function () {
        viewsFactory.getAppointments().then(function (appointmentsViewHtml) {
            viewModelsFactory.getAppointments().then(function (appointmentsViewModel) {
                var appointmentsView = new kendo.View(appointmentsViewHtml, { model: appointmentsViewModel });
                layout.showIn("#content", appointmentsView);
            });
        });
    });

    router.route("/appointments/comming", function () {
        viewsFactory.getAppointments().then(function (appointmentsViewHtml) {
            viewModelsFactory.getCommingAppointments(function () {
                router.navigate("/error");
            }).then(function (appointmentsViewModel) {
                var appointmentsView = new kendo.View(appointmentsViewHtml, { model: appointmentsViewModel });
                layout.showIn("#content", appointmentsView);
            });
        });
    });

    router.route("/appointments/today", function () {
        viewsFactory.getAppointments().then(function (appointmentsViewHtml) {
            viewModelsFactory.getTodaysAppointments(function () {
                router.navigate("/error");
            }).then(function (appointmentsViewModel) {
                var appointmentsView = new kendo.View(appointmentsViewHtml, { model: appointmentsViewModel });
                layout.showIn("#content", appointmentsView);
            });
        });
    });

    router.route("/appointments/current", function () {
        viewsFactory.getAppointments().then(function (appointmentsViewHtml) {
            viewModelsFactory.getCurrentAppointments(function () {
                router.navigate("/error");
            }).then(function (appointmentsViewModel) {
                var appointmentsView = new kendo.View(appointmentsViewHtml, { model: appointmentsViewModel });
                layout.showIn("#content", appointmentsView);
            });
        });
    });

    router.route("/appointments/date", function () {
        viewsFactory.getAppointments().then(function (appointmentsViewHtml) {
            viewModelsFactory.getAppointmentsForDate(function () {
                router.navigate("/error");
            }).then(function (appointmentsViewModel) {
                var appointmentsView = new kendo.View(appointmentsViewHtml, { model: appointmentsViewModel });
                layout.showIn("#content", appointmentsView);
            });
        });
    });

    router.route("/appointments/create", function () {
        viewsFactory.getAppointmentCreateForm().then(function (appointmentCreateViewHtml) {
            var appointmentCreateViewModel = viewModelsFactory.getAppointmentCreateViewModel(function () {
                router.navigate("/appointments");
            }, function () {
                router.navigate("/error");
            });

            var appointmentCreateView =
                new kendo.View(appointmentCreateViewHtml, { model: appointmentCreateViewModel });
            layout.showIn("#content", appointmentCreateView);
        });
    });

    router.route("/todo-lists", function () {
        viewsFactory.getTodoLists().then(function (todoListsViewHtml) {
            viewModelsFactory.getTodoLists().then(function (todoListsViewModel) {
                var todoListsView = new kendo.View(todoListsViewHtml, { model: todoListsViewModel });
                layout.showIn("#content", todoListsView);
            });
        });
    });

    router.route("/todo-list/:id", function (id) {
        viewsFactory.getTodoList(id).then(function (todoListViewHtml) {
            viewModelsFactory.getTodoList(id).then(function (todoListViewModel) {
                var todoListView = new kendo.View(todoListViewHtml, { model: todoListViewModel });
                layout.showIn("#content", todoListView);
            });
        });
    });

    router.route("/todos/create", function () {
        viewsFactory.getTodoCreateForm().then(function (todoCreateViewHtml) {
            var todoCreateViewModel = viewModelsFactory.getTodoCreateViewModel(function () {
                router.navigate("/todo-lists");
            }, function () {
                router.navigate("/error");
            });

            var todoCreateView =
                new kendo.View(todoCreateViewHtml, { model: todoCreateViewModel });
            layout.showIn("#content", todoCreateView);
        });
    });

    function getHomeView() {
        if (data.isUserLoggedIn()) {
            viewsFactory.getHomePage().then(function (homeViewHtml) {
                var homeView = new kendo.View(homeViewHtml);
                layout.showIn("#content", homeView);
            });
        } else {
            router.navigate("/login");
        }
    }

    $(function () {
        layout.render($("#app"));
        router.start("/login");
    });
})();
