// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Text.Json;

using Microsoft.AspNetCore.Diagnostics;

using Markway.Users.API.Errors;

namespace Markway.Users.API.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null && contextFeature.Error is HttpResponseException httpResponseException)
                    {
                        context.Response.StatusCode = (int)httpResponseException.StatusCode;

                        await context.Response.WriteAsync(JsonSerializer.Serialize(httpResponseException.ErrorResponse));
                    }
                });
            });
        }
    }
}

