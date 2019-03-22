function displayInfo(input){
    let songName = input[0];
    let artist = input[1];
    let duration = input[2];

    return `Now Playing: ${artist} - ${songName} [${duration}]`;
}

console.log(displayInfo(['Number One', 'Nelly', '4:09']))