function registerSystems(dataRows){
    let allSystems = new Map();

    for (let dataRow of dataRows){
        let systemInfo = dataRow.split(' | ');
        let system = systemInfo[0];
        let component = systemInfo[1];
        let subcomponent = systemInfo[2];

        if (!allSystems.has(system))
            allSystems.set(system, new Map())
        if (!allSystems.get(system).has(component))
            allSystems.set(system, allSystems.get(system).set(component, new Set()));
        allSystems.get(system).get(component).add(subcomponent);
    }

    let sortedSystems = Array.from(allSystems).sort( (s1, s2) => sortSystems(s1, s2));
                                              //.sort(sortSystems)
    for (let [outerKey, outerValue] of sortedSystems){
        console.log(outerKey);
        let sortedComponents = Array.from(outerValue).sort( (c1, c2) => c2[1].size - c1[1].size);
        for (let [component, subcomponents] of sortedComponents){
            console.log(`|||${component}`)
            for (let subcomponent of subcomponents)
                console.log(`||||||${subcomponent}`)
        }
    }

    function sortSystems(s1, s2){
        if (s1[1].size > s2[1].size)              // DESCENDING SORT
            return -1;
        if (s1[1].size < s2[1].size)
            return 1;
        if (s1[0].toLowerCase() < s2[0].toLowerCase())         // ASCENDING SORT
            return -1;
        if (s1[0].toLowerCase() > s2[0].toLowerCase())
            return 1;
        return 0;
    }
}

registerSystems([`SULS | Main Site | Home Page`,
                 `SULS | Main Site | Login Page`,
                 `SULS | Main Site | Register Page`,
                 `SULS | Judge Site | Login Page`,
                 `SULS | Judge Site | Submittion Page`,
                 `Lambda | CoreA | A23`,
                 `SULS | Digital Site | Login Page`,
                 `Lambda | CoreB | B24`,
                 `Lambda | CoreA | A24`,
                 `Lambda | CoreA | A25`,
                 `Lambda | CoreC | C4`,
                 `Indice | Session | Default Storage`,
                 `Indice | Session | Default Security`]);
