using QuizApp.Business.Dtos;
using QuizApp.Business.Services;
using QuizApp.Data.Entities;
using QuizApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Managers
{
    public class QuizManager : IQuizService
    {

        private readonly IGenericRepository<QuizEntity> _quizRepository;

        public QuizManager(IGenericRepository<QuizEntity> quizrepository)
        {
            _quizRepository = quizrepository;
        }

        public bool AddQuiz(AddQuizDto addQuizDto)
        {
            var hasQuiz = _quizRepository.GetAll(x => x.QuizText.ToLower() == addQuizDto.QuizText.ToLower()).ToList();

            if (hasQuiz.Any())
            {
                return false;
            }

            var quizEntity = new QuizEntity()
            {
                QuizText = addQuizDto.QuizText,
                Description = addQuizDto.Description

            };

            _quizRepository.Add(quizEntity);
            return true;
        }

        public QuizDto GetQuiz(int id)
        {
            var entity = _quizRepository.GetById(id);

            if (entity == null) 
            {
                return null;
            }

            var quizDto = new QuizDto()

            {
                Id = entity.Id,
                QuizText = entity.QuizText,
                Description = entity.Description

            };
            return quizDto;
        }

        public int UpdateQuiz(UpdateQuizDto updateQuizDto)
        {
            var entity = _quizRepository.GetById(updateQuizDto.Id);

            if (entity != null)
            {
                entity.QuizText = updateQuizDto.QuizText;
                entity.Description = updateQuizDto.Description;
                try
                {
                    _quizRepository.Update(entity);
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

        public int DeleteQuiz(int id) 
        
        {
            var entity = _quizRepository.GetById(id);

            if (entity == null) 
            { 
                return 0;   
            }

            try
            {

                _quizRepository.Delete(id);
                return 1;
            }

            catch(Exception) 

            {
                return -1;
            
            
            
            }

        }

        public List<QuizDto> GetAllQuiz()

        {
            var quizEntites = _quizRepository.GetAll();

            var quizDtos = quizEntites.Select(x => new QuizDto
            {
                Id = x.Id,
                QuizText = x.QuizText,
                Description = x.Description,
            }).ToList();

            return quizDtos;
        }

    }
}
