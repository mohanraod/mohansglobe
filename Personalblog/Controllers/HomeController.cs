using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Personalblog.Controllers
{
    public class HomeController : Controller
    {
        private readonly Model _model = new Model();
        public ActionResult Index()
        {
            var modelData = _model.GetData();
            String UserIP = HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(UserIP))
            {
                UserIP = HttpContext.Request.ServerVariables["REMOTE_ADDR"];
            }
            string url = "http://freegeoip.net/json/" + UserIP.ToString();
            WebClient client = new WebClient();
            string jsonstring = client.DownloadString(url);
            dynamic dynObj = JsonConvert.DeserializeObject(jsonstring);
            ViewBag.RequestCountry = dynObj.country_code;
            return View(modelData);
        }

        [HttpPost]
        public void ContactMe(Contact formData)
        {
            formData.ProfileNo = 1;
            _model.SaveContact(formData);
        }

        public string InsertData(string query)
        {
            return _model.InsertData(query);
        }
    }
}
