// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Napokon.Commons.Configurations;

using Redis.OM;

namespace Napokon.be_markway.API.Middlewares
{
    public static class CacheMiddleware
    {
        public static void ConfigureRedis(this IServiceCollection services, ISystemConfiguration _systemConfiguration)
        {
            services.AddSingleton(new RedisConnectionProvider(_systemConfiguration.RedisConnectionString));

            services.AddHostedService<CacheIndexCreationService>();
        }
    }
}
