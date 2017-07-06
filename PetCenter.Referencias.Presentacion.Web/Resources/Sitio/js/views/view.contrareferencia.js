var contrareferenciajs = {

    formContraReferencia: '#formContraReferencia',

    iniciar: function () {
        contrareferenciajs.validaciones();
    },

    validaciones: function () {

        $(this.formContraReferencia).validacionAsistencia({
            rules: {
                'ContraReferencia.FechaEntrega': {
                    required: true
                },
                'ContraReferencia.FechaCierre': {
                    required: true
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
                },
                'ContraReferencia.FechaCierre': {
                    required: 'Ingrese Fecha Salida',
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
    }

};