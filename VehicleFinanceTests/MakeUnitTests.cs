using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleFinanceAPI.Api.Controllers;
using VehicleFinanceAPI.Api.Services.Generic;
using VehicleFinanceAPI.Data.ViewModel;
using Xunit;

namespace VehicleFinanceTests
{
    public class MakeUnitTests
    {
        [Fact]
        public void AddMake_MakeAdded_ReturnMake()
        {
            var Make = new MakeViewModel() { Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now };

            var mock = new Mock<IGenericService<MakeViewModel>>();
            mock.Setup(i => i.Create(Make)).Returns(Make);

            var service = new MakeController(mock.Object);
            var actual = service.Post(Make);

            var viewResult = Assert.IsType<OkObjectResult>(actual);
            var model = (MakeViewModel)((ObjectResult)actual).Value;

            Assert.Equal(Make.Name, model.Name);
        }

        [Fact]
        public void GetMake_ReturnList()
        {
            var Make = new List<MakeViewModel>() { new MakeViewModel() { Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now },
            new MakeViewModel() { Name = "Audi", Description = "Audi BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now }};

            var mock = new Mock<IGenericService<MakeViewModel>>();
            mock.Setup(i => i.GetAll().Result).Returns(Make);

            var service = new MakeController(mock.Object);
            var actual = service.GetAll();

            var viewResult = Assert.IsType<OkObjectResult>(actual.Result);
            var model = (List<MakeViewModel>)((ObjectResult)actual.Result).Value;

            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void GetMakeById_ReturnMake()
        {
            var Make = new List<MakeViewModel>() { new MakeViewModel() {Id = 1, Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now },
            new MakeViewModel() {Id=2, Name = "Audi", Description = "Audi BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now }};

            var mock = new Mock<IGenericService<MakeViewModel>>();
            mock.Setup(i => i.GetByAny(1).Result).Returns(Make.Where(i => i.Id == 1).ToList());

            var service = new MakeController(mock.Object);
            var actual = service.GetByAny(1);

            var viewResult = Assert.IsType<OkObjectResult>(actual.Result);
            var model = (List<MakeViewModel>)((ObjectResult)actual.Result).Value;

            Assert.Single(model);
        }

        [Fact]
        public void UpdateMake_ReturnMake()
        {
            var Make = new MakeViewModel() { Id = 1, Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now };

            var newmodel = new MakeViewModel() { Id = 1, Name = "BMW", Description = "Car BMW Gobal", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now };

            var mock = new Mock<IGenericService<MakeViewModel>>();
            mock.Setup(i => i.Update(Make.Id, Make));

            var service = new MakeController(mock.Object);
            var actual = service.Put(Make.Id, newmodel);

            mock.Verify(i => i.Update(Make.Id, newmodel), Times.Once());
        }

        [Fact]
        public void DeleteMake_ReturnMake()
        {
            var Make = new MakeViewModel() { Id = 1, Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now };

            var mock = new Mock<IGenericService<MakeViewModel>>();
            mock.Setup(i => i.Delete(Make.Id));

            var service = new MakeController(mock.Object);
            var actual = service.Delete(Make.Id);

            mock.Verify(i => i.Delete(Make.Id), Times.Once());
        }
    }
}
