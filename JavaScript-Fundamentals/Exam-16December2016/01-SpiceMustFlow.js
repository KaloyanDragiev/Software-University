function calculateTotalAmount(startingYield){
    let startYield = Number(startingYield);
    let extractedSpice = 0;
    let totalDays = 0;
    while (startYield >= 100) {
        extractedSpice += startYield;
        totalDays++;
        extractedSpice -= 26;
        startYield -= 10;
    }
    if (totalDays != 0 && extractedSpice != 0)
        extractedSpice -= 26;
    console.log(totalDays);
    console.log(extractedSpice);
}

calculateTotalAmount(200);