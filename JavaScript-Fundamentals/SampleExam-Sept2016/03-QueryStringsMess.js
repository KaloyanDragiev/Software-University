function solve(dataRows){
    let pattern = /(?:^|\?|&)([^\/&=\s]+)=([^=&\s]+)/g
    let match;
    for (let line of dataRows){
        let attributes = new Map();
        while (match = pattern.exec(line)){
            let key = decode(match[1]).trim();
            let value = decode(match[2]).trim();

            if (!attributes.has(key))
                attributes.set(key, []);
            attributes.get(key).push(value);
        }
        let result = '';
        for (let [key, value] of attributes){
            result += `${key}=[${value.join(', ')}]`
        }
        console.log(result);
    }

    function decode(input){
        return input
            .replace(/\+/g, ' ')
            .replace(/%20/g, ' ')
            .replace(/\s+/g, ' ')
    }
}

solve([
    'foo=%20foo&value=+val&foo+=5+%20+203',
    'foo=poo%20&value=valley&dog=wow+',
    'url=https://softuni.bg/trainings/coursesinstances/details/1070',
    'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php'
    ]);