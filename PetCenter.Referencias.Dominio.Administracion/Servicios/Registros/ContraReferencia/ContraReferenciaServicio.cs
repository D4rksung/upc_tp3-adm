using PetCenter.Referencias.Dominio.Administracion.Base;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ContraReferencia;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Transversal.Mapeo;
using PetCenter.Referencias.Transversal.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.ContraReferencia
{
    public class ContraReferenciaServicio : IContraReferenciaServicio
    {
        #region VARIABLE

        private readonly IContraReferenciaRepositorio _contraReferenciaRepositorio;

        #endregion

        #region CONSTRUCTOR
        public ContraReferenciaServicio(IContraReferenciaRepositorio contraReferenciaRepositorio)
        {
            _contraReferenciaRepositorio = contraReferenciaRepositorio;
        }
        #endregion

        public int Registrar(RegistrarContraReferenciaDto editor)
        {
            try
            {
                var unidadDeTrabajo = _contraReferenciaRepositorio.UnidadDeTrabajo;
                var contraReferencia = editor.ContraReferencia.ProyectarComo<GCR_ContraReferencia>();
                var servicio = editor.Servicio.ProyectarComo<GG_Servicio>();
                var referencia = editor.Referencia.ProyectarComo<GCR_SolicitudRef>();

                using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionHelper.OptionsDefaults()))
                {

                    contraReferencia.NroSolicitudRef = referencia.NroSolicitudRef;

                    _contraReferenciaRepositorio.Agregar(contraReferencia);

                    //Confirmando
                    unidadDeTrabajo.Confirmar();

                    //Completando la transacción
                    scope.Complete();

                }

                return contraReferencia.NroContraReferencia;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public ContraReferenciaDto BuscarPorRefencia(int idReferencia)
        {
            var contraReferencia = _contraReferenciaRepositorio.BuscarPorRefencia(idReferencia).ProyectarComo<ContraReferenciaDto>();
            contraReferencia.NroContraReferenciaFormato = StringExtensions.GenerarCodigo(contraReferencia.NroContraReferencia);
            return contraReferencia;
        }
    }
}
