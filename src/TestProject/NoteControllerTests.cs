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
    public class NoteControllerTests
    {
        private NoteController _noteController;
        private Mock<INoteService> _noteServiceMock;

        [SetUp]
        public void Setup()
        {
            _noteServiceMock = new Mock<INoteService>();
            _noteController = new NoteController(_noteServiceMock.Object);
        }

        [Test]
        public void Create_InvalidNote_ReturnsNotFound()
        {
            // Arrange
            Note invalidNote = null;

            // Act
            var result = _noteController.Create(invalidNote);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Create_ValidNote_ReturnsOkResult()
        {
            // Arrange
            var validNote = new Note();

            _noteServiceMock.Setup(x => x.Add<NoteValidator>(validNote))
                .Returns(new Note { Id = 1 });

            // Act
            var result = _noteController.Create(validNote);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Update_InvalidNote_ReturnsNotFound()
        {
            // Arrange
            Note invalidNote = null;

            // Act
            var result = _noteController.Update(invalidNote);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Update_ValidNote_ReturnsOkResult()
        {
            // Arrange
            var validNote = new Note();

            _noteServiceMock.Setup(x => x.Update<NoteValidator>(validNote));

            // Act
            var result = _noteController.Update(validNote);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _noteController.Delete(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Delete_ValidId_ReturnsNoContentResult()
        {
            // Arrange
            int validId = 1;

            _noteServiceMock.Setup(x => x.Delete(validId));

            // Act
            var result = _noteController.Delete(validId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void Get_ReturnsOkResult()
        {
            // Arrange
            var notes = new[] { new Note(), new Note() };

            _noteServiceMock.Setup(x => x.Get())
                .Returns(notes);

            // Act
            var result = _noteController.Get();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetById_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidId = 0;

            // Act
            var result = _noteController.Get(invalidId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetById_ValidId_ReturnsOkResult()
        {
            // Arrange
            int validId = 1;

            _noteServiceMock.Setup(x => x.GetById(validId))
                .Returns(new Note { Id = validId });

            // Act
            var result = _noteController.Get(validId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}