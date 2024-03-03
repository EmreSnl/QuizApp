using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using QuizApp.Api.Models;
using QuizApp.Business.Dtos;
using QuizApp.Business.Services;
using QuizApp.Data.Context;

namespace QuizApp.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : Controller
    {
        private readonly IQuizService _quizService;
        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpPost]

        public IActionResult AddQuiz(AddQuizRequest request)
        {
            var quizAddDto = new AddQuizDto()
            {
                QuizText = request.QuizText,
                Description = request.Description
            };

            var result = _quizService.AddQuiz(quizAddDto);
            if (result)
                return Ok();
            else
                return StatusCode(500);

        }

        [HttpPut("{id}")]

        public IActionResult UpdateQuiz(int id, UpdateQuizRequest request)

        {
            var updateQuizDto = new UpdateQuizDto()
            {
                Id = id,
                QuizText = request.QuizText,
                Description = request.Description
            };

            var result = _quizService.UpdateQuiz(updateQuizDto);

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

        [HttpGet]
        public IActionResult GetQuiz(int id)

        {
            var quizDto = _quizService.GetQuiz(id);

            if (quizDto == null)
                return NotFound();

            var response = new QuizResponse()
            {
                Id = quizDto.Id,
                QuizText = quizDto.QuizText,
                Description = quizDto.Description


            };
            return Ok(response);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteQuiz(int id)
        {
            var result = _quizService.DeleteQuiz(id);

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







    }
}
