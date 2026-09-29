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
        public System.Drawing.PointF Posicao { get; set; }
        public System.Drawing.PointF Velocidade { get; set; }

        public double Raio() //AQUI É CALCULADO O RAIO DE CADA CORPO, USANDO A FORMULA DE VOLUME DE UMA ESFERA!
        {
            return Math.Cbrt((3 * Massa) / (4 * Math.PI * Densidade));
        }

        public Corpo(string nome, double massa, double densidade) //CONTRUTOR PASSANDO OS VALORES NECESSÁRIOS PARA A INSTANCIAÇÃO!
        {
            this.Nome = nome;
            this.Massa = massa;
            this.Densidade = densidade;
            this.PosX = 0; //ESSES VALORES ZERADOS SÂO ATUALIZADOS POSTERIORMENTE!
            this.PosY = 0;
            this.VelX = 0;
            this.VelY = 0;
        }
        public bool Colisao(Corpo outroCorpo) //CALCULO DA COLISÂO ENTRE CORPOS!
        {
            double distancia = Math.Sqrt(Math.Pow(outroCorpo.PosX - this.PosX, 2) + Math.Pow(outroCorpo.PosY - this.PosY, 2));
            return distancia <= (this.Raio() + outroCorpo.Raio()); //USANDO A DISTANCIA ENTRE ELES E A SOMA DOS RAIOS!
        }
    }
}
