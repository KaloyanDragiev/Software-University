function findDates(lines){
    let pattern = /\b([\d]{1,2})-([A-Z][a-z]{2})-([\d]{4})\b/g;
    for (let line of lines){
        if (pattern.test(line)){
            let matches = line.match(pattern);
            //var groups = pattern.exec(line);
            for (let match of matches){
                let dateInfo = match.split('-');
                console.log(`${match} (Day: ${dateInfo[0]}, Month: ${dateInfo[1]}, Year: ${dateInfo[2]})`)
            }
        }
    }
}

findDates(['I am born on 30-Dec-1994. Who loves 20-Dec-1994.', 'This is not date: 512-Jan-1996.', 'My father is born on the 29-Jul-1955.']);

// Version two using EXEC. Author Solution:
// function extractDates(inputSentences) {
//     let pattern =/\b([0-9]{1,2})-([A-Z][a-z]{2})-([0-9]{4})\b/g;
//     let dates = [], match;
//     for (let sentence of inputSentences)
//         while (match = pattern.exec(sentence))
//             dates.push(`${match[0]} (Day: ${match[1]}, Month: ${match[2]}, Year: ${match[3]})`);
//     console.log(dates.join("\n"));
// }
