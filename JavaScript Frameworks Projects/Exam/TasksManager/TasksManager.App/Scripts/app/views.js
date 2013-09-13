/// <reference path="../libs/_references.js" />

window.views = (function () {
    var Views = Class.create({
        init: function (rootPath) {
            this.rootPath = rootPath;
            this.templates = {};
        },

        getLogin: function () {
            return this._getTemplate("login-form");
        },

        getRegister: function () {
            return this._getTemplate("register-form");
        },

        getHomePage: function () {
            return this._getTemplate("home-page");
        },

        getError: function () {
            return this._getTemplate("error-page");
        },

        getAppointments: function () {
            return this._getTemplate("appointments-template");
        },

        getTodoLists: function () {
            return this._getTemplate("todo-lists-template");
        },

        getTodoList: function (id) {
            return this._getTemplate("todo-list-template");
        },

        getAppointmentCreateForm: function () {
            return this._getTemplate("appointment-create-form");
        },

        getAppointmentsForDateForm: function () {
            return this._getTemplate("appointments-for-date");
        },

        getTodoCreateForm: function () {
            return this._getTemplate("todo-create-form");
        },

        _getTemplate: function (name) {
            var self = this;
            var promise = new RSVP.Promise(function (resolve, reject) {
                if (self.templates[name]) {
                    resolve(self.templates[name]);
                } else {
                    $.ajax({
                        url: self.rootPath + name + ".html",
                        type: "GET",
                        success: function (templateHtml) {
                            self.templates[name] = templateHtml;
                            resolve(templateHtml);
                        },
                        error: function (errorData) {
                            reject(errorData);
                        }
                    });
                }
            });

            return promise;
        }
    });

    return {
        get: function (rootPath) {
            return new Views(rootPath);
        }
    }
})();