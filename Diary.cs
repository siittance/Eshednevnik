using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshednevnik
{
    internal class Diary
    {
        public string Name;
        public string Description;
        public DateTime Date;
        public Diary(string name, string description, DateTime date)
        {
            Name = name;
            Description = description;
            Date = date;
        }
    }
}
