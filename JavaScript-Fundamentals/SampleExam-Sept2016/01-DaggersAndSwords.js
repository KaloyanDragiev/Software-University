function solve(dataRows){
    dataRows = dataRows.map(Number);
    let html = `<table border="1">\n<thead>\n<tr><th colspan="3">Blades</th></tr>\n<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>\n</thead>\n<tbody>\n`;

    for (let line of dataRows){
        if (line <= 10)
            continue;
        let length = Math.floor(line);
        let type = 'dagger';
        if (length > 40)
            type = 'sword';
        let bladeApplication = '';
        let lengthRemainder = length % 5;
        switch (lengthRemainder){
            case 1 : bladeApplication = 'blade'; break;
            case 2 : bladeApplication = 'quite a blade'; break;
            case 3: bladeApplication = 'pants-scraper'; break;
            case 4 : bladeApplication = 'frog-butcher'; break;
            case 0 : bladeApplication = '*rap-poker'; break;
        }
        html+= `<tr><td>${length}</td><td>${type}</td><td>${bladeApplication}</td></tr>\n`;
    }

    html += `</tbody>\n</table>`;
    console.log(html);
}

solve([
    '17.8',
    '19.4',
    '13',
    '55.8',
    '126.96541651',
    '3'
]);