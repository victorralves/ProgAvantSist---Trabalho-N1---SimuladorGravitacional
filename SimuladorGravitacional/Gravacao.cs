using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorGravitacional
{
    abstract class Gravacao
    {
        public abstract void Gravar(Universo universo, int numIteracoes);
    }
}
