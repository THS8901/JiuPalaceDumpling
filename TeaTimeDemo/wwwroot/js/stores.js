var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/customer/store/getall' // 用 customer API
        },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'address', "width": "30%" },
            { data: 'city', "width": "15%" },
            { data: 'phoneNumber', "width": "10%" },
            { data: 'description', "width": "30%" }
        ]
    });
}