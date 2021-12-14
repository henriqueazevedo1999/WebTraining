using BusinessLogicalLayer;
using BusinessLogicalLayer.Interfaces;
using ClienteAPI.Application.Handlers;
using FluentValidation;
using MediatR;
using MetaData.Entities;
using System.Reflection;

namespace ClienteAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration; 
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddMvc(options =>
        //{
        //    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        //});

        services.AddControllers();
        services.AddSwaggerGen();
        AddMediatr(services);
        services.AddSingleton<IRepository<Cliente>, ClienteBLL>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();    
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private static void AddMediatr(IServiceCollection services)
    {
        // Add all the assemblies to MediatR
        services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

        // For all the validators, register them with dependency injection as scoped
        AssemblyScanner.FindValidatorsInAssembly(typeof(Startup).Assembly)
          .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

        // Add the custome pipeline validation to DI
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
    }
}
