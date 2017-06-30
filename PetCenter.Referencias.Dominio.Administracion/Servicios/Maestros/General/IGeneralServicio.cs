using PetCenter.Referencias.Dominio.Administracion.DTOs.General;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.General
{
    public interface IGeneralServicio
    {
        IEnumerable<ElementoDto> TipoDocumentoListar();
        IEnumerable<ElementoDto> PeriodoListar();
        IEnumerable<ElementoDto> MesListar();
    }
}