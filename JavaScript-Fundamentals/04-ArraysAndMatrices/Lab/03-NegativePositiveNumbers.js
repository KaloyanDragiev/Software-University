function splitNumbers(nums){
    nums = nums.map(Number);
    let result = [];
    for (let num of nums){
        if (num < 0)
            result.unshift(num);
        else
            result.push(num);
    }
    return result.join('\n');
}

console.log(splitNumbers(['3', '-2', '0', '-1']));