using System;
using System.Collections.Generic;
using System.Linq;
using DryIoc;
using Modular.NET.Core.Interfaces;
using Modular.NET.Core.Managers;

namespace Modular.NET.Core
{
    public static class Engine
    {
        #region Fields, Properties and Indexers

        private static IContainer _Container { get; }

        public static ICurrent Current => Resolve<ICurrent>();

        #endregion

        #region Constructors

        static Engine()
        {
            _Container = new Container();
        }

        #endregion

        #region Static Methods

        public static void Start()
        {
            _Container.ScanAssemblies<IModule>();

            // Configure module services
            var modules = ResolveMany<IModule>();
            foreach (var module in modules)
            {
                module.ConfigureServices(_Container);
            }
        }

        public static void Exit()
        {
            LogManager.CloseAndFlush();
        }

        public static string Diagnostics()
        {
            return string.Join("\r\n", _Container.GetServiceRegistrations()
                .Select(x =>
                    $"[{x.OptionalServiceKey}]\r\n{x.ServiceType.FullName}\r\n{x.Factory.ImplementationType?.FullName}"));
        }

        public static IContainer GetContainer()
        {
            return _Container;
        }

        public static void Register(Type serviceAndMayBeImplementationType,
            IReuse reuse = null,
            Made made = null,
            Setup setup = null,
            IfAlreadyRegistered? ifAlreadyRegistered = null,
            object serviceKey = null)
        {
            _Container.Register(serviceAndMayBeImplementationType, reuse, made, setup, ifAlreadyRegistered, serviceKey);
        }

        public static void Register(Type serviceType,
            Type implementationType,
            IReuse reuse = null,
            Made made = null,
            Setup setup = null,
            IfAlreadyRegistered? ifAlreadyRegistered = null,
            object serviceKey = null)
        {
            _Container.Register(serviceType, implementationType, reuse, made, setup, ifAlreadyRegistered, serviceKey);
        }

        public static void Register<TImplementation>(IReuse reuse = null,
            Made made = null,
            Setup setup = null,
            IfAlreadyRegistered? ifAlreadyRegistered = null,
            object serviceKey = null)
        {
            _Container.Register<TImplementation>(reuse, made, setup, ifAlreadyRegistered, serviceKey);
        }

        public static void Register<TService, TImplementation>(IReuse reuse = null,
            Made made = null,
            Setup setup = null,
            IfAlreadyRegistered? ifAlreadyRegistered = null,
            object serviceKey = null) where TImplementation : TService
        {
            _Container.Register<TService, TImplementation>(reuse, made, setup, ifAlreadyRegistered, serviceKey);
        }

        public static object MustResolve(Type serviceType)
        {
            return _Container.Resolve(serviceType);
        }

        public static object MustResolve(Type serviceType,
            string serviceKey)
        {
            return _Container.Resolve(serviceType, serviceKey);
        }

        public static T MustResolve<T>()
        {
            return _Container.Resolve<T>();
        }

        public static T MustResolve<T>(string serviceKey)
        {
            return _Container.Resolve<T>(serviceKey);
        }

        public static object Resolve(Type serviceType)
        {
            return _Container.Resolve(serviceType, IfUnresolved.ReturnDefault);
        }

        public static object Resolve(Type serviceType,
            string serviceKey)
        {
            return _Container.Resolve(serviceType, serviceKey, IfUnresolved.ReturnDefault);
        }

        public static T Resolve<T>()
        {
            return _Container.Resolve<T>(IfUnresolved.ReturnDefault);
        }

        public static T Resolve<T>(string serviceKey)
        {
            return _Container.Resolve<T>(serviceKey, IfUnresolved.ReturnDefault);
        }

        public static IEnumerable<object> ResolveMany(Type serviceType)
        {
            return _Container.ResolveMany(serviceType);
        }

        public static IEnumerable<object> ResolveMany(Type serviceType,
            string serviceKey)
        {
            return _Container.ResolveMany(serviceType, serviceKey: serviceKey);
        }

        public static IEnumerable<T> ResolveMany<T>()
        {
            return _Container.ResolveMany<T>();
        }

        public static IEnumerable<T> ResolveMany<T>(string serviceKey)
        {
            return _Container.ResolveMany<T>(serviceKey: serviceKey);
        }

        public static IResolverContext OpenScope(object name = null,
            bool trackInParent = false)
        {
            return _Container.OpenScope(name, trackInParent);
        }

        #endregion
    }
}
