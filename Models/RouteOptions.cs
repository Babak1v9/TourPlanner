using System;

namespace Models {
    public sealed class RouteOptions {
        public string Routetype { get; set; }
        public string Unit { get; set; }
        public string Language { get; set; }

        private static readonly Lazy<RouteOptions> lazy = new Lazy<RouteOptions>(() => new RouteOptions());
        public static RouteOptions Instance { get { return lazy.Value; } }

        private RouteOptions() {

            Routetype = "0";
            Unit = "0";
            Language = "3";
        }
    }
}
