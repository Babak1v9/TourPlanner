using DataAccessLayer;
using NUnit.Framework;

namespace Unit_Tests {
    public class Tests {
        ConfigurationController config;
        private string connectionString = "Host=localhost;Username=postgres;Password=swe;Database=TourPlanner";
        private string filePath = "D:\\Lukas\\Programmieren\\C#\\SWE2 Tour Planner\\Maps\\";

        [SetUp]
        public void Setup() {
            var tmpConfig = new ConfigurationController();
            config = tmpConfig;
        }


        [Test]
        public void CheckConfig() {
            Assert.True(config.connectionString == connectionString && config.filePath == filePath) ;
        }
    }
}