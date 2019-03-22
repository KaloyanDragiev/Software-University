handlers.home = function(ctx) {
    ctx.username = sessionStorage.getItem('username');
    let partialsToLoad = {
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        notification: './templates/common/notification.hbs',
    };

    if (auth.isAuthed()){
        partialsToLoad.page = './templates/userHome.hbs';
    } else {
        partialsToLoad.page = './templates/appHome.hbs'
    }

    this.loadPartials(partialsToLoad)
        .then(function() {
            this.partial('./templates/common/main.hbs');
        })
};