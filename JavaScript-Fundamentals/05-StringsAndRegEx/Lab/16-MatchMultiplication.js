function multiply([text]){
    let pattern = /(\-*[1-9]+[0-9]*)\s*\*\s*(\-*[0-9]+[0-9\.]*)/g;
    let match;
    while (match = pattern.exec(text))
        text = text.replace(match[0], Number(match[1] * Number(match[2])));
    return text
}

console.log(multiply(['My bill: 2*2.50 (beer); 2* 1.20 (kepab); -2  * 0.5 (deposit).' +
'']));

// Version 2 : author solution
// function performMultiplications([text]) {
//     return text.replace(/(-?\d+)\s*\*\s*(-?\d+(\.\d+)?)/g, (match, num1, num2) => Number(num1) * Number(num2));
// }

// Helper for replace
// let pattern = /([A-Za-z]+)([\d]+)(?=\s)/g;
// let text = 'Word98 SecondWord33 ThirdWord54';
// text = text.replace(pattern, replacer)
//
// function replacer(match, gr1, gr2) { return gr2 + gr1; }
