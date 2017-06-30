using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Criterios.Maestros.PersonaJuridica
{
    public class PersonaJuridicaIdCriterio : Criterio<GCP_PersonaJuridica>
    {
        #region VARIABLES

        private readonly int _idCliente;

        #endregion

        #region CONSTRUCTORES

        public PersonaJuridicaIdCriterio(int idCliente)
        {
            _idCliente = idCliente;
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        public override Expression<Func<GCP_PersonaJuridica, bool>> SatisfacePara()
        {
            return t => t.IdCliente == _idCliente;
        }

        #endregion
    }
}
