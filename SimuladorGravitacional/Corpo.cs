using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorGravitacional
{
    class Corpo
    {
        public string nome { get; set; } = string.Empty;
        public double massa { get; set; }
        public double densidade { get; set; }
        public double posX { get; set; }
        public double posY { get; set; }
        public double velX { get; set; }
        public double velY { get; set; }
        public double Raio()
        {
            return Math.Cbrt((3 * massa) / (4 * Math.PI * densidade));
        }

        public Corpo(string nome, double massa, double densidade)
        {
            this.nome = nome;
            this.massa = massa;
            this.densidade = densidade;
            this.posX = 0;
            this.posY = 0;
            this.velX = 0;
            this.velY = 0;
        }
        public bool Colisao(Corpo outroCorpo)
        {
            double distancia = Math.Sqrt(Math.Pow(outroCorpo.posX - this.posX, 2) + Math.Pow(outroCorpo.posY - this.posY, 2));
            return distancia <= (this.Raio() + outroCorpo.Raio());
        }
    }
}
