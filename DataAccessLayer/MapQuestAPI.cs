using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer {
    public class MapQuestAPI {
        public ConfigurationController config;
        private static string filePath;
        private RouteOptions options;
        private OptionsHelper optionsHelper;

        public MapQuestAPI() {
            config = new ConfigurationController();
            filePath = config.filePath;
            options = RouteOptions.Instance;
            optionsHelper = new OptionsHelper();
        }
        public async Task<Tour> GetTourMap(Tour tour) {
            //first part directions api
            var freeKey = "Mdd0d9He0yPgEr0Q8n0mvJ9sY6QskCFb";

            //request variables
            //string outFormat = "JSON";
            string unit = optionsHelper.GetUnit(Int32.Parse(options.Unit) + 1) ?? "k";
            string routeType = optionsHelper.GetRouteType(Int32.Parse(options.Routetype) + 1) ?? "fastest";
            string locale = optionsHelper.GetLanguage(Int32.Parse(options.Language) + 1) ?? "de_DE";

            HttpClient client = new HttpClient();
            string sessionId = "";
            string boundingBoxCombined = "";

            try {

                var httpResponse = await client.GetAsync(new Uri($"http://www.mapquestapi.com/directions/v2/route?key={freeKey}&from={tour.to}&to={tour.from}&unit=k&routeType={routeType}"));
                string stringResponse = await httpResponse.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(stringResponse);

                if ((int)jsonResponse["info"]["statuscode"] != 0) {
                    throw new Exception(jsonResponse["info"]["message"][0].ToString());
                }

                sessionId = jsonResponse["route"]["sessionId"].ToString();

                tour.distance = jsonResponse["route"]["distance"].ToString();

                var ulLat = jsonResponse["route"]["boundingBox"]["ul"]["lat"].ToString();
                var ulLng = jsonResponse["route"]["boundingBox"]["ul"]["lng"].ToString();
                var lrLat = jsonResponse["route"]["boundingBox"]["lr"]["lat"].ToString();
                var lrLng = jsonResponse["route"]["boundingBox"]["lr"]["lng"].ToString();

                boundingBoxCombined = ulLat + "," + ulLng + "," + lrLat + "," + lrLng;


                //second part - staticmap api
                var staticMapRequest = "https://www.mapquestapi.com/staticmap/v5/map";

                //request variables
                string mapSize = "640,480";
                string mapZoom = "11";
                string rand = "737758036";
                var requestStaticUrl = staticMapRequest + "?key=" + freeKey + "&size=" + mapSize + "&defaultMarker=none&zoom=" + mapZoom + "&rand=" + rand + "&session=" + sessionId + "&boundingBox=" + boundingBoxCombined;

                WebClient webclient = new WebClient();
                Uri imgUri = null;
                imgUri = new Uri(requestStaticUrl);

                string finishedPath = filePath + $"{tour.id}" + ".png";
                tour.routeInfo = finishedPath;
                await webclient.DownloadFileTaskAsync(imgUri, finishedPath);

            } catch (HttpRequestException e) {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message: {0} ", e.Message);
            }

            return tour;
        }
    }
}
