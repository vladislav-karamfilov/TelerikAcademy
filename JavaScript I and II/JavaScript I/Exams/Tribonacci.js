function Solve(args) {
    var firstElement = parseInt(args[0]);
    var secondElement = parseInt(args[1]);
    var thirdElement = parseInt(args[2]);
    var n = parseInt(args[3]);
    if (n == 1) {
        return firstElement;
    }
    else if (n == 2) {
        return secondElement;
    }
    else if (n == 3) {
        return thirdElement;
    }
    var nthElement = 0;
    for (var i = 0; i < n - 3; i++) {
        nthElement = firstElement + secondElement + thirdElement;
        firstElement = secondElement;
        secondElement = thirdElement;
        thirdElement = nthElement;
    }
    return nthElement;
}