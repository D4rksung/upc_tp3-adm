using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ReferenciaConvenioServicio;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Registros
{
    public interface IReferenciaConvenioServicioRepositorio : IRepositorio<GCR_SolicitudRef_Servicio>
    {
        IEnumerable<ReferenciaConvenioServicioVob> Listar(int idReferencia);
    }
}