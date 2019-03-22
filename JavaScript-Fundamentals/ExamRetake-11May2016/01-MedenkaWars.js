function determineWinner(dataRows){
    let victor = 0;
    let naskor = 0;

    let victorLastDamage = 0;
    let naskorLastDamage = 0;
    let victorConsecutiveHits = 1;
    let naskorConsecutiveHits = 1;

    for (let dataRow of dataRows){
        let attackInfo = dataRow.split(' ');
        let damage = Number(attackInfo[0]) * 60;
        let color = attackInfo[1];

        if (color == 'white'){
            if (victorLastDamage == damage)
                victorConsecutiveHits++;
            else
                victorConsecutiveHits = 1;
            if (victorConsecutiveHits == '2'){
                victorConsecutiveHits = 1;
                damage *= 2.75;
            }
            victorLastDamage = damage;
            victor += damage;
        }
        else{
            if (naskorLastDamage == damage)
                naskorConsecutiveHits++;
            else
                naskorConsecutiveHits = 1;
            if (naskorConsecutiveHits == '5'){
                naskorConsecutiveHits = 1;
                damage *= 4.5;
            }
            naskorLastDamage = damage;
            naskor += damage;
        }
    }

    if (naskor > victor){
        console.log('Winner - Naskor');
        console.log(`Damage - ${naskor}`);
    }
    else{
        console.log('Winner - Vitkor');
        console.log(`Damage - ${victor}`);
    }
}

determineWinner(['2 dark medenkas',
                 '1 white medenkas',
                 '2 dark medenkas',
                 '2 dark medenkas',
                 '15 white medenkas',
                 '2 dark medenkas',
                 '2 dark medenkas']);