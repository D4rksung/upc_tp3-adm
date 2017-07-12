using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.DocumentoRechazo;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;
using System.Linq;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.DocumentoRechazo
{
    public class DocumentoRechazoRepositorio : Repositorio<e.GCR_DocumentoRechazo>, IDocumentoRechazoRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public DocumentoRechazoRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public DocumentoRechazoVob BuscarPorSolicitud(int idSolicitud)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from m in set.GCR_DocumentoRechazo
                            where m.NroSolicitud == idSolicitud
                            select new DocumentoRechazoVob {
                                FechaRechazo = m.FechaRechazo,
                                NroSolicitud = m.NroSolicitud,
                                NroDocumento = m.NroDocumento,
                                Observaciones = m.Observaciones
                            });
            return consulta.FirstOrDefault();
        }
    }
}
