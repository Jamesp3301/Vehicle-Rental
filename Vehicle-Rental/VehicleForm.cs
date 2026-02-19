using System;
using System.Windows.Forms;

namespace Vehicle_Rental
{
    public partial class VehicleForm : Form
    {
        public Vehicle CreatedVehicle { get; private set; }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void VehicleForm_Load(object sender, EventArgs e)
        {
        }

        public VehicleForm()
        {
            InitializeComponent();

            
            cmbTipo.Items.Add("Car");
            cmbTipo.Items.Add("Van");
            cmbTipo.SelectedIndex = 0;

            
            numAno.Minimum = 1990;
            numAno.Maximum = DateTime.Now.Year;

            numPreco.DecimalPlaces = 2;
            numPreco.Minimum = 1;

            numPorta.Minimum = 2;
            numPorta.Maximum = 6;

            numCapa.DecimalPlaces = 1;
            numCapa.Minimum = 1;

            
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            btnSave.Click += btnSave_Click;

            UpdateFields();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFields();
        }

        private void UpdateFields()
        {
            bool isCar = cmbTipo.SelectedItem.ToString() == "Car";

            numPorta.Enabled = isCar;
            numCapa.Enabled = !isCar;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            int ano = (int)numAno.Value;
            decimal preco = numPreco.Value;

            if (cmbTipo.SelectedItem.ToString() == "Car")
            {
                int portas = (int)numPorta.Value;
                CreatedVehicle = new Car(marca, modelo, ano, preco, portas);
            }
            else
            {
                double capacidade = (double)numCapa.Value;
                CreatedVehicle = new Van(marca, modelo, ano, preco, capacidade);
            }

            DialogResult = DialogResult.OK;
        }

        private bool ValidateInput()
        {
            errorProvider1.Clear();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                errorProvider1.SetError(txtMarca, "Marca é obrigatória.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                errorProvider1.SetError(txtModelo, "Modelo é obrigatório.");
                valid = false;
            }

            return valid;
        }
    }
}

