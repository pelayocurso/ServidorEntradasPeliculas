using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace ServidorEntradasPeliculas
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<Interception>();

            container.RegisterType<IPeliculasService, PeliculasService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<DbInterceptor>()
            );
            container.RegisterType<IPeliculasRepository, PeliculasRepository>();

            container.RegisterType<IEntradasService, EntradasService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<DbInterceptor>()
            );
            container.RegisterType<IEntradasRepository, EntradasRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public class DbInterceptor : IInterceptorBehaviour {
            public IMethodReturn result;
            if (ApplicationDbContext.applicationDbContext == null) {
                using (var context = new ApplicationDbContext()) {
                    ApplicationDbContext.applicationDbContext = context;

                    using (var dbContextTransaction = context.Database.BeginTransaction()) {
                        try
                        {
                            result = getNext()(input, getNext);

                            if (result.Exception != null) {
                                throw new Exception("Ocurrio una excepcion " + result.Exception);
                            }
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        } catch (Exception e)
                        {
                            dbContextTransaction.Rollback();

                            throw new Exception("He hecho rollback de la transaccion", e);
                        }
                    }
                }

                ApplicationDbContext.applicationDbContext = null;
                return result;
            }
            else
            {
                result = getNext()(input, getNext);
                if (result.Exception != null)
                {
                    throw new Exception("Ocurrio una excepcion " + result.Exception);
                }
            }
            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        // private void WriteLog(string message)
        // {}
    }
}
