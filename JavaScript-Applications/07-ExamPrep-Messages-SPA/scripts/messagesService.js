let messagesService = (() => {
    function showReceivedMessages() {
        $('#myMessages>table>tbody').empty();
        let queryUrl = `?query={"recipient_username":"${sessionStorage.getItem('username')}"}`;
        requester.get('appdata', 'messages' + queryUrl)
            .then(fillReceivedMessagesTable)
            .catch(notification.handleError);

        function fillReceivedMessagesTable(messages) {
            for (let message of messages) {
                $('#myMessages>table>tbody').append($('<tr>')
                    .append($('<td>').text(formatSender(message.sender_name, message.sender_username)))
                    .append($('<td>').text(message.text))
                    .append($('<td>').text(formatDate(message._kmd.lmt))))
            }
        }
    }

    function showSentMessages() {
        $('#sentMessages>table>tbody').empty();
        let queryUrl = `?query={"sender_username":"${sessionStorage.getItem('username')}"}`;
        requester.get('appdata', 'messages' + queryUrl)
            .then(fillSentMessagesTable)
            .catch(notification.handleError);

        function fillSentMessagesTable(messages) {
            for (let message of messages) {
                $('#sentMessages>table>tbody').append($('<tr>')
                    .append($('<td>').text(message.recipient_username))
                    .append($('<td>').text(message.text))
                    .append($('<td>').text(formatDate(message._kmd.lmt)))
                    .append($('<td>').append($('<button>').text('Delete').click(() => {
                        deleteSentMessage(message._id);
                    }))))
            }
        }
    }

    function prepareSendMessageView() {
        requester.get('user', '')
            .then((users) => {
                let dropdownMenu = $('#msgRecipientUsername');
                dropdownMenu.empty();
                for (let user of users) {
                    dropdownMenu
                        .append($('<option>').text(formatSender(user.name, user.username)).val(user.username));
                }
            })
            .catch(notification.handleError)
    }

    function getMessageObject() {
        let recipientUsername = $('#msgRecipientUsername').val();
        let msgText = $('#msgText').val();

        return {
            sender_username: sessionStorage.getItem('username'),
            sender_name: sessionStorage.getItem('name'),
            recipient_username: recipientUsername,
            text: msgText
        };
    }

    function deleteSentMessage(messageId) {
        requester.remove('appdata', 'messages/' + messageId)
            .then(() => {
            notification.showInfo('Message deleted.');
            showSentMessages();
            })
            .catch(notification.handleError)
    }

    function formatDate(dateISO8601) {
        let date = new Date(dateISO8601);
        if (Number.isNaN(date.getDate()))
            return '';
        return date.getDate() + '.' + padZeros(date.getMonth() + 1) +
            "." + date.getFullYear() + ' ' + date.getHours() + ':' +
            padZeros(date.getMinutes()) + ':' + padZeros(date.getSeconds());

        function padZeros(num) {
            return ('0' + num).slice(-2);
        }
    }

    function formatSender(name, username) {
        if (!name)
            return username;
        else
            return username + ' (' + name + ')';
    }

    return { showReceivedMessages, showSentMessages, prepareSendMessageView, getMessageObject }
})();