function solve(dataRows){
    let database = new Map();
    for (let line of dataRows){
        let peopleInfo = line.split('-');
        if (peopleInfo.length == 1){
            let person = peopleInfo[0];
            if (!database.has(person))
                database.set(person, { followers: new Set(), followedBy : 0, following: 0})
        }
        else {
            let firstPerson = peopleInfo[0];
            let secondPerson = peopleInfo[1];
            if (!database.has(firstPerson) || !database.has(secondPerson) || firstPerson == secondPerson)
                continue;
            if (!database.get(secondPerson).followers.has(firstPerson)){
                database.get(firstPerson).following++;
                database.get(secondPerson).followers.add(firstPerson);
                database.get(secondPerson).followedBy++;
            }
        }
    }

    let sortedPeople = Array.from(database).sort(sortPeople);

    console.log(sortedPeople[0][0]);
    let counter = 1;
    for (let follower of sortedPeople[0][1].followers)
        console.log(`${counter++}. ${follower}`)

    function sortPeople(a, b) {
        if (a[1].followers.size > b[1].followers.size)
            return -1;
        if (a[1].followers.size < b[1].followers.size)
            return 1;
        if (a[1].following > b[1].following)
            return -1;
        if (a[1].following < b[1].following)
            return 1;
        return 0;
    }
}

solve([
    'A',
    'B',
    'C',
    'D',
    'A-B',
    'B-A',
    'C-A',
    'D-A'
]);