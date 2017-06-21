using System.Collections.Generic;
using PetCenter.Referencias.Infraestructura.Data.Modelo;
using System.Data.Entity.Infrastructure;
using PetCenter.Referencias.Infraestructura.Data.Recursos;

namespace PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo
{
    public class ModeloReferenciaUnidadDeTrabajo : BD_ReferenciaEntities, IModeloReferenciaUnidadDeTrabajo
    {
        public ModeloReferenciaUnidadDeTrabajo()
        { }

        public void Confirmar()
        {
            //Variables iniciales
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    SaveChanges();
                }
                catch (DbUpdateConcurrencyException duce)
                {
                    //Cuando ocurre un problema de concurrencia optimista
                    //No deberia ocurrir porque en la capa ya se usa DTOs
                    saveFailed = true;
                    try
                    {
                        foreach (var entidad in duce.Entries)
                        {
                            var obj = entidad.CurrentValues.Clone();
                            entidad.Reload();
                            entidad.CurrentValues.SetValues(obj);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        saveFailed = false;
                        //Revierte los cambios cuando ocurre errores no controlados
                        //due.Entries
                        RollbackEntries(ChangeTracker.Entries());
                        throw ex;
                    }

                }
                catch (DbUpdateException due)
                {
                    saveFailed = false;
                    //Revierte los cambios cuando ocurre errores no controlados
                    RollbackEntries(ChangeTracker.Entries());
                    throw due;

                }
            } while (saveFailed);
        }

        #region MÉTODOS DE APOYO

        /// <summary>
        /// Optiene la llave primaria de la entidad.
        /// </summary>
        /// <param name="objectStateEntry">objectStateEntry</param>
        /// <returns>Llave</returns>
        private string ObtenerKey(System.Data.Objects.ObjectStateEntry objectStateEntry)
        {
            string result = string.Empty;
            foreach (var key in objectStateEntry.EntityKey.EntityKeyValues)
            {
                result = string.IsNullOrEmpty(result)
                    ? string.Concat(key.Key, "=", key.Value.ToString().Trim())
                    : string.Concat(result, Operadores.Separador, key.Key, "=", key.Value.ToString().Trim());
            }
            return result;
        }

        /// <summary>
        /// RollbackEntries
        /// </summary>
        /// <param name="entries">entries</param>
        private void RollbackEntries(IEnumerable<DbEntityEntry> entries)
        {
            foreach (var entidad in entries)
            {
                switch (entidad.State)
                {
                    case System.Data.Entity.EntityState.Modified:
                        entidad.State = System.Data.Entity.EntityState.Unchanged;
                        break;
                    case System.Data.Entity.EntityState.Deleted:
                        entidad.Reload();
                        break;
                    case System.Data.Entity.EntityState.Added:
                        entidad.State = System.Data.Entity.EntityState.Detached;
                        break;
                    default: break;
                }
            }
        }

        #endregion
    }
}
