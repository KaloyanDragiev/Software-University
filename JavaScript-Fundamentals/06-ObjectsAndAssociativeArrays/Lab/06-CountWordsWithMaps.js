function countWords([input]){
    let wordCount = new Map();
    let words = input.split(/\W+/g).filter(w => w != '').map(w => w.toLowerCase());
    for (let word of words){
        if (!wordCount.has(word))
            wordCount.set(word, 0);
        wordCount.set(word, wordCount.get(word) + 1)
    }
    let wordsArr = Array.from(wordCount.keys()).sort();
    for (let word of wordsArr){
        console.log(`'${word}' -> ${wordCount.get(word)} times`)
    }
}

console.log(countWords(['Far too slow, you\'re far too slow.']))