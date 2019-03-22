function cook([num, op1, op2, op3, op4, op5]){
    let number = Number(num);
    let calc = function(num, op) { return op(num) };

    let chop = x => x / 2;
    let dice = x => Math.sqrt(x);
    let spice = x => x + 1;
    let bake = x => x * 3;
    let fillet = x => x * 0.8;

    let ops = [op1, op2, op3, op4, op5];
    for (let op of ops){
        switch (op){
            case 'chop' : number = calc(number, chop); break;
            case 'dice' : number = calc(number, dice); break;
            case 'spice' : number = calc(number, spice); break;
            case 'bake' : number = calc(number, bake); break;
            case 'fillet' : number = calc(number, fillet); break;
        }
        console.log(number);
    }
}

cook([32, 'chop', 'chop', 'chop', 'chop', 'chop']);