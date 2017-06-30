using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Logica.Criterios.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Logica.VOBs.General;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Mascota;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Solicitud;
using PetCenter.Referencias.Transversal.Mapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Maestros.Mascota
{
    public class MascotaServicio : IMascotaServicio
    {
        #region VARIABLE

        /// <summary>
        /// ICargoRepositorio
        /// </summary>
        private readonly IMascotaRepositorio _mascotaRepositorio;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// CargoServicio
        /// </summary>
        /// <param name="cargoRepositorio"></param>
        public MascotaServicio(IMascotaRepositorio MascotaRepositorio)
        {
            _mascotaRepositorio = MascotaRepositorio;
        }

        #endregion

        public IEnumerable<MascotaDto> Listar(int idCliente)
        {
            return _mascotaRepositorio.Listar(idCliente).ProyectarComoLista<MascotaDto>();
        }

        public RespuestaMascotaDto Busqueda(BusquedaMascotaDto solicitud)
        {
            try
            {
                var paginar = solicitud.CriterioPaginar;
                var listaPaginada = new PaginadoVob<MascotaVob>
                {
                    Elementos = new List<MascotaVob>(),
                    TotalElementos = 0
                };

                if (solicitud.TablaFilter != null)
                {
                    //Obteniendo resultado de la Busqueda
                    var entidaVob = solicitud.TablaFilter.ProyectarComo<MascotaVob>();
                    var criterio = new MascotaBuscadorCriterio(entidaVob);
                    var pagina = solicitud.CriterioPaginar.Pagina;
                    var tamanio = solicitud.CriterioPaginar.Tamanio;
                    var orden = solicitud.CriterioPaginar.Orden;
                    var ordenDir = solicitud.CriterioPaginar.OrdenDir;
                    listaPaginada = _mascotaRepositorio.Paginado(criterio, pagina, tamanio, orden, ordenDir);
                }

                //Obtenemos el resultado
                var resultado = new RespuestaMascotaDto
                {
                    lista = listaPaginada.Elementos.ProyectarComoLista<MascotaDto>(),
                    TotalElementos = listaPaginada.TotalElementos
                };

                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public MascotaDto Buscar(int idMascota)
        {
            return _mascotaRepositorio.Buscar(idMascota).ProyectarComo<MascotaDto>();
        }
    }
}
