using System;
using System.ComponentModel;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;


namespace Vehicle_Rental
{
    public partial class Form1 : Form
    {
        private BindingList<Vehicle> listaVeiculos = new BindingList<Vehicle>();
        private BindingList<Rental> listaAlugueres = new BindingList<Rental>();
        //CANCEL BUTTON STILL MAKES SHOWS ERROR FIX TOMMOROW MORNING!!!!!!!!!!!!
        public Form1()
        {
            InitializeComponent();

            dgvVeiculos.DataSource = listaVeiculos;
            dgvAlugueres.DataSource = listaAlugueres;

            cmbVeiculos.DataSource = listaVeiculos;
            cmbVeiculos.DisplayMember = "Modelo";

            btnAdd.Click += btnAdicionar_Click;
            btnEdit.Click += btnEdit_Click;
            btnRemove.Click += btnRemover_Click;
            btnAlugar.Click += btnAlugar_Click;
            this.FormClosing += Form1_FormClosing;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            VehicleForm form = new VehicleForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                listaVeiculos.Add(form.CreatedVehicle);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvVeiculos.CurrentRow == null)
                return;

            Vehicle veiculo = (Vehicle)dgvVeiculos.CurrentRow.DataBoundItem;

            if (veiculo.IsRented)
            {
                MessageBox.Show("Não pode remover um veículo alugado.");
                return;
            }

            listaVeiculos.Remove(veiculo);
        }

        private void btnAlugar_Click(object sender, EventArgs e)
        {
            if (cmbVeiculos.SelectedItem == null)
                return;

            Vehicle veiculo = (Vehicle)cmbVeiculos.SelectedItem;

            if (veiculo.IsRented)
            {
                MessageBox.Show("Veículo já está alugado.");
                return;
            }

            int dias = (int)numDias.Value;

            Rental aluguer = new Rental(veiculo, dias);

            listaAlugueres.Add(aluguer);
        }
        private string filePath = "dados.json";
        private void GuardarDados()
        {
            DadosApp dados = new DadosApp
            {
                Veiculos = listaVeiculos,
                Alugueres = listaAlugueres
            };

            string json = JsonConvert.SerializeObject(dados, Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            File.WriteAllText(filePath, json);
        }
        private void CarregarDados()
        {
            if (!File.Exists(filePath))
                return;

            string json = File.ReadAllText(filePath);

            DadosApp dados = JsonConvert.DeserializeObject<DadosApp>(json,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            if (dados != null)
            {
                listaVeiculos = dados.Veiculos ?? new BindingList<Vehicle>();
                listaAlugueres = dados.Alugueres ?? new BindingList<Rental>();

                dgvVeiculos.DataSource = listaVeiculos;
                dgvAlugueres.DataSource = listaAlugueres;
                cmbVeiculos.DataSource = listaVeiculos;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarDados();
        }

        private void btnAlugar_Click_1(object sender, EventArgs e)
        {
            int dias=(int)numDias.Value;
            if (dias <= 0) 
            {
                MessageBox.Show("O numero de dias deve ser maior do 0");
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvVeiculos.CurrentRow == null)
                return;

            Vehicle veiculo = (Vehicle)dgvVeiculos.CurrentRow.DataBoundItem;

            if (veiculo.IsRented)
            {
                MessageBox.Show("Não é possível editar um veículo alugado.");
                return;
            }

            VehicleForm form = new VehicleForm(veiculo);

            if (form.ShowDialog() == DialogResult.OK)
            {
                dgvVeiculos.Refresh();
                cmbVeiculos.Refresh();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Alugar_Click(object sender, EventArgs e)
        {

        }

        private void cmbVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

