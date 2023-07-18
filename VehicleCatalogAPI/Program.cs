using VehicleCatalogAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureAuthentication();
builder.ConfigureMvc();
builder.ConfigureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
