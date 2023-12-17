using LuminaAPI.Model.Config;
using LuminaAPI.Service;
using LuminaAPI.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.Configure<CollectionNames>(builder.Configuration.GetSection("CollectionNames"));
builder.Services.Configure<ConnectionConfig>(builder.Configuration.GetSection("ConnectionConfig"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

builder.Services.AddSingleton(builder.Configuration.GetSection("CollectionNames").Get<CollectionNames>());
builder.Services.AddSingleton(builder.Configuration.GetSection("ConnectionConfig").Get<ConnectionConfig>());
builder.Services.AddTransient<IPMSService, PMSService>();
builder.Services.AddTransient<IPADService, PADService>();
builder.Services.AddTransient<IPADTransService, PADTransService>();
builder.Services.AddTransient<IAliasService, AliasService>();
builder.Services.AddTransient<IColorService, ColorService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ISizeService, SizeService>();
builder.Services.AddTransient<IModelService, ModelService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("myAppCors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
