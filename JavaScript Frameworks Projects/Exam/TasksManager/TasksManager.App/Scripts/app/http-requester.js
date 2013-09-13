/// <reference path="_references.js" />

window.httpRequester = (function () {
    var makeRequest = function (url, type, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            var stringifiedData = "";
            if (data) {
                stringifiedData = JSON.stringify(data);
            }

            var request = {
                url: url,
                type: type,
                contentType: "application/json",
                data: stringifiedData,
                headers: headers,
                success: function (successData) {
                    resolve(successData);
                },
                error: function (errorData) {
                    reject(errorData);
                }
            };

            $.ajax(request);
        });

        return promise;
    }

    function getJson(url, headers) {
        return makeRequest(url, "GET", null, headers);
    }

    function postJson(url, data, headers) {
        return makeRequest(url, "POST", data, headers);
    }

    function deleteJson(url, headers) {
        return makeRequest(url, "DELETE", null, headers);
    }

    function putJson(url, data, headers) {
        return makeRequest(url, "PUT", data, headers);
    }

    return {
        getJson: getJson,
        postJson: postJson,
        deleteJson: deleteJson,
        putJson: putJson
    };
})();