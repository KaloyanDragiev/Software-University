function startApp()  {
    showHideMenuLinks();
    showView('viewAppHome');
    $("form").submit(function(e) { e.preventDefault() });

    function showHideMenuLinks() {
        if (sessionStorage.getItem('authToken') === null){
            $('#spanMenuLoggedInUser').text('');
            showView('viewAppHome');
            $('.anonymous').show();
            $('.useronly').hide();
        }
        else {
            $('#spanMenuLoggedInUser').text(`Welcome, ${sessionStorage.getItem('username')}`);
            $('#viewUserHomeHeading').text(`Welcome, ${sessionStorage.getItem('username')}`);
            showView('viewUserHome');
            $('.anonymous').hide();
            $('.useronly').show();
        }
    }

    // Navigation links
    $('#linkMenuAppHome').click(() => { showView('viewAppHome') });
    $('#linkMenuLogin').click(() => { showView('viewLogin') });
    $('#linkMenuRegister').click(() => { showView('viewRegister') });
    $('#linkMenuUserHome').click(() => { showView('viewUserHome') });
    $('#linkMenuMyMessages,#linkUserHomeMyMessages').click(() => {
        showView('viewMyMessages');
        messagesService.showReceivedMessages();
    });
    $('#linkMenuArchiveSent,#linkUserHomeArchiveSent').click(() => {
        showView('viewArchiveSent');
        messagesService.showSentMessages();
    });
    $('#linkMenuSendMessage,#linkUserHomeSendMessage').click(() => {
        showView('viewSendMessage');
        messagesService.prepareSendMessageView();
    });
    $('#linkMenuLogout').click(logoutUser);

    function showView(viewName) {
        $('main>section').hide();
        $(`#${viewName}`).show();
    }

    // Form Events
    $("#formLogin").submit(loginUser);
    $('#formRegister').submit(registerUser);
    $('#formSendMessage').submit(sendMessage);

    function loginUser() {
        let username = $('#loginUsername').val();
        let password = $('#loginPasswd').val();

        auth.login(username, password)
            .then((userInfo) => {
                $('#formLogin').trigger('reset');
                auth.saveSession(userInfo);
                notification.showInfo('Login successful.');
                showHideMenuLinks();
            })
            .catch(notification.handleError)
    }

    function logoutUser() {
        auth.logout()
            .then(() => {
            sessionStorage.clear();
            showHideMenuLinks();
            notification.showInfo('Logout successful.')
            })
            .catch(notification.handleError)
    }

    function registerUser() {
        let username = $('#registerUsername').val();
        let password = $('#registerPasswd').val();
        let name = $('#registerName').val();

        auth.register(username, password, name)
            .then(function(userInfo) {
                $('#formRegister').trigger('reset');
                auth.saveSession(userInfo);
                notification.showInfo('User registration successful.');
                showHideMenuLinks();
            })
            .catch(notification.handleError)
    }

    function sendMessage() {
        let messageObject = messagesService.getMessageObject();

        requester.post('appdata', 'messages', 'kinvey', messageObject)
            .then(() => {
                notification.showInfo('Message sent.');
                showView('viewArchiveSent');
                messagesService.showSentMessages();
            })
            .catch(notification.handleError)
    }
}