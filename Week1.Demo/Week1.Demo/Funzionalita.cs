using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Demo.Classi;
using Week1.Demo.Interfacce;

namespace Week1.Demo
{
    class Funzionalita
    {
        public enum State
        {
            New,
            Open,
            OnHold,
            Closed
        }
        public static void EsercizioTipo()
        {

            //value type vs reference type
            //booleani
            bool x = true;
            bool y = false;
            bool z = !x;
            Console.WriteLine("Valore z: {0}", z);

            //numerici
            int i = 0;
            int j = 34;

            int numero = 1 * (3 + 5) * 7;

            float f = 1f / 3f;
            double dou = 1d / 3d;
            decimal dec = 1m / 3m;

            Console.WriteLine("Decimali: ");
            Console.WriteLine("f: {0}, d: {1}, dec: {2}", f, dou, dec);

            DateTime now = DateTime.Now;    //eccezione in realtà è un value type non reference come potrebbe sembrare
            DateTime today = DateTime.Today;
            DateTime data = new DateTime(2021, 05, 03);
            DateTime post5Hours = now.AddHours(5);
            DateTime tomorrow = today.AddDays(1);
            DateTime nextMonth = today.AddMonths(1);
            string s = "C#";    //è un reference type

            Console.WriteLine($"Tomorrow: {tomorrow}");
            Console.WriteLine($"In 5 ore: {post5Hours}");

            State myState = State.Open;

            if (myState == State.New)
                Console.WriteLine("La mia variabile my state contiene New");
            else
                Console.WriteLine("La mia variabile my state contiene Open");

            string nome = "Antonia";
            nome = "Giulia";

            int numeroCaratteri = nome.Length;
            Console.WriteLine($"Il nome comincia per A? {nome.StartsWith("A")}");

            Persona p = new Persona();
            p.Nome = "Graziella";
            p.Cognome = "Caputo";
            p.DataNascita = new DateTime(1995, 08, 29);
            Console.WriteLine(p.ToString());
            Persona p2 = new Persona
            {
                Nome = "Antonia",
                Cognome = "Sacchitella",
                DataNascita = new DateTime(1993, 3, 2)
            };
             Console.WriteLine(p2.ToString());

            Console.WriteLine(p.CalcolaEta);

            Manager m = new Manager
            {
                Nome = "Maria", 
                Cognome = "Rossi", 
                DataNascita = DateTime.Today 
            };

            Console.WriteLine(m.CalcolaEta);

            Persona m2 = new Manager
            {
                Nome = "Giorgio",
                Cognome = "Vecchi",
                DataNascita = DateTime.Today
            };

            Console.WriteLine(m2.ToString());
            Console.WriteLine(m2.CalcolaCodiceFiscale());
            IEntita manager3 = new Manager();
            manager3.CalcolaCodiceFiscale();

           
        }

        public static int Dividi(int a, int b)
        {
            return a / b;
        }

        public static int ReturnZero(int a, int b)
        {
            return 0;
        }
    }
}
