using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquationsWorksheet.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EquationsWorksheet.Controllers
{
    public class TestPageController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public void RandomNumberButton()
        {
            Random random = new Random();

            int randomLessThan100 = random.Next(100);
            Console.WriteLine(randomLessThan100);
        }

        public void createEquations()
        {
            List<EquationClass> equations = new List<EquationClass>();
            Random random = new Random();

            EquationClass row = new EquationClass();

            for (int index = 0; index < 25; index++)
            {
                
                row.first = random.Next();
                row.second = random.Next();
                row.answer = row.first + row.second;

                equations.Add(row);
            }


        }
    }
}
