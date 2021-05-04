using System;
using FormeGeometriche.Classi;
using System.Collections.Generic;
using FormeGeometriche.Interfacce;

namespace FormeGeometriche
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangolo t1 = new Triangolo(3.5, 5.6);
            Cerchio c1 = new Cerchio(4.9);
            Rettangolo r1 = new Rettangolo(3.9, 7.8);
           
            List<FigureGeometriche> figure = new List<FigureGeometriche>();

            figure.Add(t1);
            t1.SaveToFile("triangolo.txt");
            figure.Add(c1);
            c1.SaveToFile("cerchio.txt");
            figure.Add(r1);
            r1.SaveToFile("rettangolo.txt");

            Console.WriteLine();
            foreach (FigureGeometriche f in figure)
            {
                Console.WriteLine(f.Disegno());
            }
            
            Console.WriteLine();
            foreach (IFileSerializable s in figure)
            {
                s.SaveToFile("figure.txt");
                Console.WriteLine();
                s.LoadFromFile("figure.txt");
            }

            t1.LoadFromFile("triangolo.txt");

            IFileSerializable t2 = new Triangolo(3.5, 5.6);
            t2.SaveToFile("t2.txt");

        }
    }
}
