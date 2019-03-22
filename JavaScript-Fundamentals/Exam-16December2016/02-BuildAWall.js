function construct(wallHeights){
    wallHeights = wallHeights.map(Number);
    let concreteUsed = [];
    while (wallHeights.filter(w => w < 30).length > 0){
        let dailyConcrete = 0;
        for (let i = 0; i < wallHeights.length; i++) {
            if (wallHeights[i] < 30){
                dailyConcrete += 195;
                wallHeights[i]++;
            }
        }
        concreteUsed.push(dailyConcrete);
    }
    console.log(concreteUsed.join(', '));
    let totalPesos = concreteUsed.reduce((a, b) => a + b) * 1900
    console.log(`${totalPesos} pesos`)
}

construct([17]);