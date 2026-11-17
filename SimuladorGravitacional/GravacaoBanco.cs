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
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Port = 3306,
            UserID = "root",
            Password = "root",
            Database = "trabalhon1"
        };
        public override int IniciarSimulacao(int qtdCorpos, int numIteracoes)
        {
            //AQUI É INICIADA A SIMULAÇÃO, ELA VAI RETORNAR O NÚMERO DA SIMULAÇÃO!
            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            //CRIA O COMANDO DO BD E DEFINE A QUERY COM OS PARAMETROS!
            using var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO simulacao (dataSimulacao, qtdCorposInicial, numIteracoes) VALUES (@data, @qtd, @iter);";
            command.Parameters.AddWithValue("@data", DateTime.Now);
            command.Parameters.AddWithValue("@qtd", qtdCorpos);
            command.Parameters.AddWithValue("@iter", numIteracoes);

            command.ExecuteNonQuery(); //EXECUTA O COMANDO!

            return (int)command.LastInsertedId; //RETORNA O ID DA SIMULAÇÃO, QUE VAI SER USADO PARA GRAVAR CADA ITERAÇÃO!
        }
        public override void GravarIteracao(int numSimulacao, int numIteracao, Corpo[] corpos)
        {
            //AQUI É GRAVADA CADA ITERAÇÃO, ELA VAI RECEBER O NÚMERO DA SIMULAÇÃO, O NÚMERO DA ITERAÇÃO E OS CORPOS!

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();

            using var comando = connection.CreateCommand();

            using var transaction = connection.BeginTransaction();
            comando.Transaction = transaction;


            StringBuilder sql = new StringBuilder(
                "INSERT INTO corpos (nomeCorpo, massaCorpo, posX, posY, velX, velY, densidadeCorpo) VALUES ");

            for (int k = 0; k < corpos.Length; k++)
            {
                if (k > 0) sql.Append(", ");   //VÍRGULA ENTRE AS LINHAS, MENOS ANTES DA PRIMEIRA

                //O NOME DE CADA PARÂMETRO RECEBE O ÍNDICE DO CORPO: @nome0, @nome1, @nome2...
                sql.Append($"(@nome{k}, @massa{k}, @posX{k}, @posY{k}, @velX{k}, @velY{k}, @densidade{k})");

                comando.Parameters.AddWithValue($"@nome{k}", corpos[k].Nome);
                comando.Parameters.AddWithValue($"@massa{k}", corpos[k].Massa);
                comando.Parameters.AddWithValue($"@posX{k}", corpos[k].PosX);
                comando.Parameters.AddWithValue($"@posY{k}", corpos[k].PosY);
                comando.Parameters.AddWithValue($"@velX{k}", corpos[k].VelX);
                comando.Parameters.AddWithValue($"@velY{k}", corpos[k].VelY);
                comando.Parameters.AddWithValue($"@densidade{k}", corpos[k].Densidade);
            }

            comando.CommandText = sql.ToString();
            comando.ExecuteNonQuery();
            long primeiroId = comando.LastInsertedId;   //ID DO PRIMEIRO CORPO DESTE INSERT

            using var comandoRes = connection.CreateCommand();
            comandoRes.Transaction = transaction;

            StringBuilder sqlRes = new StringBuilder(
            "INSERT INTO resultados (numIteracao, idCorpo, numSimulacao) VALUES ");

            for (int k = 0; k < corpos.Length; k++)
            {
                if (k > 0) sqlRes.Append(", ");
                sqlRes.Append($"(@iter, @id{k}, @sim)");
                comandoRes.Parameters.AddWithValue($"@id{k}", primeiroId + k);   //IDS SEQUENCIAIS
            }
            comandoRes.Parameters.AddWithValue("@iter", numIteracao);   //O MESMO VALOR PARA TODAS AS LINHAS
            comandoRes.Parameters.AddWithValue("@sim", numSimulacao);

            comandoRes.CommandText = sqlRes.ToString();
            comandoRes.ExecuteNonQuery();
            transaction.Commit();
        }
        public int[] ListarSimulacao() //AQUI É LISTADO O NÚMERO DAS SIMULAÇÕES, ELA VAI RETORNAR UM ARRAY DE INTEIROS!
        {
            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT numSimulacao FROM simulacao;";
            List<int> simulacoes = new List<int>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                simulacoes.Add(reader.GetInt32(0));
            }
            return simulacoes.ToArray();
        }
        public Corpo[] CarregarGravacao(int numSimulacao, int numIteracao) //AQUI É CARREGADO A GRAVAÇÃO, ELA VAI RECEBER O NÚMERO DA SIMULAÇÃO E RETORNAR UM ARRAY DE CORPOS!
        {
            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            using var command = connection.CreateCommand();


            command.CommandText = @"SELECT c.nomeCorpo, c.massaCorpo, c.densidadeCorpo, c.posX, c.posY, c.velX, c.velY
                                    FROM corpos c
                                    JOIN resultados r ON c.idCorpo = r.idCorpo
                                    WHERE r.numSimulacao = @sim AND r.numIteracao = @iter;";
            command.Parameters.AddWithValue("@sim", numSimulacao);
            command.Parameters.AddWithValue("@iter", numIteracao);
            List<Corpo> corpos = new List<Corpo>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nome = reader.GetString(0);
                double massa = reader.GetDouble(1);
                double densidade = reader.GetDouble(2);
                double posX = reader.GetDouble(3);
                double posY = reader.GetDouble(4);
                double velX = reader.GetDouble(5);
                double velY = reader.GetDouble(6);
                corpos.Add(new Corpo(nome, massa, densidade, posX, posY, velX, velY));
            }
            return corpos.ToArray();
        }
        public int BuscarQtdIteracoes(int numSimulacao) //AQUI É BUSCADO A QUANTIDADE DE ITERAÇÕES, ELA VAI RECEBER O NÚMERO DA SIMULAÇÃO E RETORNAR UM INTEIRO!
        {
            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT COUNT(DISTINCT numIteracao) FROM resultados WHERE numSimulacao = @sim;";
            command.Parameters.AddWithValue("@sim", numSimulacao);
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
