using System;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Atencion
{
    public class AtencionVob
    {
        public int IdAtencion { get; set; }

        public Nullable<int> NroSolicitudRef { get; set; }

        public Nullable<int> IdServicio { get; set; }

        public Nullable<int> NroConvenio { get; set; }

        public Nullable<int> Cantidad { get; set; }

        public Nullable<decimal> TarifaBase { get; set; }

        public Nullable<decimal> ValorBruto { get; set; }

        public Nullable<decimal> Descuento { get; set; }

        public Nullable<decimal> ValorNeto { get; set; }

        public Nullable<int> NroLiquidacion { get; set; }

        public string Resultado { get; set; }

        public string ResultadoTitulo { get; set; }

        public byte[] ResultadoObjeto { get; set; }

        public string Estado { get; set; }

        public int NroAtenciones { get; set; }
        public int IdCliente { get; set; }
        public string RazonSocial { get; set; }
        public Nullable<System.DateTime> FechaAtencion { get; set; }
        public string NombreServicio { get; set; }
        public string Anio { get; set; }
        public string Mes { get; set; }
    }
}
