function extract([input]){
    let resultArr = [];
    let rightPar = -1
    while (true){
        let leftPar = input.indexOf('(', rightPar + 1);
        if (leftPar == -1)
            break;
        rightPar = input.indexOf(')', leftPar + 1);
        if (rightPar == -1)
            break;
        resultArr.push(input.substring(leftPar + 1, rightPar))
    }
    return resultArr.join(', ')
}

console.log(extract(['(dock)dsfdsfs(dick)']));