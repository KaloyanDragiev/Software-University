function drawCalendar([day, month, year]){
    let result = '<table>\n  <tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>\n';
    let previousMonth = new Date(year, month - 1, 0);
    let lastMonthLastDate = previousMonth.getDate();
    let firstDateCurrentMonth = new Date(previousMonth.getTime() + 24 * 60 * 60 * 1000);
    let lastDayLastMonth = previousMonth.getDay();
    result += '  <tr>';
    if (lastDayLastMonth != 6){
        for (let i = 0; i <= lastDayLastMonth; i++)
            result += `<td class="prev-month">${lastMonthLastDate - lastDayLastMonth + i}</td>`
    }
    let counter = 1;
    for (let i = lastDayLastMonth % 6; i < 6; i++) {
        if (counter == day){
            result += `<td class="today">${counter++}</td>`;
            continue;
        }
        result += `<td>${counter++}</td>`;
    }
    if (firstDateCurrentMonth.getDay() == 0)
        result += `<td>${counter++}</td>`;
    result += '</tr>\n  <tr>';
    let currentMonthLastDate = new Date(year, month, 0).getDate();
    for (let i = counter; i <= currentMonthLastDate; i++) {
        if (i == day)
            result += `<td class="today">${day}</td>`;
        else
            result += `<td>${i}</td>`;
        counter++;
        if ((i + firstDateCurrentMonth.getDay()) % 7 == 0)
            result += '</tr>\n  <tr>'
    }
    let daysFromNextMonth = (7 * 6 - counter - lastDayLastMonth) % 7;
    for (let i = 1; i <= daysFromNextMonth; i++) {
        result += `<td class="next-month">${i}</td>`
    }

    result += '</tr>\n</table>\n';
    return result.replace('<tr></tr>\n', '');
}

console.log(drawCalendar([1, 5, 2016]))