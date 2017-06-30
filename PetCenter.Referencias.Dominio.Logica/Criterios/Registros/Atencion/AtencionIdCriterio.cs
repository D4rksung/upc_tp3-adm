using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Criterios.Registros.Atencion
{
    public class AtencionIdCriterio : Criterio<GCR_Atenciones>
    {
        #region VARIABLES
        
        private readonly int _idAtencion;

        #endregion

        #region CONSTRUCTORES
     
        public AtencionIdCriterio(int idAtencion)
        {
            _idAtencion = idAtencion;
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS
        
        public override Expression<Func<GCR_Atenciones, bool>> SatisfacePara()
        {
            return t => t.IdAtencion == _idAtencion;
        }

        #endregion
    }

}
