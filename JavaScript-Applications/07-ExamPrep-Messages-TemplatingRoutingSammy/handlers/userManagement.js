handlers.login = function() {
    this.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        notification: './templates/common/notification.hbs',
        page: './templates/login.hbs'
    })
        .then(function() {
            this.partial('./templates/common/main.hbs');
        })
};

handlers.loginAction = function(ctx) {
    auth.login(ctx.params.username, ctx.params.password)
        .then(function(userInfo) {
            auth.saveSession(userInfo);
            notification.showInfo('Successfully logged in.');
            ctx.redirect('#')
        })
};

handlers.register = function() {
    this.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        notification: './templates/common/notification.hbs',
        page: './templates/register.hbs'
    })
        .then(function() {
            this.partial('./templates/common/main.hbs');
        })
};

handlers.registerAction = function(ctx) {
    auth.register(ctx.params.username, ctx.params.password, ctx.params.name)
        .then(function(userInfo) {
            auth.saveSession(userInfo);
            notification.showInfo('Successfully registered.');
            ctx.redirect('#')
        })
};

handlers.logoutUser = function(ctx) {
    auth.logout()
        .then(function() {
            notification.showInfo('Logout successful.');
            sessionStorage.clear();
            ctx.redirect('#')
        });
};