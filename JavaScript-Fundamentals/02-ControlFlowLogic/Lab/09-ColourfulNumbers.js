function printNumbers([numberOfLines]) {
    let result = '<ul>\r\n';
    for (let i = 1; i <= numberOfLines; i++){
        result += '  <li><span style=\'color:';
        if (i % 2 == 0){
            result += 'blue';
        }
        else {
            result += 'green';
        }
        result += `'\'>${i}</span></li>\r\n`;
    }
    result+='</ul>'
    return result;
}

// console.log(printNumbers([10]));
// document.body.innerHTML = printNumbers(10);
