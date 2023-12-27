// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.Net;
using Markway.Shipments.API.Errors;
using UsersService;
using static UsersService.GrpcUser;

namespace Markway.Shipments.API.Services.Grpc.Clients;

public class UserClient : IUserClient
{
    private readonly ILogger<UserClient> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly GrpcUserClient _grpcUserClient;

    public UserClient(ILogger<UserClient> logger, 
        IHttpContextAccessor httpContextAccessor, 
        GrpcUserClient grpcUserClient)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _grpcUserClient = grpcUserClient;
    }

    public async Task<UserReply> GetUserByIdAsync(long userId)
    {
        try
        {
            UserRequest request = new() { Id = userId };

            return await _grpcUserClient.GetUserByIdAsync(request);
        }
        catch (Exception e)
        {
            _logger.LogError($"Error in UserClient in GetUserByIdAsync {e.Message} in {e.StackTrace}");
            throw new HttpResponseException(HttpStatusCode.BadRequest, new ErrorResponse(ErrorCode.SERVICE_ABBREVIATION_0001));
        }
    }
}
