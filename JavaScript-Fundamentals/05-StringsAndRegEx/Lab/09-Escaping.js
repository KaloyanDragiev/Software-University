function htmlEscape(input) {
    let result = '<ul>\n';
    for (let code of input){
        let replacedText = code.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
        result += '  <li>' + replacedText + '</li>\n';
    }
    result += '</ul>';
    return result;
}

// console.log(htmlEscape(['<b>unescaped text</b>', 'normal text']));

// Version 2 : Author Solution
// function htmlList(items) {
//     return "<ul>\n" + items.map(htmlEscape).map(
//                                     item => ` <li>${item}</li>`).join("\n") + "</ul>\n";
//     function htmlEscape(text) {
//         let map = { '"': '&quot;', '&': '&amp;', "'": '&#39;', '<': '&lt;', '>': '&gt;' };
//         return text.replace(/[\"&'<>]/g, ch => map[ch]);
//     }
// }
