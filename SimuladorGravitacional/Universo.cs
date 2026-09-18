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
                corpos[i] = new Corpo(GerarNome(), GerarNumero(minMassa, maxMassa), GerarNumero(minDensidade, maxDensidade), GerarPosicao(width), GerarPosicao(height));
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

        public double GerarPosicao(int limite)
        {
            Random random = new Random();
            return random.Next(limite);
        }
        
        public double GerarNumero(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}

