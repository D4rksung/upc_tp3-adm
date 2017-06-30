using PetCenter.Referencias.Dominio.Administracion.DTOs.General;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.General
{
    public class GeneralServicio : IGeneralServicio
    {
        public IEnumerable<ElementoDto> TipoDocumentoListar()
        {
            var lista = new List<ElementoDto>();
            lista.Add(new ElementoDto { Texto = "RUC", Valor = "RUC" });
            lista.Add(new ElementoDto { Texto = "DNI", Valor = "DNI" });
            lista.Add(new ElementoDto { Texto = "CEX", Valor = "CEX" });

            return lista;
        }

        public IEnumerable<ElementoDto> PeriodoListar()
        {
            var lista = new List<ElementoDto>();
            lista.Add(new ElementoDto { Texto = "2017", Valor = "2017" });
            return lista;
        }

        public IEnumerable<ElementoDto> MesListar()
        {
            var lista = new List<ElementoDto>();
            lista.Add(new ElementoDto { Texto = "Enero", Valor = "1" });
            lista.Add(new ElementoDto { Texto = "Febrero", Valor = "2" });
            lista.Add(new ElementoDto { Texto = "Marzo", Valor = "3" });
            lista.Add(new ElementoDto { Texto = "Abril", Valor = "4" });
            lista.Add(new ElementoDto { Texto = "Mayo", Valor = "5" });
            lista.Add(new ElementoDto { Texto = "Junio", Valor = "6" });
            lista.Add(new ElementoDto { Texto = "Julio", Valor = "7" });
            lista.Add(new ElementoDto { Texto = "Agosto", Valor = "8" });
            lista.Add(new ElementoDto { Texto = "Setiembre", Valor = "9" });
            lista.Add(new ElementoDto { Texto = "Octubre", Valor = "10" });
            lista.Add(new ElementoDto { Texto = "Noviembre", Valor = "11" });
            lista.Add(new ElementoDto { Texto = "Diciembre", Valor = "12" });
            return lista;
        }
    }
}