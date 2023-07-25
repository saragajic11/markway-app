// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace ExampleEntity.UnitTest;

using AutoMapper;

using Microsoft.Extensions.Logging;

using Moq;

using Napokon.Customer.API.Repository.Core;
using Napokon.Customer.API.Services;
using Napokon.Customer.API.Services.Core;

public class EntityServiceTests
{
    private readonly EntityService _entityService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<ILogger<EntityService>> _mockLogger;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IExampleEntityRepository> _mockEntityRepository;
    private readonly Mock<IElasticSearchService> _elasticSearchService;

    public EntityServiceTests()
    {
        _mockMapper = new();
        _mockLogger = new();
        _mockUnitOfWork = new();
        _mockEntityRepository = new();
        _elasticSearchService = new();
        _entityService = new(_mockMapper.Object, _elasticSearchService.Object, _mockUnitOfWork.Object, _mockLogger.Object);
    }

    [Fact]
    public async void Should_Result_When_TestState()
    {
        // GIVEN - Define consts and Mocks

        // WHEN - Service invocation

        // THEN - Check results
    }
}
