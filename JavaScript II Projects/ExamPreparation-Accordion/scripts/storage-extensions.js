(function () {
    if (!Storage.prototype.setObject) {
        Storage.prototype.setObject = function setObject(key, object) {
            var jsonObject = JSON.stringify(object);
            this.setItem(key, jsonObject);
        }
    }

    if (!Storage.prototype.getObject) {
        Storage.prototype.getObject = function getObject(key) {
            var jsonObject = this.getItem(key);
            return JSON.parse(jsonObject);
        }
    }
})();