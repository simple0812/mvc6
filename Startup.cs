using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

public class Startup {
    public void Configure(IApplicationBuilder app) {
        //app.Run(context => context.Response.WriteAsync("hello"));

        app.UseMvc(routes => {
                routes.MapRoute(name : "default", template : "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name : "hello", template : "{controller=Hello}/{action=World}/{id?}");
            });
    }

    public void ConfigureServices(IServiceCollection services) {
        services.AddEntityFramework().AddSqlServer().AddDbContext<MyDbContext>();
        services.AddMvc();
    }
}
