/// <reference path="../libs/_references.js" />

window.viewModels = (function () {
    var ViewModels = Class.create({
        init: function (dataPersister) {
            this.data = dataPersister;
        },

        getRegister: function (successCallback) {
            var self = this;
            var registerViewModel = {
                username: null,
                password: null,
                displayName: null,
                errorMessage: null,
                register: function (ev) {
                    var selfViewModel = this;
                    return self.data.user.register(
                        selfViewModel.get("username"), selfViewModel.get("displayName"), selfViewModel.get("password"))
                    .then(successCallback, function (errorData) {
                        selfViewModel.set("errorMessage", errorData.responseJSON.Message);
                        alert(selfViewModel.get("errorMessage"));
                    });
                }
            };

            return kendo.observable(registerViewModel);
        },

        getLogin: function (successCallback) {
            var self = this;
            var loginViewModel = {
                username: null,
                password: null,
                errorMessage: null,
                login: function (ev) {
                    var selfViewModel = this;
                    return self.data.user.login(
                        selfViewModel.get("username"), selfViewModel.get("password"))
                    .then(successCallback, function (errorData) {
                        selfViewModel.set("errorMessage", errorData.responseJSON.Message);
                        alert(selfViewModel.get("errorMessage"));
                    });
                }
            };

            return kendo.observable(loginViewModel);
        },

        getCars: function () {
            var carsViewModel = {
                cars: null,
                errorMessage: null
            };

            return this.data.cars.getAll().then(function (cars) {
                carsViewModel.cars = cars;
                return kendo.observable(carsViewModel);
            }, function (errorData) {
                carsViewModel.errorMessage = errorData.responseJSON.Message;
                alert(carsViewModel.errorMessage);
                return kendo.observable(carsViewModel);
            });
        },

        getCar: function (id) {
            var self = this;
            var carViewModel = {
                car: null,
                errorMessage: null,
                rentCar: function (ev) {
                    var selfViewModel = this;
                    if (!selfViewModel.get("car").renter) {
                        self.data.cars.rentCar(selfViewModel.get("car").id).then(function (renter) {
                            alert("The car is successfully rented!");
                            selfViewModel.get("car").set("renter", renter);
                        });
                    } else {
                        alert("The car cannot be rented because it is already rented!");
                    }
                },
                returnCar: function (ev) {
                    var selfViewModel = this;
                    if (selfViewModel.get("car").renter) {
                        self.data.cars.returnCar(selfViewModel.get("car").id).then(function () {
                            selfViewModel.get("car").set("renter", null);
                            alert("The car is successfully returned!");
                        });
                    } else {
                        alert("The car cannot be returned because it is not rented!");
                    }
                }
            };

            return this.data.cars.getById(parseInt(id)).then(function (car) {
                carViewModel.car = car;
                return kendo.observable(carViewModel);
            }, function (errorData) {
                carViewModel.errorMessage = errorData.responseJSON.Message;
                alert(carViewModel.errorMessage);
                return kendo.observable(carViewModel);
            });
        },

        getRentedCars: function () {
            var carsViewModel = {
                cars: null,
                errorMessage: null
            };

            return this.data.cars.getMyRented().then(function (cars) {
                carsViewModel.cars = cars;
                return kendo.observable(carsViewModel);
            }, function (errorData) {
                carsViewModel.errorMessage = errorData.responseJSON.Message;
                alert(carsViewModel.errorMessage);
                return kendo.observable(carsViewModel);
            });
        },

        getCarStores: function () {
            var self = this;
            var carStoresViewModel = {
                carStores: null,
                errorMessage: null
            };

            return self._getLocation().then(function (currentLocation) {
                var latitude = currentLocation.coords.latitude;
                var longitude = currentLocation.coords.longitude;

                return self.data.carStores.getAll(latitude, longitude).then(function (carStores) {
                    carStoresViewModel.carStores = carStores;
                }, function (errorData) {
                    carStoresViewModel.errorMessage = errorData.responseJSON.Message;
                    alert(carStoresViewModel.errorMessage);
                }).then(function () {
                    return kendo.observable(carStoresViewModel);
                });
            }, function () {
                alert("An error has occurred while getting your current location!")
            });
        },

        getCarStore: function (id) {
            var self = this;
            var carStoreViewModel = {
                carStore: null,
                cars: null,
                errorMessage: null
            };

            return self.data.carStores.getById(parseInt(id)).then(function (carStore) {
                carStoreViewModel.carStore = carStore;
            }, function (errorData) {
                carStoreViewModel.errorMessage = errorData.responseJSON.Message;
                alert(carStoreViewModel.errorMessage);
            }).then(function () {
                return self.data.carStores.getCars(parseInt(carStoreViewModel.carStore.id)).then(function (cars) {
                    carStoreViewModel.cars = cars;
                }, function (errorData) {
                    carStoreViewModel.errorMessage = errorData.responseJSON.Message;
                    alert(carStoreViewModel.errorMessage);
                });
            }).then(function () {
                debugger;
                return kendo.observable(carStoreViewModel);
            });
        },

        _getLocation: function () {
            if (navigator.geolocation) {
                var promise = new RSVP.Promise(function (resolve, reject) {
                    navigator.geolocation.getCurrentPosition(function (data) {
                        resolve(data);
                    }, function (error) {
                        reject(error);
                    });
                });

                return promise;
            } else {
                throw new Exception("Your browser does not support Geolocation!");
            }
        }
    });

    return {
        get: function (dataPersister) {
            return new ViewModels(dataPersister);
        }
    };
})();