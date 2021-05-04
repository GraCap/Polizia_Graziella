using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo_PubSub
{
    class Publisher
    {
        public string PublisherName { get; set; }

        public Publisher(string publisherName)
        {
            PublisherName = publisherName;
        }

        //Il publisher invia le notifiche, quindi definisco qui delegate e event

        //Delegate 
        public delegate void Notify(Publisher p, Notifications n);
        //Evento 
        public event Notify OnPublish;

        //metodo che va richiamato per lanciare l'evento
        public void Publish()
        {
            if(OnPublish != null)   //se è stata aggiunto alla lista l'evento ovvero con i metodi Subscribe/Unsubscribe
            {
                Notifications notification = new Notifications("New notification from ", DateTime.Now); //Creo la notifica
                OnPublish(this, notification);  //lancio l'evento passando questa notifica che va a finire in "OnNotificationReceived"
            }
            //se Onpublish è null è perchè ho fatto unsubscribe o non ho mai fatto subscribe e in questo caso non stampa alcuna notifica
        }
    }
}
