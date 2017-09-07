namespace GeoJSON
{
    using Net.Feature;
    using Net.Geometry;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;

    public class Program
    {

        private const string GOOGLE_MAPS_PATTERN = "https://www.google.com/maps/@{0},17z";

        public static void Main(string[] args)
        {
            string jsonPoint = "{\"type\":\"Point\",\"coordinates\":[-73.989308, 40.741895]}";
            string jsonFeature = "{\"type\":\"Feature\",\"geometry\":{\"type\":\"Point\",\"coordinates\":[-73.989308, 40.741895]},\"properties\":{\"name\":\"New York\"}}";

            GeoJsonLibraryFromPoint(jsonPoint);
            GeoJsonLibraryFromFeature(jsonFeature);

            Console.WriteLine();
            Console.WriteLine("Press any key to close the app");
            Console.ReadKey();
        }

        private static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private static void GeoJsonLibraryFromPoint(string json)
        {
            Point data = Deserialize<Point>(json);

            Console.WriteLine("POINT");
            Console.WriteLine($"Latidude: {data.Coordinates.Latitude}");
            Console.WriteLine($"Longitude: {data.Coordinates.Longitude}");
            Console.WriteLine();

            string mapPosition = data.Coordinates.Latitude.ToString().Replace(",", ".") + "," + data.Coordinates.Longitude.ToString().Replace(",", ".");
            Process.Start(String.Format(GOOGLE_MAPS_PATTERN, mapPosition));
        }

        private static void GeoJsonLibraryFromFeature(string json)
        {
            Feature data = Deserialize<Feature>(json);

            double latitude = ((GeoJSON.Net.Geometry.Position)((GeoJSON.Net.Geometry.Point)data.Geometry).Coordinates).Latitude;
            double longitude = ((GeoJSON.Net.Geometry.Position)((GeoJSON.Net.Geometry.Point)data.Geometry).Coordinates).Longitude;

            Console.WriteLine("FEATURE");
            Console.WriteLine($"Latidude: {latitude}");
            Console.WriteLine($"Longitude: {longitude}");
            Console.WriteLine();

            string mapPosition = latitude.ToString().Replace(",",".") + "," + longitude.ToString().Replace(",", ".");
            Process.Start(String.Format(GOOGLE_MAPS_PATTERN, mapPosition));
        }

    }

}