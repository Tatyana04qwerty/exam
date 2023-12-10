using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Models
{
    [Serializable]
    public class Cars
    {
        public List<Cars> Car { get; set; }
    }
    [Serializable]
    public class Car
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string brandcar { get; set; }
        public string colourcar { get; set; }
        public double insurance { get; set; }
        public double oneday { get; set; }
        public string beginning { get; set; }
        public string end { get; set; }
    }
}
