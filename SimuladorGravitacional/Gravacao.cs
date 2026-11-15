using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorGravitacional
{
    abstract class Gravacao //CLASSE ABSTRATA PARA GRAVAÇÃO DE ACORDO COM AS ESPECIFICAÇÕES DO TRABALHO!
    {
        public abstract int IniciarSimulacao(int qtdCorpos, int numIteracoes); //FUNÇÃO PARA INICIAR A SIMULAÇÃO, ELA VAI RETORNAR O NÚMERO DA SIMULAÇÃO!
        public abstract void GravarIteracao(int numSimulacao, int numIteracao, Corpo[] corpos); //FUNÇÃO PARA GRAVAR CADA ITERAÇÃO, ELA VAI RECEBER O NÚMERO DA SIMULAÇÃO, O NÚMERO DA ITERAÇÃO E OS CORPOS!

    }
}
