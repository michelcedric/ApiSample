using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ApplicationCore.UnitTests.Services
{
    [TestClass]
    public class WeatherForecastServiceTest
    {
        [TestMethod]
        public async Task GetAllAsync_Test()
        {
            await Task.CompletedTask;
            Assert.IsTrue(true);
        }
    }
}
