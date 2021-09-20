
$(document).ready(function () {
    $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/MenuItem",
            "type": "GET",
            "datatype":"json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "price", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "foodType.name", "width": "15%" }
        ],
        "width":"100%"
    });
});