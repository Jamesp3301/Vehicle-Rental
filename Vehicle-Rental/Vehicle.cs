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
        public string Brand {  get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsRented{ get; set; }
        public Vehicle(string brand, string model, int year, decimal pricePerDay)
        {
            id = ++autoId;  // auto id 
            Brand = brand;
            Model = model;
            Year = year;
            PricePerDay = pricePerDay;
            IsRented = false;
        }
    }
    
}
