function biggestElement(matrix) {
	let biggestNum = Number.NEGATIVE_INFINITY;
	matrix.forEach(r => r.forEach(c => biggestNum = Math.max(biggestNum, c)));
	return biggestNum;
}

// console.log(biggestElement(['20 50 10', '8 33 145']))

// Version 2 with for-in
// for (let row in matrix){
//      for (let col in matrix[row]){
//          let currentNum = matrix[row][col];
//          if (biggestNum < matrix[row][col])
//              biggestNum = matrix[row][col];
//      }
//  }
