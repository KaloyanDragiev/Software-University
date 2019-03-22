function calcSumFirstLastEl(input){
    let arr = input.map(Number);
    let firstElement = arr[0];
    let lastElement = arr[arr.length-1];
    return firstElement + lastElement;
}

console.log(calcSumFirstLastEl(['20', '30', '40']))