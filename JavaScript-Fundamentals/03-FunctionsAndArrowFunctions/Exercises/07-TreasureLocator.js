function locateTreasure(input){
    let tonga = (x, y) => x >= 0 && x <= 2 && y >= 6 && y <= 8;
    let tuvalu = (x, y) => x >= 1 && x <= 3 && y >= 1 && y <= 3;
    let samoa = (x, y) => x >= 5 && x <= 7 && y >= 3 && y <= 6;
    let cook = (x, y) => x >= 4 && x <= 9 && y >= 7 && y <= 8;
    let tokelau = (x, y) => x >= 8 && x <= 9 && y >= 0 && y <= 1;

    for (let i = 0; i < input.length; i+= 2){
        let [x, y] = [input[i], input[i+1]];
        let result = '';
        if (tonga(x, y)) result = 'Tonga';
        else if (tuvalu(x, y)) result = 'Tuvalu';
        else if (samoa(x, y)) result = 'Samoa';
        else if (cook(x, y)) result = 'Cook';
        else if (tokelau(x, y)) result = 'Tokelau';
        else result = 'On the bottom of the ocean';

        console.log(result);
    }
}

locateTreasure([4, 2, 1.5, 6.5, 1, 3]);