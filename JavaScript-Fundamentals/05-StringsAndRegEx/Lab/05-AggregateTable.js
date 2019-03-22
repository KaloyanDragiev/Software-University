function aggTable(input){
    let townsArr = [];
    let nums = [];

    for (let i = 0; i < input.length; i ++){
        let townInfo = input[i].split('|');
        townsArr.push(townInfo[1].trim());
        nums.push(Number(townInfo[2]))
    }
    console.log(townsArr.join(', '));
    console.log(nums.reduce((a,b) => a + b));
}

//aggTable(['| Sofia           | 300',    '| Veliko Tarnovo  | 500',    '| Yambol          | 275']);