function createObject(input){
    let object = { [input[0]] : input[1], [input[2]] : input[3], [input[4]] : input[5] };
    return object;
}

console.log(createObject(['name', 'Pesho', 'age', '23', 'gender', 'male']))
// ['name', 'Pesho', 'age', '23', 'gender', 'male']