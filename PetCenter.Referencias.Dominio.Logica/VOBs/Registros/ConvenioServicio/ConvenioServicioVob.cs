using System;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.ConvenioServicio
{
    public class ConvenioServicioVob
    {
        public int IdServicio { get; set; }

        public int NroConvenio { get; set; }

        public Nullable<decimal> TarifaBase { get; set; }

        public Nullable<decimal> FactorDcto { get; set; }

        public Nullable<decimal> TarifaReal { get; set; }

        public string Estado { get; set; }
        public string NombreServicio { get; set; }
    }
}
