function extractUniqueWords(dataRows){
    let uniqueWords = new Set();
    let text = dataRows.join();
    let wordsArray = text.split(/\W+/).filter(w => w != '');
    for (let word of wordsArray)
        uniqueWords.add(word.toLowerCase());
    console.log(Array.from(uniqueWords).join(', '))
    // console.log([...uniqueWords.values()].join(", "));
}
extractUniqueWords(['Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui.',
                    'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.',
                    'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.',
                    'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.',
                    'Morbi in ipsum varius, pharetra diam vel, mattis arcu.',
                    'Integer ac turpis commodo, varius nulla sed, elementum lectus.',
                    'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.'
]);
