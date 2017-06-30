using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

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
    }
}
