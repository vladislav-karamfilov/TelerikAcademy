function Solve(args) {
    var numbersCount = parseInt(args[0]);

    var maxSum = Number.NEGATIVE_INFINITY;
    var currentMaxSum = 0;
    
    for (var currentEndIndex = 0; currentEndIndex < numbersCount; currentEndIndex++) {
        currentMaxSum += parseInt(args[currentEndIndex + 1]);
        if (currentMaxSum > maxSum) {
            maxSum = currentMaxSum;
        }
        if (currentMaxSum < 0) {
            currentMaxSum = 0;
        }
    }
    return maxSum;
}