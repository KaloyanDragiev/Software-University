$(() => {
    showHideMenuLinks();
    $("form").submit(function(e) { e.preventDefault() });

    function showHideMenuLinks() {
        if (sessionStorage.getItem('authToken') === null){
            showView('viewWelcome');
            $('#menu').hide();
            $('#profile').hide();
        }
        else {
            $('#profile>span').text(sessionStorage.getItem('username'));
            showCatalogPosts();
            $('#menu').show();
            $('#profile').show();
        }
    }

    // Navigation links
    $('#catalogLink').click(() => { showCatalogPosts(); });
    $('#submitLink').click(() => { showView('viewSubmit'); });
    $('#postsLink').click(() => { showMyPosts();});
    $('#logoutBtn').click(logoutUser);

    function showView(viewName) {
        $('.content>section').hide();
        $(`#${viewName}`).show();
    }

    // Form Events
    $("#loginForm").submit(loginUser);
    $('#registerForm').submit(registerUser);
    $('#submitForm').submit(submitNewPost);
    $('#editPostForm').submit(editSelectedPost);
    $('#commentForm').submit(submitComment);

    function registerUser() {
        let usernamePattern = /[A-Za-z]{3,}/g;
        let passwordPattern = /[A-Za-z0-9]{6,}/g;

        let username = $('#registerForm input[name=username]').val();
        let password = $('#registerForm input[name=password]').val();
        let repeatPassword = $('#registerForm input[name=repeatPass]').val();

        if (!usernamePattern.test(username)) {
            notification.showError('Username should be at least 3 characters long with only English letters!');
            return;
        }

        if (!passwordPattern.test(password)){
            notification.showError('Password should be at least 6 symbols long and contain letters or digits!');
            return;
        }

        if (password !== repeatPassword){
            notification.showError('Password does not match repeat password!');
            return;
        }

        auth.register(username, password)
            .then((userInfo) => {
                auth.saveSession(userInfo);
                $('#registerForm').trigger('reset');
                $('#loginForm').trigger('reset');
                notification.showInfo('User registration successful.');
                showHideMenuLinks();
                showCatalogPosts();
            })
            .catch(notification.handleError)
    }

    function loginUser() {
        let usernamePattern = /[A-Za-z]{3,}/g;
        let passwordPattern = /[A-Za-z0-9]{6,}/g;

        let username = $('#loginForm input[name=username]').val();
        let password = $('#loginForm input[name=password]').val();

        if (!usernamePattern.test(username)) {
            notification.showError('Username should be at least 3 characters long with only English letters!');
            return;
        }

        if (!passwordPattern.test(password)){
            notification.showError('Password should be at least 6 symbols long and contain letters or digits!');
            return;
        }

        auth.login(username, password)
            .then((userInfo) => {
            $('#loginForm').trigger('reset');
            $('#registerForm').trigger('reset');
            auth.saveSession(userInfo);
            notification.showInfo('Login successful.');
            showHideMenuLinks();
            showCatalogPosts();
            })
            .catch(notification.handleError)
    }

    function logoutUser() {
        auth.logout()
            .then(() => {
                notification.showInfo('Logout successful.');
                sessionStorage.clear();
                showHideMenuLinks();
                showView('viewWelcome');
            })
            .catch(notification.handleError)
    }

    function showCatalogPosts() {
        showView('viewCatalog');

        requester.get('appdata', 'posts?query={}&sort={"_kmd.ect": -1}')
            .then((posts) => {
            fillPostsSection(posts, '#viewCatalog>div.posts')
            })
            .catch(notification.handleError);
    }

    function showMyPosts() {
        showView('viewMyPosts');

        requester.get('appdata', `posts?query={"author":"${sessionStorage.getItem('username')}"}&sort={"_kmd.ect": -1}`)
            .then((myPosts) => {
            fillPostsSection(myPosts, '#viewMyPosts>div.posts')
            })
            .catch(notification.handleError)
    }

    function fillPostsSection(posts, selector) {
        let postSection = $(selector);
        postSection.empty();

        if (posts.length === 0){
            postSection.append($('<h1>').text('No posts in database.'));
            return;
        }

        let rank = 1;
        for (let post of posts) {
            postSection.append(getSinglePostElement(post, rank));
            rank++;
        }
    }

    function getSinglePostElement(post, rank) {
        let controlsLinks = $('<ul>');

        if (rank > 0) {
            controlsLinks.append($('<li>').addClass('action')
                .append($('<a>').attr('href', '#').addClass('commentsLink').text('comments').click(() => showComments(post._id))));
        }

        if (sessionStorage.getItem('username') === post.author) {
            controlsLinks
                .append($('<li>').addClass('action')
                    .append($('<a>').attr('href', '#').addClass('editLink').text('edit').click(() => editPost(post._id))))
                .append($('<li>').addClass('action')
                    .append($('<a>').attr('href', '#').addClass('deleteLink').text('delete').click(() => deletePost(post._id))));
        }

        let article = $('<article>').addClass('post');
        if (Number(rank) !== 0) {
            article.append($('<div>').addClass('col rank').append($('<span>').text(rank)))
        }

        let detailsDiv = $('<div>').addClass('details');

        if (Number(rank) === 0) {
            if (post.description) {
                detailsDiv.append($('<p>').text(post.description));
            } else {
                detailsDiv.append($('<p>').text('No description'));
            }
        }

        detailsDiv
            .append($('<div>').addClass('info').text(`submitted ${calcTime(post._kmd.ect)} by ${post.author}`))
            .append($('<div>').addClass('controls').append(controlsLinks));

        return article
            .append($('<div>').addClass('col thumbnail').append($('<a>').attr('href', post.url)
                .append($('<img>').attr('src', post.imageUrl))))
            .append($('<div>').addClass('post-content')
                .append($('<div>').addClass('title')
                    .append($('<a>').attr('href', post.url).text(post.title)))
                .append(detailsDiv));

        function editPost(postId) {
            showView('viewEdit');
            $('#editPostForm').trigger('reset');
            requester.get('appdata', `posts/${postId}`)
                .then(populateEditForm)
                .catch(notification.handleError);

            function populateEditForm(postInfo) {
                $('#editPostForm input[name=url]').val(postInfo.url);
                $('#editPostForm input[name=title]').val(postInfo.title);
                $('#editPostForm input[name=image]').val(postInfo.imageUrl);
                $('#editPostForm textarea[name=description]').val(postInfo.description);
                $('#editPostForm input[name=postId]').val(postInfo._id);
            }
        }

        function deletePost(postId) {
            requester.remove('appdata', `posts/${postId}`)
                .then(() => {
                    notification.showInfo('Post deleted.');
                    showCatalogPosts();
                })
                .catch(notification.handleError)
        }
    }

    function showComments(postId) {
        showView('viewComments');
        $('#viewComments').empty();

        let getPostRequest =  requester.get('appdata', `posts/${postId}`);
        let commentsRequest = requester.get('appdata', `comments?query={"postId":"${postId}"}&sort={"_kmd.ect": -1}`);

        Promise.all([getPostRequest, commentsRequest])
            .then(([postDetails, allComments]) => fillPostComments(postDetails, allComments))
            .catch(notification.handleError)
    }

    function calcTime(dateIsoFormat) {
        let diff = new Date - (new Date(dateIsoFormat));
        diff = Math.floor(diff / 60000);
        if (diff < 1) return 'less than a minute';
        if (diff < 60) return diff + ' minute' + pluralize(diff);
        diff = Math.floor(diff / 60);
        if (diff < 24) return diff + ' hour' + pluralize(diff);
        diff = Math.floor(diff / 24);
        if (diff < 30) return diff + ' day' + pluralize(diff);
        diff = Math.floor(diff / 30);
        if (diff < 12) return diff + ' month' + pluralize(diff);
        diff = Math.floor(diff / 12);
        return diff + ' year' + pluralize(diff);
        function pluralize(value) {
            if (value !== 1) return 's';
            else return '';
        }
    }

    function fillPostComments(postDetails, allComments) {
        let postDetailsDiv = $('#viewComments');
        postDetailsDiv.append(getSinglePostElement(postDetails, 0));
        postDetailsDiv.append(`<div class="post post-content">
                <form id="commentForm">
                    <label>Comment</label>
                    <textarea name="content" type="text"></textarea>
                    <input type="hidden" name="postId" value="${postDetails._id}">
                    <input type="submit" value="Add Comment" id="btnPostComment">
                </form>
            </div>`);

        if (allComments.length === 0) {
            postDetailsDiv.append($('<h1>').text('No comments yet.'))
        }

        for (let comment of allComments) {
            let commentArticle = $('<article>').addClass('post post-content');
            commentArticle.append($('<p>').text(comment.content));
            let divClassInfo = $('<div>').addClass('info').text(`submitted ${calcTime(comment._kmd.ect)} by ${comment.author} | `);
            if (comment.author === sessionStorage.getItem('username')){
                divClassInfo.append($('<a>').attr('href', '#').addClass('deleteLink').text('delete').click(() => deleteComment(comment._id, comment.postId)))
            }
            commentArticle.append(divClassInfo);
            postDetailsDiv.append(commentArticle);
        }
        $("form").submit(function(e) { e.preventDefault() });
        $('#commentForm').submit(submitComment);
    }

    function submitComment() {
        let commentContent = $('#commentForm textarea[name=content]').val();
        let postId = $('#commentForm input[name=postId]').val();

        let newCommentObject = {
            content: commentContent,
            postId: postId,
            author: sessionStorage.getItem('username')
        };

        requester.post('appdata', 'comments', 'kinvey', newCommentObject)
            .then(() => {
            notification.showInfo('Comment created.');
            showComments(postId);
            $('#commentForm').trigger('reset');
            })
    }

    function deleteComment(commentId, postId) {
        requester.remove('appdata', `comments/${commentId}`)
            .then(() => {
                notification.showInfo('Comment deleted.');
                showComments(postId);
            })
            .catch(notification.handleError)
    }

    function submitNewPost() {
        let url = $('#submitForm input[name=url]').val();
        let title = $('#submitForm input[name=title]').val();
        let imageUrl = $('#submitForm input[name=image]').val();
        let description = $('#submitForm textarea[name=comment]').val();

        if (!validatePostData(url, title)) {
            return;
        }

        let newPost = {
            url, title, imageUrl, description,
            author: sessionStorage.getItem('username')
        };

        requester.post('appdata', 'posts', 'kinvey', newPost)
            .then(() => {
                $('#submitForm').trigger('reset');
                notification.showInfo('Post created.');
                showCatalogPosts();
            })
            .catch(notification.handleError)
    }

    function editSelectedPost() {
        let url = $('#editPostForm input[name=url]').val();
        let title = $('#editPostForm input[name=title]').val();
        let imageUrl = $('#editPostForm input[name=image]').val();
        let description = $('#editPostForm textarea[name=description]').val();
        let postId = $('#editPostForm input[name=postId]').val();

        validatePostData(url, title);

        let editedPost = {
            url, title, imageUrl, description,
            author: sessionStorage.getItem('username')
        };

        requester.update('appdata', `posts/${postId}`, '', editedPost)
            .then((postInfo) => {
                notification.showInfo(`Post ${postInfo.title} updated.`);
                showCatalogPosts();
            })
    }

    function validatePostData(url, title) {
        if (url === ''){
            notification.showError('Link Url field is not optional. Please provide one.');
            return false;
        }

        if (!url.startsWith('http')){
            notification.showError('Valid URLs should always start with "http"');
            return false;
        }

        if (title === '') {
            notification.showError('Link Title field is not optional. Please provide one.');
            return false;
        }
        return true;
    }
});