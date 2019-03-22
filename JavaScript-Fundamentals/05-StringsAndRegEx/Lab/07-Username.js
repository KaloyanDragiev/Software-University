function extractUsername(input){
    let resultArr = [];
    for (let i of input){
        let userInfo = i.split('@');
        let username = userInfo[0];
        let emailDomain = '';
        for (let email of userInfo[1].split('.')){
            emailDomain += email[0];
        }
        resultArr.push(username + '.' + emailDomain);
    }
    return resultArr.join(', ')
}

// console.log(extractUsername(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']));