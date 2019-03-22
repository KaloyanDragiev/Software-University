function printOdd(input){
    let bound = Number(input[0]);
    for (let i = 1; i <= bound; i+=2) {
        console.log(i);
    }
}

printOdd([5])