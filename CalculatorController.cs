using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Caculator.Controllers
{
    public class CalculatorController : Controller
    {
        public double __result = 0.0;
        // GET: Calculator
        public ActionResult Calculator()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CalculationLogic(string calcValues)
        {
            double _result = 0;
                List<char> symbleList = new List<char>();
                char[] splitSymble = { '+', '-', '*', '/', '%' };
                string[] st = calcValues.Split(splitSymble);
                for (int i = 0; i < calcValues.Length - 1; i++)
                {
                    if (calcValues[i] == '+' || calcValues[i] == '-' || calcValues[i] == '*' || calcValues[i] == '/' || calcValues[i] == '%')
                    {
                        symbleList.Add(calcValues[i]);
                    }
                }
                if(st[0] == "")
                {
                string firstSymbols = symbleList[0].ToString();
                _result = Convert.ToDouble(firstSymbols + st[1]);
                    for (int i = 2; i < st.Length; i++)
                    {
                        double num = Convert.ToDouble(st[i]);
                        int j = i - 1;
                        switch (symbleList[j])
                        {
                            case '+':
                                _result = Add( _result , num);
                                break;
                            case '-':
                                _result = Subraction(_result, num);
                            break;
                            case '*':
                                _result = Multiplication(_result, num);
                            break;
                            case '/':
                                _result = Division(_result, num);
                            break;
                        case '%':
                            _result = Modulo(_result, num);
                            break;
                        default:
                                _result = 0.0;
                                break;
                        }
                    }
                }
                else
                    {
                    _result = Convert.ToDouble(st[0]);
                    for (int i = 1; i < st.Length; i++)
                    {
                        double num = Convert.ToDouble(st[i]);
                        int j = i - 1;
                    switch (symbleList[j])
                    {
                        case '+':
                            _result = Add(_result, num);
                            break;
                        case '-':
                            _result = Subraction(_result, num);
                            break;
                        case '*':
                            _result = Multiplication(_result, num);
                            break;
                        case '/':
                            _result = Division(_result, num);
                            break;
                        case '%':
                            _result = Modulo(_result, num);
                            break;
                        default:
                            _result = 0.0;
                            break;
                    }
                }
                }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
       public double Add(double number1, double number2)
        {
            return __result = number1 + number2;
        }
        public double Subraction(double number1, double number2)
        {
            return __result = number1 - number2;
        }
        public double Multiplication(double number1, double number2)
        {
            return __result = number1 * number2;
        }
        public double Division(double number1, double number2)
        {
            return __result = number1 / number2;
        }
        public double Modulo(double number1, double number2)
        {
            return __result = number1 % number2;
        }
    }
}