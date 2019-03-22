handlers.shop = function(ctx) {
    requester.get('appdata', 'products')
        .then(showProductsSuccess)
        .catch(notification.handleError);

    function showProductsSuccess(products) {
        for (let product of products) {
            product.price = product.price.toFixed(2);
        }
        ctx.products = products;
        ctx.username = sessionStorage.getItem('username');
        ctx.loadPartials({
            header: './templates/common/header.hbs',
            footer: './templates/common/footer.hbs',
            notifications: './templates/common/notifications.hbs',
            page: './templates/shop.hbs'
        })
            .then(function () {
                this.partial('./templates/common/main.hbs')
                    .then(() => {
                        $('button').click(addProductToCart);
                    });
            });

        function addProductToCart(e) {
            let productId = $(e.target).attr('id');
            let productRequest = requester.get('appdata', 'products/' + productId);
            let userRequest = requester.get('user', sessionStorage.getItem('userId'));

            Promise.all([productRequest, userRequest])
                .then(([productInfo, userInfo]) => {
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
                .catch(notification.handleError);
        }
    }
};

handlers.cart = function(ctx) {
    requester.get('user', sessionStorage.getItem('userId'))
        .then(showCartSuccess)
        .catch(notification.handleError);

    function showCartSuccess(userInfo) {
        let cartProducts = [];
        for (let productId in userInfo.cart){
            cartProducts.push({
                name: userInfo.cart[productId].product.name,
                description: userInfo.cart[productId].product.description,
                quantity: userInfo.cart[productId].quantity,
                totalPrice: (userInfo.cart[productId].quantity * userInfo.cart[productId].product.price).toFixed(2),
                _id: productId
            })
        }
        ctx.cartProducts = cartProducts;
        ctx.username = sessionStorage.getItem('username');
        ctx.loadPartials({
            header: './templates/common/header.hbs',
            footer: './templates/common/footer.hbs',
            notifications: './templates/common/notifications.hbs',
            page: './templates/cart.hbs'
        })
            .then(function () {
                this.partial('./templates/common/main.hbs')
                    .then(() => {
                        $('button').click(discardItem);
                    });
            })
    }

    function discardItem(e) {
        let productId = $(e.target).attr('id');
        requester.get('user', sessionStorage.getItem('userId'))
            .then((userInfo) => {
                delete userInfo.cart[productId];
                requester.update('user', sessionStorage.getItem('userId'), 'kinvey', userInfo)
                    .then(() => {
                        notification.showInfo('Product discarded.');
                        ctx.redirect('#')
                    })
                    .catch(notification.handleError);
            })
            .catch(notification.handleError);
    }
};