function validate([x1, y1, x2, y2]){
    [x1, y1, x2, y2] = [x1, y1, x2, y2].map(Number);
    console.log(isDistanceValid(x1, y1, 0, 0));
    console.log(isDistanceValid(x2, y2, 0, 0));
    console.log(isDistanceValid(x1, y1, x2, y2));

    function isDistanceValid(xOrig, yOrig, xComp, yComp){
        let distX = Math.abs(xOrig - xComp);
        let distY = Math.abs(yOrig - yComp);

        let distance = Math.sqrt(distX * distX + distY * distY);

        if (isDistanceInteger(distance))
            return `{${xOrig}, ${yOrig}} to {${xComp}, ${yComp}} is valid`;
        return `{${xOrig}, ${yOrig}} to {${xComp}, ${yComp}} is invalid`;

        function isDistanceInteger(dist){
            let distTest = dist * 10;
            if (distTest.toString().endsWith('0'))
                return true;
            return false;
        }
    }
}

// validate(['3','0','0','4']);
// validate(['2','1','1','1']);