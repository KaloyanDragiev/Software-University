function showNums(input){
    let k = Number(input[0]);

    let firstNums = input.slice(1, k + 1);
    let secondNums = input.slice(input.length - k, input.length);
    console.log(firstNums.join(' '));
    console.log(secondNums.join(' '));
}

showNums(['2', '7', '8', '9'])