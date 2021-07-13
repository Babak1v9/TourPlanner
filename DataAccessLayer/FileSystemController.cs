using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DataAccessLayer {
    public class FileSystemController {


        private string jsonPath = @"D:\Lukas\Programmieren\C#\SWE2 Tour Planner\JsonObjects\";
        private List<Tour> importedTours = new List<Tour>();
        private ConfigurationController config;

        public FileSystemController() {
            GetFilePath();
        }

        public void GetFilePath() {
            config = new ConfigurationController();
        }

        public List<Tour> ImportJson() {

            foreach (var file in Directory.EnumerateFiles(jsonPath, "*")) {
                Tour importedTour = JsonConvert.DeserializeObject<Tour>(File.ReadAllText(file));
                importedTours.Add(importedTour);
            }
            return importedTours;

        }

        public bool ExportJson(Tour tour) {

            var finalPath = jsonPath + tour.id + ".json";

            var jsonForExport = JsonConvert.SerializeObject(new {
                id = tour.id,
                name = tour.name,
                description = tour.description,
                distance = tour.description,
                from = tour.from,
                to = tour.to,
                routeInfo = tour.routeInfo
            });

            File.WriteAllText(finalPath, jsonForExport);

            return true;
        }
    }
}
