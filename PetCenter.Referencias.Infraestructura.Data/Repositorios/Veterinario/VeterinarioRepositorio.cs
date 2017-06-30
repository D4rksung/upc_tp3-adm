using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Veterinario;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Veterinario;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.Veterinario
{
    public class VeterinarioRepositorio : Repositorio<GCR_Veterinario>, IVeterinarioRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public VeterinarioRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public IEnumerable<VeterinarioVob> Listar()
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from b in set.GCR_Veterinario
                            select new VeterinarioVob
                            {
                                IdVeterinario = b.IdVeterinario,
                                NomVeterinario = b.NomVeterinario,
                                Estado = b.Estado
                            });
            return consulta.AsEnumerable();
        }
    }
}
