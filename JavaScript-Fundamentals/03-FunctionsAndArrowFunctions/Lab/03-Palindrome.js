function palindromeCheck([input]){
    let length = input.length;
    for (let i = 0; i < length / 2; i++) {
        if (input[i] !=  input[length - 1 - i])
            return false;
    }
    return true;
}

// console.log(palindromeCheck('haha'));
// console.log(palindromeCheck('racecar'));