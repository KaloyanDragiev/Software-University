function calc3ddistance(input){
    let pointA = { x: Number(input[0]), y : Number(input[1]), z : Number(input[2]) };
    let pointB = { x: Number(input[3]), y : Number(input[4]), z : Number(input[5]) };

    let distX = Math.abs(pointA.x - pointB.x);
    let distY = Math.abs(pointA.y - pointB.y);
    let distZ = Math.abs(pointA.z - pointB.z);

    let xyDistance = Math.sqrt(distX * distX + distY * distY);
    let totalDistance = Math.sqrt(distZ * distZ + xyDistance * xyDistance)
    return totalDistance;
}

// console.log(calc3ddistance([3.5, 0, 1, 0, 2, -1]));