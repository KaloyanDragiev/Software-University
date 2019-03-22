function extractJSON(input){
    Object.values = function (obj) {
        let vals = [];
        for( let key in obj )
                vals.push(obj[key]);
        return vals;
    };

    let objArr = JSON.parse(input);
    let result = `<table>\n  <tr>`;
    result += `<th>${Object.keys(objArr[0]).join(`</th><th>`)}</th></tr>\n`;

    for (let obj of objArr){
        let values = Object.values(obj);
        result += `  <tr>`;
        for (let value of values){
            result += `<td>${htmlEscape(value)}</td>`
        }
        result += '</tr>\n';
    }
    result += '</table>';
    return result;

    function htmlEscape(text) {
        text = text.toString();
        let map = {'"': '&quot;', '&': '&amp;', "'": '&#39;', '<': '&lt;', '>': '&gt;'};
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}

// console.log(extractJSON('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]'))
