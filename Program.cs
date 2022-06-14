using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// ** Add Redis **
builder.Services.AddStackExchangeRedisCache(cacheOptions =>
{
    cacheOptions.ConfigurationOptions = ConfigurationOptions.Parse("localhost:10001");
});

// ** Add Session **
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "distcache_session";
    options.IdleTimeout = TimeSpan.FromMinutes(60 * 24);
});

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

// ** Use Session **
app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
