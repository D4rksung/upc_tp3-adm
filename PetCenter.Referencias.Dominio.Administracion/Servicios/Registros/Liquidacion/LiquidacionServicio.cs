using PetCenter.Referencias.Dominio.Administracion.Base;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Liquidacion;
using PetCenter.Referencias.Dominio.Logica.Criterios.Registros.Atencion;
using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Transversal.Mapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace PetCenter.Referencias.Dominio.Administracion.Servicios.Registros.Liquidacion
{
    public class LiquidacionServicio : ILiquidacionServicio
    {
        #region VARIABLE

        private readonly ILiquidacionRepositorio _liquidacionRepositorio;
        private readonly IConvenioDescuentoRepositorio _convenioDescuentoRepositorio;
        private readonly IAtencionRepositorio _atencionRepositorio;

        #endregion

        #region CONSTRUCTOR
        public LiquidacionServicio(ILiquidacionRepositorio liquidacionRepositorio,
            IConvenioDescuentoRepositorio convenioDescuentoRepositorio,
            IAtencionRepositorio atencionRepositorio)
        {
            _liquidacionRepositorio = liquidacionRepositorio;
            _convenioDescuentoRepositorio = convenioDescuentoRepositorio;
            _atencionRepositorio = atencionRepositorio;
        }
        #endregion


        public LiquidacionDto Calcular(IEnumerable<AtencionDto> listaAtencion)
        {
            var liquidacion = new LiquidacionDto();
            var idConvenio = listaAtencion.FirstOrDefault().NroConvenio;
            var descuentos = _convenioDescuentoRepositorio.Listar(idConvenio.Value);
            decimal descuentoComercial = 0;


            liquidacion.ValorBruto = Math.Round(Convert.ToDecimal(listaAtencion.Sum(p => p.ValorNeto)),2);

            //buscar descuento
            descuentos.ToList().ForEach(x =>
            {
                if (liquidacion.ValorBruto >= x.Minimo && liquidacion.ValorBruto <= x.Maximo)
                {
                    var factor = x.FactorDcto / 100;
                    descuentoComercial = liquidacion.ValorBruto.Value * Convert.ToDecimal(factor);
                }
            });


            liquidacion.ValorDctoComercial = Math.Round(descuentoComercial,2);
            var valorNeto = liquidacion.ValorBruto - liquidacion.ValorDctoComercial;
            liquidacion.ValorNeto = Math.Round(valorNeto.Value,2);
            liquidacion.ValorImpuesto = Math.Round((valorNeto.Value * Convert.ToDecimal(0.18)),2);
            liquidacion.ValorTotal = Math.Round(Convert.ToDecimal(liquidacion.ValorNeto + liquidacion.ValorImpuesto),2);
            return liquidacion;
        }

        public int Registrar(RegistrarLiquidacionDto editor)
        {
            try
            {
                var unidadDeTrabajo = _liquidacionRepositorio.UnidadDeTrabajo;
                var atenciones = _atencionRepositorio.ListarPorClientePeriodoMes(editor.Atencion.IdCliente, editor.Atencion.Anio, editor.Atencion.Mes);
                var liquidacion = editor.Liquidacion.ProyectarComo<GCR_Liquidaciones>();

                using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionHelper.OptionsDefaults()))
                {
                    var nroLiquidacion = 0;
                    liquidacion.Anio = editor.Atencion.Anio;
                    liquidacion.Mes = editor.Atencion.Mes;
                    liquidacion.IdCliente = editor.Atencion.IdCliente;
                    liquidacion.FechaLiquidacion = DateTime.Now;

                    _liquidacionRepositorio.Agregar(liquidacion);

                    //Confirmando
                    unidadDeTrabajo.Confirmar();

                    nroLiquidacion = liquidacion.NroLiquidacion;

                    //atenciones
                    atenciones.ToList().ForEach(
                        x =>
                        {
                            var _atencion = _atencionRepositorio.EntidadParaEditar(new AtencionIdCriterio(x.IdAtencion));
                            _atencion.NroLiquidacion = nroLiquidacion;
                            _atencionRepositorio.Modificar(_atencion);
                        });

                    //Confirmando
                    unidadDeTrabajo.Confirmar();


                    //Completando la transacción
                    scope.Complete();
                }
                return liquidacion.NroLiquidacion;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public IEnumerable<LiquidacionTotalConvenioDto> ObtenerTotalPorConvenio()
        {
            return _liquidacionRepositorio.ObtenerTotalPorConvenio().ProyectarComoLista<LiquidacionTotalConvenioDto>();
        }
    }
}