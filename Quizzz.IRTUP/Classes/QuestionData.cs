using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzz.IRTUP.Classes
{
    public class QuestionData
    {
        public int? QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string[] Choices { get; set; } // Array of 4 choices
        public int CorrectAnswerIndex { get; set; } // 0 to 3
        public string QuestionType { get; set; }
    }
}
