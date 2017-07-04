var evaluacionjs = {

    formEvaluacion: "#formEvaluacion",
    formRechazar: "#formRechazar",

    iniciar: function () {

        evaluacionjs.validaciones();

        $("#Solicitud_NroRUC").numeric(false);
        $("#Solicitud_Telefono").numeric(false);
        $("#Solicitud_TelefonoRep").numeric(false);
        $("#Solicitud_Monto").numeric('.');

    },

    validaciones: function () {

        $(this.formEvaluacion).validacionAsistencia({
            rules: {
                'Evaluacion.FechaSolicitud': {
                    required: true,
                    date: true
                },
                'Evaluacion.NroRuc': {
                    required: true,
                    maxlength: 11,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                    cantidad11Caracteres: true
                },
                'Evaluacion.RazonSocial': {
                    required: true
                },
                'Evaluacion.Direccion': {
                    required: true
                },
                'Evaluacion.TpoDocRep': {
                    required: true
                },
                'Evaluacion.NroDocumento': {
                    required: true,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                },
                'Evaluacion.NombresCompletos': {
                    required: true
                },
                'Evaluacion.Email': {
                    required: true,
                    noEspeciales: sitiojs.caracter_restringido_correo,
                    email: true
                },
                'Evaluacion.IdBanco': {
                    required: true
                },
                'Evaluacion.IdMoneda': {
                    required: true
                },
                'Evaluacion.Monto': {
                    required: true,
                    numeroMayorCero: true
                },
                'Evaluacion.FechaVencimiento': {
                    required: true
                },
                'Evaluacion.NroReferencia': {
                    required: true
                }
            },
            messages: {
                'Evaluacion.FechaSolicitud': {
                    required: 'Ingrese Fecha Solicitud',
                    date: 'Fecha Solicitud incorrecta'
                },
                'Evaluacion.NroRuc': {
                    required: 'Ingrese Nro de Ruc',
                    maxlength: 'Ruc 11 dígitos',
                    noEspeciales: 'No ingrese caracteres especiales',
                    cantidad11Caracteres: 'Ingrese 11 dígitos'
                },
                'Evaluacion.RazonSocial': {
                    required: 'Ingrese Razón Social'
                },
                'Evaluacion.Direccion': {
                    required: 'Ingrese Dirección'
                },
                'Evaluacion.TpoDocRep': {
                    required: 'Seleccione Tipo Documento'
                },
                'Evaluacion.NroDocumento': {
                    required: 'Ingrese Nro Documento',
                    noEspeciales: 'No ingrese caracteres especiales',
                },
                'Evaluacion.NombresCompletos': {
                    required: 'Ingrese Apellidos y Nombres'
                },
                'Evaluacion.Email': {
                    required: 'Ingrese Email',
                    noEspeciales: 'No ingrese caracteres especiales',
                    email: 'Correo electrónico incorrecto'
                },
                'Evaluacion.IdBanco': {
                    required: 'Ingrese Banco'
                },
                'Evaluacion.IdMoneda': {
                    required: 'Ingrese Moneda'
                },
                'Evaluacion.Monto': {
                    required: 'Ingrese Monto',
                    numeroMayorCero: 'Monto tiene que ser mayor que cero'
                },
                'Evaluacion.FechaVencimiento': {
                    required: 'Ingrese Fecha de Vencimiento'
                },
                'Evaluacion.NroReferencia': {
                    required: 'Ingrese Nro de Referencia'
                }
            }
        });
    },

    validacionesRechazar: function () {
        $(this.formRechazar).validacionAsistencia({
            rules: {
                'DocumentoRechazo.Observaciones': {
                    required: true,
                },
                'DocumentoRechazo.FechaRechazo': {
                    required: true,
                    date: true
                }
            },
            messages: {
                'DocumentoRechazo.Observaciones': {
                    required: 'Ingrese Observaciones',
                },
                'DocumentoRechazo.FechaRechazo': {
                    required: 'Ingrese Fecha Rechazo',
                    date: 'Fecha Rechazo incorrecta'
                },
            }
        });
    },

    rechazar: function () {
        $("#btn-rechazar").on("click", function () {

            var idSolicitud = $("#Solicitud_NroSolicitud").val();
            var url = helperjs.urlBase + "Solicitud/Rechazar";

            var request = {
                url: helperjs.urlBase + "Solicitud/AbrirRechazar",
                data: { idSolicitud: idSolicitud },
                success: function (data, textStatus, jqXhr) {
                    var param = {
                        data: data,
                        modalTop: true,
                        id: "modal-buscador",
                        funcOk: function () {

                            if (!$(evaluacionjs.formRechazar).valid()) return false;

                            var modelo = $(evaluacionjs.formRechazar).serializeArray();
                            helperjs.setPostUrl(url, modelo);

                        }
                    };
                    helperjs.popup(param);
                }
            };

            helperjs.ajaxSend(request);


        });
    },

    validacionBuscar: function () {
        $(this.formEvaluacion).validacionAsistencia({
            rules: {
                'Filtro.Solicitud.FechaSolicitudInicio': {
                    required: true,
                    date: true
                },
                'Filtro.Solicitud.FechaSolicitudHasta': {
                    required: true,
                    date: true,
                    dateMayorIgual: 'Filtro_Solicitud_FechaSolicitudInicio'
                }
            },
            messages: {
                'Filtro.Solicitud.FechaSolicitudInicio': {
                    required: 'Ingrese Fecha Inicio',
                    date: 'Fecha Inicio incorrecta'
                },
                'Filtro.Solicitud.FechaSolicitudHasta': {
                    required: 'Ingrese Fecha Hasta',
                    date: 'Fecha Hasta incorrecta',
                    dateMayorIgual: "La fecha de inicio no puede ser mayor que la fecha hasta"
                }
            }
        });
    }
}