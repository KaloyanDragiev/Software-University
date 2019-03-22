function assessSpeed(input){
    let speed = Number(input[0]);
    let area = input[1];

    let motorwayLimit = 130;
    let interstateLimit = 90;
    let cityLimit = 50;
    let residentialLimit = 20;

    crimeCheck(speed, area);

    function crimeCheck(speed, area){
        switch (area){
            case 'motorway' : if (speed > motorwayLimit) console.log(calcDrivingType(speed, motorwayLimit)); break;
            case 'interstate' : if (speed > interstateLimit) console.log(calcDrivingType(speed, interstateLimit)); break;
            case 'city' : if (speed > cityLimit) console.log(calcDrivingType(speed, cityLimit)); break;
            case 'residential' : if (speed > residentialLimit) console.log(calcDrivingType(speed, residentialLimit)); break;
        }
    }

    function calcDrivingType(speed, speedLimit){
        let speedOverLimit = speed - speedLimit;
        if (speedOverLimit <= 20)
            return 'speeding';
        else if (speedOverLimit <= 40)
            return 'excessive speeding';
        else
            return 'reckless driving';
    }
}


// assessSpeed([21, 'residential']);
// assessSpeed([120, 'interstate']);