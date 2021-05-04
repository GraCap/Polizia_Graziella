using System;

namespace Week1.Demo_PubSub
{
    class Program
    {
        public static void DemoEventi()
        {
            Publisher youtube = new Publisher("YouTube");
            Publisher instagram = new Publisher("Instagram");

            Subscriber sub1 = new Subscriber("Maria");
            Subscriber sub2 = new Subscriber("Giulia");
            Subscriber sub3 = new Subscriber("Graziella");

            //iscrizione all'evento
            sub1.Subscribe(youtube);
            sub3.Subscribe(youtube);
            sub2.Subscribe(instagram);

            //scateniamo l'evento
            youtube.Publish();

            Console.WriteLine("-----------------------------");

            instagram.Publish();

            Console.WriteLine("-----------------------------");

            sub1.Unsubscribe(youtube);  //Non visualizzerò notifiche perchè si è disiscritto
            youtube.Publish();
        }
        static void Main(string[] args)
        {
            DemoEventi();
        }
    }
}
