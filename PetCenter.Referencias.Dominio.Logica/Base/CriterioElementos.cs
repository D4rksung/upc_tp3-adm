namespace PetCenter.Referencias.Dominio.Logica.Base
{
    public abstract class CriterioElementos<TEntidad> : Criterio<TEntidad> where TEntidad : class
    {
        public abstract ICriterio<TEntidad> CriterioLadoIzquierda { get; }

        public abstract ICriterio<TEntidad> CriterioLadoDerecha { get; }
    }
}
