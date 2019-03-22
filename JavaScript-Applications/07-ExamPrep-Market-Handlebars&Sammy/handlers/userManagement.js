handlers.login = function(ctx) {
    ctx.username = sessionStorage.getItem('username');
    ctx.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        notifications: './templates/common/notifications.hbs',
        page: './templates/login.hbs'
    })
        .then(function() {
            this.partial('./templates/common/main.hbs');
        })
};

handlers.loginAction = function(ctx) {
    auth.login(ctx.params.username, ctx.params.password)
        .then((userInfo) => {
            auth.saveSession(userInfo);
            notification.showInfo('Login successful.');
            ctx.redirect('#');
        })
        .catch(notification.showError)
};

handlers.register = function(ctx) {
    ctx.username = sessionStorage.getItem('username');
    ctx.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        notifications: './templates/common/notifications.hbs',
        page: './templates/register.hbs'
    })
        .then(function() {
            this.partial('./templates/common/main.hbs');
        })
};

handlers.registerAction = function(ctx) {
    auth.register(ctx.params.username, ctx.params.password, ctx.params.name)
        .then((userInfo) => {
            auth.saveSession(userInfo);
            notification.showInfo('Registration successful.');
            ctx.redirect('#');
        })
        .catch(notification.showError)
};

handlers.logout = function(ctx) {
    auth.logout()
        .then(() => {
        sessionStorage.clear();
        notification.showInfo('Logout successful.');
        ctx.redirect('#');
        })
        .catch(notification.handleError)
};