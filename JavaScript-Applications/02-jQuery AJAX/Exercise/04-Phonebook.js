function attachEvents() {
    let hostUrl = 'https://phonebook-nakov.firebaseio.com/phonebook.json';
    $('#btnLoad').click(loadContacts);
    $('#btnCreate').click(createNewContact);

    function loadContacts(){
        $('#phonebook').empty();
        $.get(hostUrl)
            .then(fillContactList)
    }

    function fillContactList(data) {
        for (let entry in data) {
            $('#phonebook')
                .append($('<li>')
                    .text(`${data[entry].person}: ${data[entry].phone} `)
                    .append($('<button>')
                        .text('Delete')
                        .click(function() {
                            deleteContact(entry)
                        }))
                );
        }
    }

    function deleteContact(key){
        let deleteRequest = {
            method: "DELETE",
            url: `https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`
        };
        $.ajax(deleteRequest)
            .then(loadContacts)
    }

    function createNewContact() {
        let personName = $('#person').val();
        let phoneNumber = $('#phone').val();

        let obj = {
            person: personName,
            phone: phoneNumber
        };

        $.post(hostUrl, JSON.stringify(obj))
            .then(() => {
                $('#person').val('');
                $('#phone').val('');
                loadContacts()
            })
    }
}