using MailKit;
using System.Configuration;

var builder = WebApplication.CreateBuilder( args);


// Add services to the container.
builder.Services.AddControllersWithViews();

//activation le middleware de compression de réponse
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.SmallestSize;
});


//Liaison a la base de donnnee par le stringConnection qui se trouve dans le fichier "appsettings.json"
string strcon = builder.Configuration.GetConnectionString("SwissUmefDb");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(strcon));

//builder.Services.AddDbContext<DataContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("SwissUmefDb")));


//builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<Site_De_Swiss_UMEF.Models.IMailService, Site_De_Swiss_UMEF.Models.MailService>();


//builder.Services.AddDbContext<DataContext>(options =>
//options.UseNpgsql(builder.Configuration.GetConnectionString("SwissUmefDb")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
builder.Services.AddTransient<IEmailSender, MailJetEmailSender>();
builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 5;
    opt.Password.RequireLowercase = true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    opt.Lockout.MaxFailedAccessAttempts = 3;
});

var app = builder.Build();


//Permet de lever l'exception lier a la compatibiliter de DateTime(c#) et Timestamp(Postgresql)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseResponseCompression();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
