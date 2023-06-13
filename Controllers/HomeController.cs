
using Microsoft.AspNetCore.Mvc;
using NewProj.Models;

using NewProj.Interface;

namespace NewProj.Controllers
{



    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IName _name;
        

        public HomeController(IConfiguration config, IName name) {
            _configuration = config;
            _name = name;
            }
        public IActionResult Index()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.Lst = _name.GetProductList().ToList();
            return View(peopleViewModel);
        }
        
        public IActionResult Add()
        {
            return View();
        }

       

        [HttpPost]
        public IActionResult Add(People person)
        {
            if (person == null)
            {
                return View();
            }
            else
            {
               _name.EditUpdateProduct(person);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var MyData = _name.GetProductList();
            foreach (var item in MyData)
            {
                People peopleViewModel = new People();

                peopleViewModel.ProductId = item.ProductId;
                peopleViewModel.ProductName = item.ProductName;
                return View(peopleViewModel);
            }

            return View(); 
        }

        [HttpPost]
        public IActionResult Edit(People model)
        {

             _name.EditUpdateProduct(model);
                        
            return RedirectToAction("Index");

            //_name.GetUserByID(id);
            //return View(_name.GetUserByID(id));
        }

        //[HttpGet]
        //public IActionResult Edit()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Del(int id)
        {
            _name.DeleteProductByID(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int id ) 
            {
                _name.GetUserByID(id);
                return RedirectToAction("Index");
            }
                       
    }
}