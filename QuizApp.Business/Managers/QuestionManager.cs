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
                Option3Text = addQuestionDto.Option3Text,
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

        public QuestionDto GetQuestion(int id)
        {
            var entity = _questionRepository.GetById(id);

            if (entity == null)
            {
                return null;
            }

            var questionDto = new QuestionDto()

            {
                Id = entity.Id,
                QuestionText = entity.QuestionText,
                Option1Text = entity.Option1Text,
                Option2Text = entity.Option2Text,
                Option3Text = entity.Option3Text,
                Option4Text = entity.Option4Text,
                CorrectAnswer = entity.CorrectAnswer,
                QuizId = entity.QuizId


            };
            return questionDto;
        }

        public int DeleteQuestion(int id)

        {
            var entity = _questionRepository.GetById(id);

            if (entity == null)
            {
                return 0;
            }

            try
            {

                _questionRepository.Delete(id);
                return 1;
            }

            catch (Exception)

            {
                return -1;
            }

        }

        public List<QuestionDto> GetAllQuestion()

        {
            var questionEntites = _questionRepository.GetAll();

            var questionDtos = questionEntites.Select(x => new QuestionDto
            {
                Id = x.Id,
                QuestionText = x.QuestionText,
                Option1Text = x.Option1Text,
                Option2Text = x.Option2Text,
                Option3Text = x.Option3Text,
                Option4Text = x.Option4Text,
                CorrectAnswer = x.CorrectAnswer,
                QuizId = x.QuizId
            }).ToList();

            return questionDtos;
        }
    }
}
