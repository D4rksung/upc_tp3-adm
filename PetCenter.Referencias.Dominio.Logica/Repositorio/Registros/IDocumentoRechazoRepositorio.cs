using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.DocumentoRechazo;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Registros
{
    public interface IDocumentoRechazoRepositorio : IRepositorio<e.GCR_DocumentoRechazo>
    {
        DocumentoRechazoVob BuscarPorSolicitud(int idSolicitud);
    }
}
