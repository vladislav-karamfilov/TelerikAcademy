var controls = (function () {
    function Accordion(containerID) {
        this.container = document.getElementById(containerID);
        this.itemsList = [];
    }

    Accordion.prototype.add = function (newItemTitle) {
        return addNewListItem(this, newItemTitle);
    }

    Accordion.prototype.render = function () {
        var itemsListElement = document.createElement("ul");
        itemsListElement.style.listStyle = "none";
        var listItemsCount = this.itemsList.length;
        for (var i = 0; i < listItemsCount; i++) {
            itemsListElement.appendChild(this.itemsList[i].render());
        }

        this.container.appendChild(itemsListElement);
    }

    Accordion.prototype.serialize = function () {
        var serialized = [];

        var listItemsCount = this.itemsList.length;
        for (var i = 0; i < listItemsCount; i++) {
            serialized.push(this.itemsList[i].serialize());
        }

        return serialized;
    }

    function ListItem(title) {
        this.title = title;
        this.itemsList = [];
    }

    ListItem.prototype.serialize = function () {
        var cloned = new ListItem(this.title);
        var subItemsCount = this.itemsList.length;
        for (var i = 0; i < subItemsCount; i++) {
            cloned.itemsList.push(this.itemsList[i].serialize());
        }

        return cloned;
    }

    ListItem.prototype.add = function (newItemTitle) {
        return addNewListItem(this, newItemTitle);
    }

    ListItem.prototype.render = function () {
        var itemAnchor = getItemAnchor();
        itemAnchor.innerHTML = this.title;
        attachEventHandler(itemAnchor, "click", handleAnchorClick);

        var item = document.createElement("li");
        item.appendChild(itemAnchor);

		var listItemsCount = this.itemsList.length;
        if (listItemsCount > 0) {
            var itemsList = document.createElement("ul");
            itemsList.style.listStyle = "none";
            for (var i = 0; i < listItemsCount; i++) {
                itemsList.appendChild(this.itemsList[i].render());
            }

            itemsList.style.display = "none";
            item.appendChild(itemsList);
        }

        return item;
    }

    function handleAnchorClick(ev) {
        if (!ev) {
            ev = window.event;
        }

        if (ev.preventDefault) {
            ev.preventDefault();
        }

        if (ev.stopPropagation) {
            ev.stopPropagation();
        }

        var anchorElement = ev.target ? ev.target : ev.srcElement;
        // anchorElement.style.fontWeight = "bold";
        var subListElement = anchorElement.nextElementSibling;
        if (subListElement) {
            var childrenCount = subListElement.childElementCount;

            if (subListElement.style.display == "none") {
                for (var i = 0; i < childrenCount; i++) {
                    subListElement.childNodes[i].style.display = "list-item";
                }

                hidePrevious(subListElement.parentElement);
                hideNext(subListElement.parentElement);

                subListElement.style.display = "block";
            } else {
                var subSublist = null;
                for (var i = 0; i < childrenCount; i++) {
                    subSublist = subListElement.childNodes[i].lastChild;
                    collapse(subSublist);
                }

                subListElement.style.display = "none";
            }
        }
    }

    function hideNext(element) {
        var currentElement = element.nextElementSibling;
        while (currentElement) {
            collapse(currentElement.lastChild);
            currentElement = currentElement.nextElementSibling;
        }
    }

    function hidePrevious(element) {
        var currentElement = element.previousElementSibling;
        while (currentElement) {
            collapse(currentElement.lastChild);
            currentElement = currentElement.previousElementSibling;
        }
    }

    function collapse(element) {
        if (element instanceof HTMLUListElement && element.style.display == "block") {
            element.style.display = "none";
            for (var i = 0, childrenCount = element.childElementCount; i < childrenCount; i++) {
                collapse(element.childNodes[i].lastChild);
            }
        }
    }

    function getItemAnchor() {
        var itemAnchor = document.createElement("a");
        itemAnchor.setAttribute("href", "#");

        itemAnchor.style.textDecoration = "none";
        itemAnchor.style.color = "#000";
        itemAnchor.onmouseover = function () {
            itemAnchor.style.textDecoration = "underline";
        }

        itemAnchor.onmouseout = function () {
            itemAnchor.style.textDecoration = "none";
        }

        return itemAnchor;
    }

    function addListItem(destinationElement, elementToAdd) {
        var newItem = destinationElement.add(elementToAdd.title);
        var listItemsCount = elementToAdd.itemsList.length;
        for (var i = 0; i < listItemsCount; i++) {
            addListItem(newItem, elementToAdd.itemsList[i]);
        }
    }

    function getDeserializedAccordion(containerID, serializedAccordion) {
        var deserialized = localStorage.getObject("new-accordion");
        var newAccordion = new Accordion(containerID);
        var listItemsCount = deserialized.length;
        for (var i = 0; i < listItemsCount; i++) {
            addListItem(newAccordion, deserialized[i]);
        }

        return newAccordion;
    }

    function addNewListItem(destinationElement, newItemTitle) {
        var newListItem = new ListItem(newItemTitle);
        destinationElement.itemsList.push(newListItem);
        return newListItem;
    }

    function attachEventHandler(element, eventType, eventHandler) {
        if (element) {
            if (document.addEventListener) {
                element.addEventListener(eventType, eventHandler, false);
            } else if (document.attachEvent) {
                element.attachEvent("on" + eventType, eventHandler);
            } else {
                element['on' + eventType] = eventHandler;
            }
        }
    }

    return {
        getAccordion: function (containerID) {
            return new Accordion(containerID);
        },
        buildNewAccordion: getDeserializedAccordion
    }
})();