namespace PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion
{
    public class AtencionTotalMesDto
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string NombreMes { get; set; }
        public decimal Total { get; set; }
        public int Cantidad { get; set; }
    }
}