function calcTicketPrice(input){
    let movieTitle = input[0].toLowerCase();
    let dayOfWeek = input[1].toLowerCase();

    if (movieTitle == 'the godfather'){
        switch (dayOfWeek){
            case 'monday': return 12; break;
            case 'tuesday': return 10; break;
            case 'wednesday':
            case 'friday': return 15; break;
            case 'thursday': return 12.50; break;
            case 'saturday': return 25; break;
            case 'sunday': return 30; break;
            default: return 'error';
        }
    }
    else if (movieTitle == 'schindler\'s list'){
        switch (dayOfWeek){
            case 'monday':
            case 'tuesday':
            case 'wednesday':
            case 'thursday':
            case 'friday': return 8.50; break;
            case 'saturday':
            case 'sunday': return 15; break;
            default: return 'error';
        }
    }
    else if (movieTitle == 'casablanca'){
        switch (dayOfWeek){
            case 'monday':
            case 'tuesday':
            case 'wednesday':
            case 'thursday':
            case 'friday': return 8; break;
            case 'saturday':
            case 'sunday': return 10; break;
            default: return 'error';
        }
    }
    else if (movieTitle == 'the wizard of oz'){
        switch (dayOfWeek){
            case 'monday':
            case 'tuesday':
            case 'wednesday':
            case 'thursday':
            case 'friday': return 10; break;
            case 'saturday':
            case 'sunday': return 15; break;
            default: return 'error';
        }
    }
    else
        return 'error';
}

console.log(calcTicketPrice(['The Godfather', 'Friday']));