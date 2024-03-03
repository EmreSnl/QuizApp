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

    }
}
