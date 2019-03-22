function extraLink(input){
    let pattern = /www\.[0-9A-Za-z-]+\.[a-z]*(\.[a-z]*)*[a-z]+/g
    let match;
    for (let line of input){
        while (match = pattern.exec(line)){
            console.log(match[0])
        }
    }
}

extraLink(['Join WebStars now for free, at www.web-stars.com', 'You can also support our partners:', 'Internet - www.internet.com', 'WebSpiders - www.webspiders101.com','Sentinel - www.sentinel.-ko',]);