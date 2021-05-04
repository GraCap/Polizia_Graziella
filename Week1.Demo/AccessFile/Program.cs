using System;
using System.IO;

namespace Week1.Demo_AccessFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher();    //guardia di ciò che avviene nel file system

            //specifico la directory da tenere sotto controllo
            fsw.Path = @"C:\Users\graziella.caputo\Desktop\Avanade\PreAcademy\Settimana 9\EsempioFileWatcher";

            fsw.Filter = "*.txt";

            //qualora si verifichi uno di questi eventi, richiedo che mi venga notificato 
            fsw.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastAccess;

            //abilitiamo notifiche
            fsw.EnableRaisingEvents = true;

            //alla creazione del file viene gestito l'evento -> MULTICAST DELEGATE
            fsw.Created += GestioneEvento.HandleNewTextFile;

            Console.WriteLine("Inserisci q oer chudere il programma");
            while (Console.Read() != 'q') ;
        }
    }
}
