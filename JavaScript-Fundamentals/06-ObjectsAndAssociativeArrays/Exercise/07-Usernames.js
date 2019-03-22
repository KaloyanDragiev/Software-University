function extractUsernames(dataRows){
    let usernames = new Set();
    for (let dataRow of dataRows){
        usernames.add(dataRow);
    }

    let sortedUsernames = Array.from(usernames).sort( (n1, n2) => sortNames(n1, n2));

    function sortNames(n1, n2){
        if (n1.length < n2.length)                            // ASCENDING
            return -1;
        if (n1.length > n2.length)
            return 1;
        if (n1 < n2)         // ASCENDING
            return -1;
        if (n1 > n2)
            return 1;
        return 0;
    }

    for (let username of sortedUsernames)
        console.log(username)
}

extractUsernames(['Ashton',
                  'Kutcher',
                  'Ariel',
                  'Lilly',
                  'Keyden',
                  'Aizen',
                  'Billy',
                  'Braston']);