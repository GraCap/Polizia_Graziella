using FormeGeometriche.Interfacce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche.Classi
{
    class Triangolo : FigureGeometriche
    {
        public double Base { get; }
        public double Altezza { get; }

        public Triangolo(double baser, double altezza)
            : base("Triangolo")
        {
            Base = baser;
            Altezza = altezza;
        }
        public override double CalcoloArea() => (Base * Altezza) / 2;

        public override string Disegno()
        {
            return base.Disegno() + " Base: " + Base + " Altezza: " + Altezza + " Area: " + CalcoloArea();
        }

       
    }
}
