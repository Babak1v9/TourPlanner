using System;
using System.Collections.Generic;
using Models;
using Npgsql;

namespace DataAccessLayer {
    public sealed class DatabaseController {


        private static readonly Lazy<DatabaseController> lazy = new Lazy<DatabaseController>(() => new DatabaseController());
        public static DatabaseController Instance { get { return lazy.Value; } }
        private readonly NpgsqlConnection con;
        public ConfigurationController config;
        private DatabaseController() {

            GetConnectionStrings();
            con = new NpgsqlConnection(config.connectionString);
        }

        private void GetConnectionStrings() {
            config = new ConfigurationController();
        }

        public List<Tour> GetAllTours() {
            var fetchedTours = new List<Tour>();
            var command = new NpgsqlCommand("select * from tour_data", con);

            con.Open();
            var reader = command.ExecuteReader();

            while (reader.Read()) {

                var currentTour = new Tour();

                currentTour.id = reader["tour_id"].ToString() ?? string.Empty;
                currentTour.name = reader["tour_name"].ToString() ?? string.Empty;
                currentTour.description = reader["description"].ToString() ?? string.Empty;
                currentTour.routeInfo = reader["route_information"].ToString() ?? string.Empty;
                currentTour.distance = reader["tour_distance"].ToString() ?? string.Empty;
                currentTour.from = reader["tour_from"].ToString() ?? string.Empty;
                currentTour.to = reader["tour_to"].ToString() ?? string.Empty;

                fetchedTours.Add(currentTour);
            }
            con.Close();
            return fetchedTours;
        }

        public bool CreateTour(Tour tour, bool copy = false) {

            if (copy) {
                tour.name += " [Copy]";

                Guid myuuid = Guid.NewGuid();
                tour.id = myuuid.ToString();
            }
            var command = new NpgsqlCommand("insert into tour_data (tour_name, description, tour_distance, tour_from, tour_to, tour_id, route_information) values (:tour_name, :description, :tour_distance, :tour_from, :tour_to, :tour_id, :route_information) RETURNING tour_id", con);
            con.Open();

            command.Parameters.AddWithValue("tour_name", tour.name);
            command.Parameters.AddWithValue("description", tour.description);
            command.Parameters.AddWithValue("tour_distance", tour.distance);
            command.Parameters.AddWithValue("tour_from", tour.from);
            command.Parameters.AddWithValue("tour_to", tour.to);
            command.Parameters.AddWithValue("tour_id", tour.id);
            command.Parameters.AddWithValue("route_information", tour.routeInfo);

            command.Prepare();
            var newTour = command.ExecuteNonQuery();
            con.Close();

            if (newTour > 0) {
                return true;
            } else {
                return false;
            }
        }

