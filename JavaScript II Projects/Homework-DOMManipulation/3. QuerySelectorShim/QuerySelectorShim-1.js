if (!document.querySelector || !document.querySelectorAll) {
    document.querySelector = function (selector) {
        var element;
        switch (selector.charAt(0)) {
            case '#':
                var id = selector.substring(1, selector.length);
                element = document.getElementById(id);
                break;
            case '.':
                var className = selector.substring(1, selector.length);
                if (!document.getElementsByClassName) {
                    element = getElementsByClassName(document.body, className)[0];
                }
                else {
                    element = document.getElementsByClassName(className)[0];
                }
                break;
            default:
                element = document.getElementsByTagName(selector)[0];
                break;
        }

        return element;
    }

    document.querySelectorAll = function (selector) {
        var elements;
        switch (selector.charAt(0)) {
            case '#':
                var id = selector.substring(1, selector.length);
                elements = document.getElementById(id);
                break;
            case '.':
                var className = selector.substring(1, selector.length);
                if (!document.getElementsByClassName) {
                    elements = getElementsByClassName(document.body, className);
                }
                else {
                    elements = document.getElementsByClassName(className);
                }
                break;
            default:
                elements = document.getElementsByTagName(selector);
                break;
        }

        return elements;
    }
}

/* Internet Explorer 7 shim */
function getElementsByClassName(node, className) {
    var elements = [];
    var classNameRegEx = new RegExp('(^| )' + className + '( |$)');
    var elementsByTagName = node.getElementsByTagName("*");
    for (var i = 0, length = elementsByTagName.length; i < length; i++) {
        if (classNameRegEx.test(elementsByTagName[i].className)) {
            elements.push(elementsByTagName[i]);
        }
    }

    return elements;
}