var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Student/GetAllStudents",
        },
        "columns": [
            { "data": "studentName", "width": "20%" },
            { "data": "course.courseName", "width": "20%" },
            { "data": "studentBirthDate", "width": "15%" },
            { "data": "studentRegistrationNumber", "width": "15%" },
            {
                "data": "studentId",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Student/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>&nbsp;&nbsp;&nbsp;

                                <a href="/Student/RecordStudentGrade/${data}" class="btn btn-primary text-white" style="cursor:pointer">
                                    <i class="fas fa-plus"></i> Grade
                                </a>&nbsp;&nbsp;
                                <a onclick=Delete("/Student/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "55%"
            }
        ]
    });
}

//function Delete(url) {
//    swal({
//        title: "Are you sure you want to Delete?",
//        text: "You will not be able to restore the data!",
//        icon: "warning",
//        buttons: true,
//        dangerMode: true
//    }).then((willDelete) => {
//        if (willDelete) {
//            $.ajax({
//                type: "DELETE",
//                url: url,
//                success: function (data) {
//                    if (data.success) {
//                        toastr.success(data.message);
//                        dataTable.ajax.reload();
//                    }
//                    else {
//                        toastr.error(data.message);
//                    }
//                }
//            });
//        }
//    });
//}",
        