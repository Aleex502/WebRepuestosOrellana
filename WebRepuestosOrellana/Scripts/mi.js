$(document).ready(function () {

    $("#CantidadVentaProducto").change(function () {
        let cantidad = $("#CantidadVentaProducto").val();
        let precio = $("#PrecioUnitarioVenta").val();
        $("#TotalVenta").val(precio * cantidad);
    })

    $("#VentaProductoID").change(function () {
        let productoID = $("#VentaProductoID").val();
        let cantidad = $("#CantidadVentaProducto").val();
        $.ajax({
            type: "GET",
            url: `/productos/GetProduct/${productoID}`,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#PrecioUnitarioVenta").val(data);
                $("#TotalVenta").val(data * cantidad);
            }
        })
    })
});