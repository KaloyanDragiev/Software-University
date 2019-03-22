function calcTriangleArea ([A, B, C]){
    //[A, B, C] = [A, B, C].map(Number);
    let semiper = (Number(A) + Number(B) + Number(C)) / 2;
    return Math.sqrt(semiper * (semiper - A) * (semiper - B) * (semiper - C));
}
