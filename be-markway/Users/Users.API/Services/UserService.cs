// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using AutoMapper;
using Markway.Commons.Authorization;
using Markway.Users.API.Models;
using Markway.Users.API.Models.DTO;
using Markway.Users.API.Repository.Core;
using Markway.Users.API.Services.Core;
namespace Markway.Users.API.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IElasticSearchService elasticSearchService, IUnitOfWork unitOfWork, ILogger<UserService> logger)
            : base(logger, unitOfWork, elasticSearchService)
        {
            _mapper = mapper;
        }

        public async Task<User?> AddAsync(UserDto dto)
        {
            try
            {
                User user = _mapper.Map<User>(dto);

                user.Status = UserStatus.ACTIVE;

                return await base.AddAsync(user);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in Add {e.Message} in {e.StackTrace}");
                return null;
            }
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            try
            {
                return await _unitOfWork.Users.GetUserByUsernameAsync(username);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in GetByUsernameAsync {e.Message} in {e.StackTrace}");
                return null;
            }
        }
    }
}
