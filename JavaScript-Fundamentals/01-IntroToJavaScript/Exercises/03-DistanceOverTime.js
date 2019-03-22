function calcDistance(input){
    let v1 = Number(input[0]);
    let v2 = Number(input[1]);
    let time = Number(input[2]);

    let timeInHours = time / 3600;
    let distanceBetween = (Math.abs(v1 - v2) * timeInHours) * 1000;

    return distanceBetween
}

// console.log(calcDistance([5, -5, 40]))