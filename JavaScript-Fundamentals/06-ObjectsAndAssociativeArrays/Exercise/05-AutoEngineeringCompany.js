function registerCars(dataRows){
    let carStore = new Map();
    for (let dataRow of dataRows){
        let carInfo = dataRow.split(' | ');
        let manufacturer = carInfo[0];
        let model = carInfo[1];
        let quantity = Number(carInfo[2]);

        if (!carStore.has(manufacturer))
            carStore.set(manufacturer, new Map());
        if (!carStore.get(manufacturer).has(model))
            carStore.get(manufacturer).set(model, 0);
        carStore.get(manufacturer).set(model, carStore.get(manufacturer).get(model) + quantity)
        }

    for (let [key, value] of carStore){
        console.log(key);
        for (let [model, quantity] of value)
            console.log(`###${model} -> ${quantity}`)
    }
}

registerCars(  ['Audi | Q7 | 1000',
                'Audi | Q6 | 100',
                'BMW | X5 | 1000',
                'BMW | X6 | 100',
                'Citroen | C4 | 123',
                'Volga | GAZ-24 | 1000000',
                'Lada | Niva | 1000000',
                'Lada | Jigula | 1000000',
                'Citroen | C4 | 22',
                'Citroen | C5 | 10']);