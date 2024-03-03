namespace QuizApp.Api.Models
{
    public class UpdateQuestionRequest
    {
        public string QuestionText { get; set; }
        public string Option1Text { get; set; }
        public string Option2Text { get; set; }
        public string Option3Text { get; set; }
        public string Option4Text { get; set; }
        public int QuizId { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
