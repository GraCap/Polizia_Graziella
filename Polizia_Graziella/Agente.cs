using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia_Graziella
{
    class Agente : Persona
    {
        public DateTime DataNascita { get; }
        public int AnniDiServizio { get; }

        public Agente(string nome, string cognome, string cf, DateTime dataNascita, int anniDiServizio)
            : base(nome, cognome, cf)
        {
            DataNascita = dataNascita;
            AnniDiServizio = anniDiServizio;
        }

        //Nuovo formato per la visualizzazione delle informazioni riguardanti l'agente
        public override string Prospetto => AnniDiServizio + " anni di servizio";

        public override string ToString()
        {
            return base.Prospetto + Prospetto;
        }

       
    }
}
