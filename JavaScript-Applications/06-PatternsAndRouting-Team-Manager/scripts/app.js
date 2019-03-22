$(() => {
    const app = Sammy('#main', function () {
        this.use('Handlebars', 'hbs');

        this.get('index.html', displayHome);
        this.get('#/home', displayHome);

        function displayHome(ctx) {
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs'
            })
                .then(function() {
                    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
                    ctx.username = sessionStorage.getItem('username');
                    this.partial('./templates/home/home.hbs')
                })
        }

        this.get('#/about', function(ctx) {
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs'
            })
                .then(function() {
                    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
                    ctx.username = sessionStorage.getItem('username');
                    this.partial('./templates/about/about.hbs')
                })
        });

        // LOGIN/LOGOUT
        this.get('#/login', function(ctx) {
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                loginForm: './templates/login/loginForm.hbs'
            })
                .then(function() {
                    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
                    ctx.username = sessionStorage.getItem('username');
                    this.partial('./templates/login/loginPage.hbs')
                })
        });

        this.post('#/login', function(ctx) {
            let username = ctx.params.username;
            let password = ctx.params.password;
            auth.login(username, password)
                .then(function(data) {
                    auth.saveSession(data);
                    notification.showInfo('Successfully logged in as ' + username);
                    displayHome(ctx)
                })
                .catch(notification.handleError)
        });

        this.get('#/logout', function(ctx) {
            auth.logout()
                .then(function() {
                    notification.showInfo('Successfully logged out.');
                    sessionStorage.clear();
                    displayHome(ctx);
                })
                .catch(notification.handleError);
        });

        // REGISTER
        this.get('#/register', function(ctx) {
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                registerForm: './templates/register/registerForm.hbs'
            })
                .then(function() {
                    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
                    ctx.username = sessionStorage.getItem('username');
                    this.partial('./templates/register/registerPage.hbs')
                })
        });

        this.post('#/register', function(ctx) {
            let username = ctx.params.username;
            let password = ctx.params.password;
            let repeatPassword = ctx.params.repeatPassword;
            if (password !== repeatPassword){
                notification.showError('Passwords must match');
            }
            else {
                auth.register(username, password)
                    .then(function(data) {
                        auth.saveSession(data);
                        notification.showInfo('Successfully registered as ' + username);
                        displayHome(ctx)
                    })
                    .catch(notification.handleError)
            }
        });

        // CATALOG
        this.get('#/catalog', displayCatalog);

        function displayCatalog(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
            ctx.username = sessionStorage.getItem('username');
            ctx.hasNoTeam = sessionStorage.getItem('teamId') === null || sessionStorage.getItem('teamId') === 'undefined';
            teamsService.loadTeams()
                .then(function(teamsData) {
                    ctx.teams = teamsData;
                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        team: './templates/catalog/team.hbs',
                    })
                        .then(function() {
                            this.partial('./templates/catalog/teamCatalog.hbs')
                        })
                })
                .catch(notification.handleError);
        }

        // CREATE TEAM
        this.get('#/create', function(ctx) {
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                createForm: './templates/create/createForm.hbs'
            })
                .then(function() {
                    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
                    ctx.username = sessionStorage.getItem('username');
                    this.partial('./templates/create/createPage.hbs')
                })
        });

        this.post('#/create', function(ctx) {
            let name = ctx.params.name;
            let comment = ctx.params.comment;
            teamsService.createTeam(name, comment)
                .then(function(newTeamData) {
                    teamsService.joinTeam(newTeamData._id)
                        .then(function (userInfo) {
                            auth.saveSession(userInfo)
                        })
                        .catch(notification.handleError);
                    notification.showInfo('You successfully joined team ' + name);
                    displayCatalog(ctx);
                })
                .catch(notification.handleError)
        });

        // TEAM DETAILS
        this.get('#/catalog/:id', function(ctx){
            let teamId = ctx.params.id.substr(1);
            teamsService.loadTeamDetails(teamId)
                .then(function(team) {
                   // ctx.members = teamData.members
                    ctx.isAuthor = team._acl.creator === sessionStorage.getItem('userId');
                    ctx.isOnTeam = team._id === sessionStorage.getItem('teamId');
                    ctx.name = team.name;
                    ctx.teamId = teamId;
                    ctx.comment = team.comment;
                    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
                    ctx.username = sessionStorage.getItem('username');
                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        member: './templates/catalog/teamMember.hbs',
                        teamControls: './templates/catalog/teamControls.hbs'
                    })
                        .then(function() {
                            this.partial('./templates/catalog/details.hbs')
                        })
                })
                .catch(notification.handleError);
        });

        // JOIN TEAM
        this.get('#/join/:id', function(ctx) {
            let teamId = ctx.params.id.substr(1);
            teamsService.joinTeam(teamId)
                .then(function(userInfo) {
                    auth.saveSession(userInfo);
                    notification.showInfo('You successfully joined the team.');
                    displayCatalog(ctx);
                })
                .catch(notification.handleError)
        });

        // LEAVE TEAM
        this.get('#/leave', function(ctx) {
            teamsService.leaveTeam()
                .then(function(userInfo) {
                    auth.saveSession(userInfo);
                    notification.showInfo('You left your team.');
                    displayCatalog(ctx);
                })
                .catch(notification.handleError)
        });

        // EDIT TEAM
        this.get('#/edit/:id', function(ctx) {
            let teamId = ctx.params.id.substr(1);
            teamsService.loadTeamDetails(teamId)
                .then(function(teamDetails) {
                    ctx.name = teamDetails.name;
                    ctx.teamId = teamId;
                    ctx.comment = teamDetails.comment;
                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        editForm: './templates/edit/editForm.hbs'
                    })
                        .then(function(){
                            this.partial('./templates/edit/editPage.hbs')
                        })
                }
                )
                .catch(notification.handleError);
        });

        this.post('#/edit/:id', function(ctx) {
            let teamId = ctx.params.id.substr(1);
            teamsService.edit(teamId, ctx.params.name, ctx.params.comment)
                .then(function(){
                    notification.showInfo('Successfully edited team ' + ctx.params.name);
                    displayCatalog(ctx);
                })
        })
    });
    app.run();
});