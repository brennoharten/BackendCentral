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
    public class RankControllerTests
    {
        private RankController _rankController;
        private Mock<IRankService> _rankServiceMock;

        [SetUp]
        public void Setup()
        {
            _rankServiceMock = new Mock<IRankService>();
            _rankController = new RankController(_rankServiceMock.Object);
        }

        [Test]
        public void Create_InvalidRank_ReturnsNotFound()
        {
            // Arrange
            Rank invalidRank = null;

            // Act
            var result = _rankController.Create(invalidRank);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Create_ValidRank_ReturnsOkResult()
        {
            // Arrange
            var validRank = new Rank();

            _rankServiceMock.Setup(x => x.Add<RankValidator>(validRank))
                .Returns(new Rank { Id = 1 });

            // Act
            var result = _rankController.Create(validRank);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Update_InvalidRank_ReturnsNotFound()
        {
            // Arrange
            Rank invalidRank = null;

            // Act
            var result = _rankController.Update(invalidRank);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Update_ValidRank_ReturnsOkResult()
        {
            // Arrange
            var validRank = new Rank();

            _rankServiceMock.Setup(x => x.Update<RankValidator>(validRank));

            // Act
            var result = _rankController.Update(validRank);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _rankController.Delete(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Delete_ValidId_ReturnsNoContentResult()
        {
            // Arrange
            int validId = 1;

            _rankServiceMock.Setup(x => x.Delete(validId));

            // Act
            var result = _rankController.Delete(validId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void Get_ReturnsOkResult()
        {
            // Arrange
            var ranks = new[] { new Rank(), new Rank() };

            _rankServiceMock.Setup(x => x.Get())
                .Returns(ranks);

            // Act
            var result = _rankController.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetById_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _rankController.Get(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetById_ValidId_ReturnsOkResult()
        {
            // Arrange
            int validId = 1;

            _rankServiceMock.Setup(x => x.GetById(validId))
                .Returns(new Rank { Id = validId });

            // Act
            var result = _rankController.Get(validId);


            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
