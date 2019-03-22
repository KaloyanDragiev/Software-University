function draw([n]){
    [n] = [n].map(Number);
    let sequence = 'ATCGTTAGGG';
    let letterCounter = 0;
    console.log(`**${sequence[letterCounter++ % sequence.length]}${sequence[letterCounter++ % sequence.length]}**`)
    for (let row = 1; row < n; row++){
        if (row % 4 == 0)
            console.log(`**${sequence[letterCounter++ % sequence.length]}${sequence[letterCounter++ % sequence.length]}**`);
        else if (row % 2 == 0)
            console.log(`${sequence[letterCounter++ % sequence.length]}----${sequence[letterCounter++ % sequence.length]}`);
        else
            console.log(`*${sequence[letterCounter++ % sequence.length]}--${sequence[letterCounter++ % sequence.length]}*`);
    }
}

// draw([10]);