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
        public class Empleados
        {
            //nombres, apellidos, cargo, salario mensual

            public int ID_Empleado { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Cargo { get; set; }
            public double SalarioBruto { get; set; }
            public double Afp { get; set; }
            public double Sfs { get; set; }
            public double Isr { get; set; }
            public double SalarioNeto { get; set; }



        }

        public List<Empleados> ListaEmpleado { get; set; } = new List<Empleados>() {
                new Empleados {ID_Empleado = 1, Nombre = "Manuel", Apellido = "Ramirez", Cargo="QA", Afp =0, Isr=0,Sfs=0, SalarioBruto= 15000, SalarioNeto=0},
                new Empleados {ID_Empleado = 2, Nombre = "Jose", Apellido = "Diaz", Cargo="Programador", Afp = 0, Isr=0,Sfs=0, SalarioBruto= 50000, SalarioNeto=0},
                new Empleados {ID_Empleado = 2, Nombre = "John", Apellido = "Lopez", Cargo="Gerente", Afp = 0, Isr=0,Sfs=0, SalarioBruto= 283122, SalarioNeto=0},
                new Empleados {ID_Empleado = 2, Nombre = "Miguel", Apellido = "Cuello", Cargo="Ingeniero de planta", Afp = 0, Isr=0,Sfs=0, SalarioBruto= 115500, SalarioNeto=0},
                new Empleados {ID_Empleado = 2, Nombre = "Juan", Apellido = "Perez", Cargo="Analista de credito", Afp = 0, Isr=0,Sfs=0, SalarioBruto= 55000, SalarioNeto=0},

                new Empleados {ID_Empleado = 3, Nombre = "Edwin", Apellido = "Ortiz", Cargo="Programador", Afp =0,Isr=0,Sfs=0, SalarioBruto= 70000, SalarioNeto=0}
            };






        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Addresultados();
        }



        public void Addresultados() {

            foreach (var empleado in ListaEmpleado)
            {

                empleado.Afp = CalcAFP(empleado.SalarioBruto);
                empleado.Sfs = CalcSFS(empleado.SalarioBruto);
                empleado.Isr = CalcISR(empleado.SalarioBruto);
                empleado.SalarioNeto = empleado.SalarioBruto - (empleado.Isr + empleado.Sfs + empleado.Afp);

            }

        }


        public static double CalcAFP(double salario)
        {
            double result;
            double salarioMin = 13482;
            double porcentDes = 0.0287;
            double MonLimt = (20 * salarioMin) * porcentDes;
            result = salario * porcentDes;

            if (result >= MonLimt)
            {
                return MonLimt;
            }
            else
            {

                return result;
            }


        }

        public static double CalcISR(double salario)
        {
            double result;
            double SalarioMen = salario * 12;
            double porcentDes;

            //​Rentas hasta RD$416,220.00
            if (SalarioMen <= 416220.00)
            {
                porcentDes = 0;
                result = salario * porcentDes;
                return result;
            }
            //​Rentas hasta RD$624329.00
            else if (SalarioMen >= 416220.01 || SalarioMen <= 624329.00) 
            {
                porcentDes = 0.15;
                result = ((SalarioMen - 416220.00) * porcentDes)/ 12;
                return result;

            }
            //​Rentas hasta RD$867123.00
            else if (SalarioMen >= 624329.01 || SalarioMen <= 867123.00)
            {
                porcentDes = 0.20;
                result = (((SalarioMen - 624329.01) * porcentDes) + 31216.00)/12;
                return result;

            }
            //​Rentas Mayores a RD$867123.00
            else
            {

                porcentDes = 0.25;
                result = (((SalarioMen - 867123.01) * porcentDes) + 79776.00)/ 12;
                return result;
            }

        }


            public static double CalcSFS(double salario)
            {
            double result;
            double salarioMin = 13482;
            double porcentDes = 0.0304;
            double MonLimt = (10 * salarioMin) * porcentDes;
            result = salario * porcentDes;

            
            if (result >= MonLimt)
            {
                return MonLimt;
            }
            else
            {

                return result;
            }

        }

           


    }



}
