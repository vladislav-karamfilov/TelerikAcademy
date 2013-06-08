var Class = (function () {
    function createClass(properties) {
        var theClass = function () {
            if (this._superConstructor) {
                this._super = new this._superConstructor(arguments);
            }

            this.init.apply(this, arguments);
        }

        for (var prop in properties) {
            theClass.prototype[prop] = properties[prop];
        }

        if (!theClass.prototype.init) {
            theClass.prototype.init = function () { }
        }

        return theClass;
    }

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;
        this.prototype = new parent();
        this.prototype._superConstructor = parent;
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    }

    return {
        create: createClass
    }
})();