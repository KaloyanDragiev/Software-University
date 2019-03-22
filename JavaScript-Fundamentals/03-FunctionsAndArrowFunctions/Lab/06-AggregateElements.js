function performOp(input){
    let sum1 = 0;
    let sum1Func = input.forEach(x => sum1 += Number(x));
    let sum2 = 0;
    let sum2Func = input.forEach(x => sum2 += 1 / x);
    let concat = '';
    let concatFunc = input.forEach(x => concat += x);

    sum1Func;
    sum2Func;
    concatFunc;
    console.log(sum1);
    console.log(sum2);
    console.log(concat);
}

// Author Solution....
//function aggregateElements(input) {
//    let elements = input.map(Number);
//    aggregate(elements, 0, (a, b) => a + b);
//    aggregate(elements, 0, (a, b) => a + 1 / b);
//    aggregate(elements, '', (a, b) => a + b);
//    function aggregate(arr, initVal, func) {
//        let val = initVal;
//        for (let i = 0; i < arr.length; i++)
//            val = func(val, arr[i]);
//        console.log(val);
//    }
//}

performOp(['1', '2', '3']);