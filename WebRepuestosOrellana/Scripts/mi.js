$(document).ready(function () {
    let cantidadItems = 0;
    $("#CantidadVentaProducto").change(function () {
        let cantidad = $("#CantidadVentaProducto").val();
        let precio = $("#PrecioUnitarioVenta").val();
        if (precio.length != 0) {
            $("#TotalVenta").val(precio * cantidad);
        }
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

    $("#addLineaVenta").click((e) => {
        e.preventDefault();
        let productoTexto = $("#VentaProductoID option:selected").text();
        let productoID = $("#VentaProductoID").val();
        let cantidad = $("#CantidadVentaProducto").val();
        let ventasBody = $("#ventasBody");
        let precio = $("#PrecioUnitarioVenta").val();
        
        if (productoID !== "" && cantidad !== "" && precio !== "") {
            ventasBody.append("<tr>");
            ventasBody.append(`<td>${productoTexto}</td>`);
            ventasBody.append(`<td>${cantidad}</td>`);
            ventasBody.append(`<td>${precio}</td>`);
            ventasBody.append(`<td>${cantidad * precio}</td>`);
            ventasBody.append("</tr>");

            const data = document.getElementById("data");

            let HiddenIndex = document.createElement("input");
            let HiddenCodigo = document.createElement("input");
            let HiddenCantidad = document.createElement("input");
            let HiddenPrecio = document.createElement("input");

            HiddenIndex.name = "lineasVenta[" + cantidadItems + "].NoLinea";
            HiddenIndex.value = cantidadItems;
            HiddenIndex.type = "hidden";

            HiddenCantidad.name = "lineasVenta[" + cantidadItems + "].Cantidad";
            HiddenCantidad.value = cantidad;
            HiddenCantidad.type = "hidden";

            HiddenCodigo.name = "lineasVenta[" + cantidadItems + "].ProductoID";
            HiddenCodigo.value = productoID;
            HiddenCodigo.type = "hidden";

            HiddenPrecio.name = "lineasVenta[" + cantidadItems + "].Precio";
            HiddenPrecio.value = precio;
            HiddenPrecio.type = "hidden";
            data.appendChild(HiddenIndex);
            data.appendChild(HiddenCodigo);
            data.appendChild(HiddenCantidad);
            data.appendChild(HiddenPrecio);

            $("#VentaProductoID").val("");
            $("#CantidadVentaProducto").val(1);
            $("#PrecioUnitarioVenta").val("");
            $("#TotalVenta").val("");
            cantidadItems++;
        }
        else {
            alert("Por favor ingresa los datos necesarios")
        }
    })

    /*************************************/
    $("#CantidadVentaProducto").change(function () {
        let cantidad = $("#CantidadVentaProducto").val();
        let precio = $("#PrecioUnitarioVenta").val();
        if (precio.length != 0) {
            $("#TotalVenta").val(precio * cantidad);
        }
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

    $("#addLineaVenta").click((e) => {
        e.preventDefault();
        let productoTexto = $("#VentaProductoID option:selected").text();
        let productoID = $("#VentaProductoID").val();
        let cantidad = $("#CantidadVentaProducto").val();
        let ventasBody = $("#ventasBody");
        let precio = $("#PrecioUnitarioVenta").val();

        if (productoID !== "" && cantidad !== "" && precio !== "") {
            ventasBody.append("<tr>");
            ventasBody.append(`<td>${productoTexto}</td>`);
            ventasBody.append(`<td>${cantidad}</td>`);
            ventasBody.append(`<td>${precio}</td>`);
            ventasBody.append(`<td>${cantidad * precio}</td>`);
            ventasBody.append("</tr>");

            const data = document.getElementById("data");

            let HiddenIndex = document.createElement("input");
            let HiddenCodigo = document.createElement("input");
            let HiddenCantidad = document.createElement("input");
            let HiddenPrecio = document.createElement("input");

            HiddenIndex.name = "lineasVenta[" + cantidadItems + "].NoLinea";
            HiddenIndex.value = cantidadItems;
            HiddenIndex.type = "hidden";

            HiddenCantidad.name = "lineasVenta[" + cantidadItems + "].Cantidad";
            HiddenCantidad.value = cantidad;
            HiddenCantidad.type = "hidden";

            HiddenCodigo.name = "lineasVenta[" + cantidadItems + "].ProductoID";
            HiddenCodigo.value = productoID;
            HiddenCodigo.type = "hidden";

            HiddenPrecio.name = "lineasVenta[" + cantidadItems + "].Precio";
            HiddenPrecio.value = precio;
            HiddenPrecio.type = "hidden";
            data.appendChild(HiddenIndex);
            data.appendChild(HiddenCodigo);
            data.appendChild(HiddenCantidad);
            data.appendChild(HiddenPrecio);

            $("#VentaProductoID").val("");
            $("#CantidadVentaProducto").val(1);
            $("#PrecioUnitarioVenta").val("");
            $("#TotalVenta").val("");
            cantidadItems++;
        }
        else {
            alert("Por favor ingresa los datos necesarios")
        }
    })


    /*******************************/


});