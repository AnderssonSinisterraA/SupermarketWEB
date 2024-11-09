using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;

namespace SupermarketWEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregar servicios al contenedor.
            builder.Services.AddRazorPages();

            // Definir la cadena de conexión directamente en el código
            var connectionString = "Data Source=(localdb)\\mssqllocalDB;Database=SupermarketEF;Trusted_Connection=True;";

            // Agregar el contexto SupermarketContext a la aplicación
            builder.Services.AddDbContext<SupermarketContext>(options =>
                options.UseSqlServer(connectionString)
            );

            // Agregar servicios de autenticación
            builder.Services.AddAuthentication("MyCookieAuth")
                .AddCookie("MyCookieAuth", options =>
                {
                    options.Cookie.Name = "MyCookieAuth";
                    options.LoginPath = "/Account/Login";
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configurar el pipeline de solicitudes HTTP.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
