using DataAccessLayer;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer {

    public class TourLogHandler {

        private DatabaseController db;

        public TourLogHandler() {
            db = DatabaseController.Instance;
        }

        //method for displaying all TourLogs in UI
        public IEnumerable<TourLog> GetItems() {

            var allTourLogs = db.GetAllTourLogs();

            return allTourLogs;
        }

        //search logic method called by search command (only for dates)
        public IEnumerable<TourLog> Search(string itemName, bool caseSensitive = false) {
            IEnumerable<TourLog> items = GetItems();

            if (caseSensitive) {
                return items.Where(x => x.date.Contains(itemName));
            }
            return items.Where(x => x.date.ToLower().Contains(itemName.ToLower()));
        }

        //method for displaying logs connected to currenntly selected tour 
        public IEnumerable<TourLog> SearchById(string itemName, bool caseSensitive = false) {
            IEnumerable<TourLog> items = GetItems();

            if (caseSensitive) {
                return items.Where(x => x.tourId.Contains(itemName));
            }
            return items.Where(x => x.tourId.ToLower().Contains(itemName.ToLower()));
        }

        public void CreateTourLog(TourLog tourLog) {
            db.CreateTourLog(tourLog);
        }

        public void ModifyTourLog(TourLog tourLog) {
            db.ModifyTourLog(tourLog);
        }

        public void DeleteTourLog(TourLog tourlog) {
            db.DeleteTourLog(tourlog);
        }
    }
}
