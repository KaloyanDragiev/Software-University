function drawBoard (n){
    let color = 'black';
    let counter = 1;
    let result = '<div class="chessboard">\n';
    for (let i = 0; i < n; i++) {
        result += '\t<div>\n';
        for (let j = 0; j < n; j++) {
            if (counter % 2 == 0)
                color = 'white';
            else
                color = 'black';
            if (n % 2 == 0 && i % 2!= 0){
                if (color == 'black')
                    color = 'white';
                else if (color == 'white')
                    color = 'black';
            }
            result += `\t<span class="${color}"></span>\n`;
            counter++;
        }
        result += '\t</div>\n';
    }
    result +='</div>';
    return result
}

// console.log(drawBoard(4));
// let css = document.createElement("style");
// css.innerHTML = `
//   body { background: #CCC; }
//   .chessboard { display: inline-block; }
//   .black, .white {
//      width:50px; height:50px;
//      display: inline-block; }
//   .black { background: black; }
//   .white { background: white; }
// `;
// document.getElementsByTagName("head")[0].appendChild(css);
// document.body.innerHTML = chessboard(["5"]);
