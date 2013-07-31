/**
 *  ProtoClass.js – Standalone Prototype.js Class System.
 *  By Seraf Dos Santos
 *  
 *  From Prototype.js
 *  Sam Stephenson
 *  Copyright (c) 2005-2010 Sam Stephenson
 *  version 1.7
 *  MIT License
 */


// enumerable.js
var Enumerable = (function() {
    
    function toArray() {
        return this.map();
    }
    
    return {
        toArray:    toArray
    };
})();





// object.js
(function() {
    
    function extend(destination, source) {
      for (var property in source)
        destination[property] = source[property];
      return destination;
    }
    
    function keys(object) {
        var results = [];
        for (var property in object)
            results.push(property);
        return results;
    }
    
    function isFunction(object) {
        return typeof object === "function";
    }
    
    function isUndefined(object) {
        return typeof object === "undefined";
    }

    extend(Object, {
        extend:        extend,
        keys:          keys,
        isFunction:    isFunction,
        isUndefined:   isUndefined
    });
})();





// function.js
Object.extend(Function.prototype, (function() {
    var slice = Array.prototype.slice;
    
    function update(array, args) {
        var arrayLength = array.length, length = args.length;
        while (length--) array[arrayLength + length] = args[length];
        return array;
    }
    
    function merge(array, args) {
        array = slice.call(array, 0);
        return update(array, args);
    }
    
    function argumentNames() {
        var names = this.toString().match(/^[\s\(]*function[^(]*\(([^)]*)\)/)[1]
            .replace(/\/\/.*?[\r\n]|\/\*(?:.|[\r\n])*?\*\//g, '')
            .replace(/\s+/g, '').split(',');
            return names.length == 1 && !names[0] ? [] : names;
    }
    
    function bind(context) {
        if (arguments.length < 2 && Object.isUndefined(arguments[0])) return this;
        var __method = this, args = slice.call(arguments, 1);
        return function() {
            var a = merge(args, arguments);
            return __method.apply(context, a);
        }
    }
    
    function wrap(wrapper) {
        var __method = this;
        return function() {
            var a = update([__method.bind(this)], arguments);
            return wrapper.apply(this, a);
        }
    }
    return {
        argumentNames:       argumentNames,
        bind:                bind,
        wrap:                wrap
    }
})());





// array.js
function $A(iterable) {
    if (!iterable) return [];
    if ('toArray' in Object(iterable)) return iterable.toArray();
    var length = iterable.length || 0, results = new Array(length);
    while (length--) results[length] = iterable[length];
    return results;
}

(function () {
    var arrayProto = Array.prototype,
        slice = arrayProto.slice,
        _each = arrayProto.forEach;
    
    function first() {
        return this[0];
    }
    
    Object.extend(arrayProto, Enumerable);
    
    Object.extend(arrayProto, {
        first:     first,
    });
})();





var Prototype = {
    emptyFunction: function() { }
};





var Class = (function() {
    
    function subclass() {};
    
    function create() {
        var parent = null, properties = $A(arguments);
        if (Object.isFunction(properties[0]))
            parent = properties.shift();
            
        function klass() {
            this.initialize.apply(this, arguments);
        }
        
        Object.extend(klass, Class.Methods);
        klass.superclass = parent;
        klass.subclasses = [];
        
        if (parent) {
            subclass.prototype = parent.prototype;
            klass.prototype = new subclass;
            parent.subclasses.push(klass);
        }
        
        for (var i = 0; i < properties.length; i++)
            klass.addMethods(properties[i]);
            
        if (!klass.prototype.initialize)
            klass.prototype.initialize = Prototype.emptyFunction;
            
        klass.prototype.constructor = klass;
        return klass;
    }
    
    function addMethods(source) {
        var ancestor   = this.superclass && this.superclass.prototype;
        var properties = Object.keys(source);
        
        if (!Object.keys({ toString: true }).length) {
            if (source.toString != Object.prototype.toString)
                properties.push("toString");
            if (source.valueOf != Object.prototype.valueOf)
                properties.push("valueOf");
        }
        
        for (var i = 0, length = properties.length; i < length; i++) {
            var property = properties[i], value = source[property];
            if (ancestor && Object.isFunction(value) && value.argumentNames().first() == "$super") {
                var method = value;
                value = (function(m) {
                    return function() { return ancestor[m].apply(this, arguments); };
                })(property).wrap(method);
                
                value.valueOf = method.valueOf.bind(method);
                value.toString = method.toString.bind(method);
            }
            this.prototype[property] = value;
        }
        
        return this;
    }
    
    return {
        create: create,
        Methods: {
            addMethods: addMethods
        }
    };
})();

