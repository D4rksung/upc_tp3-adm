using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using PetCenter.Referencias.Transversal.Mapeo;

namespace PetCenter.Referencias.Transversal.Cache
{
    /// <summary>
    /// Cache del aplicacion
    /// </summary>
    public static class CacheApp
    {
        #region VARIABLES

        /// <summary>
        /// Objeto principal que contiene toda la cache
        /// </summary>
        private readonly static ObjectCache _objectCache;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Contructor principal
        /// </summary>
        static CacheApp()
        {
            _objectCache = MemoryCache.Default;
        }

        #endregion

        #region MÉTODOS - Implementacion ICache

        /// <summary>
        /// Implementa método para obtiener la lista del orígen de datos, agrega un primer item, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource"></typeparam>
        /// <typeparam name="TTypeResult"></typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param">Parámetro a pasar</param>
        /// <param name="primerItem"></param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public static List<TTypeResult> ResolverLista<TParam, TTypeSource, TTypeResult>(
            string name, 
            Func<TParam, string, string, IEnumerable<TTypeSource>> methodCall, 
            TParam param, string orden,string ordenDir,
            TTypeResult primerItem, bool refresh = false, Double minutes = 0)
            where TTypeResult : class
        {
            if (!refresh)
            {
                var listResult = (List<TTypeResult>)_objectCache.Get(name);
                if (listResult != null) return listResult;

                List<TTypeSource> listDataSource = methodCall.Invoke(param, orden, ordenDir).ToList();
                if (listDataSource.Any())
                {
                    listResult = listDataSource.ProyectarComoLista<TTypeSource, TTypeResult>();
                    listResult.Insert(0, primerItem);
                    AddItem(name, listResult, minutes);

                    return listResult;
                }

                return listDataSource.ProyectarComoLista<TTypeSource, TTypeResult>();
            }
            else
            {
                var listDataSource = methodCall.Invoke(param, orden, ordenDir).ToList();
                if (listDataSource.Any())
                {
                    var listResult = listDataSource.ProyectarComoLista<TTypeSource, TTypeResult>();
                    listResult.Insert(0, primerItem);
                    RemoveItem(name);
                    AddItem(name, listResult, minutes);

                    return listResult;
                }
                return listDataSource.ProyectarComoLista<TTypeSource, TTypeResult>();
            }
        }

        /// <summary>
        /// Implementa método para obtiener la lista del orígen de datos, agrega un primer item, guardar en cache y retorna los datos.
        /// </summary>
        /// <typeparam name="TParam">Parámetro para llamar al método que obtiene datos</typeparam>
        /// <typeparam name="TTypeSource"></typeparam>
        /// <typeparam name="TTypeResult"></typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar para obtener datos, si estos no existen en cache</param>
        /// <param name="param">Parámetro a pasar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        /// <returns></returns>
        public static List<TTypeResult> ResolverLista<TParam, TTypeSource, TTypeResult>(
            string name,
            Func<TParam, string, string, IEnumerable<TTypeSource>> methodCall,
            TParam param, string orden, string ordenDir,
            bool refresh = true, 
            Double minutes = 0)
            where TParam : class
            where TTypeResult : class
            where TTypeSource : class
        {
            if (!refresh)
            {
                var listResult = (List<TTypeResult>)_objectCache.Get(name);
                if (listResult != null) return listResult;

                List<TTypeSource> listDataSource = methodCall.Invoke(param, orden, ordenDir).ToList();
                if (listDataSource.Any())
                {
                    listResult = listDataSource.ProyectarComoLista<TTypeSource, TTypeResult>();
                    AddItem(name, listResult, minutes);

                    return listResult;
                }

                return listDataSource.ProyectarComoLista<TTypeSource, TTypeResult>();
            }
            else
            {

                var listDataSource = methodCall.Invoke(param, orden, ordenDir).ToList();
                if (listDataSource.Any())
                {
                    var listResult = listDataSource.ProyectarComoLista<TTypeSource, TTypeResult>();
                    RemoveItem(name);
                    AddItem(name, listResult, minutes);

                    return listResult;
                }
                return listDataSource.ProyectarComoLista<TTypeSource, TTypeResult>();
            }
        }

        #endregion

        #region MÉTODOS - Apoyo

        /// <summary>
        /// Agrega un item en cache
        /// </summary>
        /// <typeparam name="T">Tipo a agregar</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="value">Objeto a agregar</param>
        /// <param name="minutes">Tiempo que los datos permanecen en cache, 0 = sin fecha de expiración.</param>
        private static void AddItem<T>(string name, T value, Double minutes) where T : class
        {
            if (value != null)
            {
                if (minutes > 0)
                {
                    _objectCache.Add(name, value, DateTime.Now.AddMinutes(minutes));
                }
                else
                {
                    var cacheItemPolicy = new CacheItemPolicy
                    {
                        AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration
                    };
                    _objectCache.Add(name, value, cacheItemPolicy);
                }
            }
        }

        /// <summary>
        /// RemoveItem
        /// </summary>
        /// <param name="name">name</param>
        private static void RemoveItem(string name)
        {
            if (_objectCache.Contains(name))
                _objectCache.Remove(name);
        }

        #endregion
    }
}
