function attachEvents(){
    const baseUrl = `https://baas.kinvey.com/appdata/kid_SkoZMbpHW`;
    const kinveyUsername = 'peshata';
    const kinveyPassword = 'softuni';
    const authHeader = { "Authorization": `Basic ${btoa(kinveyUsername + ':' + kinveyPassword)}` };
    $('#btnLoadPosts').click(loadAllPosts);
    $('#btnViewPost').click(loadPostDetails);

    function loadAllPosts(){
        $('#posts').empty();
        $.ajax({
            method: "GET",
            url: baseUrl + '/posts',
            headers: authHeader
        }).then(populateDropdown)
            .catch(displayError);

        function populateDropdown(data) {
            for (let post of data) {
                $('#posts')
                    .append($('<option>')
                        .text(post.title)
                        .val(post._id))
            }
        }
    }

    function loadPostDetails(){
        $('#post-body').empty();
        $('#post-title').text('Post Details');
        $('#post-comments').empty();

        let selectedPostId = $('#posts').val();
        let commentsForPostRequestUrl = `${baseUrl}/comments/?query={"post_id":"${selectedPostId}"}`;

        let postDetailsRequest = $.ajax({
            method: "GET",
            url: baseUrl + '/posts/' + selectedPostId,
            headers: authHeader
        });

        let postCommentsRequest = $.ajax({
            method: "GET",
            url: commentsForPostRequestUrl,
            headers: authHeader
        });

        Promise.all([postDetailsRequest, postCommentsRequest])
            .then(displayPostDetails)
            .catch(displayError);

        function displayPostDetails([post, comments]){
            $('#post-body').text(post.body);
            $('#post-title').text(post.title);

            for (let comment of comments) {
                $('#post-comments').append($('<li>')
                    .text(comment.text))
            }
        }
    }

    function displayError(error){
        console.dir(error);
        let errorDiv = $('<div>')
            .text(`Error: ${error.status} (${error.statusText})`)
            .css('color', 'red')
            .css('font-weight', 'bold');
        $(document.body).prepend(errorDiv);
        setTimeout(function(){
            errorDiv.fadeOut(function(){
                errorDiv.remove();
            })
        }, 2000)
    }
}