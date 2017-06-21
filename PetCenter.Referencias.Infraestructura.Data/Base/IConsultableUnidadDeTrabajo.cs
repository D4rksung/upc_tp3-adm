
using PetCenter.Referencias.Dominio.Logica.Base;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PetCenter.Referencias.Infraestructura.Data.Base
{
    /// <summary>
    /// Unidad de trabajo consultable
    /// </summary>
    public interface IConsultableUnidadDeTrabajo : IUnidadDeTrabajo, IExecuteSql
    {
        //Devuelve entidad del contexto para que puede ser utilizada.
        DbSet<TEntidad> Set<TEntidad>() where TEntidad : class;

        //Devuelve entidad para establecer valores a las propiedaes.
        DbEntityEntry<TEntidad> Entry<TEntidad>(TEntidad entidad) where TEntidad : class;
    }
}
