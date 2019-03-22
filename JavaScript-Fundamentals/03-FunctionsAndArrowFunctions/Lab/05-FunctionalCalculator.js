function calculate([num1, num2, operator]){
    let sumFunc = function(n1, n2) { return Number(n1) + Number(n2); };
    let subtractFunc = function (n1, n2) { return n1 - n2; };
    let multiplyFunc = function (n1, n2) { return n1 * n2; };
    let divideFunc = function (n1, n2) {return n1 / n2; };
    switch (operator){
        case '+': return sumFunc(num1, num2);
        case '-': return subtractFunc(num1, num2);
        case '*': return multiplyFunc(num1, num2);
        case '/': return divideFunc(num1, num2);
    }
}

console.log(calculate(['3', '3', '/']));