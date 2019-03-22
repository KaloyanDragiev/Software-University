function isItMagical(input){
    let matrix = input.map(r => r.split(' ').map(Number));

    for (let row = 0; row < matrix.length - 1; row++)
        if (matrix[row].reduce((a, b) => a + b) != matrix[row + 1].reduce((a, b) => a + b))
            return false;

    for (let col = 0; col < matrix[0].length - 1; col++){
        let firstSum = 0;
        let secondSum = 0
        for (let row = 0; row < matrix.length; row++){
            firstSum += matrix[row][col];
            secondSum += matrix[row][col + 1];
        }

        if (firstSum != secondSum)
            return false
    }
    return true;
}

console.log(isItMagical(['11 32 45', '21 0 1', '21 1 1']));