function attachEvents(){
    let baseUrl = `https://judgetests.firebaseio.com/locations.json`;
    let weatherSymbols = {
        'Sunny': '&#x2600;',
        'Partly sunny': '&#x26C5;',
        'Overcast': '&#x2601;',
        'Rain': '&#x2614;'
    };
    $('#submit').click(getWeatherReport);

    function getWeatherReport(){
        $.get(baseUrl)
            .then(getWeatherDetails);

        function getWeatherDetails(data){
            let searchedName = $('#location').val();
            let code;
            for (let town of data){
                if (town.name === searchedName)
                    code = town.code;
            }
            let currentConditionsRequest = $.get(`https://judgetests.firebaseio.com/forecast/today/${code}.json`);
            let threeDayForecastRequest = $.get(`https://judgetests.firebaseio.com/forecast/upcoming/${code}.json `);

            Promise.all([currentConditionsRequest, threeDayForecastRequest])
                .then(displayWeatherInfo)
                .catch(displayError);

            function displayWeatherInfo([currentConditions, threeDayForecast]) {
                $('#forecast').toggle();
                if (code == null || code == undefined)
                    throw Error;

                $('#current').empty().append($('<div>').addClass('label').text('Current conditions'));
                $('#upcoming').empty().append($('<div>').addClass('label').text('Three-day forecast'));

                $('#current')
                    .append($('<span>')
                        .addClass('condition symbol')
                        .html(weatherSymbols[currentConditions.forecast.condition]))
                    .append($('<span>').addClass('condition')
                        .append($('<span>').addClass('forecast-data').text(currentConditions.name))
                        .append($('<span>').addClass('forecast-data')
                            .html(`${currentConditions.forecast.low}&#176;/${currentConditions.forecast.high}&#176;`))
                        .append($('<span>').addClass('forecast-data').text(currentConditions.forecast.condition)));

                for (let day of threeDayForecast.forecast){
                    $('#upcoming')
                        .append($('<span>').addClass('upcoming')
                            .append($('<span>').addClass('symbol').html(weatherSymbols[day.condition]))
                            .append($('<span>').addClass('forecast-data').html(`${day.low}&#176;/${day.high}&#176;`)
                            .append($('<span>').addClass('forecast-data').text(day.condition))));

                }
            }

            function displayError(){
                $('#forecast').text('Error');
            }
        }
    }
}
