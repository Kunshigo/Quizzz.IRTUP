using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzz.IRTUP.Classes
{
    internal class MultipleChoiceData
    {
        public string QuestionText { get; set; }
        public string[] Choices { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public int QuestionNo { get; set; }
    }
}
