using System;
using System.Collections.Generic;

namespace Polizia_Graziella
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *equals override per cf uguale
             *
             */
            Console.WriteLine("Database Agenti di Polizia");
            Console.WriteLine();
            Console.WriteLine("1. Mostra elenco agenti");
            Console.WriteLine("2. Mostra agenti assegnati ad un'area");
            Console.WriteLine("3. Mostra agenti per anni di servizio");
            Console.WriteLine("4. Registrare un nuovo agente");
            Console.WriteLine("0. Esci");
            do
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        ListaAgenti();
                        break;
                    case '2':
                        ChiediArea();
                        break;
                    case '3':
                        ChiediAnno();
                        break;
                    case '4':
                        ChiediDatiAgente();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (true);

        }

        private static void ChiediDatiAgente()
        {

            Console.WriteLine("\nInserisci nome dell'agente");
            string nome = (Console.ReadLine());
            Console.WriteLine("\nInserisci cognome dell'agente");
            string cognome = (Console.ReadLine());
            Console.WriteLine("\nInserisci CF dell'agente");
            string cf = (Console.ReadLine());

            DateTime dataNascita;
            do
            {
                Console.WriteLine("\nInserisci la data di nascita dell'agente");
            } while (!DateTime.TryParse(Console.ReadLine(), out dataNascita));

            int anniDiServizio;
            do
            {
                Console.WriteLine("\nInserisci gli anni di servizio");
            } while (!int.TryParse(Console.ReadLine(), out anniDiServizio));

            Agente nuovoAgente = new Agente(nome, cognome, cf, Convert.ToDateTime(dataNascita), anniDiServizio);

            MetodiAccessoDB.RegistraNuovoAgente(nome, cognome, cf, dataNascita, anniDiServizio);
        }

        private static void ListaAgenti()
        {
            List<Agente> Agenti = MetodiAccessoDB.ElencoAgenti();
            foreach (Agente x in Agenti)
                Console.WriteLine(x.ToString());
        }

        //Chiede all'utente il codice per visualizzare gli agenti afferenti all'area di interesse
        private static void ChiediArea()
        {
            int cod;
            do
            {
                Console.Write("Inserisci il codice area: ");
            } while (!int.TryParse(Console.ReadLine(), out cod));

            List<Agente> Agenti = MetodiAccessoDB.ElencoAgentiPerArea(cod);
            foreach (Agente x in Agenti)
                Console.WriteLine(x.ToString());
        }

        //Chiede all'utente il numero di anni in modo da visualizzare gli agenti caratterizzati da un numero minore o uguale di anni di servizio
        public static void ChiediAnno()
        {
            int anni;
            do
            {
                Console.Write("Inserisci gli anni di servizio: ");
            } while (!int.TryParse(Console.ReadLine(), out anni));

            List<Agente> Agenti = MetodiAccessoDB.AgentiPerAnniDiServizio(anni);
            foreach (Agente x in Agenti)
                Console.WriteLine(x.ToString());
        }
    }
}
