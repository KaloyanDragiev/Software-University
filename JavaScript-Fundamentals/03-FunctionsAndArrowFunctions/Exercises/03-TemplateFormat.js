function printXML(input){
    let result = '<?xml version="1.0" encoding="UTF-8"?>\n<quiz>\n';

    for (let i = 0; i < input.length; i+= 2){
        addQuestionXml(input[i]);
        addAnswerXml(input[i + 1]);
    }

    result += '</quiz>';

    return result;

    function addQuestionXml(questionString){
        result += `  <question>\n   ${questionString}\n  </question>\n`;
    }

    function addAnswerXml(answerString){
        result += `  <answer>\n   ${answerString}\n  </answer>\n`;
    }
}

//console.log(printXML(["Dry ice is a frozen form of which gas?", "Carbon Dioxide", "What is the brightest star in the night sky?", "Sirius"]
//));
