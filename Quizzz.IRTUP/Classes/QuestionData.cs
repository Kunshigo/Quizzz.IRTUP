using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzz.IRTUP.Classes
{
    public class QuestionData
    {
        //hey
        public int QuizID { get; set; }
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public List<string> Choices { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public string QuestionType { get; set; }
        public int QuestionNo { get; set; }
        public int TimeLimitSeconds { get; set; }
        public string[] ImagePaths { get; set; } = new string[4];
    }
}
