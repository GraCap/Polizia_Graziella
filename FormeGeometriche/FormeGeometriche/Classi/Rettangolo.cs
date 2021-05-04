using FormeGeometriche.Interfacce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche.Classi
{
    class Rettangolo : FigureGeometriche
    {
        public double Base { get; }
        public double Altezza { get; }
        public override double CalcoloArea() => Base * Altezza;

        public Rettangolo(double baser, double altezza)
            : base("Rettangolo")
        {
            Base = baser;
            Altezza = altezza;
        }

        public override string Disegno()
        {
            return base.Disegno() + " Base: " + Base + " Altezza: " + Altezza + " Area: " + CalcoloArea();
        }

       
    }
}