        public bool DeleteTour(Tour tour) {
            var command = new NpgsqlCommand("delete from tour_data where tour_id = '" + tour.id + "'", con);
            con.Open();

            command.Prepare();
            int rowsAffected = command.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0) {
                return true;
            } else {
                return false;
            }
        }
        public bool ModifyTour(Tour tour) {

            var command = new NpgsqlCommand("update tour_data set tour_name = :tour_name, description = :description, tour_distance = :tour_distance," +
                "tour_from = :tour_from, tour_to = :tour_to, route_information = :route_information where tour_id = :tour_id", con);
            con.Open();

            command.Parameters.AddWithValue("tour_name", tour.name);
            command.Parameters.AddWithValue("description", tour.description);
            command.Parameters.AddWithValue("tour_distance", tour.distance);
            command.Parameters.AddWithValue("tour_from", tour.from);
            command.Parameters.AddWithValue("tour_to", tour.to);
            command.Parameters.AddWithValue("tour_id", tour.id);
            command.Parameters.AddWithValue("route_information", tour.routeInfo);
            command.Prepare();

            int rowsAffected = command.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0) {
                return true;
            } else {
                return true;
            }
        }

        public bool CopyTour(Tour tour) {
            var rowsAffected = CreateTour(tour, true);
            return rowsAffected;
        }

        public List<TourLog> GetAllTourLogs() {
            var fetchedTourLogs = new List<TourLog>();
            var command = new NpgsqlCommand("select * from tour_log", con);

            con.Open();
            var reader = command.ExecuteReader();

            while (reader.Read()) {

                var currentTourLog = new TourLog();

                currentTourLog.logId = reader["log_id"].ToString() ?? string.Empty;
                currentTourLog.date = reader["date"].ToString() ?? string.Empty;
                currentTourLog.report = reader["report"].ToString() ?? string.Empty;
                currentTourLog.duration = reader["duration"].ToString() ?? string.Empty;
                currentTourLog.distance = reader["distance"].ToString() ?? string.Empty;
                currentTourLog.rating = reader["rating"].ToString() ?? string.Empty;
                currentTourLog.avgSpeed = reader["average_speed"].ToString() ?? string.Empty;
                currentTourLog.tourId = reader["tour_id"].ToString() ?? string.Empty;

                fetchedTourLogs.Add(currentTourLog);
            }
            con.Close();
            return fetchedTourLogs;
        }

        public bool CreateTourLog(TourLog tourLog, bool copy = false) {

            if (copy) {
                Guid myuuid = Guid.NewGuid();
                tourLog.logId = myuuid.ToString();
            }
            var command = new NpgsqlCommand("insert into tour_log (log_id, date, report, duration, distance, rating, average_speed, tour_id) values (:log_id, :date, :report, :duration, :distance, :rating, :average_speed, :tour_id) RETURNING log_id", con);
            con.Open();

            command.Parameters.AddWithValue("log_id", tourLog.logId ?? string.Empty);
            command.Parameters.AddWithValue("date", tourLog.date ?? string.Empty);
            command.Parameters.AddWithValue("report", tourLog.report ?? string.Empty);
            command.Parameters.AddWithValue("duration", tourLog.duration ?? string.Empty);
            command.Parameters.AddWithValue("distance", tourLog.distance ?? string.Empty);
            command.Parameters.AddWithValue("rating", tourLog.rating ?? string.Empty);
            command.Parameters.AddWithValue("average_speed", tourLog.avgSpeed ?? string.Empty);
            command.Parameters.AddWithValue("tour_id", tourLog.tourId ?? string.Empty);

            command.Prepare();

            int rowsAffected = command.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0) {
                return true;
            } else {
                return false;
            }
        }

        public bool ModifyTourLog(TourLog tourLog) {

            var command = new NpgsqlCommand("update tour_log set date = :date, report = :report, duration = :duration," +
                "distance = :distance, rating = :rating, average_speed = :average_speed, tour_id = :tour_id where log_id = :log_id", con);

            con.Open();

            //logId, date, report, duration, distance, rating, avgSpeed, tourId;
            command.Parameters.AddWithValue("log_id", tourLog.logId ?? string.Empty);
            command.Parameters.AddWithValue("date", tourLog.date ?? string.Empty);
            command.Parameters.AddWithValue("report", tourLog.report ?? string.Empty);
            command.Parameters.AddWithValue("duration", tourLog.duration ?? string.Empty);
            command.Parameters.AddWithValue("distance", tourLog.distance ?? string.Empty);
            command.Parameters.AddWithValue("rating", tourLog.rating ?? string.Empty);
            command.Parameters.AddWithValue("average_speed", tourLog.avgSpeed ?? string.Empty);
            command.Parameters.AddWithValue("tour_id", tourLog.tourId ?? string.Empty);
            command.Prepare();
            int rowsAffected = command.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0) {
                return true;
            } else {
                return true;
            }
        }

        public bool DeleteTourLog(TourLog tourLog) {
            var command = new NpgsqlCommand("delete from tour_log where log_id = :log_id", con);
            con.Open();

            command.Parameters.AddWithValue("log_id", tourLog.logId ?? string.Empty);
            command.Prepare();

            int rowsAffected = command.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0) {
                return true;
            } else {
                return false;
            }
        }

        public bool CopyTourLog(TourLog tourLog) {
            bool rowsAffected = CreateTourLog(tourLog, true);
            return rowsAffected;
        }
    }
}
