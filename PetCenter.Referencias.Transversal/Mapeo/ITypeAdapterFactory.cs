namespace PetCenter.Referencias.Transversal.Mapeo
{
    /// <summary>
    /// Contrato base para factoria del adaptador.
    /// </summary>
    public interface ITypeAdapterFactory
    {
        #region MÉTODOS DE LA INTERFACE

        /// <summary>
        /// Crea el tipo del adapatador.
        /// </summary>
        /// <returns>Adaptador creado del tipo ITypeAdapter.</returns>
        ITypeAdapter Create();

        #endregion
    }
}
