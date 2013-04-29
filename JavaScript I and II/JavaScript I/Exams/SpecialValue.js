function Solve(args) {
    var input = parseInput(args);
    var firstRowLength = input[0].length;
    var rowsCount = input.length;
    var maxSpecialValue = 0;
    
    for (var index = 0; index < firstRowLength; index++) {
        var visitedNegative = false;
        var currentPath = 1;
        var nextCol = input[0][index];
        if (nextCol >= 0) {
            var visited = {};
            var nextRow = 0;
            do {
                visited[nextRow + " " + nextCol] = true;
                nextRow = (nextRow + 1) % rowsCount;
                currentPath++;
                if (input[nextRow][nextCol] < 0) {
                    visitedNegative = true;
                    currentPath += Math.abs(input[nextRow][nextCol]);
                    break;
                }
                nextCol = input[nextRow][nextCol];
            } while (!visited[nextRow + " " + nextCol]);
        }
        else {
            visitedNegative = true;
            currentPath += Math.abs(nextCol);
        }
        if (visitedNegative) {
            if (maxSpecialValue < currentPath) {
                maxSpecialValue = currentPath;
            }
        }
    }
    return maxSpecialValue;
}

function parseInput(args) {
    var n = parseInt(args[0]);
    var input = new Array(n);
    for (var i = 0; i < n; i++) {
        var currentElements = args[i + 1].split(", ");
        input[i] = new Array();
        for (var j = 0; j < currentElements.length; j++) {
            input[i][j] = parseInt(currentElements[j]);
        }
    }
    return input;
}