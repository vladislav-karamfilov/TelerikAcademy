var digits9Gag = ["-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-"];

function Solve(args) {
    var numberLength = args[0].length;
    var decimalNumber = 0;
    var currentDigit = "";
    var decimalDigit;
    var numberDigits = new Array();
    for (var i = 0; i < numberLength; i++) {
        currentDigit += args[0][i];
        if (currentDigit.length >= 2) {
            decimalDigit = getDecimalDigit(currentDigit);
            if (decimalDigit >= 0) {
                numberDigits.push(decimalDigit);
                currentDigit = "";
            }
        }
    }
    var digits = numberDigits.length;
    for (var i = digits - 1; i >= 0; i--) {
        decimalNumber += numberDigits[i] * getPower(9, digits - i - 1);
    }
    return decimalNumber;
}

function getPower(number, power) {
    var result = 1;
    for (var i = 0; i < power; i++) {
        result *= number;
    }
    return result;
}

function getDecimalDigit(currentDigit) {
    for (var i = 0; i < 9; i++) {
        if (currentDigit == digits9Gag[i]) {
            return i;
        }
    }
    return -1;
}