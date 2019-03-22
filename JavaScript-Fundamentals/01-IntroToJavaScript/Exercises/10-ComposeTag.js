function compose(input){
    let location = input[0];
    let alternateText = input[1];

    return '<img src="' + location + '" alt="' + alternateText + '">';
}

// console.log(compose(['smiley.gif', 'Smiley Face']))