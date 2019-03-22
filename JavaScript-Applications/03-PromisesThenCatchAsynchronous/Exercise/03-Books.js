function attachEvents(){
    const baseUrl = `https://baas.kinvey.com/appdata/kid_SyE_umw8W/books`;
    const kinveyUsername = 'peshata';
    const kinveyPassword = 'softuni';
    const authHeader = { "Authorization": `Basic ${btoa(kinveyUsername + ':' + kinveyPassword)}` };

    $('#addBook').click(addNewBook);
    $('#editBook').click(editBook);
    loadAllBooks();

    function loadAllBooks(){
        $('#books').empty();
        $('#editBookForm').hide();
        $('#books')
            .append($('<tr>')
                .append($('<td>').text(`ISBN`))
                .append($('<td>').text('Title'))
                .append($('<td>').text('Author'))
                .append($('<td>').text('Action')));
        $.get({
            url: baseUrl,
            headers: authHeader
        })
            .then(populateBooksTable);
    }

    function populateBooksTable(data){
        for (let book of data){
            $('#books')
                .append($('<tr>')
                    .append($('<td>').text(book.isbn))
                    .append($('<td>').text(book.title))
                    .append($('<td>').text(book.author))
                    .append($('<td>')
                        .append($('<button>').addClass('btn btn-warning').text('Edit').click(() => editBookInfo(book._id)))
                        .append($('<button>').addClass('btn btn-danger').text('Delete').click(() => deleteBook(book._id)))))
        }
    }

    function addNewBook() {
        let isbn = $('#addBookForm .isbn').val();
        let title = $('#addBookForm .title').val();
        let author = $('#addBookForm .author').val();

        let newBook = { isbn, title, author };

        $.post({
            url: baseUrl,
            contentType: 'application/json',
            data: JSON.stringify(newBook),
            headers: authHeader
        })
            .then(loadAllBooks)
    }

    function editBookInfo(bookId){
        event.preventDefault();
        $.get({
            url : baseUrl + '/' + bookId,
            headers: authHeader
        })
            .then(fillEditForm);

        function fillEditForm(data) {
            $('#editBookForm .isbn').val(data.isbn);
            $('#editBookForm .title').val(data.title);
            $('#editBookForm .author').val(data.author);
            $('#editBookForm #bookId').val(bookId);
            $('#editBookForm').show();
        }
    }

    function editBook() {
        let bookId = $('#editBookForm #bookId').val();
        let updatedBook = {
            isbn: $('#editBookForm .isbn').val(),
            title: $('#editBookForm .title').val(),
            author: $('#editBookForm .author').val(),
        };

        $.ajax({
            url: baseUrl +'/' + bookId,
            method: "PUT",
            contentType: 'application/json',
            data: JSON.stringify(updatedBook),
            headers: authHeader
        })
            .then(loadAllBooks);
    }

    function deleteBook(bookId) {
        $.ajax({
            method: "DELETE",
            url: baseUrl + `/${bookId}`,
            headers: authHeader
        })
            .then(() => {
                $(this).parent().parent().remove();
                loadAllBooks();
            })
    }
}
