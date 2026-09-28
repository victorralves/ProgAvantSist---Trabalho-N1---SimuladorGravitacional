using System.ComponentModel;

namespace SimuladorGravitacional
{
    public partial class Form1 : Form
    {
        Universo universo = new Universo(0, 0, 0, 0, 0, 0, 0);
        GravacaoFilha gravacao = new GravacaoFilha();
        

        public Form1()
        {
            InitializeComponent();
            typeof(Panel)
        .GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic)
        ?.SetValue(panel1, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
                openFileDialog.Title = "Selecione o arquivo de nomes dos corpos";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = openFileDialog.FileName;
                    universo = gravacao.CarregarGravacao(caminhoArquivo);
                    panel1.Invalidate();
                    for (int i = 0; i < universo.QuantidadeIteracoes; i++)
                    {
                        universo.Largura = panel1.Width;
                        universo.Altura = panel1.Height;
                        universo.Update(1);
                        await Task.Delay(1);
                        panel1.Invalidate();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }

            MessageBox.Show("Simulação concluída!", "Conclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            universo.Largura = panel1.Width;
            universo.Altura = panel1.Height;
            foreach (Corpo corpo in universo.corpos)
            {
                if (corpo == null) continue;

                double raio = corpo.Raio();

                if (double.IsNaN(corpo.posX) || double.IsInfinity(corpo.posX) ||
                    double.IsNaN(corpo.posY) || double.IsInfinity(corpo.posY) ||
                    double.IsNaN(raio) || double.IsInfinity(raio) || raio <= 0)
                {
                    continue;
                }

                if(corpo.posX < raio)
                {
                    corpo.posX = raio;
                    corpo.velX = -corpo.velX;
                }
                else if (corpo.posX > panel1.Width - raio)
                {
                    corpo.posX = panel1.Width - raio;
                    corpo.velX = -corpo.velX;
                }

                if(corpo.posY < raio)
                {
                    corpo.posY = raio;
                    corpo.velY = -corpo.velY;
                }
                else if (corpo.posY > panel1.Height - raio)
                {
                    corpo.posY = panel1.Height - raio;
                    corpo.velY = -corpo.velY;
                }

                e.Graphics.FillEllipse(Brushes.White,
                    (float)(corpo.posX - raio),
                    (float)(corpo.posY - raio),
                    (float)(raio * 2),
                    (float)(raio * 2));
            }
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            universo = new Universo((int)numericUpDown5.Value, panel1.Height, panel1.Width, (double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value, (double)numericUpDown4.Value);
            int numIteracoes = (int)numericUpDown6.Value;
            gravacao.Gravar(universo, numIteracoes);
            panel1.Invalidate();
            for (int i = 0; i < numIteracoes; i++)
            {
                universo.Largura = panel1.Width;
                universo.Altura = panel1.Height;
                universo.Update(1);
                await Task.Delay(1);
                panel1.Invalidate();
            }

            MessageBox.Show("Simulação concluída!\nVocê pode visualizar a gravação ou até carregar ela novamente!", "Conclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= numericUpDown2.Value)
            {
                numericUpDown2.Value = numericUpDown1.Value + 1;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value <= numericUpDown1.Value)
            {
                numericUpDown1.Value = numericUpDown2.Value - 1;
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value >= numericUpDown4.Value)
            {
                numericUpDown4.Value = numericUpDown3.Value + (decimal)0.01;
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown4.Value <= numericUpDown3.Value)
            {
                numericUpDown3.Value = numericUpDown4.Value - (decimal)0.01;
            }
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            double proporcao = 16.0 / 9.0;

            if (tableLayoutPanel1 == null || panel1 == null) return;
            if (!tableLayoutPanel1.Controls.Contains(panel1)) return;

            int row = tableLayoutPanel1.GetRow(panel1);
            var rowHeights = tableLayoutPanel1.GetRowHeights();
            if (row < 0 || row >= rowHeights.Length) return;

            int larguraDisponivel = tableLayoutPanel1.ClientSize.Width;
            int alturaDisponivel = rowHeights[row];

            int largura;
            int altura;

            // A largura é o limite
            altura = (int)(larguraDisponivel / proporcao);

            if (altura <= alturaDisponivel)
            {
                largura = larguraDisponivel;
            }
            // A altura é o limite
            else
            {
                altura = alturaDisponivel;
                largura = (int)(altura * proporcao);
            }
            panel1.Width = largura;
            panel1.Height = altura;
        }
    }
}
