function capitalize([input]){
    input = input.toLowerCase();
    let seperateWords = input.split(' ');
    let capitalizedWords = [];
    for (let word of seperateWords){
        capitalizedWords.push(word[0].toUpperCase() + word.substring(1));
    }
    return capitalizedWords.join(' ');
}

// console.log(capitalize(['Capitalize these words']))