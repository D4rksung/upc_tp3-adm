using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Mascota;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Collections.Generic;
using System.Linq;
using e = PetCenter.Referencias.Dominio.Logica.Entidades;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.Mascota
{
    public class MascotaRepositorio : Repositorio<e.GCP_Mascota>, IMascotaRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public MascotaRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion

        public IEnumerable<MascotaVob> Listar(int idCliente)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from b in set.GCP_Mascota
                            where b.IdCliente == idCliente
                            select new MascotaVob
                            {
                                IdMascota = b.IdMascota,
                                NombreMascota = b.NombreMascota,
                                NombreEspecie = b.GCP_Raza.GCP_Especie.DescripcionEspecie,
                                NombreRaza = b.GCP_Raza.NombreRaza,
                                FechaNacimiento = b.FechaNacimiento,
                                IdCliente = b.IdCliente
                            });
            return consulta.AsEnumerable();
        }

        public PaginadoVob<MascotaVob> Paginado(ICriterio<MascotaVob> criterio, int indicePagina, int tamanioPagina, string orden, string ordenDir)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from b in set.GCP_Mascota
                            select new MascotaVob
                            {
                                IdMascota = b.IdMascota,
                                NombreMascota = b.NombreMascota,
                                NombreEspecie = b.GCP_Raza.GCP_Especie.DescripcionEspecie,
                                NombreRaza = b.GCP_Raza.NombreRaza,
                                FechaNacimiento = b.FechaNacimiento,
                                IdCliente = b.IdCliente
                            });
            return ListarPorCriterio(consulta, criterio, indicePagina, tamanioPagina, orden, ordenDir);//El ordern y la direccion puede ir como parametros si en el presentación se ordenan 
        }

        public MascotaVob Buscar(int idMascota)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from b in set.GCP_Mascota
                           where b.IdMascota == idMascota
                            select new MascotaVob
                            {
                                IdMascota = b.IdMascota,
                                NombreMascota = b.NombreMascota,
                                NombreEspecie = b.GCP_Raza.GCP_Especie.DescripcionEspecie,
                                NombreRaza = b.GCP_Raza.NombreRaza,
                                FechaNacimiento = b.FechaNacimiento,
                                IdCliente = b.IdCliente
                            });
            return consulta.FirstOrDefault();
        }
    }
}
