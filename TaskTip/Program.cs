using Microsoft.EntityFrameworkCore;
using TaskTipCore.Services.Customer;
using TaskTipDataLayer.Context;

var builder = WebApplication.CreateBuilder(args);

#region معرفی کانکشن پروژه


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TaskTipContext>(options =>
        options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(TaskTipContext).Assembly.FullName))
    , ServiceLifetime.Scoped);

#endregion
#region Services

builder.Services.AddTransient<ICustomerServices, CustomerServices>();


#endregion


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
