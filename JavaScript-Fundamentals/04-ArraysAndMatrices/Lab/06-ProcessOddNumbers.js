function filter(nums){
    nums = nums.map(Number);
    let reversedDoubleNums = nums.filter((n, i) => i % 2 == 1).map(n => n * 2).reverse();
    return reversedDoubleNums.join(' ');
}

console.log(filter(['10', '15', '20', '25']))