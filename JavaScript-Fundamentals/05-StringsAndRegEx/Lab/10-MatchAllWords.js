function matchWords([text]){
    return text.match(/\w+/g).join('|');
}

console.log(matchWords(['_(Underscores) are also word characters']))