var solicitudjs = {

    formSolicitud: "#formSolicitud",

    iniciar: function () {

        solicitudjs.validaciones();

        //$("#Guardar").on("click", solicitudjs.grabarSolicitud);
        $("#Solicitud_NroRuc").numeric(false);
        $("#Solicitud_Telefono").numeric(false);
        $("#Solicitud_TelefonoRep").numeric(false);
        $("#Solicitud_Monto").numeric('.');

    },

    validaciones: function () {

        $(this.formSolicitud).validacionAsistencia({
            rules: {
                'Solicitud.FechaSolicitud': {
                    required: true,
                    date: true
                },
                'Solicitud.NroRuc': {
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
                'Solicitud.IdTipoDocumento': {
                    required: true
                },
                'Solicitud.NroDocumento': {
                    required: true,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                },
                'Solicitud.NombresCompletos': {
                    required: true
                },
                'Solicitud.Email': {
                    required: true,
                    noEspeciales: sitiojs.caracter_restringido_correo,
                    email: true
                },
                'Solicitud.IdBanco': {
                    required: true
                },
                'Solicitud.IdMoneda': {
                    required: true
                },
                'Solicitud.Monto': {
                    required: true,
                    numeroMayorCero: true
                },
                'Solicitud.FechaVencimiento': {
                    required: true
                },
                'Solicitud.NroReferencia': {
                    required: true
                }
            },
            messages: {
                'Solicitud.FechaSolicitud': {
                    required: 'Ingrese Fecha Solicitud',
                    date: 'Fecha Solicitud incorrecta'
                },
                'Solicitud.NroRuc': {
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
                'Solicitud.IdTipoDocumento': {
                    required: 'Seleccione Tipo Documento'
                },
                'Solicitud.NroDocumento': {
                    required: 'Ingrese Nro Documento',
                    noEspeciales: 'No ingrese caracteres especiales',
                },
                'Solicitud.NombresCompletos': {
                    required: 'Ingrese Apellidos y Nombres'
                },
                'Solicitud.Email': {
                    required: 'Ingrese Email',
                    noEspeciales: 'No ingrese caracteres especiales',
                    email: 'Correo electrónico incorrecto'
                },
                'Solicitud.IdBanco': {
                    required: 'Ingrese Banco'
                },
                'Solicitud.IdMoneda': {
                    required: 'Ingrese Moneda'
                },
                'Solicitud.Monto': {
                    required: 'Ingrese Monto',
                    numeroMayorCero: 'Monto tiene que ser mayor que cero'
                },
                'Solicitud.FechaVencimiento': {
                    required: 'Ingrese Fecha de Vencimiento'
                },
                'Solicitud.NroReferencia': {
                    required: 'Ingrese Nro de Referencia'
                }
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
    }
}