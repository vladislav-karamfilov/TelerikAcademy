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
            var self = this;
            self.container.html(UI.getMainGameMenuUI());

            $("#nickname-container").html(self.dataPersister.user.getCurrentUserData().nickname + "!");

            self._loadOpenAndActiveGames();
        },

        _loadOpenAndActiveGames: function () {
            var self = this;
            self.dataPersister.games.getOpen(function (data) {
                $("#open-games-container").remove();
                var openGamesDiv = $("<div id='open-games-container'></div>")
                    .html("<h3>Open games</h3>").append(UI.getOpenGamesList(data));
                self.container.append(openGamesDiv);
            }, function (error) {
                UI.getErrorUI(error.responseJSON.Message);
                self.container.on("click", ".btn-back", function () {
                    self.loadUI();
                    return false;
                });
            });

            self.dataPersister.games.getCurrentUserActive(function (data) {
                $("#active-games-container").remove();
                var activeGamesDiv = $("<div id='active-games-container'></div>")
                    .html("<h3>Active games</h3>").append(UI.getActiveGamesList(data));
                self.container.append(activeGamesDiv);
            }, function (error) {
                UI.getErrorUI(error.responseJSON.Message);
                self.container.on("click", ".btn-back", function () {
                    self.loadUI();
                    return false;
                });
            });
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
                }, function (error) {
                    self.container.html(UI.getErrorUI(error.responseJSON.Message));
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
                    self.container.html(UI.getErrorUI(error.responseJSON.Message));
                    self.container.on("click", ".btn-back", function () {
                        self._loadGameUI();
                        return false;
                    });
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
                }, function (error) {
                    UI.getErrorUI(error.responseJSON.Message);
                    self.container.on("click", ".btn-back", function () {
                        self._loadGameUI();
                        return false;
                    });
                });

                return false;
            });

            self.container.on("click", "#btn-create-new-game", function () {
                var gameTitle = $("#tb-new-game-title").val();
                var gamePassword = $("#tb-new-game-password").val();
                self.dataPersister.games.create(gameTitle, gamePassword, function () {
                    var successfullGame = $("<div id='successfull-game-created-msg'>New game successfully created!</div>");
                    $("#new-game-create-container").append(successfullGame);
                    successfullGame.fadeOut(2000);
                }, function (error) {
                    self.container.html(UI.getErrorUI(error.responseJSON.Message));
                    self.container.on("click", ".btn-back", function () {
                        self._loadGameUI();
                        return false;
                    });
                })
            });

            self.container.on("click", ".btn-open-games", function () {
                self.container.find("#pasword-ask").remove();

                var passwordHolder = $("<div id='pasword-ask'></div>");
                passwordHolder.append("<label for='tb-join-password'>Password: </label>");
                passwordHolder.append("<input type='password' id='tb-join-password' />");
                passwordHolder.append("<button id='btn-submit-join-password' class='button'>Join</button>");
                $(this).parent().append(passwordHolder);
            });

            self.container.on("click", "#btn-submit-join-password", function () {
                var password = $("#tb-join-password").val();
                var gameID = $(this).parent().parent().data("gameId");
                console.log(gameID);
                self.dataPersister.games.join(gameID, password, function () {
                    self._loadGameUI();
                }, function (error) {
                    self.container.html(UI.getErrorUI(error.responseJSON.Message));
                    self.container.on("click", ".btn-back", function () {
                        self._loadGameUI();
                        return false;
                    });
                });
            });

            self.container.on("click", ".btn-active-game", function () {
                var parent = $(this).parent();
                var gameCreator = parent.data("creator");
                var myNickname = self.dataPersister.user.getCurrentUserData().nickname;
                if (gameCreator == myNickname && parent.hasClass("game-status-full")) {
                    $("#btn-game-start").remove();
                    var html =
						'<a href="#" id="btn-game-start" class="button">' +
							'Start' +
						'</a>';
                    $(this).parent().append("<br />" + html);
                } else {
                    var gameID = parent.data("gameId");
                    self.dataPersister.games.getField(gameID, function (data) {
                        self.container.html(UI.getInGameUI(data));
                        self._placeUnits(data);
                    }, function (error) {
                        self.container.html(UI.getErrorUI(error.responseJSON.Message));
                    });

                    self.container.on("click", ".btn-back", function () {
                        self._loadGameUI();
                        return false;
                    });
                }

                return false;
            });

            self.container.on("click", "#btn-game-start", function () {
                var that = this;
                var parent = $(that).parent();
                var gameId = parent.data("gameId");
                self.dataPersister.games.start(gameId, function () {
                    var startedMsg = $("<span>Started</span>");
                    parent.append(startedMsg);
                    startedMsg.fadeOut(2000);
                    $(that).fadeOut(2000);
                }, function (error) {
                    self.container.html(UI.getErrorUI(error.responseJSON.Message));
                    self.container.on("click", ".btn-back", function () {
                        self._loadGameUI();
                        return false;
                    });
                });

                return false;
            });

            self.container.on("click", "#btn-view-unread-messages", function () {
                self.dataPersister.messages.getUnread(function (data) {
                    self.container.html(UI.getUnreadMessagesList(data));
                }, function (error) {
                    UI.getErrorUI(error.responseJSON.Message);
                });

                self.container.on("click", ".btn-back", function () {
                    self._loadGameUI();
                    return false;
                });

                return false;
            });

            self.container.on("click", "#btn-view-all-messages", function () {
                self.dataPersister.messages.getAll(function (data) {
                    self.container.html(UI.getAllMessagesList(data));
                }, function (error) {
                    UI.getErrorUI(error.responseJSON.Message);
                });

                self.container.on("click", ".btn-back", function () {
                    self._loadGameUI();
                    return false;
                });

                return false;
            });
        },

        _placeUnits: function (unitsData) {
            var i, unitsCount, unit, gameField, position;
            gameField = $("#game-field");
            for (i = 0, unitsCount = unitsData.red.units.length; i < unitsCount; i++) {
                unit = unitsData.red.units[i];
                position = unit.position.y + "-" + unit.position.x;
                if (unit.type == "warrior") {
                    gameField.find("#" + position).addClass("warrior").html("<div class='unit-cell'>W</div>");
                } else {
                    gameField.find("#" + position).addClass("range").html("<div class='unit-cell'>R</div>");
                }
            }

            for (i = 0, unitsCount = unitsData.blue.units.length; i < unitsCount; i++) {
                unit = unitsData.blue.units[i];
                position = unit.position.y + "-" + unit.position.x;
                if (unit.type == "warrior") {
                    gameField.find("#" + position).addClass("warrior").html("<div class='unit-cell'>W</div>");
                } else {
                    gameField.find("#" + position).addClass("range").html("<div class='unit-cell'>R</div>");
                }
            }
        }
    });

    return {
        getController: function (dataPersister, containerSelector) {
            return new Controller(dataPersister, containerSelector);
        }
    }
}());