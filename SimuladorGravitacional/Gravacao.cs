using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorGravitacional
{
    abstract class Gravacao //CLASSE ABSTRATA PARA GRAVAÇÃO DE ACORDO COM AS ESPECIFICAÇÕES DO TRABALHO!
    {
        public abstract void Gravar(Universo universo, int numIteracoes);
        //AQUI FOI IMPLEMENTADO SOMENTE O METODO ASBTRADO PARA QUE A CLASSE FILHA REESCREVA!

    }
}
