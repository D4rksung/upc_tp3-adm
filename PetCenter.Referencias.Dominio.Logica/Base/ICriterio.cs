using System;
using System.Linq.Expressions;

namespace PetCenter.Referencias.Dominio.Logica.Base
{
    public interface ICriterio<TEntidad> where TEntidad : class
    {
        Expression<Func<TEntidad, bool>> SatisfacePara();

        Expression<Func<TEntidad, bool>> SatisfacerParaOtro();

    }
}
