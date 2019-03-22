function drawDollars(input){
    let bound = Number(input[0]);
    for (let i = 0; i < bound; i++) {
        let draw = '$'
        for (let j = 0; j < i; j++) {
            draw += '$'
        }
        console.log(draw);
    }
}

function drawVersionTwo(input){
    let bound = Number(input[0]);
    for (let i = 1; i <= bound; i++) {
        console.log(new Array(i + 1).join('$'))
    }
}

function drawVersionThree(input){
    let bound = Number(input[0]);
    for (let i = 1; i <= bound; i++) {
        console.log('$'.repeat(i));
    }
}

// drawDollars([5]);
// drawVersionTwo([5]);
// drawVersionThree([5]);