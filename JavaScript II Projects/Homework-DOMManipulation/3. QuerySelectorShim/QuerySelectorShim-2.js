if (!document.querySelector) {
    document.querySelector = function (selector) {
        return Sizzle(selector)[0];
    }
}

if (!document.querySelectorAll) {
    document.querySelectorAll = function (selector) {
        return Sizzle(selector);
    }
}