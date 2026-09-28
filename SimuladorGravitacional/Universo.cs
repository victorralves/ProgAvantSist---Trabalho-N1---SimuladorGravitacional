using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorGravitacional
{
    class Universo //A CLASSE UNIVERSO É ONDE PROCESSADO CALCULOS E A GESTÃO DE TODOS OS CORPOS, ELA É A BASE DE TODA A SIMULAÇÃO!
    {
        public double Escala { get; set; }
        public Corpo[] corpos { get; set; }
        public int QuantidadeIteracoes { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }

        //CONSTRUTOR DA CLASSE UNIVERSO, ELE É RESPONSÁVEL POR GERIR OS CORPOS!
        public Universo(int qtdCorpos, int height, int width, double minMassa, double maxMassa, double minDensidade, double maxDensidade)
        {
            corpos = new Corpo[qtdCorpos];
            Escala = 0.01;
            for (int i = 0; i < qtdCorpos; i++)
            {
                Corpo novoCorpo = new Corpo(GerarNome(), GerarNumero(minMassa, maxMassa), GerarNumero(minDensidade, maxDensidade));
                GerarPosicao(novoCorpo, width, height);
                corpos[i] = novoCorpo;
            }
        }

        //CONSTRUTOR SOBRECARREGADO! FOI NECESSÀRIO POR CONTA DA IMPLEMENTAÇÃO DE GRAVAÇÃO!
        public Universo(int qtdCorpos)
        {
            corpos = new Corpo[qtdCorpos];
            Escala = 0.01;
        }   

        public string GerarNome() //METODO PARA GERAR O NOME DOS CORPOS!
        {
            Random random = new Random();
            string nome = "";
            string caminho = "NomeCorpos.txt"; //HÁ UM ARQUIVO TXT COM MAIS DE 300 NOMES SETADOS PARA OS CORPOS!

            if (File.Exists(caminho))
            {
                string[] nomes = File.ReadAllLines(caminho);
                nome = nomes[random.Next(nomes.Length)]; //O NOME DE CADA CORPO É SORTEADO!
            }

            return nome;
        }

        public void GerarPosicao(Corpo corpo, int limiteX, int limiteY)//METODO PARA GERAR A POSIÇÃO DOS CORPOS NA TELA!
        {
            Random random = new Random();
            corpo.posX = random.Next(limiteX - (int)corpo.Raio()); //GERA UMA POSIÇÃO ALEATÓRIA PARA O CORPO!
            corpo.posY = random.Next(limiteY - (int)corpo.Raio());
        }

        //JÀ ESSE METODO VAI GERAR OS NUMEROS ALEATÓRIOS PARA A MASSA E DENSIDADE DOS CORPOS DE ACORDO COM O SELECIONADO NOS LIMITES!
        public double GerarNumero(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }

        public double CalcularForcaGravitacional(Corpo corpo1, Corpo corpo2, double distancia)
        {
            //aqui está sendo calculado a gravidade entre os corpos!!
            double gravidade = 6.674184 * Math.Pow(10, -11);
            double forca = (gravidade * (corpo1.massa * corpo2.massa) / Math.Pow(distancia, 2));
            return forca;
        }

        public void Update(double deltaTime)
        {
            //aqui está ocorrendo a atualização ou mudança dos Frames da execução!
            for (int i = 0; i < corpos.Length; i++)
            {
                if (corpos[i] == null) continue;
                double forcaX = 0;
                double forcaY = 0;
                for (int j = i+1; j < corpos.Length; j++)
                {
                    if (i == j || corpos[j] == null) continue;
                    if (i != j)
                    {
                        //CALCULO DAS FORÇAS GRAVITACIONAIS ENTRE OS CORPOS, ONDE É CALCULADO A DISTANCIA ENTRE ELES E A FORÇA QUE UM CORPO EXERCE SOBRE O OUTRO!
                        double dx = (corpos[j].posX - corpos[i].posX) * Escala;
                        double dy = (corpos[j].posY - corpos[i].posY) * Escala;
                        double distancia = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                        double forca = CalcularForcaGravitacional(corpos[i], corpos[j], distancia);
                        forcaX += forca * dx / distancia;
                        forcaY += forca * dy / distancia;
                        if (corpos[i].Colisao(corpos[j])) //RESULTADO DE UMA COLISÃO ENTRE DOIS CORPOS, ONDE O CORPO DE MAIOR MASSA ABSORVE O DE MENOR MASSA!
                        {
                            double massaTotal = corpos[i].massa + corpos[j].massa;
                            double densidadeMedia = (corpos[i].densidade + corpos[j].densidade) / 2;
                            double velXFinal = (corpos[i].massa * corpos[i].velX + corpos[j].massa * corpos[j].velX) / massaTotal;
                            double velYFinal = (corpos[i].massa * corpos[i].velY + corpos[j].massa * corpos[j].velY) / massaTotal;
                            if (corpos[i].massa >= corpos[j].massa)
                            {
                                corpos[i].massa = massaTotal;
                                corpos[i].densidade = densidadeMedia;
                                corpos[i].velX = velXFinal;
                                corpos[i].velY = velYFinal;
                                corpos[j] = null;
                            }
                            else
                            {
                                corpos[j].massa = massaTotal;
                                corpos[j].densidade = densidadeMedia;
                                corpos[j].velX = velXFinal;
                                corpos[j].velY = velYFinal;
                                corpos[i] = null;
                                break;
                            }
                            continue;
                        }
                    }
                }
                if (corpos[i] == null) continue;
                double aceleracaoX = forcaX / corpos[i].massa;
                double aceleracaoY = forcaY / corpos[i].massa;
                corpos[i].velX += aceleracaoX * deltaTime;
                corpos[i].velY += aceleracaoY * deltaTime;
            }

            for (int l = 0; l < corpos.Length; l++)
            {
                if (corpos[l] == null) continue;
                // atualiza a posição do corpo com base na velocidade
                corpos[l].posX += (corpos[l].velX * deltaTime) / Escala;
                corpos[l].posY += (corpos[l].velY * deltaTime) / Escala;
            }
        }
    }
}

