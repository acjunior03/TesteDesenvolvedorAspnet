using System.Web.Mvc;
using TesteDesenvolvedorAspNet.Contracts;
using TesteDesenvolvedorAspNet.Data;
using TesteDesenvolvedorAspNet.Repositorio;
using Unity;
using Unity.Mvc5;

namespace TesteDesenvolvedorAspNet
{
    public static class UnityConfig
    {
   //     public static void RegisterComponents()
   //     {
			//var container = new UnityContainer();
            
   //         // register all your components with the container here
   //         // it is NOT necessary to register your controllers
            
   //         // e.g. container.RegisterType<ITestService, TestService>();
            
   //         DependencyResolver.SetResolver(new UnityDependencyResolver(container));
   //     }
        public static void RegistraComponentes()
        {
            var container = new UnityContainer();
            container.RegisterType<IClienteRepositorio, ClienteRepositorio>();
            container.RegisterType<IProdutoRepositorio, ProdutoRepositorio>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}