using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Moneda;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Moneda;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Collections.Generic;
using System.Linq;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.Moneda
{
    public class MonedaRepositorio : Repositorio<e.GG_Moneda>, IMonedaRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public MonedaRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public IEnumerable<MonedaVob> Listar()
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from m in set.GG_Moneda
                            select new MonedaVob
                            {
                                IdMoneda = m.IdMoneda,
                                DesMoneda = m.DesMoneda
                            });
            return consulta.AsEnumerable();
        }
    }
}
