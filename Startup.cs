using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Runtime;
using Microsoft.Framework.Configuration;
using System;
using System.Diagnostics;


public class Startup {

    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.

            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);
            /*
            if (env.IsDevelopment())
            {
                // This reads the configuration keys from the secret store.
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }*/

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

    public IConfiguration Configuration { get; set; }

    public void Configure(IApplicationBuilder app) {
        //app.Run(context => context.Response.WriteAsync("hello"));

        

        //Middleware 1111
        app.Use(next => new TimeRecorderMiddleware(next).Invoke);

        /* Middleware 2222
        //Middleware是Func<RequestDelegate, RequestDelegate>委托类型的实例*/
        app.Use(new Func<RequestDelegate, RequestDelegate>(next => content => Invoke(next, content)));
        

        app.UseMvc(routes => {
                routes.MapRoute(name : "default", template : "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name : "hello", template : "{controller=Hello}/{action=World}/{id?}");
            });
    }

    public void ConfigureServices(IServiceCollection services) {
        services.AddEntityFramework().AddSqlServer().AddDbContext<MyDbContext>();

        services.AddMvc();
    }

    private async Task Invoke(RequestDelegate next, HttpContext content)
    {
       Console.WriteLine("初始化组件开始");
       await next.Invoke(content);
       Console.WriteLine("管道下步执行完毕");
    }
}


 public class TimeRecorderMiddleware
{
    RequestDelegate _next;

    public TimeRecorderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        var sw = new Stopwatch();
        sw.Start();


        await _next(context);

        var newDiv = @"<div id=""process"">process time:{0} ms</div>";
        var text = string.Format(newDiv, sw.ElapsedMilliseconds);
        Console.WriteLine(text);
        await context.Response.WriteAsync(text);
    }
}


