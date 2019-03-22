function attachEvents(){
    $('#btnLoadTowns').click(fillTownList);

    let townSource = $('#towns-template').html();
    let townTemplate = Handlebars.compile(townSource);
    let resultDiv = $('#root');

    function fillTownList(){
        resultDiv.empty();
        let allTowns = $('#towns').val().split(/\s*,\s*/g);
        for (let town of allTowns){
            let liTown = townTemplate( { townName: town} );
            resultDiv.append(liTown);
        }
    }
}