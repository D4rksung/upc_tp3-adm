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
            $("#Atencion_Resultado").prop('disabled', true);

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
            $('#Atencion_Resultado').prop('disabled', false);
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

        $('#Guardar').on('click', function () {
            if (!$(atencionjs.formAtencion).valid()) return false;

            var data = $(atencionjs.formAtencion).serializeArray();

            var request = {
                titulo: "Guardar Atención por Referencia",
                mensaje: "¿Está seguro de grabar los datos?",
                url: "Registrar",
                data: data
            };

            helperjs.confirmar(request);

        });
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
    },

    validacionFiltros: function () {
        $('#Filtro_Referencia_NroRuc').numeric(false);
        $('#Filtro_Referencia_NroSolicitudRef').numeric(false);
    },

    cancelar: function () {
        $("#btnCancelar").on("click", function () {
            $('#Atencion_Resultado').val('');
            $('#archivoResultado').text('');
            $('#divServicios').show();
            $('#divAtencion').hide();
        });

    }
};