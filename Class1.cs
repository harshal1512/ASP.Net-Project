using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.net
{
    
        public static class Common
        {
            public static int Cint(String input)
            {
                int x = 0;
                int.TryParse(input, out x);
                return x;

            }

            public static double Cdouble(String input)
            {
                double x = 0;
                double.TryParse(input, out x);
                return x;

            }
            public static float Cfloat(String input)
            {
                int x = 0;
                int.TryParse(input, out x);
                return x;

            }
            public static decimal Cdecimal(String input)
            {
                int x = 0;
                int.TryParse(input, out x);
                return x;

            }
            public static DateTime Cdatetime(String input)
            {
                DateTime a = new DateTime();
                DateTime.TryParse(input, out a);
                return a;

            }

        }
    

}

