
using PetCenter.Referencias.Dominio.Administracion.DTOs.General;
using PetCenter.Referencias.Dominio.Logica.Base;
using PetCenter.Referencias.Transversal.Cache;
using PetCenter.Referencias.Transversal.Enumeraciones;
using PetCenter.Referencias.Transversal.Recursos;
using PetCenter.Referencias.Transversal.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace PetCenter.Referencias.Dominio.Administracion.Base
{
    /// <summary>
    /// Extensiones base, que permiten poner valores de inicio de las listas tipos.
    /// </summary>
    public static class ExtensionesBase
    {
        #region Lista

        ///// <summary>
        ///// Proyecta la lista tablatablas y agrega un valor al inicio de texto "SELECCIONADO".
        ///// </summary>
        ///// <param name="repTablaTabla">Repositorio</param>
        ///// <param name="grupo">grupo</param>
        ///// <returns>Lista de elementos DTO</returns>
        //public static IEnumerable<ElementoDto> ResolverListaGrupoConSeleccione(this ITablaTablaRepositorio repTablaTabla, string grupo, bool refresh = true, string orden = "Valor", string ordenDir = "ASC")
        //{
        //    string valor = string.Empty;
        //    string texto = PrimerValorEnum.Seleccione.ToString();

        //    return ResolverListaGrupo(repTablaTabla, grupo, texto, valor, KeyCache.Cache_ListaElementoSeleccione_Grupo, refresh, orden, ordenDir);
        //}

        ///// <summary>
        ///// Proyecta la lista tablatablas y agrega un valor al inicio de texto "TODOS"
        ///// </summary>
        ///// <param name="repTablaTabla">Repositorio</param>
        ///// <param name="grupo">grupo</param>
        ///// <returns>Lista de elementos DTO</returns>
        //public static IEnumerable<ElementoDto> ResolverListaGrupoConTodos(this ITablaTablaRepositorio repTablaTabla, string grupo, bool refresh = true, string orden = "Valor", string ordenDir = "ASC")
        //{
        //    string valor = ((int)PrimerValorEnum.Seleccione).ToString();
        //    string texto = PrimerValorEnum.Seleccione.ToString();

        //    return ResolverListaGrupo(repTablaTabla, grupo, texto, valor, KeyCache.Cache_ListaElementoTodos_Grupo, refresh, orden, ordenDir);
        //}

        ///// <summary>
        ///// Proyecta la lista tablatablas y agrega un valor al inicio.
        ///// </summary>
        ///// <param name="repTablaTabla">Repositorio</param>
        ///// <param name="grupo">grupo</param>
        ///// <param name="texto">texto</param>
        ///// <param name="valor">Valor</param>
        ///// <returns>Lista de elementos DTO</returns>
        //public static IEnumerable<ElementoDto> ResolverListaGrupo(this ITablaTablaRepositorio repTablaTabla, string grupo, string texto, string valor, string key, bool refresh = true, string orden = "Valor", string ordenDir = "ASC")
        //{
        //    var criterioGrupo = new TablaTablaGrupoCriterio(grupo);

        //    return CacheApp.ResolverLista<ICriterio<TablaTabla>, TablaTabla, ElementoDto>(key.FormatParams(grupo),
        //        repTablaTabla.ListarParaVerOrdenar, criterioGrupo, orden, ordenDir, new ElementoDto { Texto = texto, Valor = valor }, refresh);
        //}

        ///// <summary>
        ///// Proyecta la lista tablatablas y agrega un valor al inicio de texto "SELECCIONADO".
        ///// </summary>
        ///// <param name="repTablaTabla">Repositorio</param>
        ///// <param name="grupo">grupo</param>
        ///// <param name="subgrupo">subgrupo</param>
        ///// <param name="refresh">refresh</param>
        ///// <param name="valores">valores</param>
        ///// <returns>Lista de elementos DTO</returns>
        //public static IEnumerable<ElementoDto> ResolverListaGrupoConSeleccione(this ITablaTablaRepositorio repTablaTabla, string grupo, string subgrupo, bool refresh = true, params string[] valores)
        //{
        //    string valor = string.Empty;
        //    string texto = PrimerValorEnum.Seleccione.ToString();

        //    return ResolverListaGrupo(repTablaTabla, grupo, subgrupo, texto, valor, KeyCache.Cache_ListaElementoSeleccione_Grupo_SubGrupo, refresh, valores);
        //}

        ///// <summary>
        ///// Proyecta la lista tablatablas y agrega un valor al inicio.
        ///// </summary>
        ///// <param name="repTablaTabla">Repositorio</param>
        ///// <param name="grupo">grupo</param>
        ///// <param name="subgrupo">subgrupo</param>
        ///// <param name="texto">texto</param>
        ///// <param name="valor">valor</param>
        ///// <param name="key">key</param>
        ///// <param name="refresh">refresh</param>
        ///// <param name="valores">valores</param>
        ///// <returns>Lista de elementos DTO</returns>
        //public static IEnumerable<ElementoDto> ResolverListaGrupo(this ITablaTablaRepositorio repTablaTabla, string grupo, string subgrupo, string texto, string valor, string key, bool refresh = true, params string[] valores)
        //{
        //    var criterioGrupo = new TablaTablaGrupoIdsCriterio(grupo, valores);

        //    return CacheApp.ResolverLista<ICriterio<TablaTabla>, TablaTabla, ElementoDto>(key.FormatParams(grupo, subgrupo),
        //        repTablaTabla.ListarParaVerOrdenar, criterioGrupo, "Valor", "ASC", new ElementoDto { Texto = texto, Valor = valor }, refresh);
        //}


        /// <summary>
        /// resuelve lista con identicador de un tipo especial
        /// </summary>
        /// <typeparam name="TTypeSource"></typeparam>
        /// <param name="criterio"></param>
        /// <param name="methodCall"></param>
        /// <returns></returns>
        public static IEnumerable<ElementoDto> ResolverListaTipoConSeleccione<TTypeSource>(this ICriterio<TTypeSource> criterio, Func<ICriterio<TTypeSource>, string, string, IEnumerable<TTypeSource>> methodCall, string orden, string ordenDir, bool refresh = true)
            where TTypeSource : class
        {
            string valor = string.Empty;
            string texto = PrimerValorEnum.Seleccione.ToString();

            return CacheApp.ResolverLista<ICriterio<TTypeSource>, TTypeSource, ElementoDto>(KeyCache.Cache_ListaElementoSeleccione_Grupo.FormatParams(typeof(TTypeSource)),
                methodCall, criterio, orden, ordenDir, new ElementoDto { Texto = texto, Valor = valor }, refresh);
        }

        /// <summary>
        /// resuelve lista con identicador de un tipo especial
        /// </summary>
        /// <typeparam name="TTypeSource"></typeparam>
        /// <param name="criterio"></param>
        /// <param name="methodCall"></param>
        /// <returns></returns>
        public static IEnumerable<ElementoDto> ResolverListaTipoConTodos<TTypeSource>(this ICriterio<TTypeSource> criterio, Func<ICriterio<TTypeSource>, string, string, IEnumerable<TTypeSource>> methodCall, string orden, string ordenDir, bool refresh = true)
            where TTypeSource : class
        {
            string valor = ((int)PrimerValorEnum.Seleccione).ToString();
            string texto = PrimerValorEnum.Seleccione.ToString();

            return CacheApp.ResolverLista<ICriterio<TTypeSource>, TTypeSource, ElementoDto>(KeyCache.Cache_ListaElementoTodos_Grupo.FormatParams(typeof(TTypeSource)),
                methodCall, criterio, orden, ordenDir, new ElementoDto { Texto = texto, Valor = valor }, refresh);
        }

        #endregion

        #region Util

        /// <summary>
        /// Obtener los bytes del stream
        /// </summary>
        /// <param name="stream">stream</param>
        /// <returns>Array de Byte</returns>
        public static byte[] ObtenerBytesOfStream(this Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("Error en stream de archivo: Stream no debe ser Nulo.");

            byte[] buffer = null;
            using (var memoryStream = new MemoryStream())
            {
                stream.Position = 0;
                buffer = new byte[8 * 1024];
                var len = 0; ;
                while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, len);
                }
                memoryStream.Flush();
                memoryStream.Position = 0;

                buffer = memoryStream.ToArray();// GetBuffer();

                stream.Close();
                stream.Dispose();
            }

            return buffer;
        }

        //public Guid CrearArchivo(this Stream stream)
        //{
        //    var contenido = stream.ObtenerBytesArchivo();

        //    return Guid.NewGuid();
        //}

        #endregion
    }
}
