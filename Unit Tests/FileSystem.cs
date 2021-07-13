using DataAccessLayer;
using Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Unit_Tests {
    class FileSystem {


        private FileSystemController fs;
        private Tour dummyTour;
        private List<Tour> tours;

        [SetUp]
        public void Setup() {
            fs = new FileSystemController();
            tours = new List<Tour>();
            tours = fs.ImportJson();
            dummyTour = new Tour { id = "99", description = "Test", distance = "Test", from = "test", name = "test", to = "test", routeInfo = "test" };
        }

        [Test]
        public void ImportJson() {
            if (tours != null) {
                Assert.Pass();
            } else {
                Assert.Fail();
            }

        }
        [Test]
        public void ExportJson() {
            if (fs.ExportJson(dummyTour)) {
                Assert.Pass();
            } else {
                Assert.Fail();
            }

        }
    }
}
