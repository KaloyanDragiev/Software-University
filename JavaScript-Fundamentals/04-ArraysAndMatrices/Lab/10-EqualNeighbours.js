function countEqualNeighbors(matrix){
    let counter = 0;
    for (let row = 0; row < matrix.length; row++){
        for (let col = 0; col < matrix[row].length; col++){
            let currentElement = matrix[row][col];
            if (col + 1 < matrix[row].length && currentElement == matrix[row][col + 1])
                counter++;
            if (row + 1 < matrix.length && currentElement == matrix[row + 1][col])
                counter++;
        }
    }
    return counter;
}

console.log(countEqualNeighbors(['test yes yo ho', 'well done yo 6', 'not done yet 5']));
