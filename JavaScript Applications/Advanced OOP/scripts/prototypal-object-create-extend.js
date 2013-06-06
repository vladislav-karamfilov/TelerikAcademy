if (!Object.create) {
    Object.create = function (obj) {
        function theClass() { };
        theClass.prototype = obj;
        return new theClass();
    }
}

if (!Object.prototype.extend) {
    Object.prototype.extend = function (properties) {
        function theClass() { };
        theClass.prototype = Object.create(this);
        for (var prop in properties) {
            theClass.prototype[prop] = properties[prop];
        }

        theClass.prototype._super = this;
        return new theClass();
    }
}