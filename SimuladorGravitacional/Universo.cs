using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorGravitacional
{
    class Universo
    {
        public Corpo[] corpos { get; set; }

        public Universo(int qtdCorpos, int height, int width, double minMassa, double maxMassa, double minDensidade, double maxDensidade)
        {
            corpos = new Corpo[qtdCorpos];
            for(int i = 0; i < qtdCorpos; i++)
            {
                Corpo novoCorpo = new Corpo(GerarNome(), GerarNumero(minMassa, maxMassa), GerarNumero(minDensidade, maxDensidade));
                GerarPosicao(novoCorpo, width, height);
                corpos[i] = novoCorpo;

            }
        }

        public string GerarNome()
        {
            Random random = new Random();
            string nome = "";

            if (File.Exists("NomeCorpos.txt"))
            {
                string[] nomes = File.ReadAllLines("NomeCorpos.txt");
                nome = nomes[random.Next(nomes.Length)];
            }

            return nome;
        }

        public void GerarPosicao(Corpo corpo, int limiteX, int limiteY)
        {
            Random random = new Random();
            corpo.posX = random.Next(limiteX - (int)corpo.Raio());
            corpo.posY = random.Next(limiteY - (int)corpo.Raio());
        }
        
        public double GerarNumero(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }

        public double CalcularForcaGravitacional(Corpo corpo1, Corpo corpo2, double distancia)
        {
            //Aqui está sendo calculado a gravidade entre os corpos!!
            double gravidade = 6.674184 * Math.Pow(10, -11);
            double forca = (gravidade * (corpo1.massa * corpo2.massa) / Math.Pow(distancia, 2));
            return forca;
        }

        public void Update(double deltaTime)
        {
            //Aqui está ocorrendo a atualização ou mudança dos Frames da execução!
            for (int i = 0; i < corpos.Length; i++)
            {
                double forcaX = 0;
                double forcaY = 0;
                for (int j = 0; j < corpos.Length; j++)
                {
                    if (i != j)
                    {
                        double distancia = Math.Sqrt(Math.Pow(corpos[j].posX - corpos[i].posX, 2) + Math.Pow(corpos[j].posY - corpos[i].posY, 2));
                        double forca = CalcularForcaGravitacional(corpos[i], corpos[j], distancia);
                        forcaX += forca * (corpos[j].posX - corpos[i].posX) / distancia;
                        forcaY += forca * (corpos[j].posY - corpos[i].posY) / distancia;
                    }
                }
                double aceleracaoX = forcaX / corpos[i].massa;
                double aceleracaoY = forcaY / corpos[i].massa;
                corpos[i].velX += aceleracaoX * deltaTime;
                corpos[i].velY += aceleracaoY * deltaTime;
            }

            for (int l = 0; l < corpos.Length; l++)
            {
                // Atualiza a posição do corpo com base na velocidade
                corpos[l].posX += corpos[l].velX * deltaTime;
                corpos[l].posY += corpos[l].velY * deltaTime;
            }
        }
    }
}

