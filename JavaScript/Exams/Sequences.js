function Solve(params) {
    var n = parseInt(params[0]);
    var answer = 0;
    var numbers = new Array(n);
    for (var i = 0; i < n; i++) {
        numbers[i] = parseInt(params[i + 1]);
    }
    var inNonDecreasing = false;
    for (var i = 0; i < n - 1; i++) {
        if (numbers[i] <= numbers[i + 1]) {
            if (!inNonDecreasing) {
                inNonDecreasing = true;
                answer++;
            }
        }
        else {
            answer++;
        }
    }
    return answer;
}