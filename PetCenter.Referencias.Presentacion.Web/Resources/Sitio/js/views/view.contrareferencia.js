var contrareferenciajs = {

    formContraReferencia: '#formContraReferencia',

    iniciar: function () {
        contrareferenciajs.validaciones();
    },

    validaciones: function () {

        $(this.formContraReferencia).validacionAsistencia({
            rules: {
                'ContraReferencia.FechaEntrega': {
                    required: true,
                    date: true
                },
                'ContraReferencia.FechaCierre': {
                    required: true,
                    date: true,
                    dateMayorIgual: 'ContraReferencia_FechaEntrega'
                },
                'ContraReferencia.Observaciones': {
                    required: true
                },
                'ContraReferencia.Resultados': {
                    required: true
                },
                'ContraReferencia.IdVeterinario': {
                    required: true
                }
            },
            messages: {                
                'ContraReferencia.FechaEntrega': {
                    required: 'Ingrese Fecha Ingreso',
                    date: 'Fecha Inicio incorrecta'
                },
                'ContraReferencia.FechaCierre': {
                    required: 'Ingrese Fecha Salida',
                    date: 'Fecha Inicio incorrecta',
                    dateMayorIgual: "La fecha de Ingreso no puede ser mayor que la fecha Salida"
                },
                'ContraReferencia.Observaciones': {
                    required: 'Ingrese Diagnóstico de Egreso',
                },
                'ContraReferencia.Resultados': {
                    required: 'Ingrese Recomendaciones',
                },
                'ContraReferencia.IdVeterinario': {
                    required: 'Seleccione Veterinario',
                }
            }
        });
    },

    validacionBuscar: function () {
        $(this.formContraReferencia).validacionAsistencia({
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

};