function primaryCheck(num){
    let number = Number(num);
    if (number < 2)
        return false;
    let isNumberPrime = true;
    for (let i = 2; i < Math.sqrt(number); i++) {
        if (number % i == 0){
            isNumberPrime = false;
            break;
        }
    }
    return isNumberPrime;
}

// console.log(primaryCheck(-5))
// console.log(primaryCheck(8))
// console.log(primaryCheck(81))