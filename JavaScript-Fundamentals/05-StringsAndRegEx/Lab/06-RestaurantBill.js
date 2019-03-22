function printBill(input){
    let products = [];
    let price = [];
    for (let i in input){
        if (i % 2 == 0)
            products.push(input[i])
        else
            price.push(Number(input[i]))
    }
    let totalSum = price.reduce((a, b) => a + b);
    return `You purchased ${products.join(', ')} for a total sum of ${totalSum}`
}

// function printBill(input) {
//     let items = input.filter(x => !Number(x));
//     let sum = input.filter(x => Number(x))
//         .map(Number)
//             .reduce((a,b) => a + b);
//     console.log(`You purchased ${items.join(', ')} for a total sum of ${sum}`);
// }

// console.log(printBill(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']));
