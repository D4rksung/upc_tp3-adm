using Microsoft.Practices.Unity;
using System.Configuration;
using System.Linq;
using System;
using PetCenter.Referencias.Transversal.Mapeo;

namespace PetCenter.Referencias.Inyeccion
{
    public class Dependencia
    {
        private static IUnityContainer _container;

        static Dependencia()
        {
            _container = new UnityContainer();
            //var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //if (section != null)
            //{
            //    section.Configure(container);
            //}
            //_container = container;
            ContenedorInyeccion.ObtenerRegistros(_container);
            var typeAdapterFactory = Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);

        }

        public static T Resolve<T>()
        {
            T ret = default(T);

            if (_container.IsRegistered(typeof(T)))
            {
                ret = _container.Resolve<T>();
            }

            return ret;
        }
    }
}
