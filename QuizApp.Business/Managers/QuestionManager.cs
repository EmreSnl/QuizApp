using QuizApp.Business.Dtos;
using QuizApp.Business.Services;
using QuizApp.Data.Context;
using QuizApp.Data.Entities;
using QuizApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Managers
{
    public class QuestionManager : IQuestionService
    {

        private readonly IGenericRepository<QuestionEntity> _questionRepository;

        public QuestionManager(IGenericRepository<QuestionEntity> questionrepository)
        {
            _questionRepository = questionrepository;
        }

        public bool AddQuestion(AddQuestionDto addQuestionDto)
        {
            
            var questionEntity = new QuestionEntity()
            {
               QuestionText = addQuestionDto.QuestionText,
               Option1Text = addQuestionDto.Option1Text,
               Option2Text = addQuestionDto.Option2Text,
               Option3Text  = addQuestionDto.Option3Text,
               Option4Text = addQuestionDto.Option4Text,    
               QuizId = addQuestionDto.QuizId,
               CorrectAnswer = addQuestionDto.CorrectAnswer
               

            };

            _questionRepository.Add(questionEntity);
            return true;
        }

        public int UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            var entity = _questionRepository.GetById(updateQuestionDto.Id);

            if (entity != null)
            {
                entity.QuestionText = updateQuestionDto.QuestionText;
                entity.Option1Text = updateQuestionDto.Option1Text;
                entity.Option2Text = updateQuestionDto.Option2Text;
                entity.Option3Text = updateQuestionDto.Option3Text;
                entity.Option4Text = updateQuestionDto.Option4Text; 
                entity.CorrectAnswer = updateQuestionDto.CorrectAnswer; 
                entity.QuizId = updateQuestionDto.QuizId;
                try
                {
                    _questionRepository.Update(entity);
                    return 1;
                }
                catch (Exception)
                {
                    return -1;
                }

            }
            else
            {
                return 0;
            }
        }
    }
}
