function checkEnd([main, subs]){
    return main.endsWith(subs);
}

console.log(checkEnd(['This sentence ends with fun?', 'fun?']));