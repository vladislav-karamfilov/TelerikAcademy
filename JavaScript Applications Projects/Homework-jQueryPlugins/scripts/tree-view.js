(function ($) {
    $.fn.treeView = function (speed) {
        var element, children;
        speed = speed || 400;

        element = this;
        element.find("ul").hide();
        element.on("click", "li", function (ev) {
            children = $(this).children();
            if (children.length > 0) {
                $(this).prevAll().children().hide();
                $(this).nextAll().children().hide();

                $(children[0]).toggle(speed);
            }

            ev.stopPropagation();
        });

        return this;
    }
}(jQuery));