using FormeGeometriche.Interfacce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche.Classi
{
    abstract class FigureGeometriche : IFileSerializable
    {
        public string Nome { get; set; }
        public abstract double CalcoloArea();

        public FigureGeometriche(string nome)
        {
            Nome = nome;
        }
        public virtual string Disegno()
        {
            return "Figura: " + Nome;
        }


        public void SaveToFile(string fileName)
        {
            Console.WriteLine($"Salvataggio su {fileName}. {Disegno()}");
        }
       
        public void LoadFromFile(string fileName)
        {
            Console.WriteLine($"Recupero da {fileName}. {Disegno()}");
        }
    }
}
