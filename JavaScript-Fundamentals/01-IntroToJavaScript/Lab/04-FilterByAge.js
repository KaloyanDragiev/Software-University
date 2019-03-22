function minAge (minimumAge, firstName, firstAge, secondName, secondAge){
    let firstPerson = { name : firstName, age : firstAge };
    let secondPerson = { name : secondName, age : secondAge  };

    for (let person of [firstPerson, secondPerson]){
        if (person.age >= minimumAge){
            console.log(person)
        }
    }
}

// minAge(['12', 'Ivan', '15', 'Asen', '9'])
