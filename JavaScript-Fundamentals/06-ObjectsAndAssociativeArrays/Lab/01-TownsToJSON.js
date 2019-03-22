function createJSON(input){
    jsonTowns = []
    for (let i = 1; i < input.length; i++){
        let townInfo = input[i].split('|');
        let townName = townInfo[1].trim();
        let latitude = Number(townInfo[2].trim());
        let longitude = Number(townInfo[3].trim());
        let town = { Town:townName, Latitude:latitude, Longitude:longitude }
        jsonTowns.push(town)
    }

    return JSON.stringify(jsonTowns);
}

// console.log(createJSON(['| Town | Latitude | Longitude |', '| Sofia | 42.696552 | 23.32601 |', '| Beijing | 39.913818 | 116.363625 |']))

// Version 2 : Author Solution
// function parseTownsToJSON(towns) {
//     let townsArr = [];
//     for (let town of towns.slice(1)) {
//         let [empty, townName, lat, lng] = town.split(/\s*\|\s*/);
//         let townObj = { Town: townName,
//                        Latitude: Number(lat),
//                        Longitude: Number(lng)
//                       };
//         townsArr.push(townObj);
//         }
//     return JSON.stringify(townsArr);
// }