function pointLocation(input){
    let [x, y, xMin, xMax, yMin, yMax] = input.map(Number);
    if (x >= xMin && x <= xMax && y >= yMin && y <= yMax)
        return 'inside';
    else
        return 'outside';
}

// console.log(pointLocation([8, -1, 2, 12, -3, 3]))