function convert([inches]) {
    let totalInches = Number(inches);
    let feet = Math.floor(totalInches / 12);
    let inchesLeft = totalInches % 12;
    return `${feet}'-${inchesLeft}"`;
}

console.log(convert([55]))