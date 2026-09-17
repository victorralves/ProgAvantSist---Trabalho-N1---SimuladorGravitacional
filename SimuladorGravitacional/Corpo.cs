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
    }
}
