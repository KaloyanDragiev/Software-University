$(() => {
    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_Skuz1gyv-";
    const kinveyAppSecret = "53da557b31874c79b1f0b904d45d3955";
    const kinveyAppAuthHeaders = { 'Authorization': "Basic " + btoa(kinveyAppKey + ":" + kinveyAppSecret) };

    sessionStorage.clear(); // Clear user auth data
    showHideMenuLinks();
    showView('viewHome');
    // Bind the navigation menu links
    $("#linkHome").click(showHomeView);
    // Bind the form submit actions
    $("#formLogin").submit(loginUser);
    $('#formRegister').submit(registerUser);
    $('#formCreateBook').submit(createBook);
    $('#formEditBook').submit(finalizeEditingBook);

    $("form").submit(function(e) { e.preventDefault() });
    $("#infoBox, #errorBox").click(function() {
        $(this).fadeOut();
    });

    $(document).on({
        ajaxStart: function() { $("#loadingBox").show() },
        ajaxStop: function() { $("#loadingBox").hide() }
    });

    $("#linkHome").click(showHomeView);
    $("#linkLogin").click(showLoginView);
    $("#linkRegister").click(showRegisterView);
    $("#linkListBooks").click(listBooks);
    $("#linkCreateBook").click(showCreateBookView);
    $("#linkLogout").click(logoutUser);

    function registerUser() {
        let userData = {
            username: $('#formRegister input[name=username]').val(),
            password: $('#formRegister input[name=passwd]').val()
        };
        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/",
            headers: kinveyAppAuthHeaders,
            data: userData,
            success: registerSuccess,
            error: handleAjaxError
        });
        function registerSuccess(userInfo) {
            saveAuthInSession(userInfo);
            showHideMenuLinks();
            listBooks();
            showInfo('User registration successful.');
        }
    }

    function loginUser() {
        let userData = {
            username: $('#formLogin input[name=username]').val(),
            password: $('#formLogin input[name=passwd]').val()
        };
        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/login",
            headers: kinveyAppAuthHeaders,
            contentType: 'application/json',
            data: JSON.stringify(userData),
            success: loginSuccess,
            error: handleAjaxError
        });
        function loginSuccess(userInfo) {
            saveAuthInSession(userInfo);
            showHideMenuLinks();
            listBooks();
            showInfo('Login successful.');
        }
    }

    function saveAuthInSession(userInfo) {
        sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
        sessionStorage.setItem('userId', userInfo._id);
        $('#loggedInUser').text("Welcome, " + userInfo.username + "!");
    }

    function showRegisterView() {
        $('#formRegister').trigger('reset');
        showView('viewRegister');
    }

    function listBooks(){
        showView('viewBooks');
        let table = $('#books>table>tbody');
        table.empty();

        $.get({
            url : kinveyBaseUrl + `appdata/${kinveyAppKey}/books`,
            headers: getKinveyUserAuthHeaders(),
            error: handleAjaxError,
            success: fillBooksTable
        });

        function fillBooksTable(data) {
            for (let book of data) {
                let row = $('<tr>');
                row
                    .append($('<td>').text(book.title))
                    .append($('<td>').text(book.author))
                    .append($('<td>').text(book.description));
                if (sessionStorage.getItem('userId') === book._acl.creator)
                    row.append($('<td>').append($('<button>').html('&#10006;').click(() => deleteBook(book._id)))
                        .append(' ')
                        .append($('<button>').html('&#9998;').click(() => editBook(book._id, book.title, book.author, book.description))));
                else {
                    row.append($('<td>'))
                }
                table.append(row);
            }
        }
    }

    function createBook() {
        let title = $('#formCreateBook input[name=title]').val();
        let author = $('#formCreateBook input[name=author]').val();
        let description = $('#formCreateBook textarea[name=descr]').val();

        if (title !== '' && author !== '' && description !== ''){
            $.post({
                url: `${kinveyBaseUrl}appdata/${kinveyAppKey}/books`,
                headers: getKinveyUserAuthHeaders(),
                contentType: 'application/json',
                data: JSON.stringify({ title, author, description} ),
                error: handleAjaxError,
                success: listBooks
            })
        }
        else {
            showError('Please fill all the required fields')
        }
    }

    function deleteBook(bookId) {
        $.ajax({
            url: `${kinveyBaseUrl}appdata/${kinveyAppKey}/books/${bookId}`,
            method: 'DELETE',
            headers: getKinveyUserAuthHeaders(),
            error: handleAjaxError,
            success: () => {
                listBooks();
                showInfo('Book deleted.')
            }
        })
    }

    function editBook(bookId, title, author, description) {
        showView('viewEditBook');
        $('#formEditBook input[name=title]').val(title);
        $('#formEditBook input[name=author]').val(author);
        $('#formEditBook textarea[name=descr]').val(description);
        $('#formEditBook#editBookId').val(bookId);
    }

    function finalizeEditingBook() {
        let editedBook = {
            title:  $('#formEditBook input[name=title]').val(),
            author:  $('#formEditBook input[name=author]').val(),
            description:  $('#formEditBook textarea[name=descr]').val(),
        };

        $.ajax({
            url: `${kinveyBaseUrl}appdata/${kinveyAppKey}/books/${$('#formEditBook#editBookId').val()}`,
            method: 'PUT',
            headers: getKinveyUserAuthHeaders(),
            error: handleAjaxError,
            success: () => {
                listBooks();
                showInfo('Book edited.');
            },
            contentType: 'application/json',
            data: JSON.stringify(editedBook),
        })
    }

    function showHideMenuLinks() {
        $("#linkHome").show();
        if (sessionStorage.getItem('authToken')) {
            // We have logged in user
            $("#linkLogin").hide();
            $("#linkRegister").hide();
            $("#linkListBooks").show();
            $("#linkCreateBook").show();
            $("#linkLogout").show();
        } else {
            // No logged in user
            $("#linkLogin").show();
            $("#linkRegister").show();
            $("#linkListBooks").hide();
            $("#linkCreateBook").hide();
            $("#linkLogout").hide();
        }
    }

    function showHomeView() {
        showView('viewHome');
    }

    function showLoginView() {
        showView('viewLogin');
        $('#formLogin').trigger('reset');
    }

    function showCreateBookView() {
        $('#formCreateBook').trigger('reset');
        showView('viewCreateBook');
    }

    function showView(viewName) {
        // Hide all views and show the selected view only
        $('main > section').hide();
        $('#' + viewName).show();
    }

    function logoutUser() {
        let request = {
            url : kinveyBaseUrl + `user/${kinveyAppKey}/_logout`,
            headers : getKinveyUserAuthHeaders(),
            error: handleAjaxError,
            success: successUserLogout
        };

        function successUserLogout(){
            sessionStorage.clear();
            $('#loggedInUser').text("");
            showHideMenuLinks();
            showView('viewHome');
            showInfo('Logout successful.');
        }
        $.post(request)
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
});