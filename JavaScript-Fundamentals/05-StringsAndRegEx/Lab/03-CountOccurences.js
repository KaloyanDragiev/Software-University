function countOcc([target, input]){
    let occurrences = 0;
    let p = -1
    while (true){
        p = input.indexOf(target, p + 1)
        if (p == -1)
            return occurrences
        occurrences++;
    }
}

console.log(countOcc(['ma', 'Marine mammal training is the training and caring for marine life such as, dolphins, killer whales, sea lions, walruses, and other marine mammals. It is also a duty of the trainer to do mental and physical exercises to keep the animal healthy and happy.']));
