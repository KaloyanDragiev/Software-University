function sumIncome(input){
    let towns = {};
    for (let i = 0; i < input.length; i+=2){
        let city = input[i];
        let income = Number(input[i + 1]);

        if (towns[city] == undefined)
            towns[city] = 0
        towns[city] += income;
    }
    return JSON.stringify(towns);
}

// console.log(sumIncome(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4']));