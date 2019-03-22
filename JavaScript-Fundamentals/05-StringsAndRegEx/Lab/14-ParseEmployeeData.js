function storeData(input){
    let pattern = /^([A-Z][A-Za-z]*) - ([1-9][0-9]*) - ([a-zA-Z0-9 -]+)$/g
    let emps = [], match;
    for (let empInfo of input){
        while (match = pattern.exec(empInfo))
        emps.push(`Name: ${match[1]}\nPosition: ${match[3]}\nSalary: ${match[2]}`)
    }
    return emps.join('\n')
}

console.log(storeData(['Jonathan - 2000 - Manager', 'Peter- 1000- Chuck', 'George - 1000 - Team Leader']));