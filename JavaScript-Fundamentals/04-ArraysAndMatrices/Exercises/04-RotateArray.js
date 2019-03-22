function rotate(input){
    let rotationCount = Number(input.pop()) % input.length;

    for (let i = 0; i < rotationCount; i++){
        let lastEl = input.pop();
        input.unshift(lastEl);
    }
    return input.join(' ');
}

console.log(rotate([1, 2, 3, 4, 2]));