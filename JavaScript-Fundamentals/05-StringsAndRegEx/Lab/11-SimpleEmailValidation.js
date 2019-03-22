function validateEmail([text]){
    let emailPattern = /^[A-Za-z0-9]+@[a-z]+\.[a-z]+$/g
    if (emailPattern.test(text))
        return 'Valid';
    else
        return 'Invalid';
}

console.log(validateEmail(['valid@email.bg']))