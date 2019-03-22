function convertToDecimal(binaryNum) {
    let arrAsString = binaryNum.toString();
    let result = 0;
    let power = 7;
    for (let i = 0; i < arrAsString.length; i++) {
        result += arrAsString.charAt(i) * Math.pow(2, power);
        power--;
    }
    return result;
}

// console.log(convertToDecimal(['00001001']));
// console.log(convertToDecimal(['11110000']));


// Version Two using intParse
// binaryNum = parseInt(binaryNum, 2);
