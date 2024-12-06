using Microsoft.EntityFrameworkCore;
using NotificacoesApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Entity Framework com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=notificacoes.db"));

// Adiciona suporte a controllers com views
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Notificacao}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!context.Notificacoes.Any())
    {
        context.Notificacoes.Add(new Notificacao
        {
            Tipo = "Teste",
            Gravidade = "Alta",
            DataRecebimento = DateTime.Now
        });
        context.SaveChanges();
    }
}

app.Run();


