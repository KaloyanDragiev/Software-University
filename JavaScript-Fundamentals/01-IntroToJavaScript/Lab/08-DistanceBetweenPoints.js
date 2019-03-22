function getDistance ([x1, y1, x2, y2]){
    let pointA = { x : Number.parseFloat(x1), y : Number.parseFloat(y1)};
    let pointB = { x : Number.parseFloat(x2), y : Number.parseFloat(y2)};

    let xDistance = Math.abs(pointA.x - pointB.x);
    let yDistance = Math.abs(pointA.y - pointB.y);

    let totalDistance = Math.sqrt(Math.pow(xDistance, 2) + Math.pow(yDistance, 2));
    return totalDistance;
}