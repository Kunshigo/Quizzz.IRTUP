using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzz.IRTUP.QuestionTypePanels
{
    public interface IQuestion
    {
        int QuestionID { get; set; }
        string QuestionType { get; set; }
        string QuestionText { get; set; } // Changed from get-only to get/set
        int QuestionNo { get; set; }

        // For MultipleChoice
        int CorrectAnswerIndex { get; set; }
        string[] GetChoices();

        // For TrueFalse
        string CorrectAnswer { get; set; }
    }
}
