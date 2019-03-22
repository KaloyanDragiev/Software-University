function printArray(input){
    let delimiter = input[input.length - 1];
    return input.slice(0, input.length - 1).join(delimiter);
}

// console.log(printArray(['One', 'Two', 'Three', 'Four', 'Five', '-']));

// Verison 2 : Using pop
// let delimiter = input.pop();
// return input.slice(0, input.length).join(delimiter);
