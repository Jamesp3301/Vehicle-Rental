using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental
{
    public abstract class Vehicle 
    {
        private static int autoId = 0;
        private int id;
        public int Id=>id;
    }
    
}
