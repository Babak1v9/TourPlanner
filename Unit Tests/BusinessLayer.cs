using BusinessLayer;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit_Tests {
    public class BusinessLayer {
        private Tour tour;
        private TourLog tourLog;
        private List<TourLog> tourLogs;
        private List<Tour> tours;
        private TourHandler Tours;
        private TourLogHandler TourLogs;

        [SetUp]
        public async void Setup() {

            Tours = new TourHandler();
            TourLogs = new TourLogHandler();

            tour = new Tour { id = "1", description = "Test", distance = "Test", from = "test", name = "test", to = "test", routeInfo = "test" };
            tourLog = new TourLog { logId = "1", date = "1/07/2022", report = "test", duration = "1h", distance = "22km", rating = "5/5", avgSpeed = "1000 km/h", tourId = "1" };

            tourLogs = new List<TourLog>();
            tours = new List<Tour>();

            tourLogs.Add(tourLog);
            tours.Add(tour);
        }


        [Test]
        public void ToursGetItems() {

            tours = (List<Tour>)Tours.GetItems();
            Assert.True(tours != null);

        }

        [Test]
        public void ToursSearch() {

            var output = Tours.Search(tour.name);
            Assert.True(output != null);

        }

        [Test]
        public void TourLogsGetItems() {

            tourLogs = (List<TourLog>)TourLogs.GetItems();
            Assert.True(tourLogs != null);

        }
        [Test]
        public void TourLogsSearch() {

            var output = TourLogs.Search(tourLog.date);
            Assert.True(output != null) ;
 

        }
        [Test]
        public void TourLogsSearchById() {

            var output = TourLogs.SearchById(tour.id);
            Assert.True(output != null);

        }
    }
}
