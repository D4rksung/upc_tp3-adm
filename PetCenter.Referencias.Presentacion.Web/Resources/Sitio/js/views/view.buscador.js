var buscadorjs = {

    //MAESTRO TRABAJADOR - DEVUELVE CODIGO DE TRABAJADOR
    maestroPersonalKey: function (codMper, codTrabajador, dni, apePat, nombre) {

        var request = {
            url: "MaestroPersonal/BuscadorIndex",
            data: {
            },
            codMper: codMper,
            codTrabajador: codTrabajador,
            dni: dni,
            apePat: apePat,
            nombre: nombre
        };
        buscadorBasejs.buscarKeyTrabajador(request);

    }
};