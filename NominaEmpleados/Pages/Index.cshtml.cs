using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NominaEmpleados.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        //Modelo de Empleado
        public class Empleado
        {
            //nombres, apellidos, cargo, salario mensual

            public int ID_Empleado { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Cargo { get; set; }
            public double SalarioBruto { get; set; }
            public double Afp { get; set; }
            public double Sfs { get; set; }
            public double Ars { get; set; }
            public double Isr { get; set; }
            public double SalarioNeto { get; set; }

        }




        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }



        public void OnGet()
        {



        }



         public static List<Empleado> ListaEmpleado { get; set; } = new List<Empleado>() {
                new Empleado {ID_Empleado = 1, Nombre = "Manuel", Apellido = "Ramirez", Cargo="QA", Afp =CalcAFP(), Ars=0,Isr=0,Sfs=0, SalarioBruto= 15000, SalarioNeto=0},
                new Empleado {ID_Empleado = 2, Nombre = "Jose", Apellido = "Diaz", Cargo="Programador", Afp = CalcAFP(), Ars=0,Isr=0,Sfs=0, SalarioBruto= 50000, SalarioNeto=0},
                new Empleado {ID_Empleado = 3, Nombre = "Edwin", Apellido = "Ortiz", Cargo="Programador", Afp = CalcAFP(), Ars=0,Isr=0,Sfs=0, SalarioBruto= 70000, SalarioNeto=0}
            };



      

        public static double CalcAFP() 
        {
            //SalarioBruto * 0.0287
            double result;
            double SaBruto = empleado.Where(s => s.ID_Empleado == id).Select(s => s.SalarioBruto).FirstOrDefault();
            //double Afp = empleados.Where(s => s.ID_Empleado == id).Select(s => s.Afp = 0).FirstOrDefault();
            result = SaBruto * 0.0287;
              
            return result;

        }



        //public IActionResult OnGetGenerar(int id) 
        //{
        //    return Page();
        //}

    }



}
