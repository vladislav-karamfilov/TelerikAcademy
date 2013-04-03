function Solve(args) {
    var linesCount = parseInt(args[0]);
    var textContent = "";
    for (var line = 0; line < linesCount; line++) {
        textContent += getLineText(args[line + 1]);
        textContent += "\n";
    }
    return textContent;
}

function getLineText(ftmlLine) {
    var tagName = "";
    var tagContent = "";

    var firstClosingTagOpenIndex = ftmlLine.indexOf("</");
    var firstClosingTagCloseIndex = 0;
    var firstOpenTagIndex = 0;
    var firstCloseTagIndex = 0;

    while (firstClosingTagOpenIndex >= 0) {
        firstOpenTagIndex = ftmlLine.lastIndexOf("<", firstClosingTagOpenIndex - 1);
        firstClosingTagCloseIndex = ftmlLine.indexOf(">", firstClosingTagOpenIndex);
        firstCloseTagIndex = ftmlLine.indexOf(">", firstOpenTagIndex + 1);
        tagName = ftmlLine.substr(firstOpenTagIndex + 1, firstCloseTagIndex - firstOpenTagIndex - 1);
        tagContent = ftmlLine.substr(firstCloseTagIndex + 1, firstClosingTagOpenIndex - firstCloseTagIndex - 1);
        ftmlLine = ftmlLine.replace(ftmlLine.substr(firstOpenTagIndex, firstClosingTagCloseIndex - firstOpenTagIndex + 1),
            processTag(tagName, tagContent));

        firstClosingTagOpenIndex = ftmlLine.indexOf("</");
    }
    return ftmlLine;
}

function processTag(name, content) {
    if (name == "upper") {
        return content.toUpperCase();
    }
    else if (name == "lower") {
        return content.toLowerCase();
    }
    else if (name == "del") {
        return "";
    }
    else if (name == "rev") {
        var result = "";
        for (var i = content.length - 1; i >= 0; i--) {
            result += content[i];
        }
        return result;
    }
    else if (name == "toggle") {
        var length = content.length;
        var result = "";
        for (var i = 0; i < length; i++) {
            if (content[i] >= "a" && content[i] <= "z") {
                result += content[i].toUpperCase();
            }
            else if (content[i] >= "A" && content[i] <= "Z") {
                result += content[i].toLowerCase();
            }
            else {
                result += content[i];
            }
        }
        return result;
    }
}