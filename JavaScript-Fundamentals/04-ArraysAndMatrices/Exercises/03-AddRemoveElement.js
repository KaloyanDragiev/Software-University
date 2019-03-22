function addRemove(input){
    let counter = 1;
    let result = [];
    for (let i = 0; i < input.length; i++){
        if (input[i] == 'add')
            result.push(counter);
        else if(input[i] == 'remove')
            result.pop();

        counter++;
    }
    if (result.length == 0)
        console.log('Empty')
    else
        console.log(result.join('\n'))
}

addRemove(['add', 'add', 'add', 'add']);