var liquidacionjs = {

    formLiquidacion: "#formLiquidacion",

    iniciar: function () {

        sitiojs.ValidarSoloNumerosConGuion($("#Liquidacion_ValorAjuste"));        
        $("#Liquidacion_ValorAjuste").val(0);
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
        $("#Liquidacion_ValorAjuste").keyup(function () {

            var valorAjuste = $('#Liquidacion_ValorAjuste').val();
            if (valorAjuste == '') $('#Liquidacion_ValorAjuste').val(0);

            var neto = $('#ValorNeto');
            var igv = $('#ValorImpuesto');
            var total = $('#ValorTotal');

            var _calcNeto = parseFloat(neto.text().trim()) + parseFloat(valorAjuste);

            var _calcIgv = parseFloat(_calcNeto) * 0.18;

            igv.text(_calcIgv.toFixed(2));

            var _calcTotal = parseFloat(_calcIgv) + parseFloat(neto.text().trim());

            total.text(_calcTotal.toFixed(2));
        });
    },

    guardar: function () {
        $('#Guardar').on('click', function () {
            if (!$(liquidacionjs.formLiquidacion).valid()) return false;

            var totalRegistros = $("#tab-servicios tbody > tr").length;

            //aplicamos los nuevos valores

            //var valorIGV = $("#tab-servicios tbody > tr").eq(totalRegistros - 2).find('span[id=ValorImpuesto]').text();
            //var _valorIGV = $("#tab-servicios tbody > tr").eq(totalRegistros - 2).find("td > input.tmp-valorimpuesto").get(0);
            //_valorIGV.value = valorIGV;

            var valorTotal = $("#tab-servicios tbody > tr").eq(totalRegistros - 1).find('span[id=ValorTotal]').text();
            //var _valorTotal = $("#tab-servicios tbody > tr").eq(totalRegistros - 1).find("td > input.tmp-valortotal").get(0);
            //_valorTotal.value = valorTotal;

            if (parseFloat(valorTotal) <= 0) {
                helperjs.mostrarMensajes.warning('Valor Total no puede ser menor o igual a 0.');
                return false;
            }
            else {
                var url = $(liquidacionjs.formLiquidacion).attr('action');
                var liquidacionForm = $(liquidacionjs.formLiquidacion).serializeArray();
                helperjs.setPostUrl(url, liquidacionForm);
                return false;
            }


        });
    }
}