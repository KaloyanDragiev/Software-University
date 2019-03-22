function extractWords([input]){
    let myRe = new RegExp("[a-zA-Z0-9]+", "g");
    let myArray = input.match(myRe);
    var result = myArray.join(', ').toUpperCase();
    console.log(result)
}

// Author Solution:
//function wordsUppercase([str]) {
//  let strUpper = str.toUpperCase();
//  let words = extractWords();
//  words = words.filter(w => w != '');
//  return words.join(', ');
//  function extractWords() { return strUpper.split(/\W+/); }
//}

// extractWords(['          hel        lo     ASDSADASDA   ASDASD']);
