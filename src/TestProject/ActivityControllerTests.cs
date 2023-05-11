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
    public class ActivityControllerTests
    {
        private ActivityController _activityController;
        private Mock<IActivityService> _activityServiceMock;

        [SetUp]
        public void Setup()
        {
            _activityServiceMock = new Mock<IActivityService>();
            _activityController = new ActivityController(_activityServiceMock.Object);
        }

        [Test]
        public void Create_InvalidActivity_ReturnsNotFound()
        {
            // Arrange
            Activity invalidActivity = null;

            // Act
            var result = _activityController.Create(invalidActivity);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Create_ValidActivity_ReturnsOkResult()
        {
            // Arrange
            var validActivity = new Activity();

            _activityServiceMock.Setup(x => x.Add<ActivityValidator>(validActivity))
                .Returns(new Activity { Id = 1 });

            // Act
            var result = _activityController.Create(validActivity);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Update_InvalidActivity_ReturnsNotFound()
        {
            // Arrange
            Activity invalidActivity = null;

            // Act
            var result = _activityController.Update(invalidActivity);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Update_ValidActivity_ReturnsOkResult()
        {
            // Arrange
            var validActivity = new Activity();

            _activityServiceMock.Setup(x => x.Update<ActivityValidator>(validActivity));

            // Act
            var result = _activityController.Update(validActivity);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _activityController.Delete(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Delete_ValidId_ReturnsNoContentResult()
        {
            // Arrange
            int validId = 1;

            _activityServiceMock.Setup(x => x.Delete(validId));

            // Act
            var result = _activityController.Delete(validId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void Get_ReturnsOkResult()
        {
            // Arrange
            var activities = new[] { new Activity(), new Activity() };

            _activityServiceMock.Setup(x => x.Get())
                .Returns(activities);

            // Act
            var result = _activityController.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetById_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _activityController.Get(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetById_ValidId_ReturnsOkResult()
        {
            // Arrange
            int validId = 1;

            _activityServiceMock.Setup(x => x.GetById(validId))
                .Returns(new Activity { Id = validId });

            // Act
            var result = _activityController.Get(validId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}