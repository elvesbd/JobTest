using VehicleCatalogAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureMvc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
