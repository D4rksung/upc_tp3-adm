$.ajaxSetup({ cache: false });

$(document).ajaxStart(function () {
    helperjs.showWait();
});

$(document).ajaxStop(function () {
    helperjs.hideWait();
});


var sitiojs = {


    titulo: "#web-title",
    caracter_restringido_default: "<$%&()",
    caracter_restringido_nombres: "</*#$@%&(!|°¬~^¡?¿)>",
    caracter_restringido_input_consulta: "</*#$@%&(!|°¬~^¡?¿)>" + '"',
    caracter_restringido_extension_archivo: "<1234567890ñÑ+-;=/*#$@%&(!|°¬~^¡?¿)>" + '"',
    caracter_restringido_correo: "</*#$+'%&(!|°¬~^¡?¿)>ñáéíóúÑÁÉÍÓÚ" + '"',
    caracter_correo: "@abcdefghijklmnopqrstuvwxyz0123456789._-",
    caracter_restringido_numero: "@</*#$+'%&(!|°¬~^¡?¿)>" + '"',
    caracter_restringido_telefono: "</$+'%&(!|°¬~^¡?¿)>" + '"',
    caracter_restringido_input_descripcion: "</*#$@%&!|°¬~^¡?¿>" + '"',
    caracter_Fecha_Hora: "1234567890/: ",

    cteDias: 86400000,//1000 * 60 * 60 * 24,
    cteMeses: 2629152000,//cteDias * 30.43,
    cteAnios: 31549824000,//cteMeses * 12,

    caracter_abcde: "abcdeABCDE'",

    validaNavegacion: false,

    iniciar: function () {

        //$('#wait').hide();
        //$('#waitImg').hide();
        helperjs.hideWait();

        var body = $("#site-body");
        var menu = $("#site-menu");
        var menu_a = $("#site-menu-a");
        var tempMenu = $.cookie("menu");
        var tempSubMenu = $.cookie("submenu");

        //notificacionjs.AlertasNotificaciones();

        if (tempMenu != undefined) {
            if (tempMenu == 'hide') {
                //menu.show();
                menu.removeClass("display");//
                body.removeClass("col-md-12");
                body.addClass("col-md-9");
                menu_a.addClass("hide");
            }
            else if (tempMenu == 'show') {
                //menu.hide();
                menu.css("display", "none");//
                body.removeClass("col-md-9");
                body.addClass("col-md-12");
                menu_a.removeClass("hide");
            }
        }

        if (tempSubMenu != undefined)
            $(tempSubMenu).addClass("in");

        //asistencia-menu
        $(".asistencia-menu").on("click", function () {
            var id = $(this).attr("href");

            if (!$(id).hasClass('in')) {
                $.cookie("submenu", id, { path: '/' });

                $('#accordion .panel-collapse').on('shown.bs.collapse', function () {
                    $(this).prev().find(".glyphicon").removeClass("glyphicon-triangle-right").addClass("glyphicon-triangle-bottom");
                });

            } else {
                $.removeCookie('submenu', { path: '/' })

                $('#accordion .panel-collapse').on('hidden.bs.collapse', function () {
                    $(this).prev().find(".glyphicon").removeClass("glyphicon-triangle-bottom").addClass("glyphicon-triangle-right");
                });
            }
        });

        //Incializando para todas las ventadas
        this.inciarParaTodos();

        //Iniciar tamaño reportes
        if (tempMenu != undefined) {
            if (tempMenu == 'hide') {
                $(".asistencia-report").height($("#asistencia-body").height() - 77);
            }
            else if (tempMenu == 'show') {
                $(".asistencia-report").height(helperjs.altoDisponible() - 140);
            }
        }
        else
            $(".asistencia-report").height($("#asistencia-body").height() - 77);
        //
        $("form").submit(function (event) {
            var id = this.id;
            if (!$("#" + id).valid()) return false;
        });
        //Evaluando si es IE <= 9
        if (!helperjs.esIE())
            $("html").addClass('noie');
        //else {
        //    $("form").submit(function (event) {
        //        var id = this.id;
        //        if (!$("#" + id).valid()) return false;
        //    });
        //}

        $("form").submit(function (event) {

            //if (helperjs.esIE()) {
            //    var id = this.id;
            //    if (!$("#" + id).valid()) return false;
            //}

            var id = this.id;
            if (!$("#" + id).valid()) return false;

            helperjs.showWait();


        });

        $("a").click(function (event) {
            var link = $(this);
            var href = link.attr("href");
            if (href != undefined && href != "" && href != "#" && href.indexOf("/") >= 0) {
                //helperjs.showWait();
            }
        });
    },

    animarMenu: function () {
        var body = $("#site-body");
        var menu = $("#site-menu");
        var menu_a = $("#site-menu-a");

        if (menu.is(':hidden')) {
            body.removeClass("col-md-12");
            body.addClass("col-md-9");
            menu.slideDown();
            menu_a.addClass("hide");
            $.cookie("menu", "hide", { path: '/' });
        }
        else {
            menu.slideUp(function () {
                body.removeClass("col-md-9");
                body.addClass("col-md-12");
                menu_a.removeClass("hide");
                $.cookie("menu", "show", { path: '/' });
            });
        }
    },

    inciarParaTodos: function () {

        //Tooltip
        $("[title]").tooltip();

        //Fechas
        $(".asistencia-fecha-corta").datepicker({
            format: 'dd/mm/yyyy',
            autoclose: true,
            language: "es",
            todayHighlight: true,
            todayBtn: "linked"
        });

        //Fechas
        $(".asistencia-fecha-hora-corta").datetimepicker({
            format: 'dd/mm/yyyy hh:ii',
            language: "es",
            todayBtn: true,
            todayHighlight: true,
            autoclose: true,
            pickerPosition: "top-right"
        });

        //Hora
        $(".asistencia-hora-corta").timepicker({
            minuteStep: 5,
            template: false,
            showMeridian: false,
            defaultTime: "empty"
        });

        //Métodos de validación
        $.validator.addMethod("datetime", function (value, element) {
            return Date.parseExact(value, "d/M/yyyy HH:mm");
        });

        $.validator.addMethod("date", function (value, element) {
            return Date.parseExact(value, 'd/M/yyyy');
        });

        // no permiter enter en text área
        $('textarea[maxlength]').keypress(function (e) {
            if (e.keyCode == 13) {
                return false;
            }
        });

        $('input[type="text"]').keypress(sitiojs.validacionCaracter);

        $('textarea').keypress(sitiojs.validacionCaracter);

        $.validator.addMethod("dateMayorIgual", function (value, element, dependenceId) {
            if (dependenceId != "") {
                var fecv1 = value;
                var fecv2 = $.trim($('#' + dependenceId).val());
                if (fecv2 == "" || fecv2 == null) return true;

                if (fecv1 == undefined) return false;
                if (fecv1 == "") return false;
                if (fecv1.length != 10 && fecv1.length != 16) return false;
                var date1 = helperjs.fecha_conver(fecv1);

                if (fecv2 == undefined) return false;
                if (fecv2 == "") return false;
                if (fecv2.length != 10 && fecv2.length != 16) return false;
                var date2 = helperjs.fecha_conver(fecv2);

                if (date1 >= date2) return true;
            }
            return false;
        });

        $.validator.addMethod("dateMenor", function (value, element, dependenceId) {
            if (dependenceId != "") {
                var fecv1 = value;
                var fecv2 = $.trim($('#' + dependenceId).val());
                if (fecv2 == "" || fecv2 == null) return true;

                if (fecv1 == undefined) return false;
                if (fecv1 == "") return false;
                if (fecv1.length != 10 && fecv1.length != 16) return false;
                var date1 = helperjs.fecha_conver(fecv1);

                if (fecv2 == undefined) return false;
                if (fecv2 == "") return false;
                if (fecv2.length != 10 && fecv2.length != 16) return false;
                var date2 = helperjs.fecha_conver(fecv2);

                if (date1 < date2) return true;
            }
            return false;
        });

        $.validator.addMethod("anio", function (value, element, dependenceId) {
            var fecha = Date.parse(value);
            var cadena = fecha.toString();
            var anio = cadena.substr(11, 4);
            var referencia = $.trim($('#' + dependenceId).val());
            if (anio != referencia) return false;
            return true;
        });

        $.validator.addMethod("igualA", function (value, element, dependenceId) {
            if (dependenceId != "") {
                var valor1 = value;
                var valor2 = $.trim($('#' + dependenceId).val());
                if (valor2 == "" || valor2 == null) return true;

                if (valor1 == undefined) return false;
                if (valor1 == "") return false;

                if (valor1 == valor2) return true;
            }
            return false;
        });

        $.validator.addMethod("diferenteA", function (value, element, dependenceId) {
            if (dependenceId != "") {
                var valor1 = value;
                var valor2 = $.trim($('#' + dependenceId).val());
                if (valor2 == "" || valor2 == null) return true;

                if (valor1 == undefined) return false;
                if (valor1 == "") return false;

                if (valor1 != valor2) return true;
            }
            return false;
        });

        sitiojs.addMethodNoEspeciales();
        sitiojs.addMethodCorreoExiste();

        $.validator.addMethod("horaMayorIgual", function (value, element, dependenceId) {
            if (dependenceId != "") {
                var hora1 = value.substr(0, 5);
                var hora2 = $.trim($('#' + dependenceId).val().substr(0, 5));
                if (hora2 == "" || hora2 == null) return true;

                if (hora1 == undefined) return false;
                if (hora1 == "") return false;
                if (hora1.length > 5) return false;
                if (hora1.length <= 2) hora1 = parseInt(hora1) + ":00";
                var date1 = helperjs.hora(hora1);

                if (hora2 == undefined) return false;
                if (hora2 == "") return false;
                if (hora2.length > 5) return false;
                if (hora2.length <= 2) hora2 = parseInt(hora2) + ":00";
                var date2 = helperjs.hora(hora2);

                if (parseInt(date1) >= parseInt(date2)) return true;
            }
            return false;
        });

        $.validator.addMethod("numeroMayorCero", function (value, element) {
            if (value == undefined) return false;
            if (value == "") return false;
            if (parseInt(value) > 0) return true;
            return false;
        });

        $.validator.addMethod("numeroMayorIgualCero", function (value, element) {
            if (value == undefined) return false;
            if (value == "") return false;
            if (parseInt(value) >= 0) return true;
            return false;
        });

        $.validator.addMethod("numeroMenorQue", function (value, element, dependenceId) {
            var numero = $.trim($('#' + dependenceId).val());
            if (value == undefined) return false;
            if (numero == undefined) return false;
            if (value == "") return false;
            if (numero == "") return false;
            if (parseInt(value) < parseInt(numero)) return true;
            return false;
        });

        $.validator.addMethod("numeroMayorCeroVacio", function (value, element) {
            if (value == undefined) return false;
            if (value == "") return true;
            if (parseInt(value) > 0) return true;
            return false;
        });
        $.validator.addMethod("contraseniaIgual", function (value, element, dependenceId) {
            debugger;

            var contrasenianuevarepetida = $("#" + dependenceId).val();
            if (value != contrasenianuevarepetida)
                return false
            else
                return true;

        });
        $.validator.addMethod("cantidadCaracteres", function (value, element) {
            debugger;
            var cantidad = value;
            if (cantidad.length < 6)
                return false
            else
                return true;

        });
        $.validator.addMethod("cantidad11Caracteres", function (value, element) {
            // debugger;
            var cantidad = value;
            if (cantidad.length < 11)
                return false
            else
                return true;

        });

    },

    cerrarsesion: function () {
        //$("#btncerrarsesion").on("click", function () {
        var url = helperjs.urlBase + "Inicio/CerrarSesion";
        $.ajax({
            type: 'POST',
            url: url,
            data: {
                idusuario: ""
            }
        }).done(function (response) {
            if (response.url != "") {
                window.location = response.url;
            }
            else {
                window.close();
            }
        });
        //});
    },

    inicioBandeja: function () {
        var url = helperjs.urlBase + "Inicio/Index";
        $.ajax({
            type: 'POST',
            url: url,
            data: {

            }
        }).done(function (response) {
            if (response.url != "") {
                window.location = response.url;
            }
            else {
                window.close();
            }
        });
    },

    validacionCaracter: function (e) {
        var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
        var val = String.fromCharCode(key);
        if (key == 13 && this.nodeName.toLowerCase() == "input") {
            return true;
        } else if (key == 13) {
            return false;
        }
        // allow Ctrl+A
        if ((e.ctrlKey && key == 97 /* firefox */) || (e.ctrlKey && key == 65) /* opera */) return true;
        // allow Ctrl+X (cut)
        if ((e.ctrlKey && key == 120 /* firefox */) || (e.ctrlKey && key == 88) /* opera */) return true;
        // allow Ctrl+C (copy)
        if ((e.ctrlKey && key == 99 /* firefox */) || (e.ctrlKey && key == 67) /* opera */) return true;
        // allow Ctrl+Z (undo)
        if ((e.ctrlKey && key == 122 /* firefox */) || (e.ctrlKey && key == 90) /* opera */) return true;
        // allow or deny Ctrl+V (paste), Shift+Ins
        if ((e.ctrlKey && key == 118 /* firefox */) || (e.ctrlKey && key == 86) /* opera */ || (e.shiftKey && key == 45)) {
            return true;
        }
        if (e.key != undefined && e.key != "MozPrintableKey" && e.key != val && (
        key == 8/* backspace */ ||
        key == 9 /* tab */ ||
        key == 13 /* enter */ ||
        key == 35 /* end */ ||
        key == 36 /* home */ ||
        key == 37 /* left */ ||
        key == 39 /* right */ ||
        key == 46 /* del */)) {
            return true;
        }

        var $this = $(this);

        if ($this.hasClass('respuesta')) {
            if (sitiojs.caracter_abcde.indexOf(val) > -1)
                return true;
            return false;
        }
        else if ($this.hasClass('only_otros')) {//Otras clases
            //if (casos) se puede fusionar varios casos
            //    return true;
            //return false;
        }
        else if ($this.hasClass('only_extension_archivo')) {
            if (sitiojs.caracter_restringido_extension_archivo.toString().indexOf(val) != -1)
                return false;
            return true;
        }
        else if ($this.hasClass('only_consulta')) {
            if (sitiojs.caracter_restringido_input_consulta.toString().indexOf(val) != -1)
                return false;
            return true;
        }
        else if ($this.hasClass('only_descripcion')) {
            if (sitiojs.caracter_restringido_input_descripcion.toString().indexOf(val) != -1)
                return false;
            return true;
        }
        else {
            if (sitiojs.caracter_restringido_default.indexOf(val) > -1)
                return false;
            return true;
        }
    },

    addMethodNoEspeciales: function () {
        $.validator.addMethod("noEspeciales", function (campo, element, caracteresEspeciales) {
            for (var i = 0; i < campo.length; i++) {
                if (caracteresEspeciales.indexOf(campo[i]) > -1) return false;
            }
            return true;
        });
    },

    addMethodCorreoExiste: function () {
        $.validator.addMethod("correoExiste", function (campo, element, dependenceId) {

            var correo = $.trim($('#' + dependenceId).val());

            var retorno = false;
            $.ajax({
                url: helperjs.urlBase + "Persona/ValidarCorreoExistente",
                data: { email: correo },
                dataType: "json",
                timeout: 2000,
                async: false,
                contentType: "application/json; charset=utf-8",
                type: "GET",
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                },
                success: function (data) {
                    if (data) {
                        retorno = false;
                    }
                    else {
                        retorno = true;
                    }
                }
            });
            return retorno;
        });
    },

    ValidarSoloNumerosConGuion: function (input) {
        $(input).keypress(function (e) {            
            var verified = (e.which == 8 || e.which == undefined || e.which == 0) ? null : String.fromCharCode(e.which).match(/^(-)\d{2}(\.d\{1})$/);
            if (verified) { e.preventDefault(); }
        });
    },

    ValidarSoloNumeros: function (input) {
        $(input).keypress(function (e) {
            var verified = (e.which == 8 || e.which == undefined || e.which == 0 || e.which == 46) ? null : String.fromCharCode(e.which).match(/[^0-9]/);
            //
            //var verified = (e.which == 8 || e.which == undefined || e.which == 0) ? null : String.fromCharCode(e.which).match(/^-?\d{2}(\.\d+)?$/);
            if (verified) { e.preventDefault(); }
        });
    },

    ValidarSoloAlfanumericos: function (input) {
        $(input).keypress(function (e) {            
            var regex = new RegExp("^[a-zA-Z0-9]+$");
            var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (regex.test(str)) {
                return true;
            }
            e.preventDefault();
            return false;
        });
    },

    validarHoraIgual: function (horaA, horaB) {
        if (horaB != "") {

            //comparando meridianos
            var mer1 = horaA.substr(0, 8);
            var mer2 = horaB.substr(0, 8);
            if (mer1 != mer2) return false;

            //comparando horas
            var hora1 = horaA.substr(0, 5);
            var hora2 = horaB.substr(0, 5);
            //if (hora2 == "" || hora2 == null) return true;

            if (hora1 == undefined) return false;
            if (hora1 == "") return false;
            if (hora1.length > 5) return false;
            if (hora1.length <= 2) hora1 = parseInt(hora1) + ":00";
            var date1 = helperjs.hora(hora1);

            if (hora2 == undefined) return false;
            if (hora2 == "") return false;
            if (hora2.length > 5) return false;
            if (hora2.length <= 2) hora2 = parseInt(hora2) + ":00";
            var date2 = helperjs.hora(hora2);

            if (parseInt(date1) == parseInt(date2)) return true;
        }
        return false;
    },


    validarHoraMayorIgual: function (horaA, horaB) {
        if (horaB != "") {

            //obteniendo meridianos
            var mer1 = horaA.substr(horaA.length - 2);
            var mer2 = horaB.substr(horaB.length - 2);

            var hora1 = horaA.substr(0, 5);
            var hora2 = horaB.substr(0, 5);
            if (hora2 == "" || hora2 == null) return true;

            if (hora1 == undefined) return false;
            if (hora1 == "") return false;
            if (hora1.length > 5) return false;
            if (hora1.length <= 2) hora1 = parseInt(hora1) + ":00";
            var date1 = helperjs.hora(hora1);

            if (hora2 == undefined) return false;
            if (hora2 == "") return false;
            if (hora2.length > 5) return false;
            if (hora2.length <= 2) hora2 = parseInt(hora2) + ":00";
            var date2 = helperjs.hora(hora2);



            if (mer1 == mer2) {
                if (parseInt(date1) > parseInt(date2)) return true
            } else
                return true;

        }
        return false;
    },

    validarHoraMayorIgualIntervalo: function (horaA, horaB, intervalo) {
        if (horaB != "") {

            //obteniendo meridianos
            var mer1 = horaA.substr(horaA.length - 2);
            var mer2 = horaB.substr(horaB.length - 2);

            var hora1 = horaA.substr(0, 5);
            var hora2 = horaB.substr(0, 5);
            if (hora2 == "" || hora2 == null) return true;

            if (hora1 == undefined) return false;
            if (hora1 == "") return false;
            if (hora1.length > 5) return false;

            if (hora2 == undefined) return false;
            if (hora2 == "") return false;
            if (hora2.length > 5) return false;

            if (hora1.length <= 2) hora1 = parseInt(hora1) + ":00";

            if (mer1 == 'PM' || (mer1 == 'AM' && parseInt(hora1.toString().split(':')[0]) == 12)) {
                var horas = parseInt(hora1.toString().split(':')[0]) + 12;
                hora1 = horas.toString().concat(":" + hora1.toString().split(':')[1]);
            }

            var date1 = helperjs.hora(hora1);


            if (hora2.length <= 2) hora2 = parseInt(hora2) + ":00";

            if (mer2 == 'PM' || (mer2 == 'AM' && parseInt(hora2.toString().split(':')[0]) == 12)) {
                var horas = parseInt(hora2.toString().split(':')[0]) + 12;
                hora2 = horas.toString().concat(":" + hora2.toString().split(':')[1]);
            }

            var date2 = helperjs.hora(hora2);

            if (mer2 == "PM" && mer1 == "AM") {
                var dif2 = 2400 - parseInt(date2) + parseInt(date1);
                if (Math.abs(dif2) <= parseInt(intervalo * 100))
                    return true;
            } else {

                if (mer1 == "AM" && parseInt(hora1.toString().split(':')[0]) == 12) {
                    var dif3 = parseInt(date1) - parseInt(date2) - 1200;
                    if (dif3 <= parseInt(intervalo * 100) && dif3 > 0)
                        return true;
                } else {
                    var dif1 = parseInt(date1) - parseInt(date2);
                    if (dif1 <= parseInt(intervalo * 100) && dif1 > 0)
                        return true;
                }
            }

        }
        return false;
    },



};
