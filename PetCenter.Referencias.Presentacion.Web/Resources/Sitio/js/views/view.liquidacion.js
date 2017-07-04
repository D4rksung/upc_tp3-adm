var liquidacionjs = {

    formLiquidacion: "#formLiquidacion",

    iniciar: function () {
        //$("#Liquidacion_ValorAjuste").numeric('.');
        sitiojs.ValidarSoloNumerosConGuion($("#Liquidacion_ValorAjuste"));
    },

    validacion: function () {
        $(this.formLiquidacion).validacionAsistencia({
            rules: {
                'Liquidacion.ValorAjuste': {
                    required: true,
                    noEspeciales: sitiojs.caracter_restringido_nombres
                }
            },
            messages: {
                'Liquidacion.ValorAjuste': {
                    required: 'Ingrese Valor Ajuste',
                    noEspeciales: 'No ingrese caracteres especiales'
                }
            }
        });
    },

    aplicaAjuste: function () {
        $("#Liquidacion_ValorAjuste").keypress(function () {

            $("#Liquidacion_ValorImpuesto").text('0');
            
        });
    }
}