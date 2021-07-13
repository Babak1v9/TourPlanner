using Models;
using NUnit.Framework;
using System.Collections.Generic;
using TourPlanner.Reports;


namespace Unit_Tests {
    class PdfReports {
        private PdfReportGenerator pdfGen;
        private Tour tour;
        private TourLog tourLog;
        private List<TourLog> tourLogs;

        [SetUp]
        public async void Setup() {

            pdfGen = new PdfReportGenerator();
            tour = new Tour { id = "1", description = "Test", distance = "Test", from = "test", name = "test", to = "test", routeInfo = "test" };
            tourLog = new TourLog { logId = "1", date = "1/07/2022", report = "test", duration = "1h", distance = "22km", rating = "5/5", avgSpeed = "1000 km/h", tourId = "1" };
            tourLogs = new List<TourLog>();
            tourLogs.Add(tourLog);
        }


        [Test]
        public void GenerateReport() {

            if (pdfGen.GenerateReport(tour, tourLogs)) {
                Assert.Pass();
            } else {
                Assert.Fail();
            }

        }

        [Test]
        public void GenerateSummaryReport() {

            if (pdfGen.GenerateSummaryReport("test", tourLogs)) {
                Assert.Pass();
            } else {
                Assert.Fail();
            }

        }
    }
}
