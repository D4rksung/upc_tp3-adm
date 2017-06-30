namespace PetCenter.Referencias.Dominio.Logica.Entidades
{
    public partial class GCR_Convenio
    {
        public void ProcesaAgregar(int idSolicitud)
        {
            NroSolicitud = idSolicitud;
            Estado = "1";
        }
    }
}