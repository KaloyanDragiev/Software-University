function registerTowns(data){
    let townsCount = new Map()
    for (let entry of data){
        let cityInfo = entry.split('<->');
        let city = cityInfo[0].trim();
        let population = Number(cityInfo[1].trim());

        if (!townsCount.has(city))
            townsCount.set(city, 0);

        townsCount.set(city, townsCount.get(city) + population);
    }

    for (let [key, value] of townsCount)
        console.log(`${key} : ${value}`)
}

registerTowns(['Sofia <-> 1200000',
               'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'])