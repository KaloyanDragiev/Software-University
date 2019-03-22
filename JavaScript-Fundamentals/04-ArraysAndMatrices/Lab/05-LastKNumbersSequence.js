function lastKNumbers(nums){
    let length = Number(nums[0]);
    let k = Number(nums[1]);

    let arr = [1];
    for (let i = 1; i < length; i++){
        let start = Math.max(0, i - k);
        let end = i - 1;
        let sum = 0;
        for (let j = start; j <= end; j++)
            sum += arr[j];
        arr[i] = sum;
    }
    return arr.join(' ');
}

//console.log(lastKNumbers(['8', '2']));

//1 1 2 3 5 8 13 21