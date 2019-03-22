function solve(dataRows){
    let notebook = new Map();

    for (let line of dataRows){
        let playerInfo = line.split('|');
        let color = playerInfo[0];
        let secondArg = playerInfo[1];
        let thirdArg = playerInfo[2];

        if (!notebook.has(color))
            notebook.set(color, { age: undefined, name: undefined, losses: 1, wins: 1, opponents: []});
        switch (secondArg){
            case 'age':
                notebook.get(color).age = thirdArg;
                break;
            case 'name':
                notebook.get(color).name = thirdArg;
                break;
            case 'win':
                notebook.get(color).wins++;
                notebook.get(color).opponents.push(thirdArg);
                break;
            case 'loss':
                notebook.get(color).losses++;
                notebook.get(color).opponents.push(thirdArg);
                break;
        }
    }

    let finalNotebook = {};

    let sortedNotebook = Array.from(notebook).sort((a, b) => a[0].localeCompare(b[0]));

    for (let [color, info] of sortedNotebook){
        if (info.age != undefined && info.name != undefined){
            let rank = (info.wins) / (info.losses);
            let result = { age: info.age, name: info.name, opponents: info.opponents.sort(), rank: rank.toFixed(2)};
            finalNotebook[color] = result;
        }
    }

    console.log(JSON.stringify(finalNotebook))
}

solve([
    'purple|age|99',
    'red|age|44',
    'blue|win|pesho',
    'blue|win|mariya',
    'purple|loss|Kiko',
    'purple|loss|Kiko',
    'purple|loss|Kiko',
    'purple|loss|Yana',
    'purple|loss|Yana',
    'purple|loss|Manov',
    'purple|loss|Manov',
    'red|name|gosho',
    'blue|win|Vladko',
    'purple|loss|Yana',
    'purple|name|VladoKaramfilov',
    'blue|age|21',
    'blue|loss|Pesho'
]);