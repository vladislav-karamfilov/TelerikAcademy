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
                });

                var loginView = new kendo.View(loginFormHtml, { model: loginViewModel });
                layout.showIn("#content", loginView);
            });
        }
    });

    router.route("/logout", function () {
        data.user.logout().then(function () {
            router.navigate("/home");
        });
    });

    router.route("/cars/rented", function () {
        viewsFactory.getCars().then(function (carsViewHtml) {
            viewModelsFactory.getRentedCars().then(function (carsViewModel) {
                var carsView = new kendo.View(carsViewHtml, { model: carsViewModel });
                layout.showIn("#content", carsView);
            });
        });
    });

    router.route("/cars/:id", function (id) {
        viewsFactory.getCar().then(function (carViewHtml) {
            viewModelsFactory.getCar(id).then(function (carViewModel) {
                var carView = new kendo.View(carViewHtml, { model: carViewModel });
                layout.showIn("#content", carView);
            });
        });
    });

    router.route("/car-stores", function () {
        viewsFactory.getCarStores().then(function (carStoresViewHtml) {
            viewModelsFactory.getCarStores().then(function (carStoresViewModel) {
                var carStoresView = new kendo.View(carStoresViewHtml, { model: carStoresViewModel });
                layout.showIn("#content", carStoresView);
            });
        });
    });

    router.route("/car-stores/:id", function (id) {
        viewsFactory.getCarStore().then(function (carStoreViewHtml) {
            viewModelsFactory.getCarStore(id).then(function (carStoreViewModel) {
                console.log(carStoreViewModel)
                var carStoreView = new kendo.View(carStoreViewHtml, { model: carStoreViewModel });
                layout.showIn("#content", carStoreView);
            });
        });
    });

    function getHomeView() {
        viewsFactory.getCars().then(function (carsViewHtml) {
            viewModelsFactory.getCars().then(function (carsViewModel) {
                var carsView = new kendo.View(carsViewHtml, { model: carsViewModel });
                layout.showIn("#content", carsView);
            });
        });
    }

    $(function () {
        layout.render($("#app"));
        router.start("/login");
    });
})();
