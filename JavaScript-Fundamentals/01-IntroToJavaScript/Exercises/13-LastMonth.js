function printLastDay(input){
    let month = input[1];
    let year = input[2];
    let result = 31;
    switch (month - 1){
        case 2: year % 4 == 0 ? result = 29 : result = 28; break;
        case 4:
        case 6:
        case 9:
        case 11: result = 30; break;
    }
    return result;
}

// printLastDay(['17','3','2002']);