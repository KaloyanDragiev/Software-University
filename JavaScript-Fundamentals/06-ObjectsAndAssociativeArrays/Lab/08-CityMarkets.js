function printSales(dataRows){
    let townStats = new Map();
    for (let dataRow of dataRows){
        let productInfo = dataRow.split('->').map(p => p.trim());
        let priceInfo = productInfo[2].split(':').map(p => p.trim());
        let town = productInfo[0];
        let productName = productInfo[1];
        let amountOfSales = Number(priceInfo[0]);
        let pricePerUnit = Number(priceInfo[1]);

        if (!townStats.has(town))
            townStats.set(town, new Map())
        if (!townStats.get(town).has(productName))
            townStats.get(town).set(productName, 0);

        let oldAmount = townStats.get(town).get(productName)
        let newAmount = oldAmount + amountOfSales * pricePerUnit;

        townStats.get(town).set(productName, newAmount)
    }

    for (let [key, value] of townStats){
        console.log(`Town - ${key}`)
        for (let [innerKey, innerValue] of value){
            console.log(`$$$${innerKey} : ${innerValue}`)
        }
    }
}

printSales(['Sofia -> Laptops HP -> 200 : 2000',
            'Sofia -> Raspberry -> 200000 : 1500',
            'Sofia -> Raspberry -> 200 : 100000',
            'Montana -> Portokals -> 200000 : 1',
            'Montana -> Qgodas -> 20000 : 0.2',
            'Montana -> Chereshas -> 1000 : 0.3'
]);