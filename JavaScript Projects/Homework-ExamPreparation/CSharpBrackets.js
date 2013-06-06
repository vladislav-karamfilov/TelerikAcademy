function Solve(args) {
    var lines = parseInt(args[0]);
    var indentation = args[1];
    var formatted = "";
    var currentContent = "";
    var indentationsCount = 0;
    for (var i = 0; i < lines; i++) {
        var currentLine = args[i + 2].trim();
        for (var j = 0; j < currentLine.length; j++) {
            if (currentLine[j] == "{") {
                formatted += currentContent.trim();
                currentContent = "";
                formatted += "\n";
                formatted += appendIndentations(indentation, indentationsCount);
                formatted += "{\n";
                indentationsCount++;
            }
            else if (currentLine[j] == "}") {
                formatted += currentContent.trim();
                currentContent = "";
                formatted += "\n";
                indentationsCount--;
                formatted += appendIndentations(indentation, indentationsCount);
                formatted += "}\n";
            }
            else {
                if (formatted[formatted.length - 1] == "\n") {
                    formatted += appendIndentations(indentation, indentationsCount);
                }
                if (currentContent[currentContent.length - 1] == " " && currentLine[j] == " ") {
                    continue;
                }
                currentContent += currentLine[j];
            }
        }
        formatted += currentContent.trim();
        currentContent = "";
        formatted += "\n";
    }
    return getResult(formatted);
}

function getResult(formatted) {
    var result = formatted[0];
    for (var i = 1; i < formatted.length; i++) {
        if (formatted[i] == "\n" && formatted[i - 1] == "\n") {
            continue;
        }
        result += formatted[i];
    }
    return result.trim();
}

function appendIndentations(indentation, indentationsCount) {
    var result = "";
    for (var i = 0; i < indentationsCount; i++) {
        result += indentation;
    }
    return result;
}