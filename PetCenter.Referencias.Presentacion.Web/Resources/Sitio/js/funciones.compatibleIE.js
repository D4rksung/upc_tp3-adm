
; (function (window, document) {

    /* Extension de TRIM*/
    if (!String.prototype.trim) {
        String.prototype.trim = function () {
            return this.replace(/^\s+|\s+$/g, '');
        };
    }

}(this, document));