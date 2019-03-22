function attachEvents(){
    const baseUrl = `https://baas.kinvey.com/appdata/kid_BJXTsSi-e`;
    const kinveyUsername = 'guest';
    const kinveyPassword = 'guest';
    const authHeader = { "Authorization": `Basic ${btoa(kinveyUsername + ':' + kinveyPassword)}` };

    $.ajax({
        method: "GET",
        url: baseUrl + '/students',
        headers: authHeader
    }).then(fillStudentsTable);

    function fillStudentsTable(data){
        let sortedData = data.sort((a, b) => a.ID - b.ID);
        for (let student of sortedData){
            $('#results').append($('<tr>')
                .append($('<td>').text(student.ID))
                .append($('<td>').text(student.FirstName))
                .append($('<td>').text(student.LastName))
                .append($('<td>').text(student.FacultyNumber))
                .append($('<td>').text(student.Grade)));
        }
    }

    $('#btnSubmit').click(createStudent);

    function createStudent(){
        let id = $('#ID').val();
        let firstName = $('#firstName').val();
        let lastName = $('#lastName').val();
        let facultyNumber = $('#facultyNumber').val();
        let grade = $('#grade').val();
    }
}