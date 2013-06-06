var specialConsole = (function () {
    function writeLine(format, params) {
        if (arguments.length == 0) {
            console.log("\n");
        } else if (arguments.length == 1) {
            console.log(arguments[0].toString());
        } else {
            var result = formatString(arguments);
            console.log(result);
        }
    }

    function writeError(format, message) {
        if (arguments.length == 0) {
            throw new Error("Cannot use 'writeError' function without parameters");
        } else if (arguments.length == 1) {
            writeLine(format);
        } else {
            writeLine(format, message);
        }
    }

    function writeWarning(format, message) {
        if (arguments.length == 0) {
            throw new Error("Cannot use 'writeWarning' function without parameters");
        } else if (arguments.length == 1) {
            writeLine(format);
        } else {
            writeLine(format, message);
        }
    }

    function formatString() {
        var text = arguments[0][0];
        var args = new Array();
        for (var i = 1; i < arguments[0].length; i++) {
            args.push(arguments[0][i].toString());
        }

        var formattedString = "";
        var inPlaceholder = false;
        var placeholder = "";

        for (var i = 0; i < text.length; i++) {
            if (text[i] === "{") {
                inPlaceholder = true;
                continue;
            } else if (text[i] === "}") {
                inPlaceholder = false;
                continue;
            }

            if (inPlaceholder) {
                placeholder += text[i];
            } else {
                if (placeholder.length != 0) {
                    var placeholderIndex = placeholder | 0;
                    formattedString += args[placeholderIndex];
                }

                placeholder = "";
                formattedString += text[i];
            }
        }

        if (placeholder.length != 0) {
            var placeholderIndex = placeholder | 0;
            formattedString += args[placeholderIndex];
        }

        return formattedString;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
})();