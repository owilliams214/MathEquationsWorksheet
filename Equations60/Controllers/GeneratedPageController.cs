using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EquationsWorksheet.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EquationsWorksheet.Controllers
{
    public class GeneratedPageController : Controller
    {
        // GET: /<controller>/

        public IActionResult Index()
        {
            return View();
        }

        List<EquationClass> genEquations(int max)
        {
            List<EquationClass> equations = new List<EquationClass>();
            Random random = new Random();

            for (int index = 0; index < max; index++)
            {
                EquationClass row = new EquationClass();
                row.first = random.Next(1, 15);
                row.second = random.Next(1, 15);
                row.answer = row.first + row.second;
                row.symbol = '+';
                equations.Add(row);

            }

            return equations;

        }

        
        


        public List<EquationClass> addEquations(int numOfEqua, int minNum, int maxNum)
        {
            List<EquationClass> equations = new List<EquationClass>();
            Random random = new Random();

            for (int index = 0; index < numOfEqua; index++)
            {
                EquationClass row = new EquationClass();
                row.first = random.Next(minNum,maxNum);
                row.second = random.Next(minNum, maxNum);
                row.answer = row.first + row.second;
                row.symbol = '+';
                equations.Add(row);

            }

            return equations;
        }
        public List<EquationClass> subEquations(int numOfEqua, int minNum, int maxNum, bool negatives)
        {
            List<EquationClass> equations = new List<EquationClass>();
            Random random = new Random();

            for (int index = 0; index < numOfEqua; index++)
            {
                EquationClass row = new EquationClass();
                row.first = random.Next(3, maxNum);
                int secondMax = row.first;
                if (negatives) { secondMax = maxNum; }
                row.second = random.Next(minNum, secondMax);
                row.answer = row.first - row.second;
                row.symbol = '-';
                equations.Add(row);

            }

            return equations;
        }
        public List<EquationClass> multEquations(int numOfEqua, int minNum, int maxNum)
        {
            List<EquationClass> equations = new List<EquationClass>();
            Random random = new Random();

            for (int index = 0; index < numOfEqua; index++)
            {
                EquationClass row = new EquationClass();
                row.first = random.Next(minNum, maxNum);
                row.second = random.Next(minNum, maxNum);
                row.answer = row.first + row.second;
                row.symbol = 'X';
                equations.Add(row);

            }

            return equations;
        }
        public List<EquationClass> divEquations(int numOfEqua, int minNum, int maxNum)
        {

          

            List<EquationClass> equations = new List<EquationClass>();
            Random random = new Random();

            for (int index = 0; index < numOfEqua; index++)
            {
                EquationClass row = new EquationClass();
                row.answer = random.Next(4, maxNum);
                row.second = random.Next(minNum, maxNum);
                row.first = row.answer * row.second;
                row.symbol = '/';
                equations.Add(row);

            }

            

            return equations;
        }

        public IActionResult FormEquation(int num, int symbol)
        {

            List<EquationClass> equations;
            switch (symbol)
            {
                case 1: equations = addEquations(num, 1, 25); break;


                case 2: equations = subEquations(num, 1, 25, false); break;
                //create box for negatives, pull value, and add variable to sub parameters

                case 3: equations = multEquations(num, 1, 12); break;


                case 4: equations = divEquations(num, 1, 12); break;

                default: equations = new List<EquationClass>(); break;

            }


            return View("Equations", equations);
            
        }

        public IActionResult FormEquations( )
        {
            int numOfEqua = Convert.ToInt32(Request.Form["number"]);
            int symbol = Convert.ToInt32(Request.Form["symbol"]);

            int maxNum;

            if ((Request.Form["maxNum"].ToString) == null) { maxNum = 10; }

            else { maxNum = Convert.ToInt32(Request.Form["maxNum"]); }
            bool zero = Convert.ToBoolean(Request.Form["includeZero"]);
            int minNum = 1;

            if (zero) { minNum = 0; }

            List<EquationClass> equations;
            switch (symbol){ 
                case 1:  equations = addEquations(numOfEqua, minNum, maxNum); break;

               
                case 2:  equations = subEquations(numOfEqua, minNum, maxNum, false); break;
                //create box for negatives, pull value, and add variable to sub parameters
            
                case 3:  equations = multEquations(numOfEqua, minNum, maxNum); break;

           
                case 4:  equations = divEquations(numOfEqua, minNum, maxNum); break;

                default: equations = new List<EquationClass>(); break;

                    }
            //List<EquationClass> nequations = equations;


            return View("Equations", equations);
        }

        

        
    }
}






//unused code

//List<EquationClass> equations = new List<EquationClass>();
//Random random = new Random();
//for (int index = 0; index < numOfEqua; index++)
//{
//    EquationClass row = new EquationClass();
//    bool val = false;
//    do
//    {
//        row.first = random.Next(minNum + 3, maxNum);
//        row.second = random.Next(minNum, row.first - 3);

//        if (row.first % row.second == 0)
//        {
//            row.answer = row.first / row.second;
//            row.symbol = '/';
//            equations.Add(row);

//            val = true;
//        }

//    }
//    while (val == false);
//}

//List<EquationClass> genEquations(int numOfEqua, int symbol, int minNum, int maxNum)
//{
//    List<EquationClass> equations = new List<EquationClass>();
//    Random random = new Random();

//    // EquationClass row = new EquationClass();

//    for (int index = 0; index < numOfEqua; index++)
//    {
//        EquationClass row = new EquationClass();


//        if (symbol == 4)
//        {
//            //if (minNum == 1) { minNum = 2; }
//            bool val = false;
//            do
//            {
//                row.first = random.Next(minNum + 3, maxNum);
//                row.second = random.Next(minNum, row.first - 3);

//                if (row.first % row.second == 0)
//                {
//                    row.answer = row.first / row.second;
//                    row.symbol = '/';
//                    equations.Add(row);

//                    val = true;
//                }

//            }
//            while (val == false);
//        }


//        else
//        {
//            row.first = random.Next(minNum, maxNum);
//            row.second = random.Next(minNum, maxNum);


//            switch (symbol)
//            {
//                case 1:
//                    row.symbol = '+';
//                    row.answer = row.first + row.second;
//                    break;
//                case 2:
//                    row.symbol = '-';
//                    row.answer = row.first - row.second;
//                    break;
//                case 3:
//                    row.symbol = '*';
//                    row.answer = row.first * row.second;
//                    break;

//            }
//            equations.Add(row);
//        }
//    }

//    return equations;
//}

//public RedirectResult equationForm()
//{
//    int numOfEqua = Convert.ToInt32(Request.Form["number"]);
//    int symbol = Convert.ToInt32(Request.Form["symbol"]);

//    int maxNum;

//    if ((Request.Form["maxNum"].ToString) == null) { maxNum = 10; }

//    else { maxNum = Convert.ToInt32(Request.Form["maxNum"]); }
//    bool zero = Convert.ToBoolean(Request.Form["includeZero"]);
//    int minNum = 1;


//    List<EquationClass> equations = genEquations(numOfEqua, symbol, minNum, maxNum);



//    //TempData["list"] = equations.ToList();

//    return Redirect("FormEquations?"+equations);

//}