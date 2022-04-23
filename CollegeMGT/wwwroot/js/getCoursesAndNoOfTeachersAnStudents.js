var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { //We are using an Ajax call so we have to pass in the URL
            "url": "/Prequisite/GetCoursesAndNoOfTeachersAnStudents"
        }, //Then we have to pass in the columns
        "columns": [
            { "data": "courseName", "width": "35%" },
            { "data": "teacherCount", "width": "20%" },
            { "data": "studentCount", "width": "20%" },
            { "data": "avgGrade", "width": "25%" }
        ]
    });
}

