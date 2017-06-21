
using System;

namespace PetCenter.Referencias.Dominio.Logica.Base
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        ///// <summary>
        ///// Método que confirma todos los cambios.
        ///// </summary>
        //void Confirmar(string idTransaccion, UsuarioVob usuario);

        /// <summary>
        /// Método que confirma todos los cambios.
        /// </summary>
        void Confirmar();

        /// <summary>
        /// Activa la detección de cambios
        /// </summary>
        void EnableDetectChange();

        /// <summary>
        /// Desactiva la detección de cambios
        /// </summary>
        void DisableDetectChange();

    }
}
