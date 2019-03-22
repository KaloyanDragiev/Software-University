function stringifyNumbs(input){
    let upperBorder = Number(input)
    let result = ""
    for (let i = 1; i<= upperBorder; i++){
        result += i;
    }
    return result;
}
