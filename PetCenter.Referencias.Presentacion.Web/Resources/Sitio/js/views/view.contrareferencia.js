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
    }

};