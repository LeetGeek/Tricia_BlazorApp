using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Tricia.Service
{
    public class Student : BaseElement
    {
        public string StudentId { get; set; }
        public string Stage { get; set; }
        public int Directions { get; set; }
        public IEnumerable<int> Answers { get; set; }

        public Student() :base()
        {
            Answers = Enumerable.Range(0, 15).Select(o => -1);
        }
    }
}
