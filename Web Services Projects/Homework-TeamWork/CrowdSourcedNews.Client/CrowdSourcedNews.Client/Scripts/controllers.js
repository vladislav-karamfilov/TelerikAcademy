var controllers = (function () {

    var Controller = Class.create({
        init: function (persister) {
            this.persister = persister;
            this.rootUrl = persister.rootUrl;
        },
        loadUI: function (containerSelector) {
            this.container = $(containerSelector);
            if (this.persister.isLoggedIn()) {
                this.loadArticlesUI();
            } else {
                this.loadLoginUI();
            }
            this.attachEvents();
        },
        loadArticlesUI: function (message) {
            var self = this;
            this.container.load("../news.html", function () {

                var articlesUl = $("<ul class='articles-list'></ul>");

                //get all articles
                self.persister.articles.getAllArticles(
                    function(data) {

                        for (var i = 0; i < data.length; i++) {
                            var articleLi = $("<li class='span4 article well'></li>");
                            var title = $("<h3></h3>").html(data[i].title);
                            var author = $("<p></p>").html(data[i].author);
                            var date = $("<span></span>").html(data[i].date);
                            var rating = $("<span></span>").html(data[i].rating);
                            articleLi.append(title);
                            articleLi.append(author);
                            articleLi.append(date);
                            articleLi.append(rating);
                            articleLi.data("articleId", data[i].id);
                            articlesUl.append(articleLi);
                        }

                        $("#articles-container").html("");
                        $("#articles-container").append(articlesUl);
                        if (message) {
                            $("#pubnubconsole").text('Article: "' + message + '" added!');
                        }
                    

                    }, function (error) {
                        console.log(error);
                    });

            });
        },
        
        loadMyArticlesUI: function () {
            var self = this;
            this.container.load("../news.html", function () {

                var articlesUl = $("<ul class='articles-list'></ul>");

                //get all articles
                self.persister.user.myArticles(
                    function (data) {

                        for (var i = 0; i < data.length; i++) {
                            var articleLi = $("<li class='span4 article well'></li>");
                            var title = $("<h3></h3>").html(data[i].title);
                            var author = $("<p></p>").html(data[i].author);
                            var date = $("<span></span>").html(data[i].date);
                            var rating = $("<span></span>").html(data[i].rating);
                            articleLi.append(title);
                            articleLi.append(author);
                            articleLi.append(date);
                            articleLi.append(rating);
                            articleLi.data("articleId", data[i].id);
                            articlesUl.append(articleLi);
                        }

                        $("#articles-container").html("");
                        $("#articles-container").append(articlesUl);

                    }, function (error) {
                        console.log(error);
                    });

            });
        },

        loadArticleUI: function (id) {
            var self = this;
            $.get("../addComment.html", function (formComment) {

                self.persister.articles.getArticle(id, function (data) {
                    var article = $("<div id='comments-container' class='span12 well'</div>");
                    var title = $("<h3></h3>").html(data.title);
                    var author = $("<p></p>").html(data.author);
                    var date = $("<span></span>").html(data.date);
                    var rating = $("<span></span>").html(data.rating);
                    var content = $("<p></p>").html(data.content);
                    article.append(title);
                    article.append(author);
                    article.append(date);
                    article.append(rating);
                    article.append(content);
                    article.data("articleId", data.id);

                    for (var i = 0; i < data.comments.length; i++) {
                        var comment = $("<div class='span10 well'></div>");
                        comment.append($("<p></p>").html(data.comments[i].Author));
                        comment.append($("<p></p>").html(data.comments[i].Date));
                        comment.append($("<p></p>").html(data.comments[i].Content));
                        article.append(comment);
                    }

                    $("#articles-container").html("");
                    $("#articles-container").append(article);
                    $("#articles-container").append(formComment);

                },
                    function (error) {
                        console.log(error);
                    });
            }
            );
        },
        loadArticleEditor: function() {
           $.get("../addArticle.html", function(articleEditorHtml) {
               $("#articles-container").html(articleEditorHtml);
           });
        },
        loadRegisterUI: function () {
            this.container.load("../register.html");
        },
        loadLoginUI: function () {
            this.container.load("../login.html");
        },
        attachEvents: function () {
            var self = this;
            // Events for game.html
            this.container.on("click", "#logout", function () {
                self.persister.user.logout(function () {
                    self.loadLoginUI();
                }, function (error) {
                    console.log(error);
                });
            });

            // Events for register.html
            this.container.on('click', "#login-form", function (ev) {
                ev.preventDefault();
                self.loadLoginUI();
            });

            this.container.on('click', "#register", function (ev) {
                var username = $("#username-input").val();
                var password = $("#password-input").val();
                var nickname = $("#nickname-input").val();
                self.persister.user.register({ username: username, password: password, nickname: nickname },
                    function () {
                        self.loadArticlesUI();
                    }, function (data) {
                        console.log(data);
                    });
            });

            // Events for login.html
            this.container.on('click', "#register-form", function (ev) {
                ev.preventDefault();
                self.loadRegisterUI();
            });

            this.container.on('click', "#login", function (ev) {
                var username = $("#username-input").val();
                var password = $("#password-input").val();
                self.persister.user.login({ username: username, password: password },
                    function () {
                        self.loadArticlesUI();
                    }, function (data) {
                        console.log(data);
                    });
            });

            this.container.on('click', '.article', function (ev) {
                ev.preventDefault();
                var articleId = $(this).data("articleId");
                self.loadArticleUI(articleId);
            });

            this.container.on('click', '#all-articles', function () {
                self.loadArticlesUI();
            });

            this.container.on('click', "#comment-btn", function () {
                var commentText = $("#comment-input").val();
                var articleId = $("#articles-container>div").data("articleId");
                self.persister.comment.add(commentText, articleId, function () {
                    var comment = $("<div class='span10 well'></div>");
                    comment.append($("<p></p>").html(self.persister.getNickName()));
                    comment.append($("<p></p>").html(new Date()));
                    comment.append($("<p></p>").html(commentText));
                    $("#comments-container").append(comment);
                });
            });

            this.container.on('click', '#add-article', function() {
                self.loadArticleEditor();
            });

            this.container.on('click', '#newarticle-btn', function() {
                var title = $("#title-input").val();
                var content = $("#content-input").val();
                var author = self.persister.getNickName();
                self.persister.articles.add(title, content, author);
            });

            this.container.on('click', '#my-articles', function() {
                self.loadMyArticlesUI();
            });
        }
    });

    return {
        getController: function (persister) {
            return new Controller(persister);
        }
    };
}());
