using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeGeometriche.Interfacce
{
    interface IFileSerializable
    {
        public void SaveToFile(string fileName);
        public void LoadFromFile(string fileName);
    }
}
