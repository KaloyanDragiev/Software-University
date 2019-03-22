function solve(dataRows){
    dataRows = dataRows.replace(/\n/g, 'NEWLINEHERE')
    let html = '<article>\n';

    let toIndex = dataRows.indexOf(' to="');
    let fromIndex = dataRows.indexOf(' from="');
    if (toIndex == -1 || fromIndex == -1){
        console.log('Missing attributes');
        return;
    }

    let testPattern = /^<message(?:\s+[a-z]+="[A-Za-z0-9\s.]+")*\s+(to|from)="([A-Za-z0-9\s.]+)"(?:\s+[a-z]+="[A-Za-z0-9\s.]+")*\s+(to|from)="([A-Za-z0-9\s.]+)"(?:\s+[a-z]+="[A-Za-z0-9\s.]+")*>(.+)(?:<\/message>)$/g;
    if (!testPattern.test(dataRows)){
        console.log('Invalid message format');
        return;
    }

    let pattern = /^<message(?:\s+[a-z]+="[A-Za-z0-9\s.]+")*\s+(to|from)="([A-Za-z0-9\s.]+)"(?:\s+[a-z]+="[A-Za-z0-9\s.]+")*\s+(to|from)="([A-Za-z0-9\s.]+)"(?:\s+[a-z]+="[A-Za-z0-9\s.]+")*>(.+)(?:<\/message>)$/gi
    let match = pattern.exec(dataRows);

    let to = match[2];
    let from = match[4];

    if (toIndex > fromIndex){
        to = match[4];
        from = match[2];
    }

    let message = match[5].split('NEWLINEHERE');

    html += `  <div>From: <span class="sender">${from}</span></div>\n`;
    html += `  <div>To: <span class="recipient">${to}</span></div>\n`;
    html += '  <div>\n';

    for (let line of message)
        html += `    <p>${line}</p>\n`

    html += '  </div>\n</article>';
    console.log(html);
}