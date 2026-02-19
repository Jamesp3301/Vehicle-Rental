using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental
{
    public class Rental
    {
        private static int autoId = 0;
        protected int id;
        public int Id => id;
        public Vehicle Vehicle {  get; set; }
        public int Days { get; set; }
        public decimal TotalCost {  get; set; }
        public DateTime RentalDate {  get; set; }

        public Rental(Vehicle vehicle,int days) 
        {
            id=++autoId;
            Vehicle=vehicle;
            Days=days;
            RentalDate=DateTime.Now;
            TotalCost = vehicle.CalculateRentalCost(days);
            vehicle.IsRented = true;
        }
    }
}
