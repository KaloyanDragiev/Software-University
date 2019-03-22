function calcLogarithm(nums){
    let numbers = nums.map(Number);
    let result = "";
    for (let number of numbers) {
        result += Math.log2(number) + '\n'
    }
    return result;
}

// console.log(calcLogarithm([1024, 1048576, 256, 1, 2, 50, 100]))


// Version 2 using while. Should be correct. The other one returns floating numbers
// function calcLogarithm(nums){
//     let numbers = nums.map(Number);
//     let result = "";
//     for (let number of numbers) {
//         let counter = 0;
//         while (number >= 1){
//             counter++;
//             number /= 2;
//         }
//         result += counter + '\n'
//     }
//     return counter;
// }
