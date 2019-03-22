function getInfo() {
    $('#buses').empty();
    let stopId = $('#stopId').val();
    let getRequest = {
        method: "GET",
        url: `https://judgetests.firebaseio.com/businfo/${stopId}.json`,
        success: populateResultList,
        error: () => $('#stopName').text('Error')
    };
    $.ajax(getRequest);

    function populateResultList(data){
        $('#stopName').text(data.name);
        for (let key in data.buses) {
            $('#buses')
                .append($('<li>')
                    .text(`Bus ${key} arrives in ${data.buses[key]} minutes`))
        }
    }
}