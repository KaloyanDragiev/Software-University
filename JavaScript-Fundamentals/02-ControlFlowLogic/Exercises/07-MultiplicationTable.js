function createTable([size]){
    let result = '<table border="1">\n';
    result += '  <tr><th>x</th>';
    for (let i = 1; i <= size; i++) {
        result +=`<th>${i}</th>`;
        }
    result += '</tr>\n';

    for (let row = 1; row <= size; row++) {
        result += `  <tr><th>${row}</th>`;
        for (let col = 1; col <= size; col++) {
            result +=`<td>${row*col}</td>`
        }
        result += '</tr>\n';
    }
    result += '</table>';
    return result;
}

// console.log(createTable([4]));
// document.body.innerHTML = createTable(['5']);
