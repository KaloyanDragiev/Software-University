function countBottles(dataRows){
    let flavorsObj = {};
    let bottles = {};
    for (let dataRow of dataRows){
        let juiceInfo = dataRow.split(' => ');
        let fruit = juiceInfo[0];
        let quantity = Number(juiceInfo[1]);
        if (flavorsObj[fruit] == undefined)
            flavorsObj[fruit] = 0;
        flavorsObj[fruit] += quantity;
        if (flavorsObj[fruit] >= 1000){
            if (bottles[fruit] == undefined)
                bottles[fruit] = 0;
            bottles[fruit] += Math.floor(flavorsObj[fruit] / 1000);
            flavorsObj[fruit] %= 1000;
        }
    }
    for (let bottle in bottles)
        console.log(`${bottle} => ${bottles[bottle]}`)
}

countBottles(['Orange => 11100',
                          'Peach => 32',
                          'Banana => 4150',
                          'Peach => 600',
                          'Strawberry => 19']);