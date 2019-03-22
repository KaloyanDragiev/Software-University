function createTable(input){
    let result = '<table>\n  <tr><th>name</th><th>score</th></tr>\n'
    let statObjArr = JSON.parse(input);
    for (let stat of statObjArr)
        result += `  <tr><td>${htmlEscape(stat.name)}</td><td>${htmlEscape(stat.score.toString())}</td></tr>\n`
    result += '</table>'
    return result;

    function htmlEscape(text) {
        let map = {'"': '&quot;', '&': '&amp;', "'": '&#39;', '<': '&lt;', '>': '&gt;'};
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}

console.log(createTable('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]'));