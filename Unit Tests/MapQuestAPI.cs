using Models;
using NUnit.Framework;
using System;

namespace Unit_Tests {
    class MapQuestAPI {
        Tour createdTour;

        [SetUp]
        public async void Setup() {
            //create dummy tour
            Guid myuuid = Guid.NewGuid();

            var newTour = new Tour();
            newTour.name = "UnitTest";
            newTour.description = "This is for Unit Test";
            newTour.from = "Graz";
            newTour.to = "Wien";
            newTour.id = myuuid.ToString();

            var mapQuestAPI = new DataAccessLayer.MapQuestAPI();
            createdTour = await mapQuestAPI.GetTourMap(newTour);
        }


        [Test]
        public void CheckConfig() {
            if (createdTour.routeInfo != null) {
                Assert.Pass();
            } else {
                Assert.Fail();
            }

        }
    }
}
