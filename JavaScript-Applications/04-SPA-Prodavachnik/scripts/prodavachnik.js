function startApp() {
    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_rJwuExGwW";
    const kinveyAppSecret = "4b2f5b6386c34fbb89e1232fceecef5c";
    const kinveyAppAuthHeaders = { 'Authorization': "Basic " + btoa(kinveyAppKey + ":" + kinveyAppSecret) };

    sessionStorage.clear();
    showHomeView();
    showHideMenuLinks();

    $(document).on({
        ajaxStart: function() { $("#loadingBox").show() },
        ajaxStop: function() { $("#loadingBox").hide() }
    });

    $("#formLogin").submit(loginUser);
    $('#formRegister').submit(registerUser);
    $('#formCreateAd').submit(createAd);
    $('#formEditAd').submit(editAd);
    $("form").submit(function(e) { e.preventDefault() });

    $('#linkCreateAd').click(showCreateAdView);
    $('#linkHome').click(showHomeView);
    $('#linkListAds').click(listAds);
    $('#linkLogin').click(showLoginView);
    $('#linkLogout').click(logoutUser);
    $('#linkRegister').click(showRegisterView);

    function loginUser(){
        let username = $('#formLogin').find(`input[name=username]`).val();
        let password = $('#formLogin').find(`input[name=passwd]`).val();

        if (username === '' || password === ''){
            showError('Please fill all the input fields!');
            return
        }

        $.post({
            url:kinveyBaseUrl + `user/${kinveyAppKey}/login`,
            headers: kinveyAppAuthHeaders,
            data: { username, password },
            success: successLoginUser,
            error: handleAjaxError
        });

        function successLoginUser(userInfo) {
            saveUserInfoInSession(userInfo);
            showHideMenuLinks();
            showInfo('Successfully logged in.');
            listAds()
        }
    }

    function logoutUser(){
        sessionStorage.clear();
        showHideMenuLinks();
        showHomeView();
        $('#loggedInUser').text('');
    }

    function registerUser(){
        let username = $('#formRegister').find(`input[name=username]`).val();
        let password = $('#formRegister').find(`input[name=passwd]`).val();

        if (username === '' || password === ''){
            showError('Please fill all the input fields!');
            return
        }

        $.post({
            url: kinveyBaseUrl + `user/${kinveyAppKey}/`,
            headers: kinveyAppAuthHeaders,
            data: { username, password },
            success: successRegisterUser,
            error: handleAjaxError
        });

        function successRegisterUser(userInfo){
            saveUserInfoInSession(userInfo);
            showHideMenuLinks();
            showInfo('Registered User');
            listAds();
        }
    }

    function createAd(){
        let dateInfo = $('#formCreateAd').find(`input[name=datePublished]`).val().split('-');
        let newAd = {
            title: $('#formCreateAd').find(`input[name=title]`).val(),
            description: $('#formCreateAd').find(`textarea[name=description]`).val(),
            publishDate: `${dateInfo[1]}/${dateInfo[2]}/${dateInfo[0]}`,
            price: Number($('#formCreateAd').find(`input[name=price]`).val()),
            imageUrl: $('#formCreateAd').find(`input[name=image]`).val(),
            publisher: sessionStorage.getItem('username'),
            views: 0
        };
        $.post({
            headers: getKinveyUserAuthHeaders(),
            data: JSON.stringify(newAd),
            contentType: 'application/json',
            url: kinveyBaseUrl + `appdata/${kinveyAppKey}/ads`,
            success: () => {
                listAds();
                showInfo('Book successfully created.')
            },
            error: handleAjaxError
        });
    }

    function editAd() {
        let title = $('#formEditAd').find(`input[name=title]`).val();
        let description = $('#formEditAd').find(`textarea[name=description]`).val();
        let dateInfo = $('#formEditAd').find(`input[name=datePublished]`).val().split('-');
        let publishDate = `${dateInfo[1]}/${dateInfo[2]}/${dateInfo[0]}`;
        let price = Number($('#formEditAd').find(`input[name=price]`).val());
        let publisher = sessionStorage.getItem('username');
        let id = $('#formEditAd').find(`input[name=id]`).val();
        let views = $('#formEditAd').find(`input[name=views]`).val();
        let imageUrl = $('#formEditAd').find(`input[name=image]`).val();

        $.ajax({
            method: 'PUT',
            headers: getKinveyUserAuthHeaders(),
            data: JSON.stringify({ title, description, publishDate, price: Number(price), publisher, views, imageUrl }),
            contentType: 'application/json',
            url: kinveyBaseUrl + `appdata/${kinveyAppKey}/ads/${id}`,
            success: () => {
                listAds();
                showInfo('Book successfully edited.')
            },
            error: handleAjaxError
        });
    }

    function listAds(){
        showView('viewAds');
        $.get({
            url: kinveyBaseUrl + `appdata/${kinveyAppKey}/ads`,
            headers: getKinveyUserAuthHeaders(),
            success: successListAds,
            error: handleAjaxError
        });

        function successListAds(data) {
            let tableData = $('#ads').find('table').find('tbody');
            tableData.empty();
            let sortedAds = data.sort( (a, b) => b.views - a.views);
            for (let ad of sortedAds) {
                let row = $('<tr>')
                    .append($('<td>').text(ad.title))
                    .append($('<td>').text(ad.publisher))
                    .append($('<td>').text(ad.description))
                    .append($('<td>').text(ad.price))
                    .append($('<td>').text(ad.publishDate));
                let actions = $('<td>');
                if (sessionStorage.getItem('userId') === ad._acl.creator){
                    actions.append($('<a href="#">').text('Delete').click(() => deleteAd(ad._id)))
                        .append(' ')
                        .append($('<a href="#">').text('Edit').click(() => fillEditAdDetails(ad)))
                }
                actions.append(' ', $('<a href="#">').text('Read More').click(() => viewAdDetails(ad)));
                row.append(actions);
                tableData.append(row)
            }
        }
    }

    function viewAdDetails(ad) {
        showView('viewDetailsAd');
        $('#formDetailsAd').trigger('reset');
        $('#viewDetailsAd').find(`h1`).text(ad.title);
        $('#formDetailsAd').find(`textarea[name=description]`).val(ad.description);
        $('#formDetailsAd').find(`span[name=price]`).text(`${ad.price} лв.`);
        $('#formDetailsAd').find(`span[name=publisher]`).text(ad.publisher);
        $('#formDetailsAd').find(`img[name=image]`).attr('src', ad.imageUrl);
        let dateInfo = ad.publishDate.split('/');
        $('#formDetailsAd').find(`span[name=datePublished]`).text(`${dateInfo[1]}.${dateInfo[0]}.${dateInfo[2]}`);

        ad.views++;
        $.ajax({
            method: 'PUT',
            headers: getKinveyUserAuthHeaders(),
            data: JSON.stringify(ad),
            contentType: 'application/json',
            url: kinveyBaseUrl + `appdata/${kinveyAppKey}/ads/${ad._id}`,
            error: handleAjaxError
        });
    }

    function deleteAd(id) {
        $.ajax({
            url: kinveyBaseUrl + `appdata/${kinveyAppKey}/ads/${id}`,
            method: 'DELETE',
            headers: getKinveyUserAuthHeaders(),
            success: () => {
                listAds();
                showInfo('Book deleted.')
            },
            error: handleAjaxError
        })
    }

    function fillEditAdDetails(ad){
        showView('viewEditAd');
        $('#formEditAd').trigger('reset');
        $('#formEditAd').find(`input[name=title]`).val(ad.title);
        $('#formEditAd').find(`textarea[name=description]`).val(ad.description);
        $('#formEditAd').find(`input[name=price]`).val(ad.price);
        $('#formEditAd').find(`input[name=id]`).val(Number(ad._id));
        $('#formEditAd').find(`input[name=views]`).val(ad.views);
        $('#formEditAd').find(`input[name=image]`).val(ad.imageUrl);
        let dateInfo = ad.publishDate.split('/');
        $('#formEditAd').find(`input[name=datePublished]`).val(`${dateInfo[2]}-${dateInfo[0]}-${dateInfo[1]}`);
    }

    function showCreateAdView(){
        showView('viewCreateAd');
        $('#formCreateAd').trigger('reset');
    }

    function showHomeView(){
        showView('viewHome');
    }

    function showLoginView(){
        showView('viewLogin');
        $('#formLogin').trigger('reset');
    }

    function showRegisterView(){
        showView('viewRegister');
        $('#formRegister').trigger('reset');
    }

    function showView(viewName) {
        $('main>section').hide();
        $(`#${viewName}`).show();
    }

    function showHideMenuLinks() {
        $("#linkHome").show();
        if (sessionStorage.getItem('authToken')) {
            // We have logged in user
            $("#linkLogin").hide();
            $("#linkRegister").hide();
            $("#linkListAds").show();
            $("#linkCreateAd").show();
            $("#linkLogout").show();
            $('#loggedInUser').show();
        } else {
            // No logged in user
            $("#linkLogin").show();
            $("#linkRegister").show();
            $("#linkListAds").hide();
            $("#linkCreateAd").hide();
            $("#linkLogout").hide();
            $('#loggedInUser').hide();
        }
    }

    function handleAjaxError(response) {
        let errorMsg = JSON.stringify(response);
        if (response.readyState === 0)
            errorMsg = "Cannot connect due to network error.";
        if (response.responseJSON &&
            response.responseJSON.description)
            errorMsg = response.responseJSON.description;
        showError(errorMsg);
    }

    function showInfo(message) {
        $('#infoBox').text(message).show();
        setTimeout(function() {
            $('#infoBox').fadeOut();
        }, 3000);
    }

    function showError(errorMsg) {
        $('#errorBox').text("Error: " + errorMsg).show();
    }

    function getKinveyUserAuthHeaders() {
        return {
            'Authorization': "Kinvey " + sessionStorage.getItem('authToken'),
        };
    }

    function saveUserInfoInSession(userInfo) {
        sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
        sessionStorage.setItem('userId', userInfo._id);
        sessionStorage.setItem('username', userInfo.username);
        $('#loggedInUser').text("Welcome, " + userInfo.username + "!");
    }
}