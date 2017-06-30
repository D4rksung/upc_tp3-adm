var archivojs = {

    formArchivo: "#formArchivo",

    descargaArchivo: function (url, _from) {

        var _idForm = _from;

        helperFilejs.downloadFile(url, _idForm);

    },

    busqueda: function () {

        var TamanioMin = $("#TamanioMin");
        var TamanioMax = $("#TamanioMax");

        TamanioMin.numeric('.');
        TamanioMax.numeric('.');

        archivojs.validaciones();
    },

    validaciones: function () {

        $(this.formArchivo).validacionSiga({
            rules: {
                'Filtro.archivo.Nombre': {
                    noEspeciales: sitiojs.caracter_restringido_input_consulta
                },
                'TamanioMin': {
                    numeroMayorCeroVacio: true
                },
                'TamanioMax': {
                    numeroMayorCeroVacio: true
                },
                'Filtro.archivo.Extension': {
                    noEspeciales: sitiojs.caracter_restringido_input_consulta
                }
            },
            messages: {
                'Filtro.archivo.Nombre': {
                   noEspeciales: 'No ingrese caracteres especiales'
                },
                'TamanioMin': {
                    numeroMayorCeroVacio: 'Número incorrecto'
                },
                'TamanioMax': {
                    numeroMayorCeroVacio: 'Número incorrecto'
                },
                'Filtro.archivo.Extension': {
                    noEspeciales: 'No ingrese caracteres especiales'
                }
            }
        })
    },

    mostrarSubirArchivo: function (divSubir, divBajar) {
        $(divSubir).show("slow");
        $(divBajar).hide("slow");
    },

    mostrarDescarga: function (divSubir, divBajar) {
        $(divSubir).hide("slow");
        $(divBajar).show("slow");
    },

    reSize: function () {
        try {
            var oBody = ifrm.document.body;
            var oFrame = document.all("ifrm");

            oFrame.style.height = oBody.scrollHeight + (oBody.offsetHeight - oBody.clientHeight);
            oFrame.style.width = oBody.scrollWidth + (oBody.offsetWidth - oBody.clientWidth);
        }
        //An error is raised if the IFrame domain != its container's domain
        catch (e) {
            window.status = 'Error: ' + e.number + '; ' + e.description;
        }
    }

}