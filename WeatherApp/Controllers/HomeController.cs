using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new FormModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchAsync(FormModel model)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            string citynametoquery = model.CityName;
            string apikeytouse = model.APIkey;
            var stringTask = client.GetStringAsync("http://api.openweathermap.org/data/2.5/find?q=" + citynametoquery + "&units=imperial&appid=" + apikeytouse);

            var msg = await stringTask;
            var data = JsonConvert.DeserializeObject<WeatherInfo>(msg);

            FormModel mymodel = new FormModel();
            if (data.List.Count > 0)
            {
                mymodel.Message = (string)data.Message;
                mymodel.Latitude = (decimal)data.List[0].Coord.Lat;
                mymodel.Longitude = (decimal)data.List[0].Coord.Lon;
                mymodel.TempMax = (decimal)data.List[0].Main.TempMax;
                mymodel.TempMin = (decimal)data.List[0].Main.TempMin;
                mymodel.Pressure = (decimal)data.List[0].Main.Pressure;
                mymodel.Humidity = (decimal)data.List[0].Main.Humidity;
                mymodel.CurrentTempfeelslike = (decimal)data.List[0].Main.FeelsLike;
                mymodel.WindSpeed = (decimal)data.List[0].Wind.Speed;
                mymodel.Winddegree = (decimal)data.List[0].Wind.Deg;
                mymodel.CloudCover = (decimal)data.List[0].Clouds.All;
                mymodel.CurrentTemp = (decimal)data.List[0].Main.Temp;
                mymodel.Country = (string)data.List[0].Sys.Country;
                mymodel.APICityName = (string)data.List[0].Name;
                mymodel.WeatherDesc = (string)data.List[0].Weather[0].Description;
            }
            return View("~/Views/Home/Index.cshtml", mymodel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}