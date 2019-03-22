function calcDegrees(grads){
    let degrees = grads * 0.9;
    if (Number(grads) < 0)
        degrees = 360 - Math.abs(degrees % 360); // degrees += 360;
    return degrees % 360;
}

// console.log(calcDegrees([400]))

// Version 2:
// degrees = degrees % 360;
// degrees += 360;
// degrees = degrees % 360;
