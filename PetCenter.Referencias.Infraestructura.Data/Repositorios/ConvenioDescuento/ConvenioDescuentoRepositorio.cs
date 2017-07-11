using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ConvenioDescuento;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.ConvenioDescuento
{
    public class ConvenioDescuentoRepositorio : Repositorio<e.GCR_ConvenioDescuento>, IConvenioDescuentoRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public ConvenioDescuentoRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public IEnumerable<ConvenioDescuentoVob> Listar(int idConvenio)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from cd in set.GCR_ConvenioDescuento
                            where cd.NroConvenio == idConvenio
                            select new ConvenioDescuentoVob
                            {
                                NroConvenio = cd.NroConvenio,
                                Item = cd.Item,
                                Descripcion = cd.Descripcion,
                                Minimo = cd.Minimo,
                                Maximo = cd.Maximo,
                                FactorDcto = cd.FactorDcto
                            });
            return consulta.AsEnumerable();
        }
    }
}
