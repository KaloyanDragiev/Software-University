function censor(text, words){
    for (let i = 0; i < words.length; i++){
        let badWord = words[i];
        while (text.includes(badWord)){
            text = text.replace(badWord, '-'.repeat(badWord.length))
        }
    }
    return text;
}

// Shorter version 2 using new RegExp()
// function censor(input){
//     let text = input[0];
//     for (let i = 1; i < input.length; i++){
//         let badWord = input[i];
//         text = text.replace(new RegExp(badWord, 'g'), '-'.repeat(badWord.length))
//     }
//     return text;
// }

// console.log(censor(['roses are red, violets are blue', ', violets are', 'red']));
