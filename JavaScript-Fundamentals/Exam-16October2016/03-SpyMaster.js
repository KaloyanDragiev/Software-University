function solve(dataRows){
    let specialKey = dataRows.shift();
    let specialKeyInsensitive = specialKey.split('').map(c => '['+c.toLowerCase()+c.toUpperCase()+']').join('');
    let pattern = new RegExp(`((?:\\s|^)${specialKeyInsensitive}\\s+)([A-Z!#$%]{8,})( |\\.|,|$)`, 'g');

    for (let line of dataRows){
        console.log(line.replace(pattern, replacer))
    }

    function replacer(match, g1, g2, g3){
        g2 = g2
            .replace(/!/g, '1')
            .replace(/%/g, '2')
            .replace(/#/g, '3')
            .replace(/\$/g, '4')
            .replace(/[A-Z]/g, a => a.toLowerCase());
        return g1 + g2 + g3;
    }
}

solve([
    'specialKey',
    'In this text the specialKey HELLOWORLD! is correct, but',
    'the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while',
    'SpeCIaLkeY   SOM%%ETH$IN and SPECIALKEY ##$$##$$ are!'
]);