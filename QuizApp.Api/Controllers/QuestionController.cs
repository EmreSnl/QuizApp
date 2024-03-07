using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Models;
using QuizApp.Business.Dtos;
using QuizApp.Business.Services;

namespace QuizApp.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]

        public IActionResult AddQuestion(AddQuestionRequest request)
        {
            var questionAddDto = new AddQuestionDto()
            {
                QuestionText = request.QuestionText,
                Option1Text = request.Option1Text,
                Option2Text = request.Option2Text,  
                Option3Text = request.Option3Text,
                Option4Text = request.Option4Text,
                QuizId = request.QuizId,
                CorrectAnswer = request.CorrectAnswer
            };

            var result = _questionService.AddQuestion(questionAddDto);
            if (result)
                return Ok();
            else
                return StatusCode(500);

        }

        [HttpPut("{id}")]

        public IActionResult UpdateQuestion(int id, UpdateQuestionRequest request)

        {
            var updateQuestionDto = new UpdateQuestionDto()
            {
                Id = id,
                QuestionText = request.QuestionText,
                Option1Text = request.Option1Text,
                Option2Text = request.Option2Text,
                Option3Text = request.Option3Text,
                Option4Text = request.Option4Text,
                QuizId = request.QuizId,
                CorrectAnswer = request.CorrectAnswer
            };

            var result = _questionService.UpdateQuestion(updateQuestionDto);

            switch (result)
            {
                case 0:
                    return NotFound();
                case 1:
                    return Ok();
                default:
                    return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id)

        {
            var questionDto = _questionService.GetQuestion(id);

            if (questionDto == null)
                return NotFound();

            var response = new QuestionResponse()
            {
                Id = questionDto.Id,
                QuestionText = questionDto.QuestionText,
                Option1Text = questionDto.Option1Text,
                Option2Text = questionDto.Option2Text,
                Option3Text = questionDto.Option3Text,
                Option4Text = questionDto.Option4Text,
                CorrectAnswer = questionDto.CorrectAnswer,
                QuizId = questionDto.QuizId



            };
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            var result = _questionService.DeleteQuestion(id);

            switch (result)
            {
                case 0:
                    return BadRequest();

                case 1:
                    return Ok();

                default:
                    return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {

            var questionDtos = _questionService.GetAllQuestion();

            var response = questionDtos.Select(x => new QuestionResponse()
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

            return Ok(response);

        }


    }
}
