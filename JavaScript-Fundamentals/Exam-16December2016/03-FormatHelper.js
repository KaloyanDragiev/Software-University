function detect([input]){
    let singleSpacePattern = /([.,!?;:])\s*/g;
    let noSpacePattern = /\s+([.,!?;:])/g;
    let threeDotsPattern = /\.\s*\.\s*([.,!?;:])*/g;
    let numberAfterDotsPatter = /\.\s*(\d+)/g;
    let textInQuotesPattern = /"(\s*[^"]+\s*)(?=")/g;

    let output = input.replace(singleSpacePattern, repSymbolsWithSpace);
    output = output.replace(noSpacePattern, repSymbolsWithoutSpace);
    output = output.replace(threeDotsPattern, repThreeDots);
    output = output.replace(numberAfterDotsPatter, replaceNumbersWithDots);
    output = output.replace(textInQuotesPattern, trimQuoteSpaces);
    console.log(output);

    function repSymbolsWithSpace(match){
        return match[0] + ' ';
    }
    function repSymbolsWithoutSpace(match){
        return match.trim();
    }
    function repThreeDots(match){
        return match;
    }
    function trimQuoteSpaces(match){
        return '"' + match.slice(1).trim();
    }
    function replaceNumbersWithDots(match){
        return '.' + match.slice(2);
    }
}

detect(['Terribly formatted text      .      With chaotic spacings."      Terrible .   .   .  !  quoting      "!       Also this date is pretty confusing : 20 .    12.    16 .']);


// Author Solution:
//function solve([text]) {
//    console.log(text
//        .replace(/[ ]*([.,!?:;])[ ]*/g, (match, g1) => `${g1} `)
//        .replace(/\. (?=[0-9])/g, (match) => `.`)
//        .replace(/" *(.+?) *"/g, (match, g1) => `"${g1}"`)
//        .replace(/([.,!?:;]) (?=[.,!?:;])/g, (match, g1) => g1));
//}
