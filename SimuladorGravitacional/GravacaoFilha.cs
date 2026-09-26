using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
                string dadosCorpo = $"Corpo {i + 1}: <Nome: {corpo.nome}>; <Massa: {corpo.massa}>; <Posição: ({corpo.posX} {corpo.posY})>; <Velocidade: ({corpo.velX}, {corpo.velY})>";
                File.AppendAllText(nomeArquivo, "\r\n" + dadosCorpo);
            }
        }
    }
}
