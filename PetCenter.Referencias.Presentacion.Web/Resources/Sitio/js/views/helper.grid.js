var helperGridjs = {

    getFunction: function getFunction(code, argNames) {
        argNames = argNames || [];
        var fn = window, parts = (code || "").split(".");
        while (fn && parts.length) {
            fn = fn[parts.shift()];
        }
        if (typeof (fn) === "function") {
            return fn;
        }
        argNames.push(code);
        return Function.constructor.apply(null, argNames);
    },

    updateCallback: function () {
        $('table[data-swhgajax="true"],span[data-swhgajax="true"]').each(function () {
            var self = $(this);
            var containerId = '#' + self.data('swhgcontainer');
            var callback = helperGridjs.getFunction(self.data('swhgcallback'));

            $(containerId).parent().undelegate(containerId + ' a[data-swhglnk="true"]', 'click');

            $(containerId).parent().delegate(containerId + ' a[data-swhglnk="true"]', 'click', function () {
                $(containerId).swhgLoad($(this).attr('href'), containerId, callback);
                return false;
            });
        });
    }

};