using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricia.Data
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int Order { get; set; }
        public IEnumerable<string> Answers { get; set; }
        public int CorrectAnswerId { get; set; }
    }

    
}
