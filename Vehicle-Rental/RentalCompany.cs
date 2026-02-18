using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental
{
    public static class RentalCompany
    {
        public static BindingList<Vehicle> Vehicles = new BindingList<Vehicle>();
        public static BindingList<Rental> Rentals = new BindingList<Rental>();
        static RentalCompany()
        {
            Vehicles.Add(new Car("Porsche", "911", 2020, 170, 2));
            Vehicles.Add(new Van("Ford", "Transit", 2015, 50, 4));
        }
    }
}
