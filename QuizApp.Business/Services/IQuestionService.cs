using QuizApp.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Services
{
    public interface IQuestionService
    {
        bool AddQuestion(AddQuestionDto addQuestionDto);

        int UpdateQuestion(UpdateQuestionDto updateQuestionDto);

    }
}
