// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using UsersService;

namespace Markway.Shipments.API.Services.Grpc.Clients;

public interface IUserClient
{
    Task<UserReply> GetUserByIdAsync(long userId);
}
