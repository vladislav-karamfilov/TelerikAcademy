/// <reference path="jquery-center-plugin.js" />
/// <reference path="jquery-1.10.1.js" />

var photos = (function () {
    $("#friends img").on('click', function (e) {

        $("#background").css({ "opacity": "0.7" })
                        .fadeIn("slow");

        $("#large").html("<img src='" + $(this).attr("src") + "' /><br/>" + $(this).attr("title") + "")
                   .center()
                   .fadeIn("slow");

        return false;
    });

    $(document).keypress(function (e) {
        if (e.keyCode == 27) {
            $("#background").fadeOut("slow");
            $("#large").fadeOut("slow");
        }
    });

    $("#background").click(function () {
        $("#background").fadeOut("slow");
        $("#large").fadeOut("slow");
    });

    $("#large").click(function () {
        $("#background").fadeOut("slow");
        $("#large").fadeOut("slow");
    });
});