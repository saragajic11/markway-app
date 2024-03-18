// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Markway.AuthOpenIddict;
using Markway.AuthOpenIddict.Configurations;
using Markway.AuthOpenIddict.Middlewares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ISystemConfiguration systemConfiguration = builder.AddSystemConfiguration();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddGrpcClients(systemConfiguration);

builder.ConfigureKestrel();

builder.ConfigureDatabase(systemConfiguration);

// builder.ConfigureKestrel();

builder.ConfigureOpenIdConnect();

builder.Services.AddHostedService<DatabaseSeeder>();

WebApplication app = builder.Build();

app.ExecuteDatabaseMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();
