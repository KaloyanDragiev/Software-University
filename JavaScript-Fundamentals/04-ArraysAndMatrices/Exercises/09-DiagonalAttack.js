function attack(input){
    let matrix = input.map(r => r.split(' ').map(Number));
    let mainDiagSum = 0;
    let secondDiagSum = 0;

    for (let row = 0; row < matrix.length; row++){
        for (let col = 0; col < matrix[row].length; col++){
            if (col == row)
                mainDiagSum += matrix[row][col]
            if (row + col == matrix.length - 1)
                secondDiagSum += matrix[row][col]
        }
    }

    if (mainDiagSum == secondDiagSum){
        for (let row = 0; row < matrix.length; row++){
            for (let col = 0; col < matrix[row].length; col++){
                if (col != row && row + col != matrix.length - 1)
                    matrix[row][col] = mainDiagSum;
            }
        }
    }

    return matrix.map(row => row.join(' ')).join('\n');
}

console.log(attack(['5 3 12 3 1', '11 4 23 2 5', '101 12 3 21 10', '1 4 5 2 2', '5 22 33 11 1']));