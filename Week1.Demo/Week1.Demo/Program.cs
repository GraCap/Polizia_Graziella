using System;
using Week1.Demo.Classi;

namespace Week1.Demo
{
    class Program
    {
        delegate int Operazione(int a, int b);   //DICHIARO IL DELEGATE
        static void Main(string[] args)
        {
            Funzionalita.EsercizioTipo();
            Funzionalita.Dividi(5, 10);

            Persona persona = new Persona();
            Operazione perimetroPersona = new Operazione(persona.Somma);  //ISTANZIO IL METODO
            int ris1 = perimetroPersona(3, 6);  //sfrutto l'oggetto inizializzato con il metodo delegate dichiarato nella classe a cui accedo attraverso dotnotation

            Operazione divide = new Operazione(Funzionalita.Dividi);
            int ris2 = divide(4, 8);

            Operazione zero = new Operazione(Funzionalita.ReturnZero);
            int ris3 = zero(9, 9);

            Operazione max = new Operazione(persona.Massimo);
            int ris4 = max(4, 2);

            Console.WriteLine();
        }
    }
}
