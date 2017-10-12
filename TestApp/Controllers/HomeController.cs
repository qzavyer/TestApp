using System;
using System.Linq;
using System.Web.Mvc;
using TestApp.Data;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        readonly DataContext _dataContext;

        public HomeController()
        {
            _dataContext = new DataContext();
        }

        public ActionResult Index()
        {
            try
            {
                var fields = _dataContext.GetFields();
                return View(fields);
            }
            catch (Exception)
            {
                return View(new Field[] {});
            }
        }

        [HttpGet]
        public ActionResult GetDataByName(string name)
        {
            try
            {
                var field = _dataContext.Fields.First(r => r.Name == name);
                return Content(field.Data);
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return null;
            }
        }
    }
}