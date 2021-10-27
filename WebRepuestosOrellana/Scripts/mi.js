$(document).ready(function () {

    $("#CantidadVentaProducto").change(function () {
        
    })

    $("#VentaProductoID").change(function () {
        console.log($("#VentaProductoID").val())
        let productoID = $("#VentaProductoID").val();
        $.ajax({
            type: "GET",
            url: `/productos/GetProduct/${productoID}`, 
            contentType: "application/json; charset=utf-8",
            success: function (data) { console.log(data)}
        })
    })
});