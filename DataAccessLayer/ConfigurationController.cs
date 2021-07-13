using Newtonsoft.Json;
using System.IO;

namespace DataAccessLayer {
    public class ConfigurationController {
        public string connectionString { get; set; }
        public string filePath { get; set; }

        private string jsonFilePath = @"D:\Lukas\Programmieren\C#\SWE2 Tour Planner\appsettings.json";

        private string reportsPath = @"D:\Lukas\Programmieren\C#\SWE2 Tour Planner\PDFReports\";

        public ConfigurationController() {
            GetConfig();
        }

        public void GetConfig() {

            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(jsonFilePath));
            connectionString = jsonFile["ConnectionString"];
            filePath = jsonFile["FilePath"];
        }

        public string ReportsPath { get { return reportsPath; } }
    }
}
