function printNthEl(input){
    let step = Number(input.pop());
    for (let i = 0; i < input.length; i+=step)
        console.log(input[i]);
}

printNthEl([5, 20, 31, 4, 20, 2]);