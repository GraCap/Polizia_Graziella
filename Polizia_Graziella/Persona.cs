using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia_Graziella
{
    abstract class Persona
    {
        public string Nome { get; }
        public string Cognome { get; }
        public string CF { get; }

        public Persona(string nome, string cognome, string cf)
        {
            Nome = nome;
            Cognome = cognome;
            CF = cf;
        }

        public virtual string Prospetto =>  Nome + " " + Cognome + " - " + CF + " - ";
            
        }
    }

