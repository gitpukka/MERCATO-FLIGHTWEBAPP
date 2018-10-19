using Moq;
using System;
using TuiFlight.Business;
using TuiFlight.DataAccess;
using TuiFlightModel.Models;
using Xunit;

namespace TuiFlight.TestApp
{
    public class AirlineTests
    {
        [Fact]
        public void TestAddEmptyAirline()
        {
            var mockRepository = new Mock<IRepository>();
            var service = new DataBusiness(mockRepository.Object);
            var result = service.AddAirLine(null);

            Assert.Equal(CommandRresult.ReturnCode.ImpossibleToAddAnEmptyAirlineCompany, result.ResultCode);
        }

        [Fact]
        public void TestAddAirlineWithNoKey()
        {
            var mockRepository = new Mock<IRepository>();
            var service = new DataBusiness(mockRepository.Object);
            //var airline = new Airline();
            var result = service.AddAirLine(new Airline());

            Assert.Equal(CommandRresult.ReturnCode.TheAirlineCompanyIdIsMissing, result.ResultCode);
        }

        [Fact]
        public void TestAddAirlineWithNoName()
        {
            var mockRepository = new Mock<IRepository>();
            var service = new DataBusiness(mockRepository.Object);
            var result = service.AddAirLine(new Airline { AirlineId = Guid.NewGuid() });

            Assert.Equal(CommandRresult.ReturnCode.YouMustSpecifyTheAirlineCompanyName, result.ResultCode);
        }

        [Fact]
        public void TestAddAirlineWithSuccess()
        {
            var mockRepository = new Mock<IRepository>();
            var service = new DataBusiness(mockRepository.Object);
            var result = service.AddAirLine(new Airline { AirlineId = Guid.NewGuid(), Name = "Testing Airline Company" });

            Assert.Equal(CommandRresult.ReturnCode.TheAirlineCompanyHasBeenAdded, result.ResultCode);
        }
    }
}