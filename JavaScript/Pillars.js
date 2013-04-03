var grid = new Array(8);

function Solve(args) {
    // Reading the input and filling the grid
    for (var row = 0; row < 8; row++) {
        grid[row] = new Array(8);
        var number = parseInt(args[row]);
        for (var col = 0; col < 8; col++) {
            grid[row][col] = (number >> col) & 1;
        }
    }

    for (var pillar = 7; pillar >= 0; pillar--) {
        var leftSum = getLeftSum(pillar);
        var rightSum = getRightSum(pillar);
        if (leftSum == rightSum) {
            return pillar + "\n" + leftSum;
        }
    }
    return "No";
}

function getLeftSum(pillar) {
    var sum = 0;
    for (var row = 0; row < 8; row++) {
        for (var col = 7; col > pillar; col--) {
            sum += grid[row][col];
        }
    }
    return sum;
}

function getRightSum(pillar) {
    var sum = 0;
    for (var row = 0; row < 8; row++) {
        for (var col = pillar - 1; col >= 0; col--) {
            sum += grid[row][col];
        }
    }
    return sum;
}