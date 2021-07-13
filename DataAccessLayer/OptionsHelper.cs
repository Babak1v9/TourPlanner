namespace DataAccessLayer {
    public class OptionsHelper {


        private string result;

        public string GetRouteType(int index) {

            switch (index) {
                case 1:
                    result = "fastest";
                    break;
                case 2:
                    result = "shortest";
                    break;
                case 3:
                    result = "pedestrian";
                    break;
                case 4:
                    result = "bicycle";
                    break;

            }
            return result;
        }
        public string GetUnit(int index) {

            switch (index) {
                case 1:
                    result = "k";
                    break;
                case 2:
                    result = "m";
                    break;
            }
            return result;
        }
        public string GetLanguage(int index) {

            switch (index) {
                case 1:
                    result = "en_GB";
                    break;
                case 2:
                    result = "fr_CA";
                    break;
                case 3:
                    result = "fr_FR";
                    break;
                case 4:
                    result = "de_DE";
                    break;
                case 5:
                    result = "es_ES";
                    break;
                case 6:
                    result = "es_MX";
                    break;
                case 7:
                    result = "ru_RU";
                    break;

            }
            return result;
        }
    }
}
