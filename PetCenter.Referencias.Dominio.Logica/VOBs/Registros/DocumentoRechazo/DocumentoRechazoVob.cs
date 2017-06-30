using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.VOBs.Registros.DocumentoRechazo
{
    public class DocumentoRechazoVob
    {
        public int NroDocumento { get; set; }

        public Nullable<int> NroSolicitud { get; set; }

        public Nullable<System.DateTime> FechaRechazo { get; set; }

        public string Observaciones { get; set; }
    }
}
