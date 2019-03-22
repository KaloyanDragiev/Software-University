function solve(base, increment){
    let totalStone = 0;
    let totalMarble = 0;
    let totalLapis = 0;
    let totalGold = 0;

    let counter = 1;

    let upperBound =  Math.ceil(base / 2);
    for (let i = base; i > 0; i-= 2){
        if (counter == upperBound){
            totalGold = i * i * increment;
            break;
        }
        let stone = (i - 2) * (i - 2) * increment;
        totalStone += stone;

        if (counter % 5 == 0){
            totalLapis += i * i * increment - stone;
        }
        else {
            totalMarble += i * i * increment - stone;
        }
        counter++;
    }
    console.log(`Stone required: ${Math.ceil(totalStone)}`);
    console.log(`Marble required: ${Math.ceil(totalMarble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(totalLapis)}`);
    console.log(`Gold required: ${Math.ceil(totalGold)}`);
    console.log(`Final pyramid height: ${Math.floor(counter * increment)}`)
}