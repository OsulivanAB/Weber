using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter_12_Polymorphism
{
    class clsTruck : clsVehicle
    {

        public override string AbstractMethodExample(string Mystring)
        {
            return "Class Truck abstract method example, plus the string " + Mystring;
        }

    }
}
