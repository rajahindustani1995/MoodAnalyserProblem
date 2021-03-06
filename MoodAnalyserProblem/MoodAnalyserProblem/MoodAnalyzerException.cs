using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public  class MoodAnalyzerException : Exception 
    {
        public enum ExceptionType
        {
            NULL_MESSAGE, EMPTY_MESSAGE, NO_SUCH_CLASS, NO_SUCH_METHOD, NO_SUCH_FIELD
        }

        public ExceptionType Type;

        public MoodAnalyzerException(ExceptionType type, string message) : base(message)
        {
            Type = type;
        }
    }
}
