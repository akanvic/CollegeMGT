var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { //We are using an Ajax call so we have to pass in the URL
            "url": "/Prequisite/GetSubjectsAndTeacherInformation"
        }, //Then we have to pass in the columns
        "columns": [
            { "data": "subjectName", "width": "20%" },
            { "data": "teacherName", "width": "20%" },
            { "data": "teacherBirthDate", "width": "20%" },
            { "data": "teacherSalary", "width": "10%" },
            { "data": "studentCount", "width": "10%" },
            { "data": "studentGradeAverage", "width": "10%" }
        ]
    });
}

    