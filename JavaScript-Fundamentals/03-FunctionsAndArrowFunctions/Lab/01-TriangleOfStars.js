function drawStars(count){
    for (let i = 1; i <= count; i++) {
        console.log('*'.repeat(i));
    }
    for (let i = count - 1; i >= 0; i--) {
        console.log('*'.repeat(i));
    }
}

drawStars(5)