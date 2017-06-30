var solicitudjs = {

    formSolicitud: "#formSolicitud",

    iniciar: function () {

        solicitudjs.validaciones();

        $("#Solicitud_NroRUC").numeric(false);
        $("#Solicitud_Telefono").numeric(false);
        $("#Solicitud_TelefonoRep").numeric(false);
        $("#Solicitud_ImporteGarantia").numeric('.');

        solicitudjs.ocultar();
    },

    validaciones: function () {

        $(this.formSolicitud).validacionAsistencia({
            rules: {
                'Solicitud.FechaSolicitud': {
                    required: true,
                    date: true
                },
                'Solicitud.NroRUC': {
                    required: true,
                    maxlength: 11,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                    cantidad11Caracteres: true
                },
                'Solicitud.RazonSocial': {
                    required: true
                },
                'Solicitud.Direccion': {
                    required: true
                },
                'Solicitud.TpoDocRep': {
                    required: true
                },
                'Solicitud.NroDocRep': {
                    required: true,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                },
                'Solicitud.NombreRep': {
                    required: true
                },
                'Solicitud.CorreoRep': {
                    required: true,
                    noEspeciales: sitiojs.caracter_restringido_correo,
                    email: true
                },
                //'Solicitud.IdBanco': {
                //    required: true
                //},
                //'Solicitud.IdMoneda': {
                //    required: true
                //},
                //'Solicitud.ImporteGarantia': {
                //    required: true,
                //    numeroMayorCero: true
                //},
                //'Solicitud.FechaVencimientoG': {
                //    required: true
                //},
                //'Solicitud.Nrogarantia': {
                //    required: true
                //}
            },
            messages: {
                'Solicitud.FechaSolicitud': {
                    required: 'Ingrese Fecha Solicitud',
                    date: 'Fecha Solicitud incorrecta'
                },
                'Solicitud.NroRUC': {
                    required: 'Ingrese Nro de Ruc',
                    maxlength: 'Ruc 11 dígitos',
                    noEspeciales: 'No ingrese caracteres especiales',
                    cantidad11Caracteres: 'Ingrese 11 dígitos'
                },
                'Solicitud.RazonSocial': {
                    required: 'Ingrese Razón Social'
                },
                'Solicitud.Direccion': {
                    required: 'Ingrese Dirección'
                },
                'Solicitud.TpoDocRep': {
                    required: 'Seleccione Tipo Documento'
                },
                'Solicitud.NroDocRep': {
                    required: 'Ingrese Nro Documento',
                    noEspeciales: 'No ingrese caracteres especiales',
                },
                'Solicitud.NombreRep': {
                    required: 'Ingrese Apellidos y Nombres'
                },
                'Solicitud.CorreoRep': {
                    required: 'Ingrese Email',
                    noEspeciales: 'No ingrese caracteres especiales',
                    email: 'Correo electrónico incorrecto'
                },
                //'Solicitud.IdBanco': {
                //    required: 'Ingrese Banco'
                //},
                //'Solicitud.IdMoneda': {
                //    required: 'Ingrese Moneda'
                //},
                //'Solicitud.ImporteGarantia': {
                //    required: 'Ingrese Monto',
                //    numeroMayorCero: 'Monto tiene que ser mayor que cero'
                //},
                //'Solicitud.FechaVencimientoG': {
                //    required: 'Ingrese Fecha de Vencimiento'
                //},
                //'Solicitud.Nrogarantia': {
                //    required: 'Ingrese Nro de Referencia'
                //}
            }
        });
    },

    grabarSolicitud: function () {

        //if (!$(solicitudjs.formSolicitud).valid()) return false;

        //var url = "";
        //var data = $(solicitudjs.formSolicitud).serializeArray();
        //var request = {
        //    titulo: "Guardar Solicitud",
        //    mensaje: "¿Está seguro de guardar la solicitud?",
        //    url: url,
        //    data: data
        //};

        //helperjs.confirmar(request);
    },

    ocultar: function () {
        $('#site-menu').hide();
        $('#liInicio').hide();
        $('#liNotificaciones').hide();
        $('#liCerrarSesion').hide();
        $('#site-body').removeClass("col-md-9");
        $('#site-body').addClass("col-md-12");
        $("#asistencia-header").hide();
        $('#asistencia-report-back').hide();
        $('.footer').hide();
    },

    setearMaxLength: function () {
        $("#Solicitud_TpoDocRep").change(function () {
            var tipoDocumento = $(this).val();
            var nroDocumento = $("#Solicitud_NroDocRep");
            nroDocumento.val('');
            if (tipoDocumento == 'RUC') {
                nroDocumento.attr('maxlength', '11');
            } else if (tipoDocumento == 'DNI') {
                nroDocumento.attr('maxlength', '8');
            } else if (tipoDocumento == 'CEX') {
                nroDocumento.attr('maxlength', '9');
            } else {
                nroDocumento.attr('maxlength', '15');
            }
        });
    }
}