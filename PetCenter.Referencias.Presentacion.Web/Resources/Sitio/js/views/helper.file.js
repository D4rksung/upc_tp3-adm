// MENSAJES Y ALERTAS
var helperFilejs = {

    /* ***** INI ****** */
    /* CARGA DE ARCHIVO */
    /* **************** */
    iniciar: function (req) {

        if (req == undefined) req = {};

        var sufCarga = "";
        if (req.sufijo != undefined)
            sufCarga = req.sufijo.toLowerCase();
        var urlFoto = req.urlFoto;

        var nombrearchivo = "#nombreArchivo" + sufCarga;
        //Ocultando opciones
        $("#opt-file" + sufCarga).hide();

        if (!helperjs.esIE()) {
            var namefile = "#NameFile" + sufCarga;
            var avance = "#avance" + sufCarga;
            var perup = "#perUp" + sufCarga;

            //Limpieza anterior
            $(namefile).val('');
            $(nombrearchivo).val('');

            $(namefile).change(function () {
                if (this.files.length <= 0) return false;
                var file = this.files[0];
                var name = file.name;
                var size = file.size;
                var tipo = file.type;
                var url = helperjs.urlCarga;
                if (!helperFilejs.extensionPermitida(file.name, $(this).attr("tipo"))) return false;
                if (size > 104857600) return false;/*TO-DO:configurar en web config este valor de subida*/
                if (size > 0) {
                    $(nombrearchivo).val("(" + helperjs.sizeToKMB(size) + ") " + name);

                    var formData = new FormData();
                    formData.append('fileStream', file);
                    formData.append('suf', sufCarga);

                    var forgeryToke = $("input[name='__RequestVerificationToken']").val();

                    if (forgeryToke != undefined && forgeryToke != null) {
                        formData.append('__RequestVerificationToken', forgeryToke);
                    }

                    $.ajax({
                        url: url,
                        type: 'POST',
                        beforeSend: function () {
                            $(avance).attr({ "aria-valuenow": "0" });
                            $(avance).width("0%");
                            $(perup).text('0%');
                        },
                        xhr: function () {
                            var myXhr = $.ajaxSettings.xhr();
                            if (myXhr.upload) {
                                myXhr.upload.addEventListener('progress', function (e) {
                                    if (e.lengthComputable) {
                                        $(avance).attr({ "aria-valuenow": e.loaded, 'aria-valuemax': e.total });
                                        var percent = e.loaded / e.total * 100;
                                        $(avance).width(percent.toFixed() + '%');
                                        $(perup).text(percent.toFixed() + '%');
                                    }
                                }, false);
                            }
                            return myXhr;
                        },
                        success: function (data, textStatus, jqXhr) {
                            var max = $(avance).attr('aria-valuemax');
                            if (max != "0") {
                                $(avance).attr({ "aria-valuenow": max });
                                $(avance).width("100%");
                                $(perup).text('100%');
                            }
                            else {
                                $(avance).attr({ "aria-valuenow": "0" });
                                $(avance).width("0%");
                                $(perup).text('0%');
                            }
                            //Mostrando opciones
                            $("#opt-file" + sufCarga).show();
                            var tam = parseInt($("#main-file" + sufCarga).attr("tam"));
                            $("#main-file" + sufCarga).removeClass("col-sm-" + tam);
                            $("#main-file" + sufCarga).addClass("col-sm-" + (tam - 1));

                            if (urlFoto != undefined && urlFoto != "")
                                helperFilejs.showFoto(urlFoto, sufCarga, true);
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            //TO-DO mensaje//helper.procesarErrorDefault(jqXhr, textStatus, errorThrown);
                        },
                        data: formData,
                        cache: false,
                        contentType: false,
                        processData: false
                    });
                } else {
                    //TO-DO mensaje mensaje.alerta("El tamaño del archivo es menor igual a cero.");
                }
            });
        }
        else {
            var esp_nombrearchivo = "esp_nombreArchivo" + sufCarga;
            var funChange = function () {
                if (this.value == "") return;
                if (!helperFilejs.extensionPermitida(this.value, $(this).attr("tipo"))) {
                    helperFilejs.removeFile(sufCarga, urlFoto);
                    return false;
                }
                var datax = { suf: sufCarga };

                var forgeryToke = $("input[name='__RequestVerificationToken']").val();

                if (forgeryToke != undefined && forgeryToke != null) {
                    datax.__RequestVerificationToken = forgeryToke;
                }

                $.ajaxFileUpload({
                    url: helperjs.urlCargaEsp,
                    secureuri: false,
                    fileElementId: esp_nombrearchivo,
                    data: datax,
                    dataType: 'json',
                    success: function (data, status, jqXhr) {
                        $("#" + esp_nombrearchivo).change(funChange);
                        //Mostrando opciones
                        $("#opt-file" + sufCarga).show();
                        var tam = parseInt($("#main-file" + sufCarga).attr("tam"));
                        $("#main-file" + sufCarga).removeClass("col-sm-" + tam);
                        $("#main-file" + sufCarga).addClass("col-sm-" + (tam - 1));

                        if (urlFoto != undefined && urlFoto != "")
                            helperFilejs.showFoto(urlFoto, sufCarga, true)
                    },
                    error: function (data, status, e) {
                        //TO-DO mensaje//helper.procesarErrorDefault(jqXhr, textStatus, errorThrown);
                    }
                });
            };

            $("#" + esp_nombrearchivo).change(funChange);
        }

        if (req.requerido === true) {

            var formFile = $(nombrearchivo).closest("form");
            var validator = $.data(formFile.get(0), "validator");
            if (validator == undefined) {
                formFile.validacionAsistencia();
            }
            $(nombrearchivo).rules("add", {
                required: true,
                messages: {
                    required: "Ingrese el archivo"
                }
            });

        }
        else {
            if (!helperjs.esIE())
                $(nombrearchivo).removeAttr("required");
        }
    },

    removeFile: function (suf, urlFoto) {
        var sufCarga = "";
        if (suf != undefined)
            sufCarga = suf.toLowerCase();

        if (!helperjs.esIE()) {
            var namefile = "#NameFile" + sufCarga;
            if ($(namefile).val() != "") {
                var nombrearchivo = "#nombreArchivo" + sufCarga;
                var avance = "#avance" + sufCarga;
                var perup = "#perUp" + sufCarga;
                $(namefile).val('');
                var newElement = $(namefile).clone();
                $(namefile).replaceWith(newElement);

                /****************************************/
                $(namefile).change(function () {
                    if (this.files.length <= 0) return false;
                    var file = this.files[0];
                    var name = file.name;
                    var size = file.size;
                    var tipo = file.type;
                    var url = helperjs.urlCarga;
                    if (!helperFilejs.extensionPermitida(file.name, $(this).attr("tipo"))) return false;
                    if (size > 104857600) return false;/*TO-DO:configurar en web config este valor de subida*/
                    if (size > 0) {
                        $(nombrearchivo).val("(" + helperjs.sizeToKMB(size) + ") " + name);

                        var formData = new FormData();
                        formData.append('fileStream', file);
                        formData.append('suf', sufCarga);

                        var forgeryToke = $("input[name='__RequestVerificationToken']").val();

                        if (forgeryToke != undefined && forgeryToke != null) {
                            formData.append('__RequestVerificationToken', forgeryToke);
                        }

                        $.ajax({
                            url: url,
                            type: 'POST',
                            beforeSend: function () {
                                $(avance).attr({ "aria-valuenow": "0" });
                                $(avance).width("0%");
                                $(perup).text('0%');
                            },
                            xhr: function () {
                                var myXhr = $.ajaxSettings.xhr();
                                if (myXhr.upload) {
                                    myXhr.upload.addEventListener('progress', function (e) {
                                        if (e.lengthComputable) {
                                            $(avance).attr({ "aria-valuenow": e.loaded, 'aria-valuemax': e.total });
                                            var percent = e.loaded / e.total * 100;
                                            $(avance).width(percent.toFixed() + '%');
                                            $(perup).text(percent.toFixed() + '%');
                                        }
                                    }, false);
                                }
                                return myXhr;
                            },
                            success: function (data, textStatus, jqXhr) {
                                var max = $(avance).attr('aria-valuemax');
                                if (max != "0") {
                                    $(avance).attr({ "aria-valuenow": max });
                                    $(avance).width("100%");
                                    $(perup).text('100%');
                                }
                                else {
                                    $(avance).attr({ "aria-valuenow": "0" });
                                    $(avance).width("0%");
                                    $(perup).text('0%');
                                }
                                //Mostrando opciones
                                $("#opt-file" + sufCarga).show();
                                var tam = parseInt($("#main-file" + sufCarga).attr("tam"));
                                $("#main-file" + sufCarga).removeClass("col-sm-" + tam);
                                $("#main-file" + sufCarga).addClass("col-sm-" + (tam - 1));

                                if (urlFoto != undefined && urlFoto != "")
                                    helperFilejs.showFoto(urlFoto, sufCarga, true)
                            },
                            error: function (jqXhr, textStatus, errorThrown) {
                                //TO-DO mensaje//helper.procesarErrorDefault(jqXhr, textStatus, errorThrown);
                            },
                            data: formData,
                            cache: false,
                            contentType: false,
                            processData: false
                        });
                    } else {
                        //TO-DO mensaje mensaje.alerta("El tamaño del archivo es menor igual a cero.");
                    }
                });
                /****************************************/

                $(nombrearchivo).val('');
                $(avance).attr({ "aria-valuenow": "0" });
                $(avance).width("0%");
                $(perup).text('0%');

                helperjs.ajaxSend({
                    url: helperjs.urlBase + "Base/LimpiarTemporalArchivo",
                    data: { suf: sufCarga },
                    success: function () {
                        //Ocultando opciones
                        $("#opt-file" + sufCarga).hide();
                        var tam = parseInt($("#main-file" + sufCarga).attr("tam"));
                        $("#main-file" + sufCarga).removeClass("col-sm-" + (tam - 1));
                        $("#main-file" + sufCarga).addClass("col-sm-" + tam);
                    }
                });

            }

        }
        else {
            var esp_nombrearchivo = "#esp_nombreArchivo" + sufCarga;
            if ($(esp_nombrearchivo).get(0).value != "") {
                var newElement = $(esp_nombrearchivo).clone();
                $(esp_nombrearchivo).replaceWith(newElement);

                var funChange = function () {
                    if (this.value == "") return;
                    if (!helperFilejs.extensionPermitida(this.value, $(this).attr("tipo"))) {
                        helperFilejs.removeFile(sufCarga, urlFoto);
                        return false;
                    }
                    var datax = { suf: sufCarga };

                    var forgeryToke = $("input[name='__RequestVerificationToken']").val();

                    if (forgeryToke != undefined && forgeryToke != null) {
                        datax.__RequestVerificationToken = forgeryToke;
                    }

                    $.ajaxFileUpload({
                        url: helperjs.urlCargaEsp,
                        secureuri: false,
                        fileElementId: esp_nombrearchivo.replace("#", ""),
                        data: datax,
                        dataType: 'json',
                        success: function (data, status, jqXhr) {
                            $(esp_nombrearchivo).change(funChange);
                            //Mostrando opciones
                            $("#opt-file" + sufCarga).show();
                            var tam = parseInt($("#main-file" + sufCarga).attr("tam"));
                            $("#main-file" + sufCarga).removeClass("col-sm-" + tam);
                            $("#main-file" + sufCarga).addClass("col-sm-" + (tam - 1));

                            if (urlFoto != undefined && urlFoto != "")
                                helperFilejs.showFoto(urlFoto, sufCarga, true)
                        },
                        error: function (data, status, e) {
                            //TO-DO mensaje//helper.procesarErrorDefault(jqXhr, textStatus, errorThrown);
                        }
                    });
                };

                $(esp_nombrearchivo).change(funChange);

                helperjs.ajaxSend({
                    url: helperjs.urlBase + "Base/LimpiarTemporalArchivo",
                    data: { suf: sufCarga },
                    success: function () {
                        //Ocultando opciones
                        $("#opt-file" + sufCarga).hide();
                        var tam = parseInt($("#main-file" + sufCarga).attr("tam"));
                        $("#main-file" + sufCarga).removeClass("col-sm-" + (tam - 1));
                        $("#main-file" + sufCarga).addClass("col-sm-" + tam);
                    }
                });
            }
        }

        if (urlFoto != undefined && urlFoto != "") {
            $("#imageContainer").remove();
            $('<iframe>', { id: 'imageContainer', src: "javascript:''" }).addClass("asistencia-foto").appendTo("#show-foto");
        }

    },

    showFile: function (suf) {
        var sufCarga = "";
        if (suf != undefined)
            sufCarga = suf.toLowerCase();

        var url = helperjs.urlBase + "Base/VerCargaTemporal?suf=" + sufCarga;
        var namefile = "";
        if (!helperjs.esIE())
            namefile = "#NameFile" + sufCarga;
        else
            namefile = "#esp_nombreArchivo" + sufCarga;

        if ($(namefile).get(0).value != "")
            helperFilejs.downloadFile(url, "#" + $(namefile).closest('form').attr("id"));

    },

    showFoto: function (url, sufCarga, verFotoTmp) {
        url = helperjs.urlBase + url;
        $("#imageContainer").remove();
        if (verFotoTmp === true) {
            $('<iframe>', { id: 'imageContainer', name: 'imageContainer', src: url + "?verFotoTmp=" + verFotoTmp + "&sufCarga=" + sufCarga }).addClass("asistencia-foto").appendTo("#show-foto");
        }
        else {
            $('<iframe>', { id: 'imageContainer', name: 'imageContainer', src: url }).addClass("asistencia-foto").appendTo("#show-foto");
        }

    },

    /* INI FILTRO ARCHIVO */

    extensionPermitida: function (nameFile, tipo) {

        if (tipo == "") return true;//Todo las extensiones

        var extArray = new Array();

        if (tipo == "IMAGEN") {
            extArray = new Array(".gif", ".jpg", ".png", ".tif");
        }
        else if (tipo == "FOTO") {
            extArray = new Array(".jpg", ".bmp", ".gif", ".png");
        }
        else if (tipo == "FLASH") {
            extArray = new Array(".swf");
        }
        else if (tipo == "APLICACION") {
            extArray = new Array(".exe", ".sit", ".zip", ".tar", ".swf", ".mov", ".hqx", ".ra", ".wmf", ".mp3", ".qt", ".med", ".et");
        }
        else if (tipo == "VIDEO") {
            extArray = new Array(".mov", ".ra", ".wmf", ".mp3", ".qt", ".med", ".et", ".wav");
        }
        else if (tipo == "WEB") {
            extArray = new Array(".html", ".htm", ".shtml");
        }
        else if (tipo == "DOCUMENTO") {
            extArray = new Array(".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pdf", ".txt");
        }
        else if (tipo == "DOCUMENTO_SUSTENTO") {
            extArray = new Array(".doc", ".docx", ".pdf");
        }
        else if (tipo == "DATA") {
            extArray = new Array(".dat");
        }

        var coincide = false;

        while (nameFile.indexOf("\\") != -1)
            nameFile = nameFile.slice(nameFile.indexOf("\\") + 1);

        var ext = nameFile.slice(nameFile.lastIndexOf(".")).toLowerCase();

        for (var i = 0; i < extArray.length; i++) {
            if (extArray[i] == ext) {
                coincide = true;
                break;
            }
        }
        if (!coincide) {
            var param = {
                mensaje: "Usted sólo puede subir archivos tipo <b>" + tipo + "</b> con extensiones " + (extArray.join(" ")) + "<br/>Por favor seleccione un nuevo archivo"
            };
            helperjs.alertar(param);
        }

        return coincide;
    },

    /* FIN FILTRO ARCHIVO */

    /* ***** FIN ****** */
    /* CARGA DE ARCHIVO */
    /* **************** */

    /* ******* INI ******* */
    /* DESCARGA DE ARCHIVO */
    /* ******************* */

    downloadFile: function (url, idForm) {
        var $idown = $("#fileContainer");
        if ($idown.length) {
            $idown.attr('src', url);
        } else {
            $('<iframe>', { id: 'fileContainer', src: url }).hide().appendTo(idForm);
        }
    }

    /* ******* FIN ******* */
    /* DESCARGA DE ARCHIVO */
    /* ******************* */
};