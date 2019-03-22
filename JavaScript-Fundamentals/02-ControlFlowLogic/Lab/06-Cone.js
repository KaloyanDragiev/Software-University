function coneVolumeArea ([radius, height]) {
    //let [r, h] = input.map(Number);
    let r = Number(radius);
    let h = Number(height);
    let slant = Math.sqrt(r * r + h * h)
    let volume = Math.PI * r * r * h / 3;
    let area = Math.PI * r * slant + Math.PI * r * r;
    console.log('volume = ' + Math.round(volume * 10000) / 10000);
    console.log('area = ' + Math.round(area * 10000) / 10000);
}
