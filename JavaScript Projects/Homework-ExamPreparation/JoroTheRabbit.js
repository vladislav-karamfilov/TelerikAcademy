function Solve(args) {
    // Reading the input
    var stringsPositions = args[0].split(", ");
    var terrainLength = stringsPositions.length;
    var terrainNumbers = new Array(terrainLength);
    for (var i = 0; i < terrainLength; i++) {
        terrainNumbers[i] = parseInt(stringsPositions[i]);
    }

    // Implementing the logic
    var maxJumps = 0;
    var currentPosition;
   
    for (var startPosition = 0; startPosition < terrainLength; startPosition++) {
        for (var step = 1; step <= terrainLength; step++) {
            currentPosition = startPosition;
            var visited = {};
            var jumps = 0;
            while (!visited[currentPosition]) {
                visited[currentPosition] = true;
                jumps++;
                var lastPosition = currentPosition;
                currentPosition += step;
                if (currentPosition > terrainLength - 1) {
                    currentPosition -= terrainLength;
                }
                if (terrainNumbers[lastPosition] >= terrainNumbers[currentPosition]) {
                    break;
                }
            }
            if (jumps > maxJumps) {
                maxJumps = jumps;
            }
        }
    }
    return maxJumps;
}