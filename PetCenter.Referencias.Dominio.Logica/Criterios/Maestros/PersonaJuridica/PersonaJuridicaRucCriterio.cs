using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Criterios.Maestros.PersonaJuridica
{
    public class PersonaJuridicaRucCriterio : Criterio<GCP_PersonaJuridica>
    {
        #region VARIABLES

        private readonly string _ruc;

        #endregion

        #region CONSTRUCTORES

        public PersonaJuridicaRucCriterio(string ruc)
        {
            _ruc = ruc;
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        public override Expression<Func<GCP_PersonaJuridica, bool>> SatisfacePara()
        {
            return t => t.RUC == _ruc;
        }

        #endregion
    }
}
