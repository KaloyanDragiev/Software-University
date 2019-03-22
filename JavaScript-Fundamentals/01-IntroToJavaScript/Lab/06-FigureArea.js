function calcArea (w, h, W, H){
    let [bigFigureArea, smallFigureArea] = [W * H, w * h];
    let commonArea = Math.min(w, W) * Math.min(H,h);
    return bigFigureArea + smallFigureArea - commonArea;
}
