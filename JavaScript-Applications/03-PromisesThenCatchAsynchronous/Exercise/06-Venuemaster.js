function attachEvents() {
    const kinveyAppKey = 'kid_BJ_Ke8hZg';
    const baseUrl = `https://baas.kinvey.com/`;
    const kinveyUsername = 'guest';
    const kinveyPassword = 'pass';
    const authHeader = { "Authorization": `Basic ${btoa(kinveyUsername + ':' + kinveyPassword)}` };

    $('#getVenues').click(getVenuesDates);

    function getVenuesDates() {
        let date = $('#venueDate').val();
        $.post({
            url: baseUrl + `rpc/kid_BJ_Ke8hZg/custom/calendar?query=${date}`,
            headers: authHeader,
        })
            .then(retrieveAllVenues);

        function retrieveAllVenues(data){
            for (let venue in data) {
                $.get({
                    url: baseUrl + `appdata/kid_BJ_Ke8hZg/venues/${data[venue]}`,
                    headers: authHeader
                })
                    .then(fillVenueInfo)
            }
        }

        function fillVenueInfo(venue) {
            $('#venue-info').append($('<div>').addClass('venue').attr('id', venue._id)
                .append($('<span>').addClass('venue-name')
                    .prepend($('<input type="button">').addClass('info').val('More Info').click(showDetails)).append(venue.name))
                .append($('<div>').addClass('venue-details').css('display', 'none')
                    .append($('<table>')
                        .append($('<tr>')
                            .append($('<th>').text('Ticket Price'))
                            .append($('<th>').text('Quantity'))
                            .append($('<th>')))
                        .append($('<tr>')
                            .append($('<td>').addClass('venue-price').text(`${venue.price} lv`))
                            .append($('<td>')
                                .append($('<select>').addClass('quantity')
                                    .append($('<option>').val(1).text(1))
                                    .append($('<option>').val(2).text(2))
                                    .append($('<option>').val(3).text(3))
                                    .append($('<option>').val(4).text(4))
                                    .append($('<option>').val(5).text(5))))
                            .append($('<td>').append($('<input type="button">').addClass('purchase').val('Purchase').click(() => purchaseTickets(venue._id, venue.price, venue.name))))))
                    .append($('<span>').addClass('head').text('Venue description:'))
                    .append($('<p>').addClass('description').text(venue.description))
                    .append($('<p>').addClass('description').text(`Starting time: ${venue.startingHour}`))));

            function showDetails(){
                $(this).parent().next().toggle()
            }

            function purchaseTickets(venueId, venuePrice, venueName){
                let selectedQuantity = $(`#${venueId} select`).val();
                $('#venue-info').empty()
                    .append($('<span>').addClass('head').text('Confirm Purchase'))
                    .append($('<div>').addClass('purchase-info')
                        .append($('<span>').text(venueName))
                        .append($('<span>').text(`${selectedQuantity} x ${venuePrice}`))
                        .append($('<span>').text(`Total: ${Number(selectedQuantity)*Number(venuePrice)} lv`))
                        .append($('<input type="button">').val('Confirm').click(() => finalizePurchase(venueId, selectedQuantity))));
            }

            function finalizePurchase(venueId, quantity) {
                $.post({
                    url: baseUrl + `rpc/kid_BJ_Ke8hZg/custom/purchase?venue=${venueId}&qty=${quantity}`,
                    headers: authHeader
                })
                    .then((data) => {
                    $('#venue-info').empty().html(data.html).prepend('You may print this page as your ticket')
                    })
            }
        }
    }
}