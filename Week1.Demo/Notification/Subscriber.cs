using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo_PubSub
{
    class Subscriber
    {
        public string SubscriberName { get; set; }

        public Subscriber(string subscriberName)
        {
            SubscriberName = subscriberName;
        }

        //SUBSCRIBE
        public void Subscribe(Publisher p)
        {
            //Alla notifica dell'evento registro in OnPublish, che è una sorta di lista di eventi
            p.OnPublish += OnNotificationReceived;  //Metodo che gestisce la ricezione della notifica
        }

        //metodo che gestisce la notifica dell'evento
        private void OnNotificationReceived(Publisher p, Notifications n)
        {
            Console.WriteLine("Ciao " + SubscriberName + " notifica ricevuta da " + p.PublisherName + " il giorno " +
                n.NotificationDate + ": " + n.NotificationMessage);
        }

        //UNSUBSCRIBE
        public void Unsubscribe(Publisher p)
        {
            p.OnPublish -= OnNotificationReceived;
        }
    }
}
