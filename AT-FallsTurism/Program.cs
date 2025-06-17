using AT_FallsTurism.Data;
using AT_FallsTurism.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options => {
    // Proteger as p�ginas sens�veis com o atributo [Authorize]
    options.Conventions.AuthorizePage("/Clientes/List");
    options.Conventions.AuthorizePage("/Reservas/ListaReservas");
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied"; // Define a p�gina para acesso negado
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Tempo de expira��o do cookie de autentica��o
        options.SlidingExpiration = true; // Renova o cookie se o usu�rio estiver ativo
    });

// 2. Configurar o servi�o de autoriza��o
builder.Services.AddAuthorization();

// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.AddDbContext<FallsTurismContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
