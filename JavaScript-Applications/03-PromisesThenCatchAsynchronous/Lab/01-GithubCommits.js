function loadCommits() {
    let commits = $('#commits');
    commits.empty();
    let username = $('#username').val();
    let repo = $('#repo').val();
    let baseUrl = `https://api.github.com/repos/${username}/${repo}/commits`;
    $.get(baseUrl)
        .then(createList)
        .catch((error) => commits
            .append(`<li>Error: ${error.status} (${error.statusText})</li>`));

    function createList(data){
        for (let commit of data) {
            let commitObj = commit.commit;
            commits.append($('<li>')
                .text(`${commitObj.author.name}: ${commitObj.message}`))
        }
    }
}