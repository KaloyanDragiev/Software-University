function attachEvents(){
    const baseUrl = `https://baas.kinvey.com/appdata/kid_ByR-guLUb/biggestCatches`;
    const kinveyUsername = 'peshata';
    const kinveyPassword = 'softuni';
    const authHeader = { "Authorization": `Basic ${btoa(kinveyUsername + ':' + kinveyPassword)}` };

    $('.load').click(loadCatches);
    $('.add').click(addCatch);

    function loadCatches() {
        $('#catches').empty();
        $.ajax({
            method: "GET",
            url: baseUrl,
            headers: authHeader
        })
            .then(getAllCatches);

        function getAllCatches(data) {
            for (let fishCatch of data) {
                $('#catches')
                    .append($('<div>')
                        .addClass('catch')
                        .attr('data-id', fishCatch._id)
                        .append($('<label>').text('Angler'))
                        .append($('<input>').attr('type', 'text').addClass('angler').val(fishCatch.angler))
                        .append($('<label>').text('Weight'))
                        .append($('<input>').attr('type', 'number').addClass('weight').val(fishCatch.weight))
                        .append($('<label>').text('Species'))
                        .append($('<input>').attr('type', 'text').addClass('species').val(fishCatch.species))
                        .append($('<label>').text('Location'))
                        .append($('<input>').attr('type', 'text').addClass('location').val(fishCatch.location))
                        .append($('<label>').text('Bait'))
                        .append($('<input>').attr('type', 'text').addClass('bait').val(fishCatch.bait))
                        .append($('<label>').text('Capture Time'))
                        .append($('<input>').attr('type', 'number').addClass('captureTime').val(fishCatch.captureTime))
                        .append($('<button>').addClass('update').text('Update').click(updateCatch))
                        .append($('<button>').addClass('delete').text('Delete').click(deleteCatch)))
            }
        }
    }

    function updateCatch() {
        let catchId = $(this).parent().attr('data-id');
        let selectorString = `div[data-id='${catchId}']`;
        let angler = $(selectorString + '>input.angler').val();
        let weight = $(selectorString + '>input.weight').val();
        let species = $(selectorString + '>input.species').val();
        let location = $(selectorString + '>input.location').val();
        let bait = $(selectorString + '>input.bait').val();
        let captureTime = $(selectorString + '>input.captureTime').val();

        $.ajax({
            method: "PUT",
            url: baseUrl + `/${catchId}`,
            headers: authHeader,
            contentType: 'application/json',
            data: JSON.stringify({
                angler: angler,
                weight: Number(weight),
                species: species,
                location: location,
                bait: bait,
                captureTime: Number(captureTime)
            })
        })
            .then(loadCatches);
    }

    function deleteCatch() {
        let catchId = $(this).parent().attr('data-id');

        $.ajax({
            method: "DELETE",
            url: baseUrl + `/${catchId}`,
            headers: authHeader
        })
            .then(loadCatches);
    }

    function addCatch() {
        let fishCatch = {
            angler:  $('#addForm>input.angler').val(),
            weight: Number($('#addForm>input.weight').val()),
            species: $('#addForm>input.species').val(),
            location: $('#addForm>input.location').val(),
            bait: $('#addForm>input.bait').val(),
            captureTime: Number($('#addForm>input.captureTime').val())
        };

        $.post({
            url: baseUrl,
            headers: authHeader,
            contentType: 'application/json',
            data: JSON.stringify(fishCatch)
        })
            .then(loadCatches)
    }
}
