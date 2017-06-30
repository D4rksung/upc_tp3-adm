using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ContraReferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.ContraReferencia
{
    public interface IContraReferenciaServicio
    {
        int Registrar(RegistrarContraReferenciaDto editor);
        ContraReferenciaDto BuscarPorRefencia(int idReferencia);
    }
}
