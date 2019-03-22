let handlers = {};
$(() => {
    const app = Sammy('#main', function() {
        this.use('Handlebars', 'hbs');

        this.get('index.html', handlers.home);

        this.get('#/login', handlers.login);
        this.post('#/login', handlers.loginAction);

        this.get('#/register', handlers.register);
        this.post('#/register', handlers.registerAction);

        this.get('#/logout', handlers.logout);

        this.get('#/shop', handlers.shop);

        this.get('#/cart', handlers.cart);
    });
    app.run();
});