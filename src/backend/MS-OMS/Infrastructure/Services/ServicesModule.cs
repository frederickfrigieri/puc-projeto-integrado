using Application.Services.Contracts;
using Application.Settings;
using Autofac;
using Infrastructure.Services.Http;
using System;
using System.Net.Http;

namespace Infrastructure.Services
{
    public class ServicesModule : Module
    {
        private readonly AutenticacaoSetting _autenticacaoSetting;

        public ServicesModule(AutenticacaoSetting autenticacaoSetting)
        {
            _autenticacaoSetting = autenticacaoSetting;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_autenticacaoSetting != null)
            {
                builder.Register(ctx => new HttpClient() { BaseAddress = new Uri(_autenticacaoSetting.BaseUrl) })
                    .Named<HttpClient>("HttpAutenticacao")
                    .SingleInstance();

                builder.Register(context => new AutenticacaoService(context.ResolveNamed<HttpClient>("HttpAutenticacao")))
                    .As<IAutenticacao>()
                    .InstancePerDependency();
            }
        }
    }
}
