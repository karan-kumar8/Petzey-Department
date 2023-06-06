using Business.Services.Interfaces;
using Domain.DTOs;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Assert = NUnit.Framework.Assert;

namespace TestProject
{
    [TestFixture]
    public class DepartmentControllerTests
    {
        private Mock<IDepartmentService> _departmentServiceMock;
        private Mock<ILogger<DepartmentController>> _loggerMock;
        private DepartmentController _departmentController;

        [SetUp]
        public void Setup()
        {
            _departmentServiceMock = new Mock<IDepartmentService>();
            _loggerMock = new Mock<ILogger<DepartmentController>>();
            _departmentController = new DepartmentController(_departmentServiceMock.Object, _loggerMock.Object);
        }

        [Test]
        public void EditDepartment_ValidDepartment_ReturnsOkResult()
        {
            // Arrange
            var departmentDto = new DepartmentDto
            {
                DepartmentId = Guid.NewGuid(),
                DepartmentName = "Test department",
                Description = "This is a test department",
                DepartmentEmail = "test@test.com"
            };
            _departmentServiceMock.Setup(x => x.EditDepartment(departmentDto)).Returns(departmentDto);

            // Act
            var result = _departmentController.EditDepartment(departmentDto);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }


        [Test]
        public void GetAllDepartments_ReturnsOkResult()
        {
            // Arrange
            _departmentServiceMock.Setup(x => x.GetAllDepartment()).Returns(new DepartmentDto[] { });

            // Act
            var result = _departmentController.GetAllDepartments();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

    }
}