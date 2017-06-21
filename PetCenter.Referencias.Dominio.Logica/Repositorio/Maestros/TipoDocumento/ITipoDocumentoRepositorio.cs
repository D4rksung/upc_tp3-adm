using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.TipoDocumento;
using System.Collections.Generic;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.TipoDocumento
{
    public interface ITipoDocumentoRepositorio : IRepositorio<e.TipoDocumento>
    {
        IEnumerable<TipoDocumentoVob> Listar();
    }
}
