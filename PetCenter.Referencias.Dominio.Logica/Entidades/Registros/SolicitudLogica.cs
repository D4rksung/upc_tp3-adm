namespace PetCenter.Referencias.Dominio.Logica.Entidades
{
    public partial class GCR_Solicitud_Convenio
    {
        public void ProcesaAgregar(GCR_Solicitud_Convenio solicitud)
        {
            Estado = "1"; //Emitido
            Referencia = string.IsNullOrEmpty(solicitud.Referencia) ? "" : solicitud.Referencia;
            Telefono = string.IsNullOrEmpty(solicitud.Telefono) ? "" : solicitud.Telefono;
            Web = string.IsNullOrEmpty(solicitud.Web) ? "" : solicitud.Web;
            TelefonoRep = string.IsNullOrEmpty(solicitud.TelefonoRep) ? "" : solicitud.TelefonoRep;
            DocReciboObjeto = solicitud.DocReciboObjeto == null ? null : solicitud.DocReciboObjeto;
            DocReciboTitulo = string.IsNullOrEmpty(solicitud.DocReciboTitulo) ? "" : solicitud.DocReciboTitulo;
            DocColegiaturaObjeto = solicitud.DocColegiaturaObjeto == null ? null : solicitud.DocColegiaturaObjeto;
            DocColegiaturaTitulo = string.IsNullOrEmpty(solicitud.DocColegiaturaTitulo) ? "" : solicitud.DocColegiaturaTitulo;
            DocSunatObjeto = solicitud.DocSunatObjeto == null ? null : solicitud.DocSunatObjeto;
            DocSunatTitulo = string.IsNullOrEmpty(solicitud.DocSunatTitulo) ? "" : solicitud.DocSunatTitulo;
            DocLicenciaObjeto = solicitud.DocLicenciaObjeto == null ? null : solicitud.DocLicenciaObjeto;
            DocLicenciaTitulo = string.IsNullOrEmpty(solicitud.DocLicenciaTitulo) ? "" : solicitud.DocLicenciaTitulo;
            DocCentralObjeto = solicitud.DocCentralObjeto == null ? null : solicitud.DocCentralObjeto;
            DocCentralTitulo = string.IsNullOrEmpty(solicitud.DocCentralTitulo) ? "" : solicitud.DocCentralTitulo;
        }

        public void ProcesaModificar(GCR_Solicitud_Convenio solicitud)
        {
            Referencia = string.IsNullOrEmpty(solicitud.Referencia) ? "" : solicitud.Referencia;
            Telefono = string.IsNullOrEmpty(solicitud.Telefono) ? "" : solicitud.Telefono;
            Web = string.IsNullOrEmpty(solicitud.Web) ? "" : solicitud.Web;
            TelefonoRep = string.IsNullOrEmpty(solicitud.TelefonoRep) ? "" : solicitud.TelefonoRep;
        }

        public void ProcesaAceptado()
        {
            Estado = "2"; // Aceptado
        }
        public void ProcesaRechazado()
        {
            Estado = "3"; // Rechazado
        }
    }
}