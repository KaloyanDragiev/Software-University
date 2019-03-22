function position(input){
    let x1 = 10, x2 = 50;
    let y1 = 20, y2 = 80;
    let z1 = 15, z2 = 50;
    let elements = input.map(Number)
    for (let i = 0; i < elements.length; i+= 3){
        let [x, y, z] = [elements[i], elements[i+1], elements[i+2]];
        if (isPointIn(x, y, z))
            console.log('inside');
        else
            console.log('outside');
    }

    function isPointIn(x, y, z){
        if (x >= x1 && x <= x2 && y >= y1 && y <= y2 && z >= z1 && z <= z2){
            return true;
        }
        return false;
    }
}

// position([13.1, 50, 31.5, 50, 80, 50, -5, 18, 43]);