using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SimuladorGravitacional
{
    class GravacaoFilha : Gravacao //ESCOLHEMOS O NOME COMO GRAVAÇÂO FILHA PARA NÃO FUGIR MUITO DO DESEJADO INICIALMENTE!
    {
        public override void Gravar(Universo universo, int numIteracoes)
        {
            int contador = 1;
            string caminhoPasta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArquivosGravacao");
            //A PASTA DE GRAVAÇÃO VAI ESTAR DENTRO DO DIRETÓRIO DE DEBUG!

            string nomeArquivo = Path.Combine(caminhoPasta, $"simulacao_{contador}.txt"); //NOMEIAÇÃO DO ARQUIVO DE GRAVAÇÃO!

            if(!System.IO.Directory.Exists(caminhoPasta)) //SE A PASTA NÃO EXISTIR, ELE VAI CRIAR A PASTA NO CAMINHO DA PASTA DO DEBUG!
            {
                System.IO.Directory.CreateDirectory(caminhoPasta);
            }

            while (File.Exists(nomeArquivo)) //SE EXISTIR UM ARQUIVO COM O NÚMERO DO CONTADOR, ELE VAI INCREMENTAR O CONTADOR ATÉ ENCONTRAR UM NOME DE ARQUIVO DISPONÍVEL!
            {
                contador++;
                nomeArquivo = Path.Combine(caminhoPasta, $"simulacao_{contador}.txt");
            }

            //FORMALIZAÇÃO DO ARQUIVO DE GRAVAÇÃO, COM O CABEÇALHO E OS DADOS DE CADA CORPO!
            //DE ACORDO COM O QUE FOI PEDIDO NO TRABALHO!
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

        public Universo CarregarGravacao(string caminhoArquivo) //FUNÇÃO PARA CARREGAR A SIMULAÇÃO GRAVADA!
        {
            if (!File.Exists(caminhoArquivo)) //VERIFICA SE O ARQUIVO EXISTE
            {
                throw new FileNotFoundException($"O arquivo {caminhoArquivo} não foi encontrado.");
            }

            string[] linhas = File.ReadAllLines(caminhoArquivo); //LEITURA DAS LINHAS DO ARQUIVO!

            string linhaCabecalho = "";
            foreach (string l in linhas) //PERCORRE E PROCURA O CABEÇALHO PARA PEGAR AS INFORMAÇÔES NECESSARIAS!
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
            int qtdCorpos = int.Parse(cabecalho[0].Split(':')[1].Trim()); //PEGA AS INFORMAÇÕES DE QUANTIDADE NO CABEÇALHO!
            int qtdIteracoes = int.Parse(cabecalho[1].Split(':')[1].Trim()); //PEGA AS INFORMAÇÕES DE ITERAÇÕES NO CABEÇALHO!

            Universo universoCarregado = new Universo(qtdCorpos);
            universoCarregado.QuantidadeIteracoes = qtdIteracoes; //PASSA A INFORMAÇÃO DE ITERAÇÕES PARA O UNIVERSO CARREGADO!

            int indiceCorpo = 0;

            foreach (string linha in linhas) //AQUI COMEÇA A PERCORRER AS LINHAS DO ARQUIVO PARA PEGAR OS DADOS DE CADA CORPO!
            {
                if (!linha.StartsWith("Corpo")) continue;
                if (indiceCorpo >= qtdCorpos) break;

                try
                {
                    string[] blocos = linha.Split(';'); //EM CADA LINHA É CONSIDERADO OS BLOCOS DE ACORDO COM AS INFORMAÇÕES NECESSÀRIAS E PEDIDAS NO TRABALHO!

                    if (blocos.Length >= 5) //NO TOTAL SÃO 5 BLOCOS (NOME, MASSA, DENSIDADE, POSIÇÃO, VELOCIDADE), SE TIVER MENOS, NÃO VAI PROCESSAR A LINHA!
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

                        Corpo novoCorpo = new Corpo(nomeLimpo, massa, densidade); //PASSA AS INFORMAÇÕES PARA O CONSTRUTOR DA CLASSE CORPO!

                        novoCorpo.posX = posX; //PASSA AS INFORMAÇÕES DE POSIÇÃO E VELOCIDADE PARA O CORPO!
                        novoCorpo.posY = posY; //ISSO É SEPARADO POIS O CONSTRUTOR NAO RECEBE!

                        novoCorpo.velX = velX;
                        novoCorpo.velY = velY;

                        novoCorpo.Posicao = new System.Drawing.PointF((float)posX, (float)posY); //AQUI FOI NECESSÁRIO CRIAR UM NOVO PONTO PARA A POSIÇÃO E VELOCIDADE!
                        novoCorpo.Velocidade = new System.Drawing.PointF((float)velX, (float)velY); //JUSTAMENTE POIS O CONSTRUTOR NÃO RECEBE ESSES VALORES!

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
