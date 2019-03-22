function countLetter(str, letter){
    let count = 0;
    for (let strLet of str){
        if (strLet == letter)
            count++;
    }
    console.log(count);
}

// countLetter('hello', 'l')
