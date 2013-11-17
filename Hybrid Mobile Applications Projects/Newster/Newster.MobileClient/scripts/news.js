(function (global) {
    var NewsViewModel,
        data = dataPersisters.get(),
        app = global.app = global.app || {};

    NewsViewModel = kendo.data.ObservableObject.extend({
        currentCoordinates: true,
        id: 0,
        author: "",
        title: "",
        content: "",
        imageUrl: "",
        date: null,
        categoryId: 0,
        categoryName: "",
        latitude: null,
        longitude: null,
        votes: 0,

        _createNews: function () {
            try {
                var self = this;
                data.news.create(
                    self.get("title"),
                    self.get("content"),
                    self.get("imageUrl"),
                    self.get("categoryId"),
                    self.get("latitude"),
                    self.get("longitude"))
                .then(function () {
                    navigator.notification.alert("A news created successfully!", function () {
                        app.application.navigate("views/all-news.html#all-news-view");
                    }, "Successfully created news", "OK");
                }, function (errorData) {
                    navigator.notification.vibrate(100);
                    navigator.notification.alert(errorData.responseText, function () { }, "Creating a news failed", 'OK');
                });
            } catch (ex) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(ex, function () { }, "Creating a news failed", 'OK');
            }
        },

        create: function () {
            var self = this;
            if (self.get("currentCoordinates")) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    self.set("latitude", position.coords.latitude);
                    self.set("longitude", position.coords.longitude);
                    self._createNews();
                }, function () {
                    navigator.notification.vibrate(100);
                    navigator.notification.alert(
                        "Getting current coordinates failed... Check your internet connection",
                        function () { },
                        "Getting current coordinates failed",
                        'OK');
                }, {
                    timeout: 3000,
                    enableHighAccuracy: true
                });
            } else {
                self._createNews();
            }
        },

        details: function (id) {
            var self = this;
            try {
                data.news.getById(id).then(function (news) {
                    self.set("id", news.id);
                    self.set("title", news.title);
                    self.set("content", news.content);
                    self.set("author", news.author);
                    self.set("imageUrl", news.image);
                    self.set("categoryName", news.category);
                    self.set("date", news.date);
                    self.set("categoryId", news.categoryId);
                    self.set("latitude", news.coordinates ? news.coordinates.latitude : null);
                    self.set("longitude", news.coordinates ? news.coordinates.longitude : null);
                    self.set("votes", news.votes);

                    app.application.navigate("views/news-details.html#news-details-view");
                }, function (errorData) {
                    navigator.notification.vibrate(100);
                    navigator.notification.alert(errorData.responseText, function () { }, "Getting news details failed", 'OK');
                });
            } catch (ex) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(ex, function () { }, "Getting news details failed", 'OK');
            }
        },

        getAll: function () {
            data.news.getAllNews().then(function (allNews) {
                $("#all-news").kendoMobileListView({
                    dataSource: allNews,
                    template: $("#newsTemplate").html()
                });
            }, function (errorData) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(errorData.responseText, function () { }, "Getting all news failed", 'OK');
            });
        },

        getLatest: function () {
            data.news.getLatestNews().then(function (latestNews) {
                $("#latest-news").kendoMobileListView({
                    dataSource: latestNews,
                    template: $("#newsTemplate").html()
                });
            }, function (errorData) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(errorData.responseText, function () { }, "Getting latest news failed", 'OK');
            });
        },

        getTopVoted: function () {
            data.news.getTopVotedNews().then(function (topVotedNews) {
                $("#top-voted-news").kendoMobileListView({
                    dataSource: topVotedNews,
                    template: $("#votedNewsTemplate").html()
                });
            }, function (errorData) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(errorData.responseText, function () { }, "Getting top voted news failed", 'OK');
            });
        },

        comment: function (comment) {
            var newsArticleId = this.get("id");
            try {
                return data.news.comment(newsArticleId, comment).then(function () { }, function (errorData) {
                    navigator.notification.vibrate(100);
                    navigator.notification.alert(errorData.responseText, function () { }, "Commenting news failed", 'OK');
                });
            } catch (ex) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(ex, function () { }, "Commenting news failed", 'OK');
            }
        },

        getComments: function () {
            var self = this,
                newsArticleId = self.get("id");
            try {
                return data.news.getComments(newsArticleId).then(function (comments) {
                    return comments;
                }, function (errorData) {
                    navigator.notification.vibrate(100);
                    navigator.notification.alert(errorData.responseText, function () { }, "Getting news article comments failed", 'OK');
                });
            } catch (ex) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(ex, function () { }, "Getting news article comments failed", 'OK');
            }
        },

        vote: function () {
            var self = this,
                newsArticleId = self.get("id");
            try {
                data.news.vote(newsArticleId).then(function () {
                    var newVotesCount = self.get("votes") + 1;
                    self.set("votes", newVotesCount);
                }, function (errorData) {
                    navigator.notification.vibrate(100);
                    navigator.notification.alert(errorData.responseText, function () { }, "Commenting news failed", 'OK');
                });
            } catch (ex) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(ex, function () { }, "Commenting news failed", 'OK');
            }
        }
    });

    app.news = new NewsViewModel();
})(window);