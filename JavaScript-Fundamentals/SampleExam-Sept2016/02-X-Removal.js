function solve(dataRows){
    let matrix = dataRows.map(r => r.split(''));
    let indexesToRemove = new Set();

    for (let row = 1; row < matrix.length - 1; row++){
        for (let col = 1; col < matrix[row].length; col++){

            if (matrix[row - 1][col - 1] == undefined
            || matrix[row - 1][col + 1] == undefined
            || matrix[row][col] == undefined
            || matrix[row + 1][col - 1] == undefined
            || matrix[row + 1][col + 1] == undefined)
                continue;

            let topLeftLetter = matrix[row - 1][col - 1].toLowerCase();
            let topRightLetter = matrix[row - 1][col + 1].toLowerCase();
            let middleLetter = matrix[row][col].toLowerCase();
            let bottomLeftLetter = matrix[row + 1][col - 1].toLowerCase();
            let bottomRightLetter = matrix[row + 1][col + 1].toLowerCase();

            if (topLeftLetter == topRightLetter
                && topRightLetter == middleLetter
                && middleLetter == bottomLeftLetter
                && bottomLeftLetter == bottomRightLetter){
                indexesToRemove.add(`${row - 1},${col - 1}`);
                indexesToRemove.add(`${row - 1},${col + 1}`);
                indexesToRemove.add(`${row},${col}`);
                indexesToRemove.add(`${row + 1},${col - 1}`);
                indexesToRemove.add(`${row + 1},${col + 1}`);
            }
        }
    }

    for (let coordinates of indexesToRemove){
        let row = coordinates.split(',')[0];
        let col = coordinates.split(',')[1];
        matrix[row][col] = ''
    }

    console.log(matrix.map(row => row.join('')).join('\n'));
}

solve([
    'puoUdai',
    'miU',
    'ausupirina',
    '8n8i8',
    'm8o8a',
    '8l8o860',
    'M8i8',
    '8e8!8?!'
]);