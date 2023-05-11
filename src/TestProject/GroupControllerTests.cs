using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Application.Controllers;
using Service.Validators;

namespace Application.Tests.Controllers
{
    [TestFixture]
    public class GroupControllerTests
    {
        private GroupController _groupController;
        private Mock<IGroupService> _groupServiceMock;

        [SetUp]
        public void Setup()
        {
            _groupServiceMock = new Mock<IGroupService>();
            _groupController = new GroupController(_groupServiceMock.Object);
        }

        [Test]
        public void Create_InvalidGroup_ReturnsNotFound()
        {
            // Arrange
            Group invalidGroup = null;

            // Act
            var result = _groupController.Create(invalidGroup);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Create_ValidGroup_ReturnsOkResult()
        {
            // Arrange
            var validGroup = new Group();

            _groupServiceMock.Setup(x => x.Add<GroupValidator>(validGroup))
                .Returns(new Group { Id = 1 });

            // Act
            var result = _groupController.Create(validGroup);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Update_InvalidGroup_ReturnsNotFound()
        {
            // Arrange
            Group invalidGroup = null;

            // Act
            var result = _groupController.Update(invalidGroup);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Update_ValidGroup_ReturnsOkResult()
        {
            // Arrange
            var validGroup = new Group();

            _groupServiceMock.Setup(x => x.Update<GroupValidator>(validGroup));

            // Act
            var result = _groupController.Update(validGroup);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _groupController.Delete(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Delete_ValidId_ReturnsNoContentResult()
        {
            // Arrange
            int validId = 1;

            _groupServiceMock.Setup(x => x.Delete(validId));

            // Act
            var result = _groupController.Delete(validId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void Get_ReturnsOkResult()
        {
            // Arrange
            var groups = new[] { new Group(), new Group() };

            _groupServiceMock.Setup(x => x.Get())
                .Returns(groups);

            // Act
            var result = _groupController.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetById_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _groupController.Get(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetById_ValidId_ReturnsOkResult()
        {
            // Arrange
            int validId = 1;

            _groupServiceMock.Setup(x => x.GetById(validId))
                .Returns(new Group { Id = validId });

            // Act
            var result = _groupController.Get(validId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
