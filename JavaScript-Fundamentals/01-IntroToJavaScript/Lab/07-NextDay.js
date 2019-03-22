 function nextDay(year, month, date){
    let someDate = new Date(year, month - 1, date);
    let nextDay = new Date(someDate.getTime() + 24 * 60 * 60 * 1000)
     return nextDay.getFullYear() + '-' + (nextDay.getMonth() + 1) + '-' + nextDay.getDate()
  }

// nextDay(['2016', '9', '30'])
