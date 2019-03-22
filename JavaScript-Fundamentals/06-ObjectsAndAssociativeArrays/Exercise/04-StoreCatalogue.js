function sortCatalogue(dataRows){
    let store = new Map()
    for (let dataRow of dataRows){
        let productInfo = dataRow.split(':').map(prod => prod.trim());
        let productName = productInfo[0];
        let price = Number(productInfo[1]);
        let firstLetter = productName[0];
        if (!store.has(firstLetter))
            store.set(firstLetter, new Map())
        store.get(firstLetter).set(productName, price)
    }
    let sortedStore = Array.from(store.keys()).sort();
    for (let letter of sortedStore){
        console.log(letter);
        let sortedProductNames = Array.from(store.get(letter).keys()).sort();
        for (let prod of sortedProductNames){
            console.log(`  ${prod}: ${store.get(letter).get(prod)}`)
        }
    }
}

sortCatalogue(['Appricot : 20.4',
                'Fridge : 1500',
                'TV : 1499',
                'Deodorant : 10',
                'Boiler : 300',
                'Apple : 1.25',
                'Anti-Bug Spray : 15',
                'T-Shirt : 10']);
