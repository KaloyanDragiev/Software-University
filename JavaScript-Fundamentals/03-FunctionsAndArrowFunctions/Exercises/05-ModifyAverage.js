function modify([num]){
    while (averageCheck(num.toString())){
        num += '' + '9';
    }

    console.log(num);

    function averageCheck(numberAsString){
        let sum = 0;
        for (let i = 0; i < numberAsString.length; i++){
            sum += Number(numberAsString[i]);
        }
        if (sum / numberAsString.length > 5){
            return false;
        }
        return true;
    }
}

modify([101]);
modify([5835]);