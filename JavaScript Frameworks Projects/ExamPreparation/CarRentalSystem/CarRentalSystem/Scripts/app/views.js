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

        getCars: function () {
            return this._getTemplate("cars-list");
        },

        getCarStores: function () {
            return this._getTemplate("car-stores-list");
        },

        getCar: function () {
            return this._getTemplate("car-template");
        },

        getCarStore: function () {
            return this._getTemplate("car-store-template");
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