function hideInfo(input){
    let pattern = /\*[A-Z][A-Za-z]*(?:\s|$)|\+[0-9-]{10}(?:\s|$)|![A-Za-z0-9]+(?:\s|$)|_[A-Za-z0-9]+(?:\s|$)/g;
    let finalText = input.join('\n');
    let match;
    while (match = pattern.exec(finalText)){
        let trimmedMatch = match[0].trim();
        finalText = finalText.replace(trimmedMatch, '|'.repeat(trimmedMatch.length));
    }
    return finalText
}

console.log(hideInfo(['Agent *Ivankov was in the room when it all happened.',
    'The person in the room was heavily armed.',
    'Agent *Ivankov had to act quick in order.*Ivankov',
    'He picked up his phone and called some unknown number.',
    'I think +555-49-790 it was +555-49-796',
    'I can\'t really remember...',
    'He said something about "finishing work" with subject !2491a23BVB34Q and returning to Base _Aurora21',
    'Then after that he disappeared from my sight.',
    'As if he vanished in the shadows.',
    'A moment, shorter than a second, later, I saw the person flying off the top floor',
    'I really don\'t know what happened there.',
    'This is all I saw, that night.',
    'I cannot explain it myself...']));