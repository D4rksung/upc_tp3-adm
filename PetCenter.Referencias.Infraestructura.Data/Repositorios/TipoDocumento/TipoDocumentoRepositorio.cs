using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.TipoDocumento;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.TipoDocumento;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Collections.Generic;
using System.Linq;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.TipoDocumento
{
    public class TipoDocumentoRepositorio : Repositorio<e.TipoDocumento>, ITipoDocumentoRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public TipoDocumentoRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public IEnumerable<TipoDocumentoVob> Listar()
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from m in set.TipoDocumento
                            select new TipoDocumentoVob
                            {
                                IdTipoDocumento = m.IdTipoDocumento,
                                Descripcion = m.Descripcion
                            });
            return consulta.AsEnumerable();
        }
    }
}
