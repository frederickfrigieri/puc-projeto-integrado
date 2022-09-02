using Autofac;

namespace Infrastructure.Services
{
    public class ServicesModule : Module
    {
        public ServicesModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            //if (_apiUsuarioSettings != null)
            //{
            //    builder.Register(ctx => new HttpClient() { BaseAddress = new Uri(_apiUsuarioSettings.BaseUrl) })
            //        .Named<HttpClient>("HttpApiUsuario")
            //        .SingleInstance();

            //    builder.Register(context => new UsuarioService(context.ResolveNamed<HttpClient>("HttpApiUsuario")))
            //        .As<IUsuarioService>()
            //        .InstancePerDependency();
            //}

            //builder.Register(ctx => new HttpClient())
            //  .Named<HttpClient>("HttpApiIFood")
            //  .SingleInstance();
        }
    }
}
