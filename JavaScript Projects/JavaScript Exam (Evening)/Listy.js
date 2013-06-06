function Solve(args) {
    var linesCount = args.length;

    var variables = {};
    var openingBracketIndex;
    var closingBracketIndex;
    var command;
    var commandArgs;
    var answer = 0;
    for (var i = 0; i < linesCount; i++) {
        openingBracketIndex = args[i].indexOf("[");
        closingBracketIndex = args[i].lastIndexOf("]");
        command = args[i].substr(0, openingBracketIndex);
        commandArgs = args[i].substr(openingBracketIndex + 1, closingBracketIndex - openingBracketIndex - 1);
        answer = processCommand(command, commandArgs, variables);
    }
    return answer;
}

function processCommand(command, arguments, variables) {
    var splittedCommand = command.match(/[^ ]+/g);
    var splittedArgs = arguments.match(/[^, ]+/g);
    if (splittedCommand === null) {
        return variables[splittedArgs[0]];
    }
    if (splittedCommand[0] == "def") {
        if (splittedCommand.length == 2) {
            variables[splittedCommand[1]] = splittedArgs;
        }
        else if (splittedCommand.length == 3) {
            if (splittedCommand[2] == "sum") {
                variables[splittedCommand[1]] = getSum(splittedArgs, variables);
            }
            else if (splittedCommand[2] == "avg") {
                variables[splittedCommand[1]] = Math.floor(getSum(splittedArgs, variables) / splittedArgs.length);
            }
            else if (splittedCommand[2] == "min") {
                variables[splittedCommand[1]] = getMin(splittedArgs, variables);
            }
            else if (splittedCommand[2] == "max") {
                variables[splittedCommand[1]] = getMax(splittedArgs, variables);
            }
        }
        return 0; // Neutral value (these commands do not return a real value)
    }
    else if (splittedCommand[0] == "sum") {
        return getSum(splittedArgs, variables);
    }
    else if (splittedCommand[0] == "avg") {
        return Math.floor(getSum(splittedArgs, variables) / splittedArgs.length);
    }
    else if (splittedCommand[0] == "min") {
        return getMin(splittedArgs, variables);
    }
    else if (splittedCommand[0] == "max") {
        return getMax(splittedArgs, variables);
    }
    else {
        return NaN; // Error flag
    }
}

function getSum(arguments, variables) {
    var argsCount = arguments.length;
    var parsed;
    var sum = 0;
    for (var i = 0; i < argsCount; i++) {
        parsed = parseInt(arguments[i]);
        if (!isNaN(parsed)) {
            sum += parsed;
        }
        else {
            if (variables[arguments[i]] instanceof Array) {
                sum += getSum(variables[arguments[i]], variables);
            }
            else {
                sum += variables[arguments[i]];
            }
        }
    }
    return sum;
}

function getMin(arguments, variables) {
    var min = Number.POSITIVE_INFINITY;
    var argCount = arguments.length;
    var parsed;
    for (var i = 0; i < argCount; i++) {
        parsed = parseInt(arguments[i]);
        if (!isNaN(parsed)) {
            if (parsed < min) {
                min = parsed;
            }
        }
        else {
            var tempMin;
            if (variables[arguments[i]] instanceof Array) {
                tempMin = getMin(variables[arguments[i]], variables);
            }
            else {
                tempMin = variables[arguments[i]];
            }
            if (tempMin < min) {
                min = tempMin;
            }
        }
    }
    return min;
}

function getMax(arguments, variables) {
    var max = Number.NEGATIVE_INFINITY;
    var argCount = arguments.length;
    var parsed;
    for (var i = 0; i < argCount; i++) {
        parsed = parseInt(arguments[i]);
        if (!isNaN(parsed)) {
            if (parsed > max) {
                max = parsed;
            }
        }
        else {
            var tempMax;
            if (variables[arguments[i]] instanceof Array) {
                tempMax = getMax(variables[arguments[i]], variables);
            }
            else {
                tempMax = variables[arguments[i]];
            }
            if (tempMax > max) {
                max = tempMax;
            }
        }
    }
    return max;
}