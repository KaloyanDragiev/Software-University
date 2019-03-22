function extractJSON(input){
    let objArr = JSON.parse(input);
    let result = `<table>\n  <tr>`;
    let keysArray = Object.keys(objArr[0])
    result += `<th>${keysArray.join(`</th><th>`)}</th></tr>\n`;

    for (let obj of objArr){
        result += `  <tr>`;
        for (let key of keysArray){
            result += `<td>${htmlEscape(obj[key])}</td>`
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