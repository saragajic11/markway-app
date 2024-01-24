// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.Commons.Configurations;
using Markway.Shipments.API.Constants;
using Markway.Shipments.API.Middlewares;
using Markway.Shipments.API.Services.Grpc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ISystemConfiguration systemConfiguration = builder.AddSystemConfiguration();

builder.ConfigureDatabase(systemConfiguration);

builder.Services.ConfigureElasticSearch(systemConfiguration);

builder.Services.ConfigureRedis(systemConfiguration);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddServices();

builder.Services.AddHealthChecks();

builder.Services.AddAuthenticationAndAuthorization(systemConfiguration);

builder.ConfigureCors();

builder.ConfigureKestrel();

builder.AddGrpcClients(systemConfiguration);

builder.Services.AddGrpc();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

app.ConfigureExceptionHandler();

app.ExecuteDatabaseMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGrpcService<GrpcShipmentService>();

app.UseRouting();

// It goes after useRouting() or useEndpoints()
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(Policies.CORS.ALLOW_ALL_ORIGIN);

app.MapHealthChecks(Endpoints.HEALTH);

app.MapControllers();

app.Run();
