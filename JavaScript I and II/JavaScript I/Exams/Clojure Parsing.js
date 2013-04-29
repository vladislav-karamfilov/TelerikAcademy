var functions = {};
var InvalidOperation = "Division by zero! At Line:";

function Solve(args) {
    var linesCount = args.length;
    
    var firstClosingBracket;
    var lastOpeningBracket;
    var command;
    var commandResult;

    for (var i = 0; i < linesCount; i++) {
        var currentLine = args[i];
        firstClosingBracket = currentLine.indexOf(")");
        while (firstClosingBracket >= 0) {
            lastOpeningBracket = currentLine.lastIndexOf("(", firstClosingBracket);

            command = currentLine.substr(lastOpeningBracket + 1, firstClosingBracket - lastOpeningBracket - 1);
            commandResult = processCommand(command);
            if (commandResult == InvalidOperation) {
                return InvalidOperation + (i + 1);
            }

            currentLine = currentLine.replace(currentLine.substr(lastOpeningBracket, firstClosingBracket - lastOpeningBracket + 1), commandResult);
            firstClosingBracket = currentLine.indexOf(")");
        }
    }

    return commandResult;
}

function processCommand(command) {
    var answer;

    var splittedCommand = command.match(/[^ ]+/g);
    var commandName = splittedCommand[0];
    var commandArgsCount = splittedCommand.length - 1;

    if (commandName == "+") {
        answer = 0;
        var parsed;
        for (var i = 0; i < commandArgsCount; i++) {
            parsed = parseInt(splittedCommand[i + 1]);
            if (!isNaN(parsed)) {
                answer += parsed;
            }
            else {
                answer += functions[splittedCommand[i + 1]];
            }
        }
    }
    else if (commandName == "-") {
        var parsed = parseInt(splittedCommand[1]);
        if (!isNaN(parsed)) {
            answer = parsed;
        }
        else {
            answer = functions[splittedCommand[1]];
        }
        for (var i = 1; i < commandArgsCount; i++) {
            parsed = parseInt(splittedCommand[i + 1]);
            if (!isNaN(parsed)) {
                answer -= parsed;
            }
            else {
                answer -= functions[splittedCommand[i + 1]];
            }
        }
    }
    else if (commandName == "/") {
        var parsed = parseInt(splittedCommand[1]);
        if (!isNaN(parsed)) {
            answer = parsed;
        }
        else {
            answer = functions[splittedCommand[1]];
        }
        for (var i = 1; i < commandArgsCount; i++) {
            parsed = parseInt(splittedCommand[i + 1]);
            if (!isNaN(parsed)) {
                if (parsed === 0) {
                    return InvalidOperation;
                }
                else {
                    answer = Math.floor(answer / parsed);
                }
            }
            else {
                if (functions[splittedCommand[i + 1]] === 0) {
                    return InvalidOperation;
                }
                else {
                    answer = Math.floor(answer / functions[splittedCommand[i + 1]]);
                }
            }
        }
    }
    else if (commandName == "*") {
        answer = 1;
        var parsed;
        for (var i = 0; i < commandArgsCount; i++) {
            parsed = parseInt(splittedCommand[i + 1]);
            if (!isNaN(parsed)) {
                answer *= parsed;
            }
            else {
                answer *= functions[splittedCommand[i + 1]];
            }
        }
    }
    else if (commandName == "def") {
        var parsed = parseInt(splittedCommand[2]);
        if (!isNaN(parsed)) {
            functions[splittedCommand[1]] = parsed;
        }
        else {
            functions[splittedCommand[1]] = functions[splittedCommand[2]];
        }
        answer = functions[splittedCommand[1]];
    }
    return answer;
}