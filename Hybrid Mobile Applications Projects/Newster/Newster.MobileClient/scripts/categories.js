(function (global) {
    var CategoriesViewModel,
        data = dataPersisters.get(),
        app = global.app = global.app || {};

    CategoriesViewModel = kendo.data.ObservableObject.extend({
        name: "",
        selectedCategory: {
            name: "",
            news: [],
        },

        create: function () {
            var categoryName = this.get("name");
            data.categories.create(categoryName).then(function () {
                navigator.notification.alert("Category created successfully!", function () {
                    app.application.navigate("views/categories.html#categories-view");
                }, "Created category", 'OK');
            }, function (errorData) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(errorData.responseText, function () { }, "Creating category failed", 'OK');
            });
        },

        getAll: function () {
            data.categories.getAllCategories().then(function (allCategories) {
                $("#all-categories").kendoMobileListView({
                    dataSource: allCategories,
                    template: $("#categoriesTemplate").html()
                });
            }, function (errorData) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(errorData.responseText, function () { }, "Getting all categories failed", 'OK');
            });
        },

        getNews: function (categoryId, categoryName) {
            var self = this;
            data.categories.getNews(categoryId).then(function (categoryNews) {
                self.set("selectedCategory.name", categoryName);
                self.set("selectedCategory.news", categoryNews);

                app.application.navigate("views/category-news.html#category-news-view");
            }, function (errorData) {
                navigator.notification.vibrate(100);
                navigator.notification.alert(errorData.responseText, function () { }, "Getting category news failed", 'OK');
            });
        }
    });

    app.categories = new CategoriesViewModel();
})(window);