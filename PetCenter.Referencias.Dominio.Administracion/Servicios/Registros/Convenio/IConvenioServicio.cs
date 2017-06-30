using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Convenio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Convenio
{
    public interface IConvenioServicio
    {
        int Registrar(RegistrarConvenioDto registro);
        ConvenioDto Buscar(int idConvenio);
    }
}
