using AT_FallsTurism.Data;
using AT_FallsTurism.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options => {
    // Proteger as páginas sensíveis com o atributo [Authorize]
    options.Conventions.AuthorizePage("/Clientes/List");
    options.Conventions.AuthorizePage("/Reservas/ListaReservas");
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied"; // Define a página para acesso negado
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Tempo de expiração do cookie de autenticação
        options.SlidingExpiration = true; // Renova o cookie se o usuário estiver ativo
    });

// 2. Configurar o serviço de autorização
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
