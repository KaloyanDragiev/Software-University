handlers.myMessages = function(ctx) {
    ctx.username = sessionStorage.getItem('username');
    requester.get('appdata', `messages?query={"recipient_username":"${sessionStorage.getItem('username')}"}`).
        then((messages) => {
        for (let msg of messages) {
            msg.timestamp = formatDate(msg._kmd.lmt);
            msg.name = formatSender(msg.sender_name, msg.sender_username)
        }
        ctx.messages = messages;
        this.loadPartials({
            header: './templates/common/header.hbs',
            footer: './templates/common/footer.hbs',
            notification: './templates/common/notification.hbs',
            message: './templates/common/receivedMessage.hbs',
            page: './templates/myMessages.hbs'
        })
            .then(function() {
                this.partial('./templates/common/main.hbs');
            });
    })
        .catch(notification.handleError);
};

handlers.sendMessage = function(ctx) {
    ctx.username = sessionStorage.getItem('username');
    requester.get('user', '')
        .then((users) => {
        ctx.users = users.filter(u => u.username !== ctx.username);
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                notification: './templates/common/notification.hbs',
                page: './templates/sendNewMessage.hbs'
            })
                .then(function() {
                    this.partial('./templates/common/main.hbs');
                })
        })
        .catch(notification.handleError);
};

handlers.sendMessageAction = function(ctx) {
    let newMessage = {
        recipient_username: ctx.params.recipient,
        sender_name: sessionStorage.getItem('name'),
        sender_username: sessionStorage.getItem('username'),
        text: ctx.params.text
    };
    requester.post('appdata', 'messages', 'kinvey', newMessage)
        .then(function() {
            notification.showInfo('Message sent.');
            ctx.redirect('#/archiveMessages')
        })
        .catch(notification.handleError)
};

handlers.archiveMessages = function(ctx) {
    ctx.username = sessionStorage.getItem('username');
    requester.get('appdata', `messages?query={"sender_username":"${sessionStorage.getItem('username')}"}`)
        .then(function(sentMessages) {
            for (let msg of sentMessages) {
                msg.timestamp = formatDate(msg._kmd.lmt);
            }
            ctx.sentMessages = sentMessages;
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                notification: './templates/common/notification.hbs',
                sentMessage: './templates/common/sentMessage.hbs',
                page: './templates/sentMessages.hbs'
            })
                .then(function() {
                    this.partial('./templates/common/main.hbs').then(() => {
                        $('button').click((e) => {
                            let id = ($(e.target).attr('id'));
                            requester.remove('appdata', 'messages/' + id)
                                .then(() => {
                                notification.showInfo('Message successfully deleted.');
                                ctx.redirect('#');
                                })
                                .catch(notification.handleError)
                        })
                    });
                })
    })
        .catch(notification.handleError);
};

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