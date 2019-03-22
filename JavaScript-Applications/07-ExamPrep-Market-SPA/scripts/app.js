$(() => {
    showHideMenuLinks();
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
    $('#linkMenuShop,#linkUserHomeShop').click(() => {
        showView('viewShop');
        showProductsInStore();
    });
    $('#linkMenuCart,#linkUserHomeCart').click(() => {
        showView('viewCart');
        showProductsInCart();
    });

    $('#linkMenuLogout').click(logoutUser);

    function showView(viewName) {
        $('main>section').hide();
        $(`#${viewName}`).show();
    }

    // Form Events
    $("#formLogin").submit(loginUser);
    $('#formRegister').submit(registerUser);

    function loginUser() {
        let username = $('#loginUsername').val();
        let password = $('#loginPasswd').val();

        auth.login(username, password)
            .then((userInfo) => {
                $('#formLogin').trigger('reset');
                auth.saveSession(userInfo);
                notification.showInfo('Successfully logged in.');
                showHideMenuLinks();
            })
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

    function logoutUser() {
        auth.logout()
            .then(() => {
                sessionStorage.clear();
                showHideMenuLinks();
                notification.showInfo('Logout successful.')
            })
            .catch(notification.handleError)
    }

    function showProductsInStore() {
        requester.get('appdata', 'products')
            .then(showProductsSuccess)
            .catch(notification.handleError);

        function showProductsSuccess(products){
            let tableData = $('#shopProducts tbody');
            tableData.empty();
            for (let product of products) {
                tableData.append($('<tr>')
                    .append($('<td>').text(product.name))
                    .append($('<td>').text(product.description))
                    .append($('<td>').text(Number(product.price).toFixed(2)))
                    .append($('<td>').append($('<button>').text('Purchase').click(() => addProductToCart(product)))))
            }

            function addProductToCart(productInfo) {
                requester.get('user', sessionStorage.getItem('userId'))
                    .then((userInfo) => {
                        if (userInfo.cart === undefined) {
                            userInfo.cart = {}
                        }
                        if (userInfo.cart[productInfo._id] === undefined) {
                            userInfo.cart[productInfo._id] = {
                                quantity: 1,
                                product: {
                                    name: productInfo.name,
                                    description: productInfo.description,
                                    price: productInfo.price
                                }
                            };

                        } else {
                            let currentQuantity = Number(userInfo.cart[productInfo._id].quantity);
                            userInfo.cart[productInfo._id].quantity = currentQuantity + 1;
                        }
                        requester.update('user', sessionStorage.getItem('userId'), 'kinvey', userInfo)
                            .then(() => {
                            notification.showInfo('Product purchased.');
                            })
                            .catch(notification.handleError);
                    })
                    .catch(notification.handleError)

            }
        }
    }

    function showProductsInCart(){
        let tableData = $('#cartProducts tbody');
        tableData.empty();
        requester.get('user', sessionStorage.getItem('userId'))
            .then((userInfo) => {
                for (let productId in userInfo.cart){
                    tableData.append($('<tr>')
                        .append($('<td>').text(userInfo.cart[productId].product.name))
                        .append($('<td>').text(userInfo.cart[productId].product.description))
                        .append($('<td>').text(userInfo.cart[productId].quantity))
                        .append($('<td>').text((userInfo.cart[productId].quantity * userInfo.cart[productId].product.price).toFixed(2)))
                        .append($('<td>').append($('<button>').text('Discard').click(() => discardItem(productId)))))
                }
            })
            .catch(notification.handleError);

        function discardItem(productId) {
            requester.get('user', sessionStorage.getItem('userId'))
                .then((userInfo) => {
                    delete userInfo.cart[productId];
                    requester.update('user', sessionStorage.getItem('userId'), 'kinvey', userInfo)
                        .then(() => {
                            notification.showInfo('Product discarded.');
                            showProductsInCart();
                        })
                        .catch(notification.handleError);
                })
                .catch(notification.handleError);
        }
    }
});