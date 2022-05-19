using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleFinanceAPI.Api.Controllers;
using VehicleFinanceAPI.Api.Services.Generic;
using VehicleFinanceAPI.Data.ViewModel;
using Xunit;

namespace VehicleFinanceTests
{
    public class VehicleUnitTests
    {
        [Fact]
        public void AddVehicle_VehicleAdded_ReturnVehicle()
        {
            var VehicleType = new VehicleTypeViewModel() { Name = "Car", Description= "Car", Id = 1 };
            var MakeType = new MakeViewModel() { Name = "BMW", Description = "BMW", Id = 1 };
            var FinanceType = new FinanceTypeViewModel() { Name = "Personal Loan", Description = "Loan", Id = 1 };
            var Vehicle = new VehicleViewModel() { Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now, FkVehicleType = VehicleType, FkFinanceType = FinanceType, FkMake = MakeType };

            var mock = new Mock<IGenericService<VehicleViewModel>>();
            mock.Setup(i => i.Create(Vehicle)).Returns(Vehicle);

            var service = new VehicleController(mock.Object);
            var actual = service.Post(Vehicle);

            var viewResult = Assert.IsType<OkObjectResult>(actual);
            var model = (VehicleViewModel)((ObjectResult)actual).Value;

            Assert.Equal(Vehicle.Name, model.Name);
        }

        [Fact]
        public void GetVehicle_ReturnList()
        {
            var Vehicle = new List<VehicleViewModel>() { new VehicleViewModel() { Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now },
            new VehicleViewModel() { Name = "Audi", Description = "Audi BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now }};

            var mock = new Mock<IGenericService<VehicleViewModel>>();
            mock.Setup(i => i.GetAll().Result).Returns(Vehicle);

            var service = new VehicleController(mock.Object);
            var actual = service.GetAll();

            var viewResult = Assert.IsType<OkObjectResult>(actual.Result);
            var model = (List<VehicleViewModel>)((ObjectResult)actual.Result).Value;

            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void GetVehicleByMake_ReturnList()
        {
            var Vehicle = new List<VehicleViewModel>() { new VehicleViewModel() {FkMakeId = 1, Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now },
            new VehicleViewModel() {FkMakeId = 1, Name = "Audi", Description = "Audi BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now }};

            var mock = new Mock<IGenericService<VehicleViewModel>>();
            mock.Setup(i => i.GetByAny(1).Result).Returns(Vehicle.Where(i => i.FkMakeId == 1).ToList());

            var service = new VehicleController(mock.Object);
            var actual = service.GetByAny(1);

            var viewResult = Assert.IsType<OkObjectResult>(actual.Result);
            var model = (List<VehicleViewModel>)((ObjectResult)actual.Result).Value;

            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void GetVehicleById_ReturnVehicle()
        {
            var Vehicle = new List<VehicleViewModel>() { new VehicleViewModel() {Id = 1, Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now },
            new VehicleViewModel() {Id=2, Name = "Audi", Description = "Audi BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now }};

            var mock = new Mock<IGenericService<VehicleViewModel>>();
            mock.Setup(i => i.GetByAny(1).Result).Returns(Vehicle.Where(i => i.Id == 1).ToList());

            var service = new VehicleController(mock.Object);
            var actual = service.GetByAny(1);

            var viewResult = Assert.IsType<OkObjectResult>(actual.Result);
            var model = (List<VehicleViewModel>)((ObjectResult)actual.Result).Value;

            Assert.Single(model);
        }

        [Fact]
        public void UpdateVehicle_ReturnVehicle()
        {
            var Vehicle = new VehicleViewModel() { Id = 1, Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now };

            var newmodel = new VehicleViewModel() { Id = 1, Name = "BMW", Description = "Car BMW Gobal", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now };

            var mock = new Mock<IGenericService<VehicleViewModel>>();
            mock.Setup(i => i.Update(Vehicle.Id, Vehicle));

            var service = new VehicleController(mock.Object);
            var actual = service.Put(Vehicle.Id, newmodel);

            mock.Verify(i => i.Update(Vehicle.Id, newmodel), Times.Once());
        }

        [Fact]
        public void DeleteVehicle_ReturnVehicle()
        {
            var Vehicle = new VehicleViewModel() { Id = 1, Name = "BMW", Description = "Car BMW", CreatedBy = 1, ModifiedBy = 1, CreatedDate = DateTime.Now };

            var mock = new Mock<IGenericService<VehicleViewModel>>();
            mock.Setup(i => i.Delete(Vehicle.Id));

            var service = new VehicleController(mock.Object);
            var actual = service.Delete(Vehicle.Id);

            mock.Verify(i => i.Delete(Vehicle.Id), Times.Once());
        }
    }
}
