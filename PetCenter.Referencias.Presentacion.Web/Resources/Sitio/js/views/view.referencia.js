var referenciajs = {

    formBuscaConvenio: "#formBuscaConvenio",
    formReferencia: "#formReferencia",
    formReferenciaServicio: "#formReferenciaServicio",

    iniciar: function () {

        $("#Convenio_NroConvenio").numeric(false);
        $("#ReferenciaConvenioServicio_Cantidad").numeric(false);
    },

    validacionesBuscarConvenio: function () {
        $(this.formBuscaConvenio).validacionAsistencia({
            rules: {
                'Convenio.NroConvenio': {
                    required: true
                }
            },
            messages: {
                'Convenio.NroConvenio': {
                    required: 'Ingrese Nro de Convenio',
                }
            }
        });

    },

    configurarTabs: function () {
        $('#tabReferencia a').click(function (e) {
            e.preventDefault()
            $(this).tab('show');
        });
    },

    abrePopup: function (codMascota, nombre, raza, especie, fnac) {
        referenciajs.mascotaKey(codMascota, nombre, raza, especie, fnac);
    },

    mascotaKey: function (codMascota, nombre, raza, especie, fnac) {
        var idCliente = $('#Convenio_IdCliente').val();

        var request = {
            url: "Mascota/BuscadorIndex",
            data: {
                idCliente: idCliente
            },
            codMascota: codMascota,
            nombre: nombre,
            raza: raza,
            especie: especie,
            fnac: fnac
        };

        mascotajs.buscarKeyMascota(request);

    },

    agregarConvenioServicio: function () {

        var idConvenio = $("#Convenio_NroConvenio").val();

        var request = {
            url: helperjs.urlBase + "ReferenciaServicio/BuscadorIndex",
            data: { idConvenio: idConvenio },
            success: function (data, textStatus, jqXhr) {
                var param = {
                    data: data,
                    modalTop: true,
                    id: "modal-buscador",
                    funcOk: function () {

                        if (!$(referenciajs.formReferenciaServicio).valid()) return false;

                        var body = $("#tab-refServicios tbody");
                        var row = "";

                        var encontro = false;

                        var codServicio = $("#ReferenciaConvenioServicio_IdServicio :selected").val();
                        var desServicio = $("#ReferenciaConvenioServicio_IdServicio :selected").text();
                        var real = $("#ConvenioServicio_TarifaReal").val();
                        var base = $("#ConvenioServicio_TarifaBase").val();
                        var dscto = $("#ConvenioServicio_FactorDcto").val();
                        var cantidad = $("#ReferenciaConvenioServicio_Cantidad").val();
                        var observaciones = $("#ReferenciaConvenioServicio_Observaciones").val();
                        var nroConvenio = $('#Convenio_NroConvenio').val();
                        var valorBruto = parseFloat(cantidad) * parseFloat(base);
                        var valorNeto = ((100 - parseFloat(dscto)) / 100) * valorBruto;
                      
                        $("#tab-refServicios tbody > tr").each(function () {
                            var tr = $(this);
                            var idServicio = tr.find("td > input.tmp-idservicio").get(0).value;

                            if (idServicio == codServicio) {
                                encontro = true;
                            }
                        });

                        if (!encontro) {

                            row = row.concat("",
                              "<tr>",
                                 "<td class='asistencia-column-center'>", desServicio, "</td>",
                                 "<td class='asistencia-column-center'>", cantidad, "</td>",
                                 "<td class='asistencia-column-center'>", base, "</td>",
                                 "<td class='asistencia-column-center'>", dscto, "</td>",
                                 "<td class='asistencia-column-center'>", real, "</td>",
                                 "<td class='asistencia-column-center'>", observaciones, "</td>",
                                 "<td class='asistencia-column-center'>",

                                 "<input class='sel singleCheckBox' id='0' type='checkbox' />",
                                 "<input id='Referencia.ListaReferenciaConvenioServicio_000__IdServicio' name='Referencia.ListaReferenciaConvenioServicio[000].IdServicio' class='tmp-idservicio' value='", codServicio, "' type='hidden'>",
                                 "<input id='Referencia.ListaReferenciaConvenioServicio_000__NroConvenio' name='Referencia.ListaReferenciaConvenioServicio[000].NroConvenio' class='tmp-nroconvenio' value='", nroConvenio, "' type='hidden'>",
                                 "<input id='Referencia.ListaReferenciaConvenioServicio_000__Cantidad' name='Referencia.ListaReferenciaConvenioServicio[000].Cantidad' class='tmp-cantidad' value='", cantidad, "' type='hidden'>",
                                 "<input id='Referencia.ListaReferenciaConvenioServicio_000__Observaciones' name='Referencia.ListaReferenciaConvenioServicio[000].Observaciones' class='tmp-observaciones' value='", observaciones, "' type='hidden'>",
                                 "<input id='Referencia.ListaReferenciaConvenioServicio_000__TarifaBase' name='Referencia.ListaReferenciaConvenioServicio[000].TarifaBase' class='tmp-tarifabase' value='", base, "' type='hidden'>",
                                 "<input id='Referencia.ListaReferenciaConvenioServicio_000__ValorBruto' name='Referencia.ListaReferenciaConvenioServicio[000].ValorBruto' class='tmp-valorbruto' value='", valorBruto, "' type='hidden'>",
                                 "<input id='Referencia.ListaReferenciaConvenioServicio_000__Descuento' name='Referencia.ListaReferenciaConvenioServicio[000].Descuento' class='tmp-descuento' value='", dscto, "' type='hidden'>",
                                 "<input id='Referencia.ListaReferenciaConvenioServicio_000__ValorNeto' name='Referencia.ListaReferenciaConvenioServicio[000].ValorNeto' class='tmp-valorneto' value='", valorNeto, "' type='hidden'>",

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

    validacionesBuscarConvenioServicio: function () {
        $(this.formReferenciaServicio).validacionAsistencia({
            rules: {
                'ReferenciaConvenioServicio.IdServicio': {
                    required: true
                },
                'ReferenciaConvenioServicio.Cantidad': {
                    required: true,
                    numeroMayorCero: true,
                    noEspeciales: sitiojs.caracter_restringido_numero,
                },
                'ReferenciaConvenioServicio.Observaciones': {
                    required: true
                }
            },
            messages: {
                'ReferenciaConvenioServicio.IdServicio': {
                    required: 'Ingrese Servicio',
                },
                'ReferenciaConvenioServicio.Cantidad': {
                    required: 'Ingrese Cantidad',
                    numeroMayorCero: 'Ingrese mayor a 0',
                    noEspeciales: 'No ingrese caracteres especiales',
                },
                'ReferenciaConvenioServicio.Observaciones': {
                    required: 'Ingrese Observaciones'
                },
            }
        });
    },

    seleccioneConvenioServicio: function () {
        $("#ReferenciaConvenioServicio_IdServicio").change(function () {

            var idServicio = $('#ReferenciaConvenioServicio_IdServicio :selected').val();
            var nroConvenio = $('#Convenio_NroConvenio').val();

            if (idServicio == '') idServicio = 0;
            if (nroConvenio == '') nroConvenio = 0;

            $.ajax({
                url: helperjs.urlBase + "ReferenciaServicio/ObtenerConvenioServicio",
                data: { idServicio: idServicio, nroConvenio: nroConvenio },
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                type: "GET",
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                },
                success: function (data) {

                    if (data == null) {
                        $('#ReferenciaConvenioServicio_NroConvenio').val(0);
                        $('#ConvenioServicio_FactorDcto').val(0);
                        $('#ConvenioServicio_TarifaBase').val(0);
                        $('#ConvenioServicio_TarifaReal').val(0);
                        $('#ReferenciaConvenioServicio_Cantidad').val(0);
                    }
                    else {
                        $('#ReferenciaConvenioServicio_NroConvenio').val(data.NroConvenio);
                        $('#ConvenioServicio_FactorDcto').val(data.FactorDcto);
                        $('#ConvenioServicio_TarifaBase').val(data.TarifaBase);
                        $('#ConvenioServicio_TarifaReal').val(data.TarifaReal);
                    }
                }
            });
        });
    },

    calculaReal: function () {
        $("#ReferenciaConvenioServicio_Cantidad").on("keyup", function () {
            var codConvenioReferencia = $('#ReferenciaConvenioServicio_IdConvenioServicio :selected').val();
            var real = $("#ReferenciaConvenioServicio_Real");
            var base = $("#ReferenciaConvenioServicio_Base");
            var dscto = $("#ReferenciaConvenioServicio_Descuento");
            var cantidad = $("#ReferenciaConvenioServicio_Cantidad");

            if (codConvenioReferencia == '') {
                real.val(0);
            } else {
                var _dscto = ((100 - parseFloat(dscto.val())) / 100) * (parseFloat(cantidad.val()) * parseFloat(base.val()));
                real.val(_dscto.toFixed(2));
                //console.log(dscto.val());
                //console.log(dscto.val());
            }

        });
    },

    quitarConvenioServicio: function () {
        var body = $("#tab-refServicios tbody");
        $(body).find('input[type="checkbox"]:checked').each(function () {
            var tr = $(this).parent().parent();
            tr.remove();
        });
    },

    grabar: function () {
        $("#btn-continuar-3").on("click", function () {

            //valida si se ha ingresado mascota
            var idMascota = $('#Mascota_IdMascota').val();
            if (idMascota == '' || idMascota == null || idMascota == 0) {
                helperjs.mostrarMensajes.warning('Seleccione una mascota.');
                return false;
            }

            //valida si se ha registrado al menos 1 servicio
            var rowCount = $('#tab-refServicios tbody > tr').length;
            if (rowCount == 0) {
                helperjs.mostrarMensajes.warning('Registre al menos un servicio.');
                return false;
            }

            var indexServicios = -1;
            $("#tab-refServicios tbody > tr").each(function () {
                indexServicios += 1;
                var tr = $(this);

                var idservicio = tr.find("td > input.tmp-idservicio").get(0);
                idservicio.id = idservicio.id.replace("000", indexServicios);
                idservicio.name = idservicio.name.replace("000", indexServicios);

                var nroconvenio = tr.find("td > input.tmp-nroconvenio").get(0);
                nroconvenio.id = nroconvenio.id.replace("000", indexServicios);
                nroconvenio.name = nroconvenio.name.replace("000", indexServicios);

                var cantidad = tr.find("td > input.tmp-cantidad").get(0);
                cantidad.id = cantidad.id.replace("000", indexServicios);
                cantidad.name = cantidad.name.replace("000", indexServicios);

                var observaciones = tr.find("td > input.tmp-observaciones").get(0);
                observaciones.id = observaciones.id.replace("000", indexServicios);
                observaciones.name = observaciones.name.replace("000", indexServicios);

                var tarifabase = tr.find("td > input.tmp-tarifabase").get(0);
                tarifabase.id = tarifabase.id.replace("000", indexServicios);
                tarifabase.name = tarifabase.name.replace("000", indexServicios);

                var valorbruto = tr.find("td > input.tmp-valorbruto").get(0);
                valorbruto.id = valorbruto.id.replace("000", indexServicios);
                valorbruto.name = valorbruto.name.replace("000", indexServicios);

                var descuento = tr.find("td > input.tmp-descuento").get(0);
                descuento.id = descuento.id.replace("000", indexServicios);
                descuento.name = descuento.name.replace("000", indexServicios);

                var valorneto = tr.find("td > input.tmp-valorneto").get(0);
                valorneto.id = valorneto.id.replace("000", indexServicios);
                valorneto.name = valorneto.name.replace("000", indexServicios);

            });

            var url = $(referenciajs.formReferencia).attr('action');
            var referenciaForm = $(referenciajs.formReferencia).serializeArray();
            helperjs.setPostUrl(url, referenciaForm);
            return false;

        });
    }
};