using DataAccessLayer;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Tests {
    class Database {
        DatabaseController db;
        ConfigurationController config;
        private string connectionString = "Host=localhost;Username=postgres;Password=swe;Database=TourPlanner";
        private string filePath = "D:\\Lukas\\Programmieren\\C#\\SWE2 Tour Planner\\Maps\\";
        private Tour tour;
        private TourLog tourLog;

        [SetUp]
        public void Setup() {
            var tmpConfig = new ConfigurationController();
            config = tmpConfig;

            db = DatabaseController.Instance;

            tour = new Tour { id = "1", description = "Test", distance = "Test", from = "test", name = "test", to = "test", routeInfo = "test" };
            tourLog = new TourLog { logId = "1", date = "1/07/2022", report = "test", duration = "1h", distance = "22km", rating = "5/5", avgSpeed = "1000 km/h", tourId = "1" };
        }


        [Test]
        public void CheckConfig() {
            Assert.True(config.connectionString == connectionString && config.filePath == filePath);
        }

        // TOURS DB
        [Test]
        public void CreateTour() {
            Assert.True(db.CreateTour(tour));
        }

        [Test]
        public void CopyTour() {
            Assert.True(db.CopyTour(tour));
        }

        [Test]
        public void ModifyTour() {
            Assert.True(db.ModifyTour(tour));
        }

        [Test]
        public void DeleteTour() {
            Assert.True(db.DeleteTour(tour));
        }

        // TOUR LOGS DB
        [Test]
        public void CreateTourLog() {
            Assert.True(db.CreateTourLog(tourLog));
        }
        [Test]
        public void CopyTourLog() {
            Assert.True(db.CopyTourLog(tourLog));
        }
        [Test]
        public void ModifyTourLog() {
            Assert.True(db.ModifyTourLog(tourLog));
        }
        [Test]
        public void DeleteTourLog() {
            Assert.True(db.DeleteTourLog(tourLog));
        }

        [Test]
        public void GetAllTours() {
            var tours = db.GetAllTours();
            Assert.True(tours != null);
        }
        [Test]
        public void GetAllTourLogs() {
            var tourLogs = db.GetAllTourLogs();
            Assert.True(tourLogs != null);
        }
    }
}
