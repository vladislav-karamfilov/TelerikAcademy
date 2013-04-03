var durankulakDigits = getDurankulakDigits();

function Solve(args) {
    var currentDurankulakDigit = "";
    var decimalNumbers = new Array();
    for (var i = 0; i < args[0].length; i++) {
        currentDurankulakDigit += args[0][i];
        var decimalNumber = getDecimalNumber(currentDurankulakDigit);
        if (decimalNumber >= 0) {
            decimalNumbers.push(decimalNumber);
            currentDurankulakDigit = "";
        }
    }
    return convertToDecimalNumber(decimalNumbers);
}

function convertToDecimalNumber(decimalNumbers) {
    var result = 0;
    var decimalNumbersCount = decimalNumbers.length;
    for (var i = decimalNumbersCount - 1; i >= 0; i--) {
        result += decimalNumbers[i] * Math.pow(168, decimalNumbersCount - i - 1);
    }
    return result;
}

function getDecimalNumber(currentDurankulakDigit) {
    for (var i = 0; i < 168; i++) {
        if (currentDurankulakDigit == durankulakDigits[i]) {
            return i;
        }
    }
    return -1;
}

function getDurankulakDigits() {
    var durankulakDigits = new Array(168);
    var capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    for (var i = 0; i < 168; i++) {
        if (i < 26) {
            durankulakDigits[i] = capitalLetters[i];
        }
        else if (i < 52) {
            durankulakDigits[i] = "a" + capitalLetters[i % 26];
        }
        else if (i < 78) {
            durankulakDigits[i] = "b" + capitalLetters[i % 26];
        }
        else if (i < 104) {
            durankulakDigits[i] = "c" + capitalLetters[i % 26];
        }
        else if (i < 130) {
            durankulakDigits[i] = "d" + capitalLetters[i % 26];
        }
        else if (i < 156) {
            durankulakDigits[i] = "e" + capitalLetters[i % 26];
        }
        else {
            durankulakDigits[i] = "f" + capitalLetters[i % 26];
        }
    }

    return durankulakDigits;
}