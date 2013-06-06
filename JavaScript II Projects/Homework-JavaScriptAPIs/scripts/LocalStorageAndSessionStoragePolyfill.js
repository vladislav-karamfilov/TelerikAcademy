if (!window.localStorage || !window.sessionStorage) {
    (function () {
        var Storage = function (type) {
            function createCookie(name, value, days) {
                var expires = '';
                if (days) {
                    var date = new Date();
                    date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                    expires = '; expires=' + date.toGMTString();
                }

                document.cookie = name + '=' + value + expires + '; path=/';
            }

            function readCookie(name) {
                var nameEquals = name + '=';
                var cookiesSplitted = document.cookie.split(';');
                var currentCookie;

                for (var i = 0; i < cookiesSplitted.length; i++) {
                    currentCookie = cookiesSplitted[i];
                    while (currentCookie.charAt(0) == ' ') {
                        currentCookie = currentCookie.substring(1, currentCookie.length);
                    }

                    if (currentCookie.indexOf(nameEquals) == 0) {
                        return currentCookie.substring(nameEquals.length, currentCookie.length);
                    }
                }

                return null;
            }

            function setData(data) {
                data = JSON.stringify(data);
                if (type == 'session') {
                    window.name = data;
                } else {
                    createCookie('localStorage', data, 365);
                }
            }

            function clearData() {
                if (type == 'session') {
                    window.name = '';
                } else {
                    createCookie('localStorage', '', 365);
                }
            }

            function getData() {
                var data = type == 'session' ? window.name : readCookie('localStorage');
                return data ? JSON.parse(data) : {};
            }

            // Initialise if there's already data
            var data = getData();

            function numKeys() {
                var n = 0;
                for (var k in data) {
                    if (data.hasOwnProperty(k)) {
                        n++;
                    }
                }

                return n;
            }

            return {
                clear: function () {
                    data = {};
                    clearData();
                    this.length = numKeys();
                },
                getItem: function (key) {
                    key = encodeURIComponent(key);
                    return data[key] === undefined ? null : data[key];
                },
                key: function (i) {
                    var counter = 0;
                    for (var k in data) {
                        if (counter == i) return decodeURIComponent(k);
                        else counter++;
                    }

                    return null;
                },
                removeItem: function (key) {
                    key = encodeURIComponent(key);
                    delete data[key];
                    setData(data);
                    this.length = numKeys();
                },
                setItem: function (key, value) {
                    key = encodeURIComponent(key);
                    data[key] = String(value);
                    setData(data);
                    this.length = numKeys();
                },
                length: 0
            };
        };

        if (!window.localStorage) {
            window.localStorage = new Storage('local');
        }

        if (!window.sessionStorage) {
            window.sessionStorage = new Storage('session');
        }
    })();
}