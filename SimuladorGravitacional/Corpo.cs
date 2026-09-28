using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorGravitacional
{
    class Corpo //A CLASSE CORPO É ONDE ESTÂO DEFINIDAS AS PROPRIEDADES DE CADA CORPO QUE VAI SER GERADO POSTERIOEMNTE!
    {
        public string nome { get; set; } = string.Empty;
        public double massa { get; set; }
        public double densidade { get; set; }
        public double posX { get; set; }
        public double posY { get; set; }
        public double velX { get; set; }
        public double velY { get; set; }
        public System.Drawing.PointF Posicao { get; set; }
        public System.Drawing.PointF Velocidade { get; set; }

        public double Raio() //AQUI É CALCULADO O RAIO DE CADA CORPO, USANDO A FORMULA DE VOLUME DE UMA ESFERA!
        {
            return Math.Cbrt((3 * massa) / (4 * Math.PI * densidade));
        }

        public Corpo(string nome, double massa, double densidade) //CONTRUTOR PASSANDO OS VALORES NECESSÁRIOS PARA A INSTANCIAÇÃO!
        {
            this.nome = nome;
            this.massa = massa;
            this.densidade = densidade;
            this.posX = 0; //ESSES VALORES ZERADOS SÂO ATUALIZADOS POSTERIORMENTE!
            this.posY = 0;
            this.velX = 0;
            this.velY = 0;
        }
        public bool Colisao(Corpo outroCorpo) //CALCULO DA COLISÂO ENTRE CORPOS!
        {
            double distancia = Math.Sqrt(Math.Pow(outroCorpo.posX - this.posX, 2) + Math.Pow(outroCorpo.posY - this.posY, 2));
            return distancia <= (this.Raio() + outroCorpo.Raio()); //USANDO A DISTANCIA ENTRE ELES E A SOMA DOS RAIOS!
        }
    }
}
