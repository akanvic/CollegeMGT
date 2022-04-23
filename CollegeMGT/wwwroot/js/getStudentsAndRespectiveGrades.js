var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { //We are using an Ajax call so we have to pass in the URL
            "url": "/Prequisite/GetStudentsAndRespectiveGrades"
        }, //Then we have to pass in the columns
        "columns": [
            { "data": "studentName", "width": "40%" },
            { "data": "subjectName", "width": "40%" },
            { "data": "gradeValue", "width": "20%" }
        ]
    });
}

