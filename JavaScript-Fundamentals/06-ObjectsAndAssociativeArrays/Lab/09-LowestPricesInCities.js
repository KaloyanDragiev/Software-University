function findLowestPrice(dataRows){
    let productsByTown = new Map();

    for (let dataRow of dataRows){
        let productInfo = dataRow.split('|');
        let town = productInfo[0].trim();
        let product = productInfo[1].trim();
        let price = Number(productInfo[2].trim());

        if (!productsByTown.has(product)){
            productsByTown.set(product, new Map())
        }
        productsByTown.get(product).set(town, price)
    }

    for (let [prodName, townPrice] of productsByTown){
        let minPrice = Number.MAX_VALUE;
        let desiredTown = '';
        for (let [town, price] of townPrice){
            if (price < minPrice){
                minPrice = price;
                desiredTown = town;
            }

        }
        console.log(`${prodName} -> ${minPrice} (${desiredTown})`)
    }
}

findLowestPrice(['Sample Town | Sample Product | 1000',
                'Sample Town | Orange | 2',
                'Sample Town | Peach | 1',
                'Sofia | Orange | 3',
                'Sofia | Peach | 2',
                'New York | Sample Product | 1000.1',
                'New York | Burger | 10'
]);