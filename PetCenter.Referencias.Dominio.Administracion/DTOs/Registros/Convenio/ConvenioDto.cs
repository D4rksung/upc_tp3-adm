using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioDescuento;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioServicio;
using System;
using System.Collections.Generic;

namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Convenio
{
    public class ConvenioDto
    {
        public int NroConvenio { get; set; }

        public Nullable<int> IdCliente { get; set; }

        public Nullable<int> NroSolicitud { get; set; }

        public Nullable<System.DateTime> FechaConvenio { get; set; }

        public Nullable<System.DateTime> FechaVencimiento { get; set; }

        public Nullable<decimal> ImporteConvenio { get; set; }

        public string Observacion { get; set; }

        public string Estado { get; set; }

        public IEnumerable<ConvenioServicioDto> ListaConvenioServicio { get; set; }
        public IEnumerable<ConvenioDescuentoDto> ListaConvenioDescuento { get; set; }
        public string NroRuc { get; set; }
        public string RazonSocial { get; set; }
    }
}