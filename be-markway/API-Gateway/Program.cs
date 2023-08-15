// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.HttpOverrides;

using Napokon.API_Gateway.Middlewares;
using Napokon.Auth.Configurations;

using Ocelot.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

AuthenticationConfiguration authenticationConfiguration = builder.AddAuthenticationConfiguration();

builder.ConfigureAppConfiguration();
builder.ConfigureAuthentication(authenticationConfiguration);
builder.ConfigureCors();

WebApplication app = builder.Build();

app.UseRouting();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    RequireHeaderSymmetry = false,
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseCors(AuthenticationConfiguration.ALLOW_ALL_ORIGIN);
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseOcelot().Wait();

app.Run();
