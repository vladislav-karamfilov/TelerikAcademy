function Solve(args) {
    var fieldSizes = args[0].split(" ");
    var rows = parseInt(fieldSizes[0]);
    var cols = parseInt(fieldSizes[1]);

    var startPosition = args[1].split(" ");
    var startRow = parseInt(startPosition[0]);
    var startCol = parseInt(startPosition[1]);

    var fieldNumbers = new Array(rows);
    var fieldDirections = new Array(rows);
    var visited = new Array(rows);
    var value = 1;
    for (var row = 0; row < rows; row++) {
        fieldNumbers[row] = new Array(cols);
        fieldDirections[row] = new Array(cols);
        visited[row] = new Array(cols);
        for (var col = 0; col < cols; col++) {
            fieldNumbers[row][col] = value++;
            fieldDirections[row][col] = args[row + 2][col];
            visited[row][col] = false;
        }
    }

    var newCoordsAddition;
    var sumOfNumbers = 0;
    var numberOfCells = 0;
    while (true) {
        sumOfNumbers += fieldNumbers[startRow][startCol];
        numberOfCells++;
        visited[startRow][startCol] = true;

        newCoordsAddition = processDirection(fieldDirections[startRow][startCol]);
        startRow += newCoordsAddition[0];
        startCol += newCoordsAddition[1];

        if (!isInField(startRow, startCol, fieldNumbers)) {
            return "out " + sumOfNumbers;
        }
        if (visited[startRow][startCol]) {
            return "lost " + numberOfCells;
        }
    }
}

function isInField(row, col, field) {
    if (row < 0 || row >= field.length) {
        return false;
    }
    if (col < 0 || col >= field[0].length) {
        return false;
    }
    return true;
}

function processDirection(direction) {
    if (direction == "r") {
        return [0, 1];
    }
    else if (direction == "l") {
        return [0, -1];
    }
    else if (direction == "d") {
        return [1, 0];
    }
    else {
        return [-1, 0]
    }
}