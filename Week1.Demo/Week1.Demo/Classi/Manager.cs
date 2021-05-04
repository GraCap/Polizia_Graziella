using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo.Classi
{
    class Manager: Persona
    {
        public decimal Stipendio
        {
            get
            {
                return CalcolaEta * DateTime.Today.Year;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Stipendio: " + Stipendio;
        }
    }
}
