function sortIt(input){
    return input
        .sort((a, b) => insensitive(a, b))
        .join('\n');

    function insensitive(s1, s2) {
        if (s1.length < s2.length)
            return -1;
        if (s1.length > s2.length)
            return 1;
        if (s1.toLowerCase() < s2.toLowerCase())
            return -1
        if (s1.toLowerCase() > s2.toLowerCase())
            return 1;
        return 0;
    }
}

// console.log(sortIt(['test', 'Deny', 'omen', 'Default']));