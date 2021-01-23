var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#FacturasTable').DataTable({
        "ajax": {
            "url": "/facturas/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "clienteNombre", "width": "17.5%" },
            { "data": "clienteNit", "width": "17.5%" },
            { "data": "fecha", "width": "17.5%" },
            { "data": "total", "width": "17.5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/Facturas/Delete?id='+${data})>
                            Eliminar
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Anular('/Facturas/Anular?id='+${data})>
                            Anular
                        </a>
                        <a href="/Facturas/Detalle?id='+${data}" class="btn btn-info from-control text-white">
                            Detalle
                         </a>
                        </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Quieres eliminar la factura?",
        text: "Una ves eliminada no se podra recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
