using API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.WebHost.UseUrls("http://0.0.0.0:80");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
    options.AddPolicy("FrontEndClient", builder =>
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .WithOrigins("http://localhost.sportz.io"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontEndClient");
app.UseAuthorization();
app.MapControllers();
app.Run();
