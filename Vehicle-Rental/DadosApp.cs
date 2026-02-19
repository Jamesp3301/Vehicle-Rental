using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Vehicle_Rental
{
    public class DadosApp
    {
        public BindingList<Vehicle> Veiculos { get; set; }
        public BindingList<Rental> Alugueres { get; set; }
    }
}
