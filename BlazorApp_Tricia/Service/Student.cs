using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Tricia.Service
{
    public class Student : BaseElement
    {
        private Dictionary<string, object> _answers;
        private Dictionary<string, object> _stats;
        public string StudentId { get; set; }
        public string Stage { get; set; }
        public int Directions { get; set; }
        
        public string ParagraphResponse { get; set; }

        public Dictionary<string, object> Answers { get => _answers ?? (_answers = new Dictionary<string, object>()); set => _answers = value; }
        public Dictionary<string, object> Stats { get => _stats ?? (_stats = new Dictionary<string, object>()); set => _stats = value; }

        public Student() :base()
        {
            

        }
    }
}
