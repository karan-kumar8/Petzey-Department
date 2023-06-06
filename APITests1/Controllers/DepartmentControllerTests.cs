using API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.Controllers.Tests
{
	[TestClass]
	public class DepartmentControllerTests
	{
		private DepartmentController _controller;
		private Mock<IDepartmentService> _departmentServiceMock;
		private Mock<ILogger<DepartmentController>> _loggerMock;
		private Mock<IMapper> _mapperMock;

		[TestInitialize]
		public void SetUp()
		{
			_departmentServiceMock = new Mock<IDepartmentService>();
			_loggerMock = new Mock<ILogger<DepartmentController>>();
			_mapperMock = new Mock<IMapper>();

			_controller = new DepartmentController(
				_departmentServiceMock.Object,
				_loggerMock.Object
			);
		}

		[TestMethod]
		public void AddDepartment_ReturnsOkResult_WhenDepartmentAddedSuccessfully()
		{
			// Arrange
			var departmentDto = new DepartmentDto
			{
				DepartmentName = "Test Department",
				Description = "Test Department Description",
				Status = true,
				DepartmentEmail = "test@example.com"
			};
			var department = new Departments
			{
				DepartmentId = Guid.NewGuid(),
				DepartmentName = departmentDto.DepartmentName,
				Description = departmentDto.Description,
				Status = departmentDto.Status,
				DepartmentEmail = departmentDto.DepartmentEmail
			};
			_mapperMock.Setup(m => m.Map<Departments>(departmentDto)).Returns(department);
			_departmentServiceMock.Setup(s => s.AddDepartment(departmentDto)).Returns(department);

			// Act
			var result = _controller.AddDepartment(departmentDto) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(department, result.Value);
		}

		[TestMethod]
		public void AddDepartment_ReturnsBadRequest_WhenDepartmentIsNull()
		{
			// Arrange
			var departmentDto = new DepartmentDto();
			_departmentServiceMock.Setup(s => s.AddDepartment(departmentDto)).Returns((Departments)null);

			// Act
			var result = _controller.AddDepartment(departmentDto) as BadRequestResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void EditDepartment_ReturnsOkResult_WhenDepartmentEditedSuccessfully()
		{
			// Arrange
			var departmentDto = new DepartmentDto
			{
				DepartmentId = Guid.NewGuid(),
				DepartmentName = "Test Department",
				Description = "Test Department Description",
				Status = true,
				DepartmentEmail = "test@example.com"
			};
			var department = new Departments
			{
				DepartmentId = departmentDto.DepartmentId,
				DepartmentName = departmentDto.DepartmentName,
				Description = departmentDto.Description,
				Status = departmentDto.Status,
				DepartmentEmail = departmentDto.DepartmentEmail
			};
			_mapperMock.Setup(m => m.Map<Departments>(departmentDto)).Returns(department);
			_departmentServiceMock.Setup(s => s.EditDepartment(departmentDto)).Returns(department);

			// Act
			var result = _controller.EditDepartment(departmentDto) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(department, result.Value);
		}

		[TestMethod]
		public void EditDepartment_ReturnsNotFound_WhenDepartmentIsNull()
		{
			// Arrange
			var departmentDto = new DepartmentDto();
			_departmentServiceMock.Setup(s => s.EditDepartment(departmentDto)).Returns((Departments)null);

			// Act
			var result = _controller.EditDepartment(departmentDto) as NotFoundResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetAllDepartments_ReturnsOkResult_WhenDepartmentsRetrievedSuccessfully()
		{
			// Arrange
			var departments = new List<DepartmentDto>
			{
				new DepartmentDto { DepartmentName = "Department 1" },
				new DepartmentDto { DepartmentName = "Department 2" },
				new DepartmentDto { DepartmentName = "Department 3" }
			};
			_departmentServiceMock.Setup(s => s.GetAllDepartment()).Returns(departments);

			// Act
			var result = _controller.GetAllDepartments() as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(departments, result.Value);
		}

		[TestMethod]
		public void GetDepartmentById_ReturnsOkResult_WhenDepartmentRetrievedSuccessfully()
		{
			// Arrange
			var departmentId = Guid.NewGuid();
			var department = new DepartmentDto
			{
				DepartmentId = departmentId,
				DepartmentName = "TestDepartment",
				Description = "Test Department Description",
				Status = true,
				DepartmentEmail = "test@example.com"
			};
			_departmentServiceMock.Setup(s => s.GetDepartmentById(departmentId)).Returns(department);

			// Act
			var result = _controller.GetDepartmentById(departmentId) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(department, result.Value);
		}

		[TestMethod]
		public void GetDepartmentById_ReturnsNotFound_WhenDepartmentIsNull()
		{
			// Arrange
			var departmentId = Guid.NewGuid();
			_departmentServiceMock.Setup(s => s.GetDepartmentById(departmentId)).Returns((DepartmentDto)null);

			// Act
			var result = _controller.GetDepartmentById(departmentId) as NotFoundResult;

			// Assert
			Assert.IsNotNull(result);
		}
		
	}
}
