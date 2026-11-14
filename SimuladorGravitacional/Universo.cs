using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorGravitacional
{
    class Universo //A CLASSE UNIVERSO É ONDE PROCESSADO CALCULOS E A GESTÃO DE TODOS OS CORPOS, ELA É A BASE DE TODA A SIMULAÇÃO!
    {
        public double Escala { get; set; }
        public Corpo[] Corpos { get; set; }
        public int QuantidadeIteracoes { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }

        //CONSTRUTOR DA CLASSE UNIVERSO, ELE É RESPONSÁVEL POR GERIR OS CORPOS!
        public Universo(int qtdCorpos, int height, int width, double minMassa, double maxMassa, double minDensidade, double maxDensidade)
        {
            Corpos = new Corpo[qtdCorpos];
            Escala = 0.01;
            for (int i = 0; i < qtdCorpos; i++)
            {
                Corpo novoCorpo = new Corpo(GerarNome(), GerarNumero(minMassa, maxMassa), GerarNumero(minDensidade, maxDensidade));
                GerarPosicao(novoCorpo, width, height);
                Corpos[i] = novoCorpo;
            }
        }

        //CONSTRUTOR SOBRECARREGADO! FOI NECESSÀRIO POR CONTA DA IMPLEMENTAÇÃO DE GRAVAÇÃO!
        public Universo(int qtdCorpos)
        {
            Corpos = new Corpo[qtdCorpos];
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
            int raio = (int)Math.Ceiling(corpo.Raio());
            //GERA UMA POSIÇÃO ALEATÓRIA PARA O CORPO, ENTRE RAIO E LIMITE - RAIO, PARA ELE NASCER INTEIRO DENTRO DA TELA!
            corpo.PosX = random.Next(raio, Math.Max(raio + 1, limiteX - raio));
            corpo.PosY = random.Next(raio, Math.Max(raio + 1, limiteY - raio));
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
            double forca = (gravidade * (corpo1.Massa * corpo2.Massa) / Math.Pow(distancia, 2));
            return forca;
        }

        public void Update(double deltaTime)
        {
            Parallel.For(0, this.Corpos.Length, i => {
                if (Corpos[i] == null) return;
                for (int j = i + 1; j < Corpos.Length; j++)
                {
                    Corpo a = Corpos[i], b = Corpos[j];
                    if (i == j || b == null) continue;
                    if (a != null && a.Colisao(b))//RESULTADO DE UMA COLISÃO ENTRE DOIS CORPOS, ONDE O CORPO DE MAIOR MASSA ABSORVE O DE MENOR MASSA!
                    {
                        lock (this)
                        {
                            if (Corpos[i] == null) break;
                            if (Corpos[j] == null) continue;
                            if (!Corpos[i].Colisao(Corpos[j])) continue;

                            double massaTotal = Corpos[i].Massa + Corpos[j].Massa;
                            double densidadeMedia = (Corpos[i].Densidade + Corpos[j].Densidade) / 2;
                            double velXFinal = (Corpos[i].Massa * Corpos[i].VelX + Corpos[j].Massa * Corpos[j].VelX) / massaTotal;
                            double velYFinal = (Corpos[i].Massa * Corpos[i].VelY + Corpos[j].Massa * Corpos[j].VelY) / massaTotal;
                            if (Corpos[i].Massa >= Corpos[j].Massa)
                            {
                                Corpos[i].Massa = massaTotal;
                                Corpos[i].Densidade = densidadeMedia;
                                Corpos[i].VelX = velXFinal;
                                Corpos[i].VelY = velYFinal;
                                Corpos[j] = null;
                            }
                            else
                            {
                                Corpos[j].Massa = massaTotal;
                                Corpos[j].Densidade = densidadeMedia;
                                Corpos[j].VelX = velXFinal;
                                Corpos[j].VelY = velYFinal;
                                Corpos[i] = null;
                                break;
                            }
                            continue;
                        }
                    }
                }
            });
            //aqui está ocorrendo a atualização ou mudança dos Frames da execução!
            Parallel.For(0, this.Corpos.Length, i =>
            {
                if (Corpos[i] == null) return;
                double forcaX = 0;
                double forcaY = 0;
                for (int j = i + 1; j < Corpos.Length; j++)
                {
                    if (i == j || Corpos[j] == null) continue;
                    if (i != j)
                    {
                        //CALCULO DAS FORÇAS GRAVITACIONAIS ENTRE OS CORPOS, ONDE É CALCULADO A DISTANCIA ENTRE ELES E A FORÇA QUE UM CORPO EXERCE SOBRE O OUTRO!
                        double dx = (Corpos[j].PosX - Corpos[i].PosX) * Escala;
                        double dy = (Corpos[j].PosY - Corpos[i].PosY) * Escala;
                        double distancia = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                        double forca = CalcularForcaGravitacional(Corpos[i], Corpos[j], distancia);
                        forcaX += forca * dx / distancia;
                        forcaY += forca * dy / distancia;
                    }
                }
                if (Corpos[i] == null) return;
                double aceleracaoX = forcaX / Corpos[i].Massa;
                double aceleracaoY = forcaY / Corpos[i].Massa;
                Corpos[i].VelX += aceleracaoX * deltaTime;
                Corpos[i].VelY += aceleracaoY * deltaTime;
            });


            Parallel.For (0, this.Corpos.Length, i => {
                if (Corpos[i] == null) return;
                // atualiza a posição do corpo com base na velocidade
                Corpos[i].PosX += (Corpos[i].VelX * deltaTime) / Escala;
                Corpos[i].PosY += (Corpos[i].VelY * deltaTime) / Escala;
            }) ;
        }
    }
}

