using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorGravitacional
{
    class Corpo //A CLASSE CORPO É ONDE ESTÂO DEFINIDAS AS PROPRIEDADES DE CADA CORPO QUE VAI SER GERADO POSTERIOEMNTE!
    {
        public string Nome { get; set; } = string.Empty;
        public double Massa { get; set; }
        public double Densidade { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double VelX { get; set; }
        public double VelY { get; set; }

        public double Raio() //AQUI É CALCULADO O RAIO DE CADA CORPO, USANDO A FORMULA DE VOLUME DE UMA ESFERA!
        {
            return Math.Cbrt((3 * Massa) / (4 * Math.PI * Densidade));
        }

        public Corpo(string nome, double massa, double densidade, double posX = 0, double posY = 0 , double velX = 0, double velY = 0) //CONTRUTOR PASSANDO OS VALORES NECESSÁRIOS PARA A INSTANCIAÇÃO!
        {
            this.Nome = nome;
            this.Massa = massa;
            this.Densidade = densidade;
            this.PosX = posX; //ESSES VALORES SÂO ATUALIZADOS COM OS PARÂMETROS DO CONTRUTOR!
            this.PosY = posY;
            this.VelX = velX;
            this.VelY = velY;
        }
        public bool Colisao(Corpo outroCorpo) //CALCULO DA COLISÂO ENTRE CORPOS!
        {
            if(outroCorpo == null) return false;
            double distancia = Math.Sqrt(Math.Pow(outroCorpo.PosX - this.PosX, 2) + Math.Pow(outroCorpo.PosY - this.PosY, 2));
            return distancia <= (this.Raio() + outroCorpo.Raio()); //USANDO A DISTANCIA ENTRE ELES E A SOMA DOS RAIOS!
        }
    }
}
