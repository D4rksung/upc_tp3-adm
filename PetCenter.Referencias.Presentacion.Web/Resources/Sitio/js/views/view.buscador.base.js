var buscadorBasejs = {

    formBuscador: "#buscadorForm",

    iniciar: function () {
        var controlador = $("#buscador_entidad").val().toLowerCase();
        var url = helperjs.urlBase + controlador + "/BuscadorGrid";

        //Buscar
        $("#btn-buscador").on("click", function () {

            var dataForm = $(buscadorBasejs.formBuscador).serialize();
            var request = {
                url: url,
                data: dataForm,
                success: function (data, textStatus, jqXhr) {
                    $('#grid-buscador').html(data);
                    $("[title]").tooltip();
                    helperGridjs.updateCallback();

                    $("#grid-det table thead a").each(function () {
                        var href = $(this).attr("href");
                        $(this).attr("href", href + "&" + dataForm);
                    });

                    $("#grid-det-foot a").each(function () {
                        var href = $(this).attr("href");
                        $(this).attr("href", href + "&" + dataForm);
                    });

                }
            };
            helperjs.ajaxSend(request);
            return false;
        });

        //Limpiar
        $("#btn-limpiar").on("click", function () {
            $(buscadorBasejs.formBuscador + " input, " + buscadorjs.formBuscador + " textarea ").each(function () {
                if ($(this).attr('name') == '__RequestVerificationToken') return;
                if ($(this).hasClass('noeliminar')) return;

                if ($(this).prop("checked")) {
                    $(this).prop("checked", false)
                } else {
                    $(this).val('');
                }

            });

            $(buscadorBasejs.formBuscador + " select").each(function () {
                if ($(this).hasClass('noeliminar')) return;
                $(this).val($(this).children().first().val());
            });

            var request = {
                url: url,
                data: { entidad: null },
                success: function (data, textStatus, jqXhr) {
                    $('#grid-buscador').html(data);
                }
            };
            helperjs.ajaxSend(request);

            return false;
        });


    },

    buscarKey: function (args) {
        var request = {
            url: helperjs.urlBase + args.url,
            data: args.data,
            success: function (data, textStatus, jqXhr) {
                var param = {
                    data: data,
                    modalTop: true,
                    btnAceptar: false,
                    id: "modal-buscador",
                    afterShow: function () {
                        $("#buscador_key").val(args.key);
                        $("#buscador_value").val(args.value);
                    }
                };
                helperjs.popup(param);

            }
        };
        helperjs.ajaxSend(request);
    },

    buscarKeyTrabajador: function (args) {
        var request = {
            url: helperjs.urlBase + args.url,
            data: args.data,
            success: function (data, textStatus, jqXhr) {
                var param = {
                    data: data,
                    modalTop: true,
                    btnAceptar: false,
                    id: "modal-buscador",
                    afterShow: function () {
                        $("#buscador_codMper").val(args.codMper);
                        $("#buscador_codTrabajador").val(args.codTrabajador);
                        $("#buscador_dni").val(args.dni);
                        $("#buscador_apePat").val(args.apePat);
                        $("#buscador_nombre").val(args.nombre);
                    }
                };

                helperjs.popup(param);

            }
        };
        helperjs.ajaxSend(request);
    },

    selectKeyMaestroProveedor: function (codMper,codTrabajador, dni, apePat, nombre) {
        $("#" + $("#buscador_codMper").val()).val(codMper);
        $("#" + $("#buscador_codTrabajador").val()).val(codTrabajador);
        $("#" + $("#buscador_dni").val()).val(dni);
        $("#" + $("#buscador_apePat").val()).val(apePat);
        $("#" + $("#buscador_nombre").val()).val(nombre);
        $("#modal-buscador").modal('hide');
    },
}