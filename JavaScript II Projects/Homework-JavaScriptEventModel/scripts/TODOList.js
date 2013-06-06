var todoListModule = (function () {
    function TodoList(containerID) {
        this.container = document.getElementById(containerID);

        this.tasksListContainer = document.createElement("ul");

        this.tasks = [];
    }

    TodoList.prototype.load = function () {
        var self = this;

        var input = getInput();
        self.container.appendChild(input);

        var addButton = getAddButton();
        self.container.appendChild(addButton);
        addEventListener(addButton, "click", function () {
            var newTask = self.container.firstElementChild.value;
            self.tasks.push(newTask);
            render(self);
        });

        var deleteButton = getDeleteButton();
        self.container.appendChild(deleteButton);
        addEventListener(deleteButton, "click", function () {
            removeCheckedTasks(self);
            render(self);
        });

        var showButton = getShowButton();
        self.container.appendChild(showButton);
        addEventListener(showButton, "click", function () {
            self.container.lastElementChild.style.display = "block";
        });

        var hideButton = getHideButton();
        self.container.appendChild(hideButton);
        addEventListener(hideButton, "click", function myfunction() {
            self.container.lastElementChild.style.display = "none";
        });

        self.container.appendChild(self.tasksListContainer);
    }

    function render(todoList) {
        clearTasksListContainer(todoList);

        var task;
        for (var i = 0, tasksCount = todoList.tasks.length; i < tasksCount; i++) {
            task = document.createElement("label");
            task.innerHTML = "<input type='checkbox' id='check" + i + "' /> " + todoList.tasks[i] + "<br />";
            todoList.tasksListContainer.appendChild(task);
        }
    }

    function clearTasksListContainer(todoList) {
        while (todoList.tasksListContainer.firstChild) {
            todoList.tasksListContainer.removeChild(todoList.tasksListContainer.firstChild);
        }
    }

    function removeCheckedTasks(todoList) {
        var currentTaskCheckbox;
        for (var i = 0, j = 0; i < todoList.tasks.length; i++, j++) {
            currentTaskCheckbox = document.getElementById("check" + j);
            if (currentTaskCheckbox.checked) {
                todoList.tasks.splice(i, 1);
                i--;
            }
        }
    }

    function getDeleteButton() {
        var deleteButton = document.createElement("input");
        deleteButton.setAttribute("type", "button");
        deleteButton.setAttribute("value", "Delete selected tasks");
        deleteButton.style.padding = "2px 10px";
        deleteButton.style.backgroundColor = "#f00";
        return deleteButton;
    }

    function getHideButton() {
        var hideButton = document.createElement("input");
        hideButton.setAttribute("type", "button");
        hideButton.setAttribute("value", "Hide TODO list");
        hideButton.style.padding = "2px 10px";
        hideButton.style.backgroundColor = "#f00";
        return hideButton;
    }

    function getShowButton() {
        var showButton = document.createElement("input");
        showButton.setAttribute("type", "button");
        showButton.setAttribute("value", "Show TODO list");
        showButton.style.padding = "2px 10px";
        showButton.style.backgroundColor = "#00ff21";
        return showButton;
    }

    function getAddButton() {
        var addButton = document.createElement("input");
        addButton.setAttribute("type", "submit");
        addButton.setAttribute("value", "Add");
        addButton.style.padding = "2px 10px";
        addButton.style.backgroundColor = "#00ff21";
        return addButton;
    }

    function getInput() {
        var input = document.createElement("input");
        input.setAttribute("type", "text");
        input.setAttribute("placeholder", "Enter a new task");
        return input;
    }

    function addEventListener(element, eventType, eventHandler) {
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
        TodoList: TodoList
    }
})();