using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental
{
    public class Car : Vehicle
    {
        public int DoorNum { get; set; } 
        public Car(string brand, string model, int year, decimal priceperday, int doors)
            : base(brand, model, year, priceperday) 
        {
            DoorNum = doors;
        }
        public override decimal CalculateRentalCost(int days)
        {
            return PricePerDay * days;
        }
        public override string GetVehicleType()
        {
            return "Car";
        }
    }
}
