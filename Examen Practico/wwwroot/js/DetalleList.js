var detalledata;

$(document).ready(function () {
    GetDetalleFactura();
});

function GetDetalleFactura() {
    detalledata = $.ajax({
        "url": "/facturas/detalle/",
        "type": "GET",
        "datatype": "json"
    });
}