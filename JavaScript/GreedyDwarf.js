function Solve(args) {
    var inputValley = args[0].split(", ");
    var valleyLength = inputValley.length;
    var valley = new Array(valleyLength);
    for (var i = 0; i < valleyLength; i++) {
        valley[i] = parseInt(inputValley[i]);
    }
    var m = parseInt(args[1]);
    var patterns = new Array(m);
    for (var i = 0; i < m; i++) {
        var currentPattern = args[i + 2].split(", ");
        patterns[i] = new Array(currentPattern.length);
        for (var j = 0; j < currentPattern.length; j++) {
            patterns[i][j] = parseInt(currentPattern[j]);
        }
    }
    return findMaxCoins(valley, patterns);
}

function findMaxCoins(valley, patterns) {
    var maxCoins = -9007199254740992;
    for (var i = 0; i < patterns.length; i++) {
        var currentCoins = valley[0];
        var currentIndexInValley = 0;
        var visited = new Array(valley.length);
        visited[0] = true;
        for (var j = 0; j < patterns[i].length; j++) {
            if (isValidIndex(currentIndexInValley + patterns[i][j], visited)) {
                visited[currentIndexInValley + patterns[i][j]] = true;
                currentCoins += valley[currentIndexInValley + patterns[i][j]];
                currentIndexInValley += patterns[i][j];
            }
            else {
                break;
            }
            if (j == patterns[i].length - 1) {
                j = -1;
            }
        }
        if (currentCoins > maxCoins) {
            maxCoins = currentCoins;
        }
    }
    return maxCoins;
}

function isValidIndex(index, visited) {
    if (index < 0) {
        return false;
    }
    if (index >= visited.length) {
        return false;
    }
    if (visited[index]) {
        return false;
    }
    return true;
}