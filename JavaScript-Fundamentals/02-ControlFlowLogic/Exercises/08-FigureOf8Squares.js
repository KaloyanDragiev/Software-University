function drawFigure([size]){
    let bound = size % 2 == 0 ? size - 1 : size;
    let result = '';

    for (let row = 1; row <= bound; row++) {
        if (row == 1 || row == bound || Math.ceil(bound / 2) == row){
            result += `+${'-'.repeat(size - 2)}+${'-'.repeat(size - 2)}+\n`;
        }
        else{
            result += `|${' '.repeat(size - 2)}|${' '.repeat(size - 2)}|\n`
        }
    }
    return result;
}

console.log(drawFigure([8]));