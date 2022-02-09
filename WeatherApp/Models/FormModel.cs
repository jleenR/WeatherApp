namespace WeatherApp.Models
{
    public class FormModel
    {
        public string APIkey { get; set; }
        public string CityName { get; set; }
        public string APICityName { get; set; }
        public string Message { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal CurrentTemp { get; set; }
        public decimal CurrentTempfeelslike { get; set; }
        public decimal TempMin { get; set; }
        public decimal TempMax { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal Winddegree { get; set; }

        public decimal CloudCover { get; set; }
        public string Rain { get; set; }
        public string Snow { get; set; }
        public string WeatherDesc { get; set; }
        public string SkyStatus { get; set; }
        public string Country { get; set; }
        public string Icon { get; set; }

        
    }
}