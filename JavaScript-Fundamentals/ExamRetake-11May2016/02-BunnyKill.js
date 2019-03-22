function countDamageAndBunnies(dataRows){
    let coordinates = dataRows.pop().split(' ');
    let matrix = dataRows.map(r => r.split(' ').map(Number));
    let damage = 0;
    let bunniesKilled = 0;

    for (let coordinate of coordinates){
        let bombInfo = coordinate.split(',');
        let bombRow = Number(bombInfo[0]);
        let bombCol = Number(bombInfo[1]);
        let bombDamage = matrix[bombRow][bombCol];

        let bombUpperRow = Math.max(0, bombRow - 1);
        let bombLowerRow = Math.min(bombRow + 1, matrix.length - 1);
        let bombLeftCol = Math.max(0, bombCol - 1);
        let bombRightCol = Math.min(matrix[bombRow].length - 1, bombCol + 1);

        if (bombDamage > 0){
            for (let row = bombUpperRow; row <= bombLowerRow; row ++){
                for (let col = bombLeftCol; col <= bombRightCol; col ++){
                    matrix[row][col] -= bombDamage;
                }
            }
            damage += bombDamage;
            bunniesKilled++;
        }
    }

    for (let row = 0; row < matrix.length; row ++){
        for (let col = 0; col < matrix[row].length; col ++){
            if (matrix[row][col] > 0){
                bunniesKilled++;
                damage+= matrix[row][col];
            }
        }
    }
    console.log(damage);
    console.log(bunniesKilled);
}

countDamageAndBunnies([ '10 10 10 10 10',
                        '10 10 10',
                        '10 10 10',
                        '0,0 1,1']);

/*if (bombDamage > 0){
 for (let row = bombRow - 1; row <= bombRow + 1; row ++){
 for (let col = bombCol - 1; col <= bombCol  + 1; col ++){
 try{
 matrix[row][col] -= bombDamage;
 }
 finally {
 continue;
 }
 }
 }
 damage += bombDamage;
 bunniesKilled++;
 }*/