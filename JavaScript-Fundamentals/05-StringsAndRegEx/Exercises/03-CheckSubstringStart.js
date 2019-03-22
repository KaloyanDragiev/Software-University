function checkStart([main, subs]){
    return main.startsWith(subs);
}

console.log(checkStart(['How have you been?', 'how']));
