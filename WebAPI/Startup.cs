using Aplicacao.Aplicacoes;
using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.Genericos;
using Dominio.Interfaces.InterfaceServicos;
using Dominio.Servicos;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Token;

namespace WebAPI
{
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Inje��o de depend�ncia do BD
            services.AddDbContext<Contexto>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("ConexaoDDD")));

            //Inje��o de depend�ncia IdentityUser
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<Contexto>();

            //Inje��o de depend�ncia Interface e Repositorio
            services.AddSingleton(typeof(IGenericos<>), typeof(RepositorioGenerico<>));
            services.AddSingleton<INoticia, RepositorioNoticia>();
            services.AddSingleton<IUsuario, RepositorioUsuario>();

            //Inje��o de depend�ncia Servi�o Dominio
            services.AddSingleton<IServicoNoticia, ServicoNoticia>();


            //Inje��o de depend�ncia Interface Aplica��o
            services.AddSingleton<IAplicacaoNoticia, AplicacaoNoticia>();
            services.AddSingleton<IAplicacaoUsuario, AplicacaoUsuario>();


            //Inje��o de depend�ncia seguran�a Tokwen TokenJWT, TokenJWTBuilder e JwtSecurityKey
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(option =>
              {
                  option.TokenValidationParameters = new TokenValidationParameters
                  {
                      //Valida��es
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,

                      ValidIssuer = "Teste.Securiry.Bearer", //Campo de alter��o do seu projeto ou odo neg�cio da sua empresa
                      ValidAudience = "Teste.Securiry.Bearer", //Campo de alter��o do seu projeto ou odo neg�cio da sua empresa
                      IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
                  };

                  //Eventos caso aconte�a algun erro
                  option.Events = new JwtBearerEvents
                  {
                      OnAuthenticationFailed = context =>
                      {
                          Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                          return Task.CompletedTask;
                      },
                      OnTokenValidated = context =>
                      {
                          Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                          return Task.CompletedTask;
                      }
                  };
              });

            //Inje��o de depend�ncia Controllers
            services.AddControllers();

            //Inje��o de depend�ncia Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
