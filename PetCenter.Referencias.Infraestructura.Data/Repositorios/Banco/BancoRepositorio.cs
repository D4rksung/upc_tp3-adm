using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Banco;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Banco;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Collections.Generic;
using System.Linq;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.Banco
{
    public class BancoRepositorio : Repositorio<e.GG_Banco>, IBancoRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public BancoRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public IEnumerable<BancoVob> Listar()
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from b in set.GG_Banco
                            select new BancoVob
                            {
                               IdBanco = b.IdBanco,
                               NomBanco = b.NomBanco
                            });
            return consulta.AsEnumerable();
        }

    }
}
