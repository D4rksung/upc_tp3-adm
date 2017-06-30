var mascotajs = {

    formBuscador: "#buscadorForm",

    iniciarPopup: function () {
        var controlador = $("#buscador_entidad").val().toLowerCase();
        var url = helperjs.urlBase + controlador + "/BuscadorGrid";

        //Buscar
        $("#btn-buscador").on("click", function () {

            var dataForm = $(mascotajs.formBuscador).serialize();
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
            $(mascotajs.formBuscador + " input, " + mascotajs.formBuscador + " textarea ").each(function () {
                if ($(this).attr('name') == '__RequestVerificationToken') return;
                if ($(this).hasClass('noeliminar')) return;

                if ($(this).prop("checked")) {
                    $(this).prop("checked", false)
                } else {
                    $(this).val('');
                }

            });

            $(mascotajs.formBuscador + " select").each(function () {
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

    buscarKeyMascota: function (args) {
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
                        $("#buscador_codMascota").val(args.codMascota);
                        $("#buscador_nombre").val(args.nombre);
                        $("#buscador_especie").val(args.especie);
                        $("#buscador_raza").val(args.raza);
                        $("#buscador_fnac").val(args.fnac);
                    }
                };

                helperjs.popup(param);

            }
        };
        helperjs.ajaxSend(request);
    },

    selectKeyMascota: function (codMascota, nombre, especie, raza, fnac) {
        $("#" + $("#buscador_codMascota").val()).val(codMascota);
        $("#" + $("#buscador_nombre").val()).val(nombre);
        $("#" + $("#buscador_especie").val()).val(especie);
        $("#" + $("#buscador_raza").val()).val(raza);
        $("#" + $("#buscador_fnac").val()).val(fnac);
        $("#modal-buscador").modal('hide');
    },
};