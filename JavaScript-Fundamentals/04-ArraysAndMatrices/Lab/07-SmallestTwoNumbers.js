function showTwoSmallest(nums){
    nums = nums.map(Number);
    nums.sort((a,b) => a - b);
    return nums.splice(0, 2);
}

// console.log(showTwoSmallest(['30', '15', '50', '5']));
