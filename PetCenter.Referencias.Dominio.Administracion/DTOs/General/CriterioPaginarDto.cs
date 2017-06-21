namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Comun
{
    public class CriterioPaginarDto
    {
        /// <summary>
        /// Pagina
        /// </summary>
        public int Pagina { get; set; }

        /// <summary>
        /// Tamanio
        /// </summary>
        public int Tamanio { get; set; }

        /// <summary>
        /// Orden
        /// </summary>
        public string Orden { get; set; }

        /// <summary>
        /// OrdenDir
        /// </summary>
        public string OrdenDir { get; set; }
    }
}
