function calcInterest(input){
    let principalSum = Number(input[0]);
    let interestRatePercent = Number(input[1]) / 100;
    let compoundingPeriodMonths = Number(input[2]);
    let years = Number(input[3]);

    let compoundingFrequency = 12 / compoundingPeriodMonths;
    let interestOverFrequency = interestRatePercent / compoundingFrequency
    let power = years * compoundingFrequency;

    let totalAmount = principalSum * Math.pow((1 + interestOverFrequency), power);

    return totalAmount.toFixed(2);
}

// console.log(calcInterest([1500, 4.3, 3, 6]))