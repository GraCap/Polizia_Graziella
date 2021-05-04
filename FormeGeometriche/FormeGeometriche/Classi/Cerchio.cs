using FormeGeometriche.Interfacce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche.Classi
{
    class Cerchio : FigureGeometriche
    {
        const double PiGreco = 3.14;
        public double Raggio { get; }
        public Cerchio(double raggio)
            : base("Cerchio")
        {
            Raggio = raggio;
        }
        public override double CalcoloArea()
        {
            return Raggio * Raggio * PiGreco;
        }

        public override string Disegno()
        {
            return base.Disegno() + " Pigreco: " + PiGreco + " Raggio: " + Raggio + " Area: " + CalcoloArea();
        }

   

    }

}
