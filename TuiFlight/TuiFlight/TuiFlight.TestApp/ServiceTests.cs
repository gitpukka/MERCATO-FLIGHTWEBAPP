using Moq;
using System;
using TuiFlight.Business;
using TuiFlight.DataAccess;
using Xunit;

namespace TuiFlight.TestApp
{
    public class ServiceTests
    {
        [Fact]
        public void TestGetDistanceBetweenToPoints()
        {
            var mockRepository = new Mock<IRepository>();
            var result = DataBusiness.GetDistanceBetweenToPoints(43.9067, 4.90194, 51.1894, 4.46028, "K");

            Assert.Equal(Math.Round(810.434262225298, 2), Math.Round(result, 2));
        }
    }
}