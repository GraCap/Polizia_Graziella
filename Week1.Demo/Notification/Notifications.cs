﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo_PubSub
{
    class Notifications
    {
        public string NotificationMessage { get; set; }
        public DateTime NotificationDate { get; set; }

        //costruttore
        public Notifications(string notificationMessage, DateTime notificationDate)
        {
            NotificationMessage = notificationMessage;
            NotificationDate = notificationDate;
        }
    }
}
