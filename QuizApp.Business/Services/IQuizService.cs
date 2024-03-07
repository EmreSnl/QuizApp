using QuizApp.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Services
{
    public interface IQuizService
    {
        bool AddQuiz(AddQuizDto addQuizDto);

        int UpdateQuiz(UpdateQuizDto updateQuizDto);

        QuizDto GetQuiz(int id);

        int DeleteQuiz(int id);

        List<QuizDto> GetAllQuiz();

    }
}
