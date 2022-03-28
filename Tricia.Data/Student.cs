using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricia.Data
{
    public class Student : BaseElement
    {
        public string StudentId { get; set; }
        public string Stage { get; set; }
        public int Directions { get; set; }
        public IEnumerable<int> Answers { get; set; }
    }
}
