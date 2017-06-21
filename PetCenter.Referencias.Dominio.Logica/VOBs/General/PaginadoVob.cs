using System.Collections.Generic;
namespace PetCenter.Referencias.Dominio.Logica.VOBs.General
{
    public class PaginadoVob<T>
    {
        public IEnumerable<T> Elementos { get; set; }

        public int TotalElementos { get; set; }

        public PaginadoVob() { }

        public PaginadoVob(IEnumerable<T> elementos, int totalElementos)
        {
            TotalElementos = totalElementos;
            Elementos = elementos;
        }


        public string ToList()
        {
            throw new System.NotImplementedException();
        }
    }
}
