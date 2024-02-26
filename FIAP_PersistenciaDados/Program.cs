using FIAP_PersistenciaDados.Interfaces;
using FIAP_PersistenciaDados.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IProdutoService, ProdutoService>();

//// Configura��o da inje��o de depend�ncia para o AppDbContext
//builder.Services.AddDbContext<AppDbContext>(options =>
//        options.UseNpgsql("Host=host.docker.internal;Database=persistenciadados;Username=postgres;Password=102030"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produtos}/{action=Index}/{id?}");

app.Run();