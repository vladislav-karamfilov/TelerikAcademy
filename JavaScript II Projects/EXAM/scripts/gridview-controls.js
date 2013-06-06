var controls = (function () {
    var selector = 0;

    var tagsToReplace = {
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;'
    };

    function GridView(containerSelector) {
        this.container = containerSelector;
        this.header = null;
        this.rows = [];
    }

    GridView.prototype.addHeader = function (columns) {
        this.header = columns;
    }

    GridView.prototype.addRow = function (columns) {
        var newRow = new GridViewRow(columns);
        this.rows.push(newRow);
        return newRow;
    }

    function getRendered(element) {
        var content = document.createDocumentFragment();
        var table = document.createElement("table");
        if (element.header) {
            var tableHead = document.createElement("thead");
            var headerElementsCount = element.header.length;
            var cell;
            for (var i = 0; i < headerElementsCount; i++) {
                cell = document.createElement("th");
                cell.setAttribute("class", "col-" + i);
                attachEventHandler(cell, "click", sort);
                cell.innerHTML = "<a href=''>" + safeTagsReplace(element.header[i]) + "</a>";
                tableHead.appendChild(cell);
            }
        
            var rowsCount = element.rows.length;
            if (rowsCount > 0) {
                var tbody = document.createElement("tbody");
                var newRow;
                for (var i = 0; i < rowsCount; i++) {
                    newRow = element.rows[i].render();
                    tbody.appendChild(newRow);

                    if (hasClass(newRow, "nested")) {
                        var nestedRow = newRow.lastElementChild;
                        nestedRow.style.display = "none";
                        tbody.appendChild(nestedRow);
                    }
                }

                table.appendChild(tbody);
            }

            table.appendChild(tableHead);
        }

        content.appendChild(table);
        return content;
    }

    GridView.prototype.getGridViewData = function () {
        var cloned = {
            rows: []
        };
        if (this.header) {
            cloned.header = [];
            for (var i = 0; i < this.header.length; i++) {
                cloned.header.push(this.header[i]);
            }
        }
        
        for (var i = 0; i < this.rows.length; i++) {
            cloned.rows.push(this.rows[i].serialize());
        }

        return cloned;
    }

    GridViewRow.prototype.serialize = function () {
        var cloned = new GridViewRow(selector++);
        cloned.columns = this.columns;
        if (this.gridView) {
            cloned.gridView = this.gridView.getGridViewData();
        }

        return cloned;
    }

    GridView.prototype.render = function () {
        var containerElement = document.querySelector(this.container);
        var content = getRendered(this);
        containerElement.appendChild(content);
    }

    function GridViewRow(columns) {
        this.containerSelector = "#" + selector;
        this.columns = columns;
        this.gridView = null;
    }

    GridViewRow.prototype.getNestedGridView = function () {
        this.gridView = new GridView(this.containerSelector);
        return this.gridView;
    }

    GridViewRow.prototype.render = function () {
        var tableRow = document.createElement("tr");
        tableRow.setAttribute("id", selector++);
        attachEventHandler(tableRow, "click", handleRowClick);
        var columnsCount = this.columns.length;
        var cell;
        for (var j = 0; j < columnsCount; j++) {
            cell = document.createElement("td");
            cell.setAttribute("class", "col-" + j);
            cell.innerHTML = safeTagsReplace(this.columns[j]);
            tableRow.appendChild(cell);
        }

        var nested;
        if (this.gridView) {
            nested = getRendered(this.gridView);
            tableRow.appendChild(nested);
            tableRow.setAttribute("class", "nested");
        }

        return tableRow;
    }

    // Task 3
    function handleRowClick(ev) {
        if (!ev) {
            ev = window.event;
        }

        if (ev.preventDefault) {
            ev.preventDefault();
        }

        if (ev.stopPropagation) {
            ev.stopPropagation();
        }

        var cellElement = ev.target ? ev.target : ev.srcElement;
        var parent = cellElement.parentElement;
        if (hasClass(parent, "nested")) {
            if (parent.nextElementSibling.style.display == "none") {
                parent.nextElementSibling.style.display = "block";
            } else {
                parent.nextElementSibling.style.display = "none";
            }
        }
    }

    function sort(ev) {
        if (!ev) {
            ev = window.event;
        }

        if (ev.preventDefault) {
            ev.preventDefault();
        }

        if (ev.stopPropagation) {
            ev.stopPropagation();
        }

        var eventSource = ev.target ? ev.target : ev.srcElement;
        
        if (eventSource instanceof HTMLAnchorElement) {
            eventSource = eventSource.parentElement;
        }

        var columnElements = document.querySelectorAll("td." + eventSource.className);
        var toSort = [];
        for (var i = 0, len = columnElements.length; i < len; i++) {
            toSort.push(columnElements[i]);
        }

        if (parseInt(toSort[0].innerHTML)) {
            toSort.sort(function (a, b) {
                return parseInt(a.innerHTML) - parseInt(b.innerHTML);
            })  
        } else {
            toSort.sort();
        }

        console.log(toSort);
    }

    function deserialize(element) {
        var deserialized;
        deserialized = element.getNestedGridView;
        if (element.gridView) {
            deserialized.gridView = deserialize(element.gridView);
        }

        return deserialized;
    }

    function addNewRow(destination, toAdd) {
        var row = destination.addRow(toAdd.columns);
        if (toAdd.gridView) {
            var newGridView = row.getNestedGridView();
            newGridView.addHeader(toAdd.gridView.header);
            for (var i = 0; i < toAdd.gridView.rows.length; i++) {
                addNewRow(newGridView, toAdd.gridView.rows[i]);
            }
        }
    }

    function buildGridView(containerSelector, fromObject) {
        var newGridView = new GridView(containerSelector);
        newGridView.addHeader(fromObject.header);
        for (var i = 0; i < fromObject.rows.length; i++) {
            addNewRow(newGridView, fromObject.rows[i]);
        }

        console.log(newGridView);
        return newGridView;
    }

    function hasClass(element, className) {
        return (' ' + element.className + ' ').indexOf(' ' + className + ' ') > -1;
    }

    function attachEventHandler(element, eventType, eventHandler) {
        if (element) {
            if (document.addEventListener) {
                element.addEventListener(eventType, eventHandler, false);
            } else if (document.attachEvent) {
                element.attachEvent("on" + eventType, eventHandler);
            } else {
                element["on" + eventType] = eventHandler;
            }
        }
    }

    function replaceTag(tag) {
        return tagsToReplace[tag] || tag;
    }

    function safeTagsReplace(object) {
        return object.toString().replace(/[&<>]/g, replaceTag);
    }

    return {
        getGridView: function (containerSelector) {
            return new GridView(containerSelector);
        },
        buildGridView: buildGridView
    }
})();