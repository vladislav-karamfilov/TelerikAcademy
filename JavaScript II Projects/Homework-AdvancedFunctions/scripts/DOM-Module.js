var dom = (function () {
    var MAX_FRAGMENTS_COUNT = 100;
    var fragmentsBuffer = {};

    function appendChild(element, parentSelector) {
        var parentElement = document.querySelector(parentSelector);
        parentElement.appendChild(element);
    }

    function removeChildren(parentSelector, childrenSelector) {
        var elementsToRemove = document.querySelectorAll(parentSelector + " " + childrenSelector);
        for (var i = 0, length = elementsToRemove.length; i < length; i++) {
            elementsToRemove[i].parentNode.removeChild(elementsToRemove[i]);
        }
    }

    function attachEventHandler(elementSelector, eventType, eventHandler) {
        var element = document.querySelector(elementSelector);
        if (element.addEventListener) {
            element.addEventListener(eventType, eventHandler, false);
        } else {
            element.attachEvent("on" + eventType, eventHandler);
        }
    }

    function appendToBuffer(parentSelector, element) {
        if (!fragmentsBuffer[parentSelector]) {
            fragmentsBuffer[parentSelector] = document.createDocumentFragment();
        }

        fragmentsBuffer[parentSelector].appendChild(element);

        if (fragmentsBuffer[parentSelector].childNodes.length === MAX_FRAGMENTS_COUNT) {
            var parentElement = document.querySelector(parentSelector);
            parentElement.appendChild(fragmentsBuffer[parentSelector]);
            fragmentsBuffer[parentSelector] = null;
        }
    }

    function getElements(elementSelector) {
        return document.querySelectorAll(elementSelector);
    }

    return {
        appendChild: appendChild,
        removeChildren: removeChildren,
        attachEventHandler: attachEventHandler,
        appendToBuffer: appendToBuffer,
        getElements: getElements
    }
})();