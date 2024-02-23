using Castle.Core.Logging;
using ErrorOr;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using N5Challenge.Application.Common.DTO;
using N5Challenge.Application.Common.Interfaces;
using N5Challenge.Application.Permissions.Commands.RequestPermission;
using N5Challenge.Domain.Permissions;
using TestCommon.Permissions;

namespace N5Challenge.Application.UnitTests.Permissions.Commands
{
    public class RequestPermissionCommandHandlerTests
    {
        private readonly Mock<IPermissionRepository> _permissionRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IElasticsearchService<ElasticRegistryDTO>> _elasticSearcServiceMock;

        public RequestPermissionCommandHandlerTests()
        {
            _permissionRepositoryMock = new();
            _unitOfWorkMock = new();
            _elasticSearcServiceMock = new();
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenPermissionAlreadyExists()
        {
            // Arrange
            var command = new RequestPermissionCommand("Juan", "Sosa", 1);

            _permissionRepositoryMock.Setup(x => x.GetPermission(It.IsAny<Permission>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Permission("dummyName", "dummySurname", 1));

            var handler = new RequestPermissionCommandHandler(_permissionRepositoryMock.Object, _unitOfWorkMock.Object, _elasticSearcServiceMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Conflict);
        }

        [Fact]
        public async Task Handle_Should_ReturnCreatedPermission_WhenValidCommand()
        {
            // Arrange
            var command = new RequestPermissionCommand("Juan", "Sosa", 1);

            _elasticSearcServiceMock.Setup(x => x.CreateRegisterAsync(It.IsAny<ElasticRegistryDTO>())).ReturnsAsync(true);

            var handler = new RequestPermissionCommandHandler(_permissionRepositoryMock.Object, _unitOfWorkMock.Object, _elasticSearcServiceMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.AssertCreatedFrom(command);
        }

        [Fact]
        public async Task Handle_Should_NotCallUnitOfWork_WhenPermissionAlreadyExists()
        {
            // Arrange
            var command = new RequestPermissionCommand("Juan", "Sosa", 1);

            _permissionRepositoryMock.Setup(x => x.GetPermission(It.IsAny<Permission>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Permission("dummyName", "dummySurname", 1));

            var handler = new RequestPermissionCommandHandler(_permissionRepositoryMock.Object, _unitOfWorkMock.Object, _elasticSearcServiceMock.Object);

            // Act
            await handler.Handle(command, default);

            // Assert
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenElasticsearchFails()
        {
            // Arrange
            var command = new RequestPermissionCommand("Juan", "Sosa", 1);

            _elasticSearcServiceMock.Setup(x => x.CreateRegisterAsync(It.IsAny<ElasticRegistryDTO>())).ReturnsAsync(false);

            var handler = new RequestPermissionCommandHandler(_permissionRepositoryMock.Object, _unitOfWorkMock.Object, _elasticSearcServiceMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Unexpected);
        }
    }
}
