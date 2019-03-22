function justSPLITit([text, delimiter]){
    return text.split(delimiter).join('\n');
}

console.log(justSPLITit(['One-Two-Three-Four-Five', '-']));