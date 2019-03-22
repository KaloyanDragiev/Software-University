function findOccurr([text, word]){
    let pattern = new RegExp('\\b' +word + '\\b', 'gi')
    let match;
    let counter = 0;
    while (match = pattern.exec(text)){
        counter++;
    }
    return counter;
}

console.log(findOccurr(['The waterfall was so high, that the child couldn’t see its peak.', 'the']));