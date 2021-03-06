﻿using PetCenter.Referencias.Dominio.Logica.Entidades;
using PetCenter.Referencias.Dominio.Logica.Repositorio.Registros;
using PetCenter.Referencias.Dominio.Logica.VOBs.Registros.Liquidacion;
using PetCenter.Referencias.Infraestructura.Data.Base;
using PetCenter.Referencias.Infraestructura.Data.UnidadDeTrabajo;
using System.Collections.Generic;
using System.Linq;

namespace PetCenter.Referencias.Infraestructura.Data.Repositorios.Liquidacion
{
    public class LiquidacionRepositorio : Repositorio<GCR_Liquidaciones>, ILiquidacionRepositorio
    {
        #region CONSTRUCTOR
        /// <summary>
        /// EquipoRepositorio
        /// </summary>
        /// <param name="unidadDeTrabajo"></param>
        public LiquidacionRepositorio(IModeloReferenciaUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
        #endregion


        public IEnumerable<LiquidacionTotalConvenioVob> ObtenerTotalPorConvenio()
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from liq in set.GCR_Liquidaciones
                            let g = new
                            {
                                IdCliente = liq.IdCliente,
                                NombreConvenio = liq.GCP_Cliente.GCP_PersonaJuridica.RazonSocial
                            }
                            group liq by g into p
                            select new LiquidacionTotalConvenioVob
                            {
                                Total = p.Sum(x => x.ValorTotal.Value),
                                NombreConvenio = p.Key.NombreConvenio
                            });
            return consulta.AsEnumerable();
        }

        public LiquidacionVob Buscar(int nroLiquidacion)
        {
            var set = ObtenerSet<IModeloReferenciaUnidadDeTrabajo>(this);
            var consulta = (from liq in set.GCR_Liquidaciones
                            where liq.NroLiquidacion == nroLiquidacion
                            select new LiquidacionVob
                            {
                                NroLiquidacion = liq.NroLiquidacion,
                                Anio = liq.Anio,
                                Mes = liq.Mes,
                                IdCliente = liq.IdCliente,
                                FechaLiquidacion = liq.FechaLiquidacion,
                                ValorBruto = liq.ValorBruto,
                                ValorDctoComercial = liq.ValorDctoComercial,
                                ValorNeto = liq.ValorNeto,
                                ValorAjuste = liq.ValorAjuste,
                                ValorImpuesto = liq.ValorImpuesto,
                                ValorTotal = liq.ValorTotal
                            });
            return consulta.FirstOrDefault();
        }

    }
}
