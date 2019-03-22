function concatReverse(input){
    let result = '';
    for (let str of input)
        result += str;
    let concatResult = '';
    for (let i = result.length - 1; i>= 0; i--)
        concatResult += result[i];
    console.log(concatResult)
}

// concatReverse(['I', 'am', 'student'])

// Version two using JOIN REVERSE ARRAY.FROM
//function concatenateAndReverse(arr) {
//let allStrings = arr.join('');
//let chars = Array.from(allStrings);
//let revChars = chars.reverse();
//let revStr = revChars.join('');
//return revStr;
//}

// Version three with one line
//    return input.join('').split('').reverse().join('');

