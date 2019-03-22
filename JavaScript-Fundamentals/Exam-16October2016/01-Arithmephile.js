function solve(dataRows){
    let numbers = dataRows.map(Number);
    let biggestProduct = Number.NEGATIVE_INFINITY;
    for (let i = 0; i < numbers.length; i++){
        if (numbers[i] < 10 && numbers[i] >= 0) {
            let upperBound = numbers[i];
            let product = 1;
            for (let j = 1; j <= upperBound; j++)
                product *= numbers[i + j];
            if (product > biggestProduct)
                biggestProduct = product;
        }
    }
    return biggestProduct;
}

console.log(solve(['1', '-297', '2', '30', '44', '3', '56', '20', '24']));