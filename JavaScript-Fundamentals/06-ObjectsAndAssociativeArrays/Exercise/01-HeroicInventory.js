function registerHeroes(dataRows){
    let heroArr = [];
    for (let dataRow of dataRows){
        let heroInfo = dataRow.split(' / ');
        let heroName = heroInfo[0];
        let heroLevel = Number(heroInfo[1]);
        let heroItems = []
        if (heroInfo.length > 2)
            heroItems = heroInfo[2].split(', ');

        let hero = {name:heroName, level: heroLevel, items:heroItems}
        heroArr.push(hero);
    }
    return JSON.stringify(heroArr)
}

console.log(registerHeroes(['Isacc / 25 / Apple, GravityGun',
                            'Derek / 12 / BarrelVest, DestructionSword',
                            'Hes / 1 / Desolator']));