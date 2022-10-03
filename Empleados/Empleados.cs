using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados
{
    class Empleados
    {
            private string nombre;
            private string dui;
           private double salario;

        

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }
        
        public double Salario
        {
            get { return salario; }
            set { salario = value; }
        }
            public double AFP(double Salario)
            {
            double CalAFP = Salario * 0.0625;
            return CalAFP;
            }

        public  double ISSS (double Salario)
        {
            double CalcISSS = salario * 0.03;
            return CalcISSS;

        }

    }
}
