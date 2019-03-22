function solve() {
    let currentId = 'depot';
    let nextStop = '';

    function depart() {
        $('#depart').attr('disabled', true);
        $('#arrive').removeAttr('disabled');

        let getRequest = {
            method: "GET",
            url: `https://judgetests.firebaseio.com/schedule/${currentId}.json`,
            success: updateInfoBoxDeparture,
            error: disableButtons
        };

        $.ajax(getRequest);
    }

    function arrive() {
        $('#arrive').attr('disabled', true);
        $('#depart').removeAttr('disabled');

        $('.info').text(`Arriving at ${nextStop}`);
    }

    function updateInfoBoxDeparture(data) {
        $('.info').text(`Next Stop ${data.name}`);
        currentId = data.next;
        nextStop = data.name;
    }

    function disableButtons(){
        $('#depart').attr('disabled', true);
        $('#arrive').attr('disabled', true);
        $('.info').text('Error');
    }

    return {
        depart,
        arrive
    };
}