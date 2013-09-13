/// <reference path="../libs/_references.js" />

window.viewModels = (function () {
    var ViewModels = Class.create({
        init: function (dataPersister) {
            this.data = dataPersister;
        },

        getRegister: function (successCallback, errorCallback) {
            var self = this;
            var registerViewModel = {
                username: null,
                email: null,
                password: null,
                register: function (ev) {
                    var selfViewModel = this;
                    return self.data.user.register(
                        selfViewModel.get("username"), selfViewModel.get("email"), selfViewModel.get("password"))
                    .then(successCallback, function (errorData) {
                        window.errorMessage = errorData.responseJSON.Message;
                        if (errorCallback) {
                            debugger;
                            errorCallback();
                        }
                    });
                }
            };

            return kendo.observable(registerViewModel);
        },

        getLogin: function (successCallback, errorCallback) {
            var self = this;
            var loginViewModel = {
                username: null,
                password: null,
                login: function (ev) {
                    var selfViewModel = this;
                    return self.data.user.login(
                        selfViewModel.get("username"), selfViewModel.get("password"))
                    .then(successCallback, function (errorData) {
                        window.errorMessage = errorData.responseJSON.Message;
                        if (errorCallback) {
                            errorCallback();
                        }
                    });
                }
            };

            return kendo.observable(loginViewModel);
        },

        getAppointments: function (errorCallback) {
            var appointmentsViewModel = {
                appointments: null
            };

            return this.data.appointments.getAll().then(function (appointments) {
                appointmentsViewModel.appointments = appointments;
            }, function (errorData) {
                window.errorMessage = errorData.responseJSON.Message;
                if (errorCallback) {
                    errorCallback();
                }
            }).then(function () {
                return kendo.observable(appointmentsViewModel);
            });
        },

        getAppointmentCreateViewModel: function (successCallback, errorCallback) {
            var self = this;
            var appointmentViewModel = {
                subject: null,
                description: null,
                appointmentDate: null,
                duration: null,
                create: function (ev) {
                    self.data.appointments.create(
                            this.get("subject"),
                            this.get("description"),
                            this.get("appointmentDate"),
                            this.get("duration"))
                        .then(successCallback, function (errorData) {
                            window.errorMessage = errorData.responseJSON.Message;
                            if (errorCallback) {
                                errorCallback();
                            }
                        });
                }
            };

            return kendo.observable(appointmentViewModel);
        },

        getCommingAppointments: function (errorCallback) {
            var appointmentsViewModel = {
                appointments: null
            };

            return this.data.appointments.getComming().then(function (appointments) {
                appointmentsViewModel.appointments = appointments;
            }, function (errorData) {
                window.errorMessage = errorData.responseJSON.Message;
                if (errorCallback) {
                    errorCallback();
                }
            }).then(function () {
                return kendo.observable(appointmentsViewModel);
            });
        },

        getTodaysAppointments: function (errorCallback) {
            var appointmentsViewModel = {
                appointments: null
            };

            return this.data.appointments.getForToday().then(function (appointments) {
                appointmentsViewModel.appointments = appointments;
            }, function (errorData) {
                window.errorMessage = errorData.responseJSON.Message;
                if (errorCallback) {
                    errorCallback();
                }
            }).then(function () {
                return kendo.observable(appointmentsViewModel);
            });
        },

        getCurrentAppointments: function (errorCallback) {
            var appointmentsViewModel = {
                appointments: null
            };

            return this.data.appointments.getCurrent().then(function (appointments) {
                appointmentsViewModel.appointments = appointments;
            }, function (errorData) {
                window.errorMessage = errorData.responseJSON.Message;
                if (errorCallback) {
                    errorCallback();
                }
            }).then(function () {
                return kendo.observable(appointmentsViewModel);
            });
        },

        getAppointmentsForDate: function (date, errorCallback) {
            var appointmentsViewModel = {
                appointments: null
            };

            return this.data.appointments.getByDate(date).then(function (appointments) {
                appointmentsViewModel.appointments = appointments;
            }, function (errorData) {
                window.errorMessage = errorData.responseJSON.Message;
                if (errorCallback) {
                    errorCallback();
                }
            }).then(function () {
                return kendo.observable(appointmentsViewModel);
            });
        },

        getTodoLists: function (errorCallback) {
            var todoListsViewModel = {
                todoLists: null
            };

            return this.data.todoLists.getAll().then(function (todoLists) {
                todoListsViewModel.todoLists = todoLists;
            }, function (errorData) {
                window.errorMessage = errorData.responseJSON.Message;
                if (errorCallback) {
                    errorCallback();
                }
            }).then(function () {
                return kendo.observable(todoListsViewModel);
            });
        },

        // Needs refresh!!!
        getTodoList: function (id, errorCallback) {
            var self = this;
            var todoListViewModel = {
                todosList: null,
                changeState: function (ev) {
                    var selfViewModel = this;
                    var id = ev.data.id;
                    self.data.todoLists.changeStateOfTodo(id).then(function () { }, function (errorData) {
                        window.errorMessage = errorData.responseJSON.Message;
                        if (errorCallback) {
                            errorCallback();
                        }
                    });
                }
            };

            return this.data.todoLists.getTodos(id).then(function (todos) {
                todoListViewModel.todosList = todos;
            }, function (errorData) {
                window.errorMessage = errorData.responseJSON.Message;
                if (errorCallback) {
                    errorCallback();
                }
            }).then(function () {
                return kendo.observable(todoListViewModel);
            });
        },

        getTodoCreateViewModel: function (successCallback, errorCallback) {
            var self = this;
            var todoViewModel = {
                text: null,
                create: function (ev) {
                    var id = ev.data.id;
                    self.data.todoLists.addTodo(id, this.get("text")).then(successCallback, function (errorData) {
                        window.errorMessage = errorData.responseJSON.Message;
                        if (errorCallback) {
                            errorCallback();
                        }
                    });
                }
            };

            return kendo.observable(todoViewModel);
        }
    });

    return {
        get: function (dataPersister) {
            return new ViewModels(dataPersister);
        }
    };
})();