function calcSumVAT(input){
    let sum = 0
    let countOfNumbers = input.length;
    for (let i = 0; i < countOfNumbers; i++){
        sum += Number(input[i]);
    }
    console.log('sum = ' + sum);
    console.log('VAT = ' + sum * 0.2);
    console.log('total = ' + (sum * 1.2))
}

//calcSumVAT('1.20', '2.60', '3.50')
