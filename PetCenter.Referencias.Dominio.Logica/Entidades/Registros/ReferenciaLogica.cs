namespace PetCenter.Referencias.Dominio.Logica.Entidades
{
    public partial class GCR_SolicitudRef
    {
        public void ProcesaAgregar(int idMascota, int idConvenio)
        {
            IdMascota = IdMascota;
            NroConvenio = idConvenio;
            Estado = "1";
        }
    }
}