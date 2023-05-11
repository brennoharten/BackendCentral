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
    public class ProfileControllerTests
    {
        private ProfileController _profileController;
        private Mock<IProfileService> _profileServiceMock;

        [SetUp]
        public void Setup()
        {
            _profileServiceMock = new Mock<IProfileService>();
            _profileController = new ProfileController(_profileServiceMock.Object);
        }

        [Test]
        public void Create_InvalidProfile_ReturnsNotFound()
        {
            // Arrange
            Profile invalidProfile = null;

            // Act
            var result = _profileController.Create(invalidProfile);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Create_ValidProfile_ReturnsOkResult()
        {
            // Arrange
            var validProfile = new Profile();

            _profileServiceMock.Setup(x => x.Add<ProfileValidator>(validProfile))
                .Returns(new Profile { Id = 1 });

            // Act
            var result = _profileController.Create(validProfile);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Update_InvalidProfile_ReturnsNotFound()
        {
            // Arrange
            Profile invalidProfile = null;

            // Act
            var result = _profileController.Update(invalidProfile);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Update_ValidProfile_ReturnsOkResult()
        {
            // Arrange
            var validProfile = new Profile();

            _profileServiceMock.Setup(x => x.Update<ProfileValidator>(validProfile));

            // Act
            var result = _profileController.Update(validProfile);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _profileController.Delete(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Delete_ValidId_ReturnsNoContentResult()
        {
            // Arrange
            int validId = 1;

            _profileServiceMock.Setup(x => x.Delete(validId));

            // Act
            var result = _profileController.Delete(validId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void Get_ReturnsOkResult()
        {
            // Arrange
            var profiles = new[] { new Profile(), new Profile() };

            _profileServiceMock.Setup(x => x.Get())
                .Returns(profiles);

            // Act
            var result = _profileController.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetById_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _profileController.Get(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetById_ValidId_ReturnsOkResult()
        {
            // Arrange
            int validId = 1;

            _profileServiceMock.Setup(x => x.GetById(validId))
                .Returns(new Profile { Id = validId });

            // Act
            var result = _profileController.Get(validId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
