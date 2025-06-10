var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/store/getall"
        },
        "columns": [
            { "data": "name", "width": "10%" },
            { "data": "address", "width": "30%" },
            { "data": "city", "width": "15%" },
            { "data": "phoneNumber", "width": "10%" },
            { "data": "description", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/admin/store/upsert?id=${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> 編輯
                            </a>
                            <a onClick=Delete('/admin/store/delete/${data}') class="btn btn-danger mx-2">
                                <i class="bi bi-trash-fill"></i> 刪除
                            </a>
                        </div>`;
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: '確定要刪除嗎？',
        text: "此操作無法還原！",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: '是的，刪除！'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            });
        }
    });
}
