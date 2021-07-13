using DataAccessLayer;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer {
    public class TourHandler {

        private DatabaseController db;

        public TourHandler() {
            db = DatabaseController.Instance;
        }

        //method for displaying all tours in UI
        public IEnumerable<Tour> GetItems() {

            var allTours = db.GetAllTours();

            return allTours;
        }

        //method for search logic
        public IEnumerable<Tour> Search(string itemName, bool caseSensitive = false) {
            IEnumerable<Tour> items = GetItems();

            if (caseSensitive) {
                return items.Where(x => x.name.Contains(itemName));
            }
            return items.Where(x => x.name.ToLower().Contains(itemName.ToLower()));
        }

        //connection to data access layer
        public void CreateTour(Tour tour) {
            db.CreateTour(tour);
        }

        public void ModifyTour(Tour tour) {
            db.ModifyTour(tour);
        }

        public void DeleteTour(Tour tour) {
            db.DeleteTour(tour);
        }
    }
}
