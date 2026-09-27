using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SimuladorGravitacional
{
    class GravacaoFilha : Gravacao
    {
        public override void Gravar(Universo universo, int numIteracoes)
        {
            int contador = 1;
            string caminhoPasta = "C:\\Users\\victo\\source\\repos\\ProgramacaoAvancadaDeSistemas\\TrabalhoN1 - SimuladorGravitacional\\SimuladorGravitacional\\SimuladorGravitacional\\ArquivosGravacao\\";
            //ESSE CAMINHO DE PASTA SÓ VAI SERVIR PARA O MEU COMPUTADOR, VOCÊ QUE FEZ O DOWNLOAD DO PROJETO,
            //A PASTA DE GRAVAÇÃO VAI ESTAR DENTRO DO DIRETÓRIO DE DEBUG!

            string nomeArquivo = Path.Combine(caminhoPasta, $"simulacao_{contador}.txt");

            if(!System.IO.Directory.Exists(caminhoPasta))
            {
                System.IO.Directory.CreateDirectory(caminhoPasta);
            }

            while (File.Exists(nomeArquivo))
            {
                contador++;
                nomeArquivo = Path.Combine(caminhoPasta, $"simulacao_{contador}.txt");
            }

            File.WriteAllText(nomeArquivo, "Dados da nova simulação.\r\n");

            string cabecalho = $"Quant. Corpo: {universo.corpos.Length}; Quant. Iterações: {numIteracoes}; TempoEntreIterações: 1 \r\n";
            File.AppendAllText(nomeArquivo, cabecalho);

            for (int i = 0; i < universo.corpos.Length; i++)
            {
                Corpo corpo = universo.corpos[i];
                string dadosCorpo = string.Format(CultureInfo.InvariantCulture,
                    "Corpo {0}: <Nome: {1}>; <Massa: {2}>; <Densidade: {3}>; <Posição: ({4}, {5})>; <Velocidade: ({6}, {7})>",
                    i + 1, corpo.nome, corpo.massa, corpo.densidade, corpo.posX, corpo.posY, corpo.velX, corpo.velY);
                File.AppendAllText(nomeArquivo, "\r\n" + dadosCorpo);
            }
        }

        public Universo CarregarGravacao(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
            {
                throw new FileNotFoundException($"O arquivo {caminhoArquivo} não foi encontrado.");
            }

            string[] linhas = File.ReadAllLines(caminhoArquivo);

            string linhaCabecalho = "";
            foreach (string l in linhas)
            {
                if (l.Contains("Quant. Corpo"))
                {
                    linhaCabecalho = l;
                    break;
                }
            }

            if (string.IsNullOrEmpty(linhaCabecalho))
            {
                throw new InvalidDataException("Não foi possível encontrar as configurações de 'Quant. Corpo' no arquivo.");
            }

            string[] cabecalho = linhaCabecalho.Split(';');
            int qtdCorpos = int.Parse(cabecalho[0].Split(':')[1].Trim());
            int qtdIteracoes = int.Parse(cabecalho[1].Split(':')[1].Trim());

            Universo universoCarregado = new Universo(qtdCorpos);
            universoCarregado.QuantidadeIteracoes = qtdIteracoes;

            int indiceCorpo = 0;

            foreach (string linha in linhas)
            {
                if (!linha.StartsWith("Corpo")) continue;
                if (indiceCorpo >= qtdCorpos) break;

                try
                {
                    string[] blocos = linha.Split(';');

                    if (blocos.Length >= 5)
                    {
                        string blocoNome = blocos[0].Substring(blocos[0].IndexOf('<'));
                        string nomeLimpo = blocoNome.Split(':')[1].Replace(">", "").Trim();

                        string massaLimpa = blocos[1].Split(':')[1].Replace(">", "").Trim();
                        double massa = double.Parse(massaLimpa, System.Globalization.CultureInfo.InvariantCulture);

                        string densidadeLimpa = blocos[2].Split(':')[1].Replace(">", "").Trim().Replace(',', '.');
                        double densidade = double.Parse(densidadeLimpa, System.Globalization.CultureInfo.InvariantCulture);

                        string posTexto = blocos[3].Split(':')[1].Replace(">", "").Replace("(", "").Replace(")", "").Trim();
                        string[] posCoordenadas = posTexto.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        float posX = float.Parse(posCoordenadas[0].Trim(), System.Globalization.CultureInfo.InvariantCulture);
                        float posY = float.Parse(posCoordenadas[1].Trim(), System.Globalization.CultureInfo.InvariantCulture);

                        string velTexto = blocos[4].Split(':')[1].Replace(">", "").Replace("(", "").Replace(")", "").Trim();
                        string[] velCoordenadas = velTexto.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        float velX = float.Parse(velCoordenadas[0].Trim(), System.Globalization.CultureInfo.InvariantCulture);
                        float velY = float.Parse(velCoordenadas[1].Trim(), System.Globalization.CultureInfo.InvariantCulture);

                        Corpo novoCorpo = new Corpo(nomeLimpo, massa, densidade);

                        novoCorpo.posX = posX;
                        novoCorpo.posY = posY;

                        novoCorpo.velX = velX;
                        novoCorpo.velY = velY;

                        novoCorpo.Posicao = new System.Drawing.PointF((float)posX, (float)posY);
                        novoCorpo.Velocidade = new System.Drawing.PointF((float)velX, (float)velY);

                        universoCarregado.corpos[indiceCorpo] = novoCorpo;
                        indiceCorpo++;
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidDataException($"Erro ao processar a linha: {linha}. Detalhes: {ex.Message}");
                }
            }

            return universoCarregado;
        }
    }
}
