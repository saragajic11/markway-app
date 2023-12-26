// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Net;
using Markway.Commons.Authorization;
using Markway.Shipments.API.Errors;
using Markway.Shipments.API.Services.Core;
using Markway.Shipments.API.Services.Grpc.Clients;
using UsersService;

namespace Markway.Shipments.API.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly ILogger _logger;
    private readonly IUserClient _userClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(ILogger<CurrentUserService> logger, IUserClient userClient, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _userClient = userClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<UserReply> GetCurrentUserAsync()
    {
        try
        {
            long currentUserId = long.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == Claims.CLAIM_UID)?.Value);

            UserReply? user = await _userClient.GetUserByIdAsync(currentUserId);

            if (user is null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest, new ErrorResponse(ErrorCode.SERVICE_ABBREVIATION_0001));
            }

            return user;
        }
        catch (Exception e)
        {
            _logger.LogError($"Error in CurrentUserService in GetCurrentUserAsync {e.Message} in {e.StackTrace}");
            throw new HttpResponseException(HttpStatusCode.BadRequest, new ErrorResponse(ErrorCode.SERVICE_ABBREVIATION_0001));
        }
    }
}
