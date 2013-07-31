/// <reference path="class.js" />
/// <reference path="data-layer.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="jquery-center-plugin.js" />
/// <reference path="ui.js" />

var Controllers = (function () {
    var Controller = Class.create({
        init: function (dataPersister, containerSelector) {
            this.dataPersister = dataPersister;
            this.container = $(containerSelector).center(false);
        },

        loadUI: function () {
            if (this.dataPersister.isUserLoggedIn()) {
                this._loadGameUI();
            } else {
                this._loadLoginFormUI();
            }

            this._attachUIEventHandlers();
        },

        _loadLoginFormUI: function () {
            this.container.html(UI.getLoginForm());
        },

        _loadGameUI: function () {
            this.container.html(UI.getMainGameMenuUI());
            $("#nickname-container").html(this.dataPersister.user.getCurrentUserData().nickname + "!");
        },

        _attachUIEventHandlers: function () {
            this._attachLoginFormEventHandlers();
            this._attachMainGameUIEventHandlers();
        },

        _attachLoginFormEventHandlers: function () {
            var self = this;
            self.container.on("click", "#btn-sign-in", function () {
                self.container.find(".selected").removeClass("selected");
                $("#btn-sign-in").addClass("selected");
                $("#register-form").hide();
                $("#login-form").show();

                return false;
            });

            self.container.on("click", "#btn-sign-up", function () {
                self.container.find(".selected").removeClass("selected");
                $("#btn-sign-up").addClass("selected");
                $("#login-form").hide();
                $("#register-form").show();

                return false;
            });

            self.container.on("click", "#btn-login", function () {
                var userName = $("#tb-login-username").val();
                var password = $("#tb-login-password").val();
                self.dataPersister.user.login(userName, password, function () {
                    self._loadGameUI();
                }, function (error) {
                    self.container.html(UI.getErrorUI(error.responseJSON.Message));
                    self.container.on("click", ".btn-back", function () {
                        self._loadLoginFormUI();
                        return false;
                    });
                });

                return false;
            });

            self.container.on("click", "#btn-register", function () {
                var userName = $("#tb-register-username").val();
                var nickName = $("#tb-register-nickname").val();
                var password = $("#tb-register-password").val();
                self.dataPersister.user.register(userName, nickName, password, function () {
                    self._loadGameUI();
                }, function () {
                    self.container.html(UI.getErrorUI());
                    self.container.on("click", ".btn-back", function () {
                        self._loadLoginFormUI();
                        return false;
                    });
                });

                return false;
            });
        },

        _attachMainGameUIEventHandlers: function () {
            var self = this;
            self.container.on("click", "#btn-logout", function () {
                self.dataPersister.user.logout(function () {
                    self._loadLoginFormUI();
                }, function (error) {
                    UI.getErrorUI(error.responseJSON.Message);
                });

                return false;
            });

            self.container.on("click", "#btn-view-scores", function () {
                self.dataPersister.user.getScores(function (data) {
                    self.container.html(UI.getScoresUI(data));
                    self.container.on("click", ".btn-back", function () {
                        self._loadGameUI();
                        return false;
                    });
                }, function () {
                    UI.getUnknownErrorUI();
                });

                return false;
            });

            self.container.on("click", "#btn-view-messages", function () {
                // TODO: !!!
            });

            self.container.on("click", "#btn-view-active-games", function () {
                self.dataPersister.games.getCurrentUserActive(function (data) {
                    self.container.html(UI.getActiveGamesUI(data));
                    self.container.on("click", ".btn-back", function () {
                        self._loadGameUI();
                        return false;
                    });
                }, UI.getUnknownErrorUI());
                return false;
            });

            self.container.on("click", "#btn-view-open-games", function () {
                self.dataPersister.games.getOpen(function (data) {
                    self.container.html(UI.getOpenGamesUI(data));
                    self.container.on("click", ".btn-back", function () {
                        self._loadGameUI();
                        return false;
                    });
                }, UI.getUnknownErrorUI());
                return false;
            });

            self.container.on("click", "#btn-create-game-choice", function () {
                self.container.html(UI.getCreateNewGameUI());
                $("#btn-create-game").on("click", function () {
                    var title = $("#tb-new-game-title").val();
                    var number = $("#tb-new-game-number").val();
                    var password = $("#tb-new-game-password").val();
                    self.dataPersister.games.create(title, number, password, function () {

                    }, function () {

                    });

                    return false;
                });

                self.container.on("click", ".btn-back", function () {
                    self._loadGameUI();
                    return false;
                });

                return false;
            });
        },
    });

    return {
        getController: function (dataPersister, containerSelector) {
            return new Controller(dataPersister, containerSelector);
        }
    }
}());