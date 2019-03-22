function attachEvents(){
    const baseUrl = `https://baas.kinvey.com/appdata/kid_ryDho3sUb`;
    const kinveyUsername = 'peshata';
    const kinveyPassword = 'softuni';
    const authHeader = { "Authorization": `Basic ${btoa(kinveyUsername + ':' + kinveyPassword)}` };

    let editCountryDiv = $('#editCountryDiv');
    let addNewTownRow =  $('#addNewTownForm');
    let countryTowns = $('#countryTowns');
    let results = $('#results');
    loadCountriesTable();

    function loadCountriesTable(){
        editCountryDiv.hide();
        results.empty();
        $.ajax({
            method: "GET",
            url: baseUrl + '/Countries',
            headers: authHeader
        }).then(fillCountriesTable);
    }

    function fillCountriesTable(data){
        results.append($('<tr>').append($('<th>').text('Name')).append($('<th>').text('Action')));
        for (let country of data){
            $('#results').append($('<tr>')
                .append($('<td>').text(country.name).click(() => showCountryTowns(country._id)))
                .append($('<td>').append($('<button>')
                    .text('Delete')
                    .click(() => deleteCountry(country._id)))
                        .append(($('<button>').text('Edit').click(() => editCountry(country._id)))
                )));
        }

        function deleteCountry(id){
            let townsToDeleteAsWellUrl = `${baseUrl}/Towns/?query={"countryId":"${id}"}`;
            // TODO: delete the towns of the country, after deleting the country

            $.ajax({
                method: "DELETE",
                url: baseUrl + `/Countries/${id}`,
                headers: authHeader
            })
                .then(loadCountriesTable)
        }

        function editCountry(id) {
            $.get({
                url: baseUrl + `/Countries/${id}`,
                headers: authHeader
            })
                .then(populateEditCountryInput);

            function populateEditCountryInput(country) {
                editCountryDiv.show();
                $('#editCountryName').val(country.name);
                $('#countryToEditId').val(country._id);
            }
        }

        function showCountryTowns(id) {
            countryTowns.empty();
            let townsFromCountryUrl = `${baseUrl}/Towns/?query={"countryId":"${id}"}`;
            $.get({
                url: townsFromCountryUrl,
                headers: authHeader
            }).then((data) => {
                countryTowns.append($('<tr id="addNewTownForm">').append($('<td colspan="2"></td>')
                    .append($('<label>').text('Add new town: '))
                    .append($('<input type="text" id="addTownName">'))
                    .append($('<input type="hidden" id="countryToAddTownTo">').val(id))
                    .append($('<button>').text('Add Town').click(addNewTownToSelectedCountry))));
                if (data.length > 0){
                    for (let town of data){
                        let actionButtons = $('<td>');
                        actionButtons.append($('<button>').text('Delete').click(() => deleteTown(town._id, town.countryId)));
                        actionButtons.append(' ');
                        actionButtons.append($('<button>').text('Edit').click(() => { editTown(town._id, town.countryId, town.name)}));
                        countryTowns
                            .append($('<tr>')
                                .append($('<td>').text(town.name))
                                .append(actionButtons));
                    }
                }
                else {
                    countryTowns.append($('<tr>').append($('<td>').text('No towns for current country')))
                }
            });

            function deleteTown(townId, countryId){
                $.ajax({
                    method: "DELETE",
                    url: baseUrl + `/Towns/${townId}`,
                    headers: authHeader
                })
                    .then(() => {
                        showCountryTowns(countryId)
                    })
            }

            function addNewTownToSelectedCountry() {
                let countryForNewTown = $('#countryToAddTownTo').val();
                let newTownName = $('#addTownName').val();

                if (newTownName !== ''){
                    $.post({
                        url: baseUrl + '/Towns',
                        data: JSON.stringify({ name: newTownName, countryId: countryForNewTown }),
                        contentType: 'application/json',
                        headers: authHeader
                    })
                        .then(() => showCountryTowns(countryForNewTown));
                }
            }

            function editTown(id, countryId, townName){
                countryTowns.append($('<tr>').append($('<td colspan="2">')
                    .append($('<label>').text('Edit town Name: '))
                    .append($('<input type="text" id="editTownName">').val(townName))
                    .append($('<button>').text('Edit').click(() => editSelectedTown(id, countryId)))));

                function editSelectedTown(townEditId, countryId) {
                    let newTownName = $('#editTownName').val();
                    let putUrl = baseUrl + `/Towns/${townEditId}`;
                    if (newTownName !== '') {
                        $.ajax({
                            url: putUrl,
                            method: "PUT",
                            contentType: 'application/json',
                            data: JSON.stringify({ name: newTownName, countryId: countryId}),
                            headers: authHeader
                        })
                            .then(() => showCountryTowns(countryId))
                    }
                }
            }
        }
    }

    $('#btnSubmit').click(createCountry);

    function createCountry(){
        let name = $('#name').val();
        if (name !== ''){
            $.post({
                url: baseUrl + '/Countries',
                data: JSON.stringify({ name: name }),
                contentType: 'application/json',
                headers: authHeader
            })
                .then(() => {
                $('#name').val('');
                loadCountriesTable();
                });
        }
    }

    $('#btnEditCountry').click(changeCountryName);

    function changeCountryName() {
        let countryToEditId = $('#countryToEditId').val();
        let newCountryName = $('#editCountryName').val();
        let putUrl = baseUrl + `/Countries/${countryToEditId}`;
        if (newCountryName !== '') {
            $.ajax({
                url: putUrl,
                method: "PUT",
                contentType: 'application/json',
                data: JSON.stringify({ name: newCountryName}),
                headers: authHeader
            })
                .then(loadCountriesTable)
        }
    }
}