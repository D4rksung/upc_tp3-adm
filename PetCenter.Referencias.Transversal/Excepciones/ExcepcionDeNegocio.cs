using System;

namespace PetCenter.Referencias.Transversal.Excepciones
{

    /// <summary>
    /// Exepcion controlada de negocio
    /// </summary>
    public class ExcepcionDeNegocio : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase ExcepcionDeNegocio con un mensaje de error especificado y una referencia a la excepción interna que representa la causa de esta excepción.
        /// </summary>
        /// <param name="mensaje">Mensaje que describe el error.</param>
        /// <param name="innerException">La excepción que es la causa de la excepción actual o una referencia nula.</param>
        public ExcepcionDeNegocio(String mensaje, Exception innerException = null) : base(mensaje, innerException) { }
    }

}
