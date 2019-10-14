using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ProxyKit.Recipe.Simple
{
    public class ProxyStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddProxy(
                //httpClientBuilder => httpClientBuilder.ConfigureHttpClient(client =>
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "zt4ubir0dv2gptla3prfhbap"))//c3ZfZXphcGxhdGluOlplZnNBMTAw
                );
           

        }

        public void Configure(IApplicationBuilder app)
        {
            app.RunProxy(context => context
                .ForwardTo("http://localhost") //http://s84.rt.ru/SystemNavigator/Main.aspx?App=FIN_ANALITIC_1
                .AddXForwardedHeaders()
                .Send());
        }
    }
}