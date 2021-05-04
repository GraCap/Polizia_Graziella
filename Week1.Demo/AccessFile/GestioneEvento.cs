using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo_AccessFile
{
    public class GestioneEvento
    {
        public static void HandleNewTextFile(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Un nuovo file è stato creato {e.Name}");

            //Lettura del file
            using StreamReader reader = File.OpenText(e.FullPath);
                Console.WriteLine($"--- Lettura di {e.Name} ---");
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            reader.Close();
            Console.WriteLine("Fine del contenuto");


            //Scrittura file
            using StreamWriter writer = File.CreateText(@"C:\Users\graziella.caputo\Desktop\Avanade\PreAcademy\Settimana 9\EsempioFileWatcher\ProvaScrittura.txt");
            writer.WriteLine($"Scrivo nuove informazioni su file");
            writer.Close();
        }
    }
}
