var visited;

function Solve(args) {
    var firstInputLine = args[0].split(" ");
    var rows = parseInt(firstInputLine[0]);
    var cols = parseInt(firstInputLine[1]);
    var numberOfJumps = parseInt(firstInputLine[2]);

    var field = getField(rows, cols);

    var secondInputLine = args[1].split(" ");
    var startRow = parseInt(secondInputLine[0]);
    var startCol = parseInt(secondInputLine[1]);

    var jumpsPatterns = getJumpsPatterns(numberOfJumps, args);

    var jumpsMade = 0;
    var sumOfNumbers = 0;
    var isCaught = false;

    var currentJumpPattern = 0;
    while (true) {
        visited[startRow][startCol] = true;
        jumpsMade++;
        sumOfNumbers += field[startRow][startCol];
        startRow += jumpsPatterns[currentJumpPattern % numberOfJumps][0];
        startCol += jumpsPatterns[currentJumpPattern % numberOfJumps][1];
        if (!isInField(startRow, startCol, field)) {
            break;
        }
        if (visited[startRow][startCol]) {
            isCaught = true;
            break;
        }
        currentJumpPattern++;
    }

    if (isCaught) {
        return "caught " + jumpsMade;
    }
    else {
        return "escaped " + sumOfNumbers;
    }
}

function isInField(currentRow, currentCol, field) {
    if (currentRow < 0 || currentRow >= field.length) {
        return false;
    }
    if (currentCol < 0 || currentCol >= field[0].length) {
        return false;
    }
    return true;
}

function getJumpsPatterns(numberOfJumps, args) {
    var jumpsPatterns = new Array(numberOfJumps);
    for (var i = 0; i < numberOfJumps; i++) {
        var currentInputLine = args[i + 2].split(" ");
        jumpsPatterns[i] = new Array(2);
        jumpsPatterns[i][0] = parseInt(currentInputLine[0]);
        jumpsPatterns[i][1] = parseInt(currentInputLine[1]);
    }
    return jumpsPatterns;
}

function getField(rows, cols) {
    var field = new Array(rows);
    var value = 1;
    visited = new Array(rows);
    for (var row = 0; row < rows; row++) {
        field[row] = new Array(cols);
        visited[row] = new Array(cols);
        for (var col = 0; col < cols; col++) {
            field[row][col] = value++;
            visited[row][col] = false;
        }
    }
    return field;
}