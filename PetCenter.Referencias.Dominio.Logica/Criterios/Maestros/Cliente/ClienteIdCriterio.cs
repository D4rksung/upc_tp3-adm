using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Criterios.Maestros.Cliente
{
    public class ClienteIdCriterio : Criterio<GCP_Cliente>
    {
        #region VARIABLES

        private readonly int _idCliente;

        #endregion

        #region CONSTRUCTORES

        public ClienteIdCriterio(int idCliente)
        {
            _idCliente = idCliente;
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        public override Expression<Func<GCP_Cliente, bool>> SatisfacePara()
        {
            return t => t.IdCliente == _idCliente;
        }

        #endregion
    }
}
