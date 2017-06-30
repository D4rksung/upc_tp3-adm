using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Dominio.Logica.VOBs.Maestros.Mascota;
using PetCenter.Referencias.Transversal.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Dominio.Logica.Criterios.Maestros.Mascota
{
    public class MascotaBuscadorCriterio : Criterio<MascotaVob>
    {
        #region VARIABLES

        /// <summary>
        /// _area
        /// </summary>
        private readonly MascotaVob _mascota;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="solicitud">AreaVob</param>
        public MascotaBuscadorCriterio(MascotaVob mascota)
        {
            _mascota = mascota;
        }

        #endregion

        #region MÉTODOS REEMPLAZADOS

        /// <summary>
        /// SatisfacePara
        /// </summary>
        /// <returns>TupaVob</returns>
        public override Expression<Func<MascotaVob, bool>> SatisfacePara()
        {
            string todos = ((int)PrimerValorEnum.Seleccione).ToString();
            Criterio<MascotaVob> criterio = new CriterioTrue<MascotaVob>();

            #region Filtro 

            //Nro de Ruc
            if (!string.IsNullOrEmpty(_mascota.NombreMascota))
                criterio &= new CriterioDirect<MascotaVob>(p => p.NombreMascota.Contains(_mascota.NombreMascota));

            //idcliente
            criterio &= new CriterioDirect<MascotaVob>(p => p.IdCliente == _mascota.IdCliente);

            #endregion

            return criterio.SatisfacePara();
        }

        #endregion
    }
}
