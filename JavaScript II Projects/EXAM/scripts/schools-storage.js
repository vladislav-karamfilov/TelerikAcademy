var schoolStorage = (function () {
    if (!Storage.prototype.save) {
        Storage.prototype.save = function setObject(key, object) {
            var jsonObject = JSON.stringify(object);
            this.setItem(key, jsonObject);
        }
    }

    if (!Storage.prototype.load) {
        Storage.prototype.load = function getObject(key) {
            var jsonObject = this.getItem(key);
            return JSON.parse(jsonObject);
        }
    }

    return {
        schoolsRepository: localStorage
    }
})();