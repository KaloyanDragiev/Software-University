function calcAreaPerim(input){
    let width = Number(input[0]);
    let height = Number(input[1]);

    let area = width * height;
    let perimeter = 2 * (width + height);

    console.log(area);
    console.log(perimeter);
}

// calcAreaPerim([2, 2])