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
            GravacaoBanco gravacao = new GravacaoBanco();

            int[] simulacoes = gravacao.ListarSimulacao();
            foreach (int numSimulacao in simulacoes)
            {
                var button = new Button() { Text = numSimulacao.ToString(), Size = new Size(60, 60) };
                button.Click += button_Clicado;
                flowLayoutPanel1.Controls.Add(button);
            }
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
