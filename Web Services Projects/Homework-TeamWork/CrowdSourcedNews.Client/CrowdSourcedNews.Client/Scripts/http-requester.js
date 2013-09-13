var httpRequester = (function () {
    'use strict';

    function getJson(url, success, error) {

        $.ajax({
            url: url,
            type: "GET",
            timeout: 5000,
            contentType: "application/json",
            success: success,
            error: error
        });
    }

    function postJson(url, data, success, error) {

        $.ajax({
            url: url,
            type: "POST",
            timeout: 5000,
            contentType: "application/json",
            data: JSON.stringify(data),
            success: success,
            error: error
        });
    }

    return {
        postJson: postJson,
        getJson: getJson
    };
}());