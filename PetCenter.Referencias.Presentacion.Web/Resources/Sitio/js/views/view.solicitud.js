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

    grabar: function () {

        $('#Guardar').on('click', function () {

            if (!$(solicitudjs.formSolicitud).valid()) return false;

            //validamos la obligatoriedad de 3 archivos.
            contador = 0;
            var nombreArchivors = $("#tabla-archivos tr").eq(0).find("input[id=nombreArchivors]").val();
            var nombreArchivoccv = $("#tabla-archivos tr").eq(1).find("input[id=nombreArchivoccv]").val();
            var nombreArchivorsu = $("#tabla-archivos tr").eq(2).find("input[id=nombreArchivorsu]").val();
            var nombreArchivolf = $("#tabla-archivos tr").eq(3).find("input[id=nombreArchivolf]").val();
            var nombreArchivorcr = $("#tabla-archivos tr").eq(4).find("input[id=nombreArchivorcr]").val();

            if (nombreArchivors != "") contador++;
            if (nombreArchivoccv != "") contador++;
            if (nombreArchivorsu != "") contador++;
            if (nombreArchivolf != "") contador++;
            if (nombreArchivorcr != "") contador++;

            if (contador < 3) {
                helperjs.mostrarMensajes.warning('Ingrese como mínimo 3 archivos adjuntos.');
                return false;
            }
            
            var data = $(solicitudjs.formSolicitud).serializeArray();

            var request = {
                titulo: "Guardar Solicitud",
                mensaje: "¿Está seguro de grabar los datos?",
                url: "Registrar",
                data: data
            };

            helperjs.confirmar(request);

        });

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
                sitiojs.ValidarSoloNumeros(nroDocumento);
            } else if (tipoDocumento == 'DNI') {
                nroDocumento.attr('maxlength', '8');
                sitiojs.ValidarSoloNumeros(nroDocumento);
            } else if (tipoDocumento == 'CEX') {
                $(nroDocumento).unbind();
                nroDocumento.attr('maxlength', '9');
                sitiojs.ValidarSoloAlfanumericos(nroDocumento);
            } else {
                nroDocumento.attr('maxlength', '15');
            }
        });
    }
}