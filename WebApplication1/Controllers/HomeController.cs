﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAllCars _carRep;

        public HomeController(IAllCars carRepository)
        {

            _carRep = carRepository;
           
        }

        public ViewResult Index() {
            var homeCars = new HomeViewModel
            {
                favCars = _carRep.GetFavCars
            };
            return View(homeCars);
        }
    }
}
