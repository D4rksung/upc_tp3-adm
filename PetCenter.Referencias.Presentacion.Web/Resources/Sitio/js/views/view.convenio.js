var conveniojs = {

    formBuscadorServicio: "#formBuscadorServicio",
    formBuscadorDescuento: "#formBuscadorDescuento",
    formConvenio: "#formConvenio",

    iniciar: function () {
        $("#ConvenioServicio_Descuento").numeric(false);
        $("#ConvenioServicio_Base").numeric(false);

        $("#ConvenioDescuento_Minimo").numeric(false);
        $("#ConvenioDescuento_Maximo").numeric(false);
        $("#ConvenioDescuento_Porcentaje").numeric(false);

        $("#Convenio_ImporteConvenio").numeric('.');

        // $("#Guardar").on("click", conveniojs.grabar);

    },

    validacionesBuscadorServicio: function () {

        $(this.formBuscadorServicio).validacionAsistencia({
            rules: {
                'ConvenioServicio.IdServicio': {
                    required: true
                },
                'ConvenioServicio.FactorDcto': {
                    required: true,
                    numeroMayorCero: true,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                    //numeroMenorQue: 'Cien'
                },
            },
            messages: {
                'ConvenioServicio.IdServicio': {
                    required: 'Seleccione Servicio',
                },
                'ConvenioServicio.FactorDcto': {
                    required: 'Ingrese Descuento',
                    numeroMayorCero: 'Ingrese mayor a 0',
                    noEspeciales: 'No ingrese caracteres especiales',
                    //numeroMenorQue: '% de asistencia debe ser menor a cien.',
                },
            }
        });
    },

    validacionesBuscadorDescuento: function () {

        $(this.formBuscadorDescuento).validacionAsistencia({
            rules: {
                'ConvenioDescuento.Descripcion': {
                    required: true
                },
                'ConvenioDescuento.Minimo': {
                    required: true,
                    numeroMayorCero: true,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                    //numeroMenorQue: 'Cien'
                },
                'ConvenioDescuento.Maximo': {
                    required: true,
                    numeroMayorCero: true,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                    //numeroMenorQue: 'Cien'
                },
                'ConvenioDescuento.FactorDcto': {
                    required: true,
                    numeroMayorCero: true,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                    //numeroMenorQue: 'Cien'
                }
            },
            messages: {
                'ConvenioDescuento.Descripcion': {
                    required: 'Ingrese Descripción',
                },
                'ConvenioDescuento.Minimo': {
                    required: 'Ingrese Mínimo',
                    numeroMayorCero: 'Ingrese mayor a 0',
                    noEspeciales: 'No ingrese caracteres especiales',
                    //numeroMenorQue: '% de asistencia debe ser menor a cien.',
                },
                'ConvenioDescuento.Maximo': {
                    required: 'Ingrese Máximo',
                    numeroMayorCero: 'Ingrese mayor a 0',
                    noEspeciales: 'No ingrese caracteres especiales',
                    //numeroMenorQue: '% de asistencia debe ser menor a cien.',
                },
                'ConvenioDescuento.FactorDcto': {
                    required: 'Ingrese Porcentaje',
                    numeroMayorCero: 'Ingrese mayor a 0',
                    noEspeciales: 'No ingrese caracteres especiales',
                    //numeroMenorQue: '% de asistencia debe ser menor a cien.',
                }
            }
        });
    },

    validaciones: function () {
        $(this.formConvenio).validacionAsistencia({
            rules: {
                'Convenio.FechaConvenio': {
                    required: true
                },
                'Convenio.FechaVencimiento': {
                    required: true,
                },
                'Convenio.ImporteConvenio': {
                    required: true,
                    numeroMayorCero: true,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                },
                //'Convenio.Observacion': {
                //    required: true,
                //}
            },
            messages: {
                'Convenio.FechaConvenio': {
                    required: 'Seleccione Fecha Convenio',
                },
                'Convenio.FechaVencimiento': {
                    required: 'Seleccione Fecha Vencimiento',
                },
                'Convenio.ImporteConvenio': {
                    required: 'Ingrese Línea de Crédito',
                    numeroMayorCero: 'Ingrese mayor a 0',
                    noEspeciales: 'No ingrese caracteres especiales',
                },
                //'Convenio.Observacion': {
                //    required: 'Ingrese Observación',
                //}
            }
        });
    },

    agregaDescuento: function () {
        var request = {
            url: helperjs.urlBase + "Descuento/BuscadorIndex",
            data: {},
            success: function (data, textStatus, jqXhr) {
                var param = {
                    data: data,
                    modalTop: true,
                    id: "modal-buscador",
                    funcOk: function () {

                        if (!$(conveniojs.formBuscadorDescuento).valid()) return false;

                        var body = $("#tab-descuentos tbody");
                        var row = "";

                        var encontro = false;
                        //   var codServicio = $('#ConvenioServicio_IdServicio :selected').val();
                        var min = $("#ConvenioDescuento_Minimo").val();
                        var max = $("#ConvenioDescuento_Maximo").val();
                        var desc = $("#ConvenioDescuento_Descripcion").val();
                        var porc = $("#ConvenioDescuento_FactorDcto").val();

                        //$("#tab-descuentos tbody > tr").each(function () {
                        //    var tr = $(this);
                        //    var idServicio = tr.find("td > input.tmp-idServicio").get(0).value;

                        //    if (idServicio == codServicio) {
                        //        encontro = true;
                        //    }
                        //});

                        if (!encontro) {

                            row = row.concat("",
                              "<tr>",
                                 "<td class='asistencia-column-center'>", desc, "</td>",
                                 "<td class='asistencia-column-center'>", porc, "</td>",
                                 "<td class='asistencia-column-center'>", min, "</td>",
                                 "<td class='asistencia-column-center'>", max, "</td>",
                                 "<td class='asistencia-column-center'>",

                                 "<input class='sel singleCheckBox' id='0' type='checkbox' />",
                                 "<input id='Convenio.ListaConvenioDescuento_000__Minimo' name='Convenio.ListaConvenioDescuento[000].Minimo' class='tmp-minimo' value='", min, "' type='hidden'>",
                                 "<input id='Convenio.ListaConvenioDescuento_000__Maximo' name='Convenio.ListaConvenioDescuento[000].Maximo' class='tmp-maximo' value='", max, "' type='hidden'>",
                                 "<input id='Convenio.ListaConvenioDescuento_000__Descripcion' name='Convenio.ListaConvenioDescuento[000].Descripcion' class='tmp-descripcion' value='", desc, "' type='hidden'>",
                                 "<input id='Convenio.ListaConvenioDescuento_000__FactorDcto' name='Convenio.ListaConvenioDescuento[000].FactorDcto' class='tmp-porcentaje' value='", porc, "' type='hidden'>",

                                 "</td>",
                               "</tr>"
                               );

                            body.append(row);

                        }

                    }
                };
                helperjs.popup(param);
            }
        };

        helperjs.ajaxSend(request);
    },

    quitaDescuento: function () {
        var body = $("#tab-descuentos tbody");
        $(body).find('input[type="checkbox"]:checked').each(function () {
            var tr = $(this).parent().parent();
            tr.remove();
        });
    },

    agregaServicio: function () {
        var request = {
            url: helperjs.urlBase + "Servicio/BuscadorIndex",
            data: {},
            success: function (data, textStatus, jqXhr) {
                var param = {
                    data: data,
                    modalTop: true,
                    id: "modal-buscador",
                    funcOk: function () {

                        if (!$(conveniojs.formBuscadorServicio).valid()) return false;

                        var body = $("#tab-servicios tbody");
                        var row = "";

                        var encontro = false;

                        var codServicio = $('#ConvenioServicio_IdServicio :selected').val();
                        var desServicio = $('#ConvenioServicio_IdServicio :selected').text();
                        var dscto = $("#ConvenioServicio_FactorDcto").val();
                        var base = $("#ConvenioServicio_TarifaBase").val();
                        var real = $("#ConvenioServicio_TarifaReal").val();

                        $("#tab-servicios tbody > tr").each(function () {
                            var tr = $(this);
                            var idServicio = tr.find("td > input.tmp-idServicio").get(0).value;

                            if (idServicio == codServicio) {
                                encontro = true;
                            }
                        });

                        if (!encontro) {

                            row = row.concat("",
                              "<tr>",
                                 "<td class='asistencia-column-left'>", desServicio, "</td>",
                                 "<td class='asistencia-column-right'>", dscto, "</td>",
                                 "<td class='asistencia-column-right'>", base, "</td>",
                                 "<td class='asistencia-column-right'>", real, "</td>",
                                 "<td class='asistencia-column-center'>",

                                 "<input class='sel singleCheckBox' id='0' type='checkbox' />",
                                 "<input id='Convenio.ListaConvenioServicio_000__IdServicio' name='Convenio.ListaConvenioServicio[000].IdServicio' class='tmp-idServicio' value='", codServicio, "' type='hidden'>",
                                 "<input id='Convenio.ListaConvenioServicio_000__FactorDcto' name='Convenio.ListaConvenioServicio[000].FactorDcto' class='tmp-descuento' value='", dscto, "' type='hidden'>",
                                 "<input id='Convenio.ListaConvenioServicio_000__TarifaBase' name='Convenio.ListaConvenioServicio[000].TarifaBase' class='tmp-base' value='", base, "' type='hidden'>",
                                 "<input id='Convenio.ListaConvenioServicio_000__TarifaReal' name='Convenio.ListaConvenioServicio[000].TarifaReal' class='tmp-real' value='", real, "' type='hidden'>",
                                 "</td>",
                               "</tr>"
                               );

                            body.append(row);

                        }

                    }
                };
                helperjs.popup(param);
            }
        };

        helperjs.ajaxSend(request);
    },

    quitaServicio: function () {
        var body = $("#tab-servicios tbody");
        $(body).find('input[type="checkbox"]:checked').each(function () {
            var tr = $(this).parent().parent();
            tr.remove();
        });
    },

    grabar: function () {
        $("#Guardar").on("click", function () {

            if (!$(conveniojs.formConvenio).valid()) return false;

            //Se ingresa al menos un servicio
            var rowCount = $('#tab-servicios tbody > tr').length;
            if (rowCount == 0) {
                helperjs.mostrarMensajes.warning('Registre al menos un servicio.');
                return false;
            } else {
                //Servicios
                var indexServicios = -1;
                $("#tab-servicios tbody > tr").each(function () {
                    indexServicios += 1;
                    var tr = $(this);

                    var idServicio = tr.find("td > input.tmp-idServicio").get(0);
                    idServicio.id = idServicio.id.replace("000", indexServicios);
                    idServicio.name = idServicio.name.replace("000", indexServicios);

                    var dscto = tr.find("td > input.tmp-descuento").get(0);
                    dscto.id = dscto.id.replace("000", indexServicios);
                    dscto.name = dscto.name.replace("000", indexServicios);

                    var base = tr.find("td > input.tmp-base").get(0);
                    base.id = base.id.replace("000", indexServicios);
                    base.name = base.name.replace("000", indexServicios);

                    var real = tr.find("td > input.tmp-real").get(0);
                    real.id = real.id.replace("000", indexServicios);
                    real.name = real.name.replace("000", indexServicios);

                });

                //Descuentos
                var indexDescuentos = -1;
                $("#tab-descuentos tbody > tr").each(function () {
                    indexDescuentos += 1;
                    var tr = $(this);

                    var minimo = tr.find("td > input.tmp-minimo").get(0);
                    minimo.id = minimo.id.replace("000", indexDescuentos);
                    minimo.name = minimo.name.replace("000", indexDescuentos);

                    var maximo = tr.find("td > input.tmp-maximo").get(0);
                    maximo.id = maximo.id.replace("000", indexDescuentos);
                    maximo.name = maximo.name.replace("000", indexDescuentos);

                    var descripcion = tr.find("td > input.tmp-descripcion").get(0);
                    descripcion.id = descripcion.id.replace("000", indexDescuentos);
                    descripcion.name = descripcion.name.replace("000", indexDescuentos);

                    var porcentaje = tr.find("td > input.tmp-porcentaje").get(0);
                    porcentaje.id = porcentaje.id.replace("000", indexDescuentos);
                    porcentaje.name = porcentaje.name.replace("000", indexDescuentos);

                });

                var url = $(conveniojs.formConvenio).attr('action');
                var convenioForm = $(conveniojs.formConvenio).serializeArray();
                helperjs.setPostUrl(url, convenioForm);
                return false;
            }
        });

    },

    seleccionaServicio: function () {
        $("#ConvenioServicio_IdServicio").change(function () {

            var idServicio = $('#ConvenioServicio_IdServicio :selected').val();

            if (idServicio == '') {
                idServicio = 0;
                $('#ConvenioServicio_TarifaBase').val(0);
                $('#ConvenioServicio_FactorDcto').val(0);
            }

            $.ajax({
                url: helperjs.urlBase + "Convenio/ObtenerServicio",
                data: { idServicio: idServicio },
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
                        $('#ConvenioServicio_TarifaBase').val(0);
                    }
                    else {
                        $('#ConvenioServicio_TarifaBase').val(data.TarifaBase);
                    }

                    conveniojs.calculaTarifaReal();
                }
            });



        });
    },

    ingresaDescuentoServicio: function () {
        $("#ConvenioServicio_FactorDcto").on("keyup", function () {
            conveniojs.calculaTarifaReal();
        });
    },

    calculaTarifaReal: function () {
        var real = $("#ConvenioServicio_TarifaReal");
        var base = $("#ConvenioServicio_TarifaBase").val();
        var dscto = $("#ConvenioServicio_FactorDcto").val();

        var _base = base == '' ? 0 : base == null ? 0 : parseFloat(base);
        var _dscto = dscto == '' ? 0 : dscto == null ? 0 : parseFloat(dscto);

        var tarifaReal = ((100 - dscto) / 100) * base;

        real.val(tarifaReal);

    }
};