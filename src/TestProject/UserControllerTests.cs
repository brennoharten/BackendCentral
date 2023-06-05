using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Application.Controllers;
using Application.ViewModels;
using Service.Validators;

namespace Application.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _userController;
        private Mock<IUserService> _userServiceMock;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _userController = new UserController(_userServiceMock.Object);
        }

        [Test]
        public void Create_InvalidUser_ReturnsNotFound()
        {
            // Arrange
            UserViewModel invalidUser = null;

            // Act
            var result = _userController.Create(invalidUser);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Create_ValidUser_ReturnsOkResult()
        {
            // Arrange
            var validUser = new User();

            _userServiceMock.Setup(x => x.Add<UserValidator>(validUser))
                .Returns(new User { Id = 1 });

            // Act
            var result = _userController.Create(new UserViewModel());

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Update_InvalidUser_ReturnsNotFound()
        {
            // Arrange
            User invalidUser = null;

            // Act
            var result = _userController.Update(invalidUser);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Update_ValidUser_ReturnsOkResult()
        {
            // Arrange
            var validUser = new User();

            _userServiceMock.Setup(x => x.Update<UserValidator>(validUser));

            // Act
            var result = _userController.Update(validUser);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _userController.Delete(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Delete_ValidId_ReturnsNoContentResult()
        {
            // Arrange
            int validId = 1;

            _userServiceMock.Setup(x => x.Delete(validId));

            // Act
            var result = _userController.Delete(validId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void Get_ReturnsOkResult()
        {
            // Arrange
            var users = new[] { new User(), new User() };

            _userServiceMock.Setup(x => x.Get())
                .Returns(users);

            // Act
            var result = _userController.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetById_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _userController.Get(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetById_ValidId_ReturnsOkResult()
        {
            // Arrange
            int validId = 1;

            _userServiceMock.Setup(x => x.GetById(validId))
                .Returns(new User { Id = validId });

            // Act
            var result = _userController.Get(validId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}

