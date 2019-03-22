function solve(dataRows){
    let numbers = [];
    let operands = [];

    for (let line of dataRows){
        if (line == '+' || line == '-' || line == '*' || line == '/'){
            if (numbers.length < 2){
                console.log('Error: not enough operands!')
                return;
            }
            let result = 0;
            let secondNum = numbers.pop();
            let firstNum = numbers.pop();
            switch (line){
                case '+' : result = firstNum + secondNum; break;
                case '-' : result = firstNum - secondNum; break;
                case '*' : result = firstNum * secondNum; break;
                case '/' : result = firstNum / secondNum; break;
            }
            numbers.push(result);
        }
        else
            numbers.push(Number(line))
    }
    if (numbers.length == 1){
        console.log(numbers.pop());
    }
    else{
        console.log('Error: too many operands!')
    }
}