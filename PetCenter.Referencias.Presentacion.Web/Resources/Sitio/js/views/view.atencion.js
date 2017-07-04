var atencionjs = {

    formAtencion: "#formAtencion",

    iniciar: function () {
        $('#divAtencion').hide();
        atencionjs.validacion();
    },

    mostrarAtencion: function (idServicio, desServicio, soloLectura) {

        $('#Servicio_IdServicio').val(idServicio);
        $('#Servicio_NombreServicio').val(desServicio);

        $('#divServicios').hide();
        $('#divAtencion').show();

        if (soloLectura == true) {
            $('#Guardar').hide();
            $('#main-filers').hide();

            var idReferencia = $('#Referencia_NroSolicitudRef').val();
            var idConvenio = $('#Referencia_NroConvenio').val();

            $.ajax({
                url: helperjs.urlBase + "Atencion/ObtenerAtencion",
                data: { idReferencia: idReferencia, idServicio: idServicio, idConvenio: idConvenio },
                dataType: "json",
                asyc: false,
                contentType: "application/json; charset=utf-8",
                type: "GET",
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                },
                success: function (data) {

                    if (data == null) {
                        $('#Atencion_Resultado').val('');
                    }
                    else {
                        $('#Atencion_Resultado').val(data.Resultado);

                        if (data.ResultadoTitulo != null && data.ResultadoTitulo != '') {
                            $('#archivoResultado').text(data.ResultadoTitulo);
                            var _ruta = "archivojs.descargaArchivo('/Atencion/Descarga?idReferencia=" + idReferencia + "&idServicio=" + idServicio + "&idConvenio=" + idConvenio + "','#formAtencion')"
                            $('#archivoResultado').attr('onclick', _ruta + '; return false;');
                        }
                    }
                    conveniojs.calculaTarifaReal();
                }
            });
        } else {
            $('#Guardar').show();
        }
    },

    validacion: function () {
        $(this.formAtencion).validacionAsistencia({
            rules: {
                'Atencion.Resultado': {
                    required: true
                }
            },
            messages: {
                'Atencion.Resultado': {
                    required: 'Ingrese Detalle',
                }
            }
        });
    },

    grabar: function () {

        //$("#Guardar").on("click", function () {

        //    if (!$(atencionjs.formAtencion).valid()) return false;

        //    var url = $(atencionjs.formAtencion).attr('action');
        //    var atencionForm = $(atencionjs.formConvenio).serializeArray();
        //    helperjs.setPostUrl(url, atencionForm);
        //    return false;

        //});

    },

    validacionBuscar: function () {
        $(this.formAtencion).validacionAsistencia({
            rules: {
                'Filtro.Referencia.FechaSolicitudInicio': {
                    required: true,
                    date: true
                },
                'Filtro.Referencia.FechaSolicitudFin': {
                    required: true,
                    date: true,
                    dateMayorIgual: 'Filtro_Referencia_FechaSolicitudInicio'
                }
            },
            messages: {
                'Filtro.Referencia.FechaSolicitudInicio': {
                    required: 'Ingrese Fecha Inicio',
                    date: 'Fecha Inicio incorrecta'
                },
                'Filtro.Referencia.FechaSolicitudFin': {
                    required: 'Ingrese Fecha Fin',
                    date: 'Fecha Hasta incorrecta',
                    dateMayorIgual: "La fecha de inicio no puede ser mayor que la fecha fin"
                }
            }
        });
    }
};