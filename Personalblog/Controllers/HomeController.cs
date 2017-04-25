using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(modelData);
        }

        [HttpPost]
        public void ContactMe(Contact formData)
        {
            formData.ProfileNo = 1;
            _model.SaveContact(formData);
        }
    }
}
