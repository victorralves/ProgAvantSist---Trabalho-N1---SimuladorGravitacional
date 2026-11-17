using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimuladorGravitacional
{
    public partial class Form2 : Form
    {
        private Form1 form1;

        public Form2(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //AQUI É INICIADA A SIMULAÇÃO, ELA VAI RETORNAR O NÚMERO DA SIMULAÇÃO!
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3307,
                UserID = "root",
                Password = "123",
                Database = "trabalhon1",
            };
            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT numSimulacao FROM simulacao;";

            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int numSimulacao = reader.GetInt32(0);
                var button = new Button() { Text = numSimulacao.ToString(), Size = new Size(60, 60) };
                button.Click += button_Clicado;
                flowLayoutPanel1.Controls.Add(button);
            }
            reader.Close();
        }
        
        private void button_Clicado(object ? sender, EventArgs e)
        {
            try
            {
                if (sender is Button botaoClicado)
                {
                   form1.ReceberSimulacao(int.Parse(botaoClicado.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao processar a simulação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
