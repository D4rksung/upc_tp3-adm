using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ContraReferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.Repositorio.Registros
{
    public interface IContraReferenciaRepositorio : IRepositorio<GCR_ContraReferencia>
    {
        ContraReferenciaVob BuscarPorRefencia(int idReferencia);
    }
}
