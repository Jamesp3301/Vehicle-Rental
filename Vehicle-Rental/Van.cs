using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental
{
    public class Van : Vehicle
    {
        public Double CargoCap { get; set; }
        public Van(string brand, string model, int year, decimal priceperday, double cargocap)
            : base(brand, model, year, priceperday)
        {
            CargoCap = cargocap;
        }
    
    public override decimal CalculateRentalCost(int days)
        {
            return (PricePerDay * days) * 1.15m;
        }
        public override string GetVehicleType()
        {
            return "Van";
        }
    }   
}
