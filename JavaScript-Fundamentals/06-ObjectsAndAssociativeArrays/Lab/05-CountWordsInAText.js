function countWords([data]){
    let words = {};
    let dataArr = data.split(/\W+/).filter(w => w != '');
                //data.split(/[^A-Za-z0-9_]+/).filter(w => w != '');
    for (let word of dataArr){
        if (words[word] == undefined)
            words[word] = 0;
        words[word]++;
    }
    return JSON.stringify(words);
}

console.log(countWords(['Far too slow, you\'re far too slow.']))
