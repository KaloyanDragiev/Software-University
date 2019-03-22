function solveEquation(input){
    let a = Number(input[0]);
    let b = Number(input[1]);
    let c = Number(input[2]);

    let discr = b * b - 4 * a * c;

    if (discr < 0)
        return 'No';
    else if (discr == 0){
        return -b / (2 * a);
    }
    else {
        let sqrtDiscr = Math.sqrt(discr);
        let firstRoot = (- b + sqrtDiscr) / (2 * a);
        let secondRoot = (- b - sqrtDiscr) / (2 * a);
        return `${Math.min(firstRoot,secondRoot)}\n${Math.max(firstRoot,secondRoot)}`;
    }
}

//console.log(solveEquation([5,2,1]));
//console.log(solveEquation([1,-12,36]));
//console.log(solveEquation([6,11,-35]));
