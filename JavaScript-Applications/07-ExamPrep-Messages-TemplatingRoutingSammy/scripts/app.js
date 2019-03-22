const handlers = { };

$(() => {
    const app = Sammy('#main', function() {
        this.use('Handlebars', 'hbs');

        this.get('index.html', handlers.home);

        this.get('#/login', handlers.login);
        this.post('#/login', handlers.loginAction);

        this.get('#/register', handlers.register);
        this.post('#/register', handlers.registerAction);

        this.get('#/myMessages', handlers.myMessages);

        this.get('#/archiveMessages', handlers.archiveMessages);

        this.get('#/sendMessage', handlers.sendMessage);
        this.post('#/sendMessage', handlers.sendMessageAction);

        this.get('#/logout', handlers.logoutUser);
    });

    app.run();
});