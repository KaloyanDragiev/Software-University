function findPath([x1, y1, x2, y2, x3, y3]){
    [x1, y1, x2, y2, x3, y3] = [x1, y1, x2, y2, x3, y3].map(Number);
    let A = { x : x1, y : y1}, B = { x : x2, y : y2}, C = { x : x3, y : y3};

    let counter = 1;
    let dist1 = calcDistance(A.x, A.y, B.x, B.y);
    let dist2 = calcDistance(B.x, B.y, C.x, C.y);
    let dist3 = calcDistance(C.x, C.y, A.x, A.y);

    let distArray = [dist1, dist2, dist3];
    distArray.sort((a, b) => b[0] - a[0]);
    return `${distArray[0][1]}->${distArray[1][1]}->${distArray[2][1]}: ${distArray[0][0] + distArray[1][0]}`;

    function calcDistance (xOrig, yOrig, xTarget, yTarget){
        let distX = Math.abs(xOrig - xTarget);
        let distY = Math.abs(yOrig - yTarget);
        return [Math.sqrt(distX * distX + distY * distY), counter++];
    }
}
// console.log(findPath([0, 0, 2, 0, 4, 0]));