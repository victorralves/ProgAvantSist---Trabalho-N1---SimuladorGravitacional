using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SimuladorGravitacional
{
    class GravacaoBanco : Gravacao //ESCOLHEMOS O NOME COMO GRAVAÇÂO FILHA PARA NÃO FUGIR MUITO DO DESEJADO INICIALMENTE!
    {
        public override int IniciarSimulacao(int qtdCorpos, int numIteracoes)
        {
            //AQUI É INICIADA A SIMULAÇÃO, ELA VAI RETORNAR O NÚMERO DA SIMULAÇÃO!
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "root",
                Database = "trabalhon1",
            };
            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            //CRIA O COMANDO DO BD E DEFINE A QUERY COM OS PARAMETROS!
            using var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO simulacao (dataSimulacao, qtdCorposInicial, numInteracoes) VALUES (@data, @qtd, @iter); SELECT LAST_INSERT_ID();";
            command.Parameters.AddWithValue("@data", DateTime.Now);
            command.Parameters.AddWithValue("@qtd", qtdCorpos);
            command.Parameters.AddWithValue("@iter", numIteracoes);

            return Convert.ToInt32(command.ExecuteScalar()); ; //RETORNA O NÚMERO DA SIMULAÇÃO!
        }
        public override void GravarIteracao(int numSimulacao, int numIteracao, Corpo[] corpos)
        {
            //AQUI É GRAVADA CADA ITERAÇÃO, ELA VAI RECEBER O NÚMERO DA SIMULAÇÃO, O NÚMERO DA ITERAÇÃO E OS CORPOS!
            //IMPLEMENTAÇÃO DE CONEXÃO COM BANCO DE DADOS AQUI!
        }
    }
}
